using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{

    public Color first = Color.yellow;
    public Color second = Color.cyan;
    private float speed = 1;
    private float duration = 1;
    private Renderer rend;

    public bool returnToMainMenu = false;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text message;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        if(returnToMainMenu)
        {

            timerIsRunning = true;
            message.text = "Congradulations! You win. It took you " + string.Format("{0:00}:{1:00}", Level_Time.TimeTakenMin, Level_Time.TimeTakenSec);
        }
    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(1, 2, 3);

        float lerp = Mathf.PingPong(Time.time * speed, duration);

        rend.material.color = Color.Lerp(first, second, lerp);

        if(returnToMainMenu)
        {

            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Time has run out!");
                    timeRemaining = 0;
                    timerIsRunning = false;
                    SceneManager.LoadScene(0);
                }
            }
        }
    }
}
