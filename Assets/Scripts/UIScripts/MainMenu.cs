using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToOptions() 
    {
        optionsMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Exit() 
    {
        Application.Quit();
    }

    public void StartRun() 
    {
        SceneManager.LoadScene(1);
    }
}
