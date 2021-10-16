using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start()
    {

        FindObjectOfType<AudioManager>().StopAll();
        FindObjectOfType<AudioManager>().Play("Menu Music");
    }

    public void StartGame()
    {

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {

        Application.Quit();
    }

}
