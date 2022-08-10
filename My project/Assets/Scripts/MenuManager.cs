using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    [SerializeField] private TMP_Dropdown runnerChoice;

    [SerializeField] private GameObject[] runnerTexts;

    public int choice;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this);
        
    }

    void Start()
    {
    }

    public void ChangeRunner()
    {
        choice = runnerChoice.value;
        Debug.Log("Change Runner");
        foreach (GameObject runner in runnerTexts)
        {
            runner.SetActive(false);
        }

        runnerTexts[choice].SetActive(true);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturnToTitle()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (runnerChoice != null)
        {
            choice = runnerChoice.value;
            
        }
        
    }
}
