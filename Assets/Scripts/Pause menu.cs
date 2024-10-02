using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pausemenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public InputActionReference pause;

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        pause.action.started += Pause;
    }

    private void OnDisable()
    {
        pause.action.started -= Pause;
    }

    private void Pause(InputAction.CallbackContext obj)
    {
        Debug.Log("pressed");

        if(GameIsPaused)
        {
            Resume();
        }
        else
        {
            Paused();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Paused()
    {
       pauseMenuUI.SetActive(true);
       Time.timeScale = 0f;
       GameIsPaused = true;
    }

    public void LoadingMenu()
    {
        Debug.Log("Loading menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
