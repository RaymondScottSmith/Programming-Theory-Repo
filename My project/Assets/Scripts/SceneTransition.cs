using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown runnerChoice;

    [SerializeField] private GameObject[] runnerTexts;

    private int choice;
    public void StartGame()
    {
        MenuManager.Instance.choice = choice;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void ChangeRunner()
    {
        choice = runnerChoice.value;
        foreach (GameObject runner in runnerTexts)
        {
            runner.SetActive(false);
        }

        runnerTexts[choice].SetActive(true);
    }
    
    void Update()
    {
        if (runnerChoice != null)
        {
            choice = runnerChoice.value;
            
        }
        
    }

}
