using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Select : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Level1()
    {

        SceneManager.LoadScene(2);
    }

    public void Level2()
    {

        SceneManager.LoadScene(3);
    }

}
