using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    private PauseAction action;
    public static bool paused = false;
    public GameObject pauseMenu;
  
    void Awake()
    {
        action = new PauseAction();
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        action.Pause.PauseGame.performed += _ => DeterminePause();
    }

    private void DeterminePause()
    {
        if(paused)
            ResumeGame();
        else
            PauseGame();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        paused = true;
        pauseMenu.SetActive(true);
    }
    
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        paused = false;
        pauseMenu.SetActive(false);
    }
/*
    public void Quit()
    {
        Application.Quit();
    }
*/
    

    void Update()
    {
        
    }
}
