using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;

    [SerializeField] private TMP_Dropdown runnerChoice;

    private int choice;
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
        ShowOptions();
    }

    private void ShowOptions()
    {
        
    }

    public void SetRunner()
    {
        Debug.Log(choice + " chosen");
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
