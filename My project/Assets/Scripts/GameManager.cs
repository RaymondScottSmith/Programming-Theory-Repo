using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState gameState;

    [SerializeField]
    private AudioSource mainMusic;

    [SerializeField] private AudioClip runnerCrashSound;
    [SerializeField] private AudioClip ufoCrashSound;

    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject loseScreen;
    
    [SerializeField] private ParticleSystem ufoExplosion;

    [SerializeField] private int runningTime;

    [SerializeField] private GameObject[] runners;

    [SerializeField] private TextMeshProUGUI timerText;

    // ENCAPSULATION
    public Vector3 baseGravity
    {
        get;
        private set;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        baseGravity = new Vector3(0f, -9.81f, 0f);
        
        int runnerChoice = 0;
        if (MenuManager.Instance != null)
        {
            runnerChoice = MenuManager.Instance.choice;
        }
        Instantiate(runners[runnerChoice], Vector3.zero, runners[runnerChoice].transform.rotation);
        gameState = GameState.Running;
        mainMusic = GetComponent<AudioSource>();
        mainMusic.Play();
        victoryScreen.SetActive(false);
        loseScreen.SetActive(false);
        StartCoroutine(RunningTime());
    }

    public void GameOverWin()
    {
        if (gameState == GameState.Running)
        {
            gameState = GameState.Win;
            mainMusic.Stop();
            
            mainMusic.PlayOneShot(runnerCrashSound);
            victoryScreen.SetActive(true);
        }
        
    }
    public void GameOverLose()
    {
        if (gameState == GameState.Running)
        {
            gameState = GameState.Lose;
            mainMusic.Stop();
            
            ufoExplosion.Play();
            Destroy(FindObjectOfType<ObstacleSpawner>().gameObject);
            mainMusic.PlayOneShot(ufoCrashSound);
        
            loseScreen.SetActive(true);
        }
        
    }

    private IEnumerator RunningTime()
    {
        int timer = runningTime;
        while (timer > 0)
        {
            if (gameState != GameState.Running)
            {
                break;
            }

            timerText.text = timer.ToString();
            yield return new WaitForSeconds(1);
            timer--;
        }

        if (gameState == GameState.Running)
        {
            GameOverLose();
        }
        timerText.text = timer.ToString();
            
    }

    public void BackToTitle()
    {
        MenuManager.Instance.ReturnToTitle();
    }

    
}

public enum GameState
{
    Running,
    Win,
    Lose
}
