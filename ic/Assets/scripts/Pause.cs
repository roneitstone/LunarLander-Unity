using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public bool start = true;

    PlayerControls controls;


    private void Awake()
    {
        controls = new PlayerControls();

        controls.Jogar.Pause.performed += ctx => Start();
        start = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {

            PauseMenu();
           
        }
        else
        {
            if (GameIsPaused)
            {
                Resume();
            }
        }
    }

    private void Start()
    {
        if(start == false)
        {
            start = true;

        }
        else
        {

            start = false;

        }
    }

    private void OnEnable()
    {
        controls.Jogar.Enable();
    }

    private void OnDisable()
    {
        controls.Jogar.Disable();
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        start = false;
    }

    void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
