using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool paused = false;
    public GameObject pauseMenu;

    public void Pause()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void Resume()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
