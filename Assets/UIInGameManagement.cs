using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(PlayerControls))]

public class UIInGameManagement : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject inGameUI;
    public GameObject optionsMenu;

    // Start is called before the first frame update

    private PlayerControls playerControls;

   

    private void Awake()
    {
        playerControls = new PlayerControls();
        //playerControls.Controls.Movement.started += ctx => Movement();
        //playerControls.Controls.Movement.started += ctx => 
    }

    void Update()
    {
        if (playerControls.Controls.Pause.IsPressed()) 
        {
            Pause();
        } 
    }


    public void Resume() 
    {
        if(Time.timeScale == 0) 
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(false);
            inGameUI.SetActive(true);
        }
        
    }

    public void Options() 
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
        inGameUI.SetActive(false);
    }


    public void Pause() 
    {
        if (Time.timeScale == 1) 
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            optionsMenu.SetActive(false);
            inGameUI.SetActive(false);
        }
        
    }

    public void Quit() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
}
