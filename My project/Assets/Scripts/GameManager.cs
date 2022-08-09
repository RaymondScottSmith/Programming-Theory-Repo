using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver;

    [SerializeField]
    private AudioSource mainMusic;

    [SerializeField] private AudioClip crashSound;
    
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
        mainMusic = GetComponent<AudioSource>();
        mainMusic.Play();
    }

    public void GameOver()
    {
        mainMusic.Stop();
        isGameOver = true;
        mainMusic.PlayOneShot(crashSound);
        
    }
}
