using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerJoystick : MonoBehaviour
{

	private Rigidbody player;
	public int speed;
	private Renderer color;
	public JoystickController joystick;
	public Text timer;
	private float time = 0;

	// Use this for initialization
	void Start()
	{

		player = GetComponent<Rigidbody>();
		color = GetComponent<Renderer>();
		time = 0;
		Level_Time.TimeTakenMin = 0;
		Level_Time.TimeTakenSec = 0;

	}

	// Update is called once per frame
	void Update()
	{
		time = time + Time.deltaTime;
		
		float minutes = Mathf.FloorToInt(time / 60);
		float seconds = Mathf.FloorToInt(time % 60);
		Level_Time.TimeTakenMin = minutes;
		Level_Time.TimeTakenSec = seconds;

		
		timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);

	}

	void FixedUpdate()
	{

		//float h = Input.GetAxis ("Horizontal");
		//float v = Input.GetAxis ("Vertical");

		float h = joystick.Horizontal();
		float v = joystick.Vertical();
		Vector3 move = new Vector3(h, 0.0f, v);

		player.AddForce(move * speed);

	}

	void OnCollisionEnter(Collision collision)
    {

		if(collision.gameObject.CompareTag("Point"))
        {

			collision.gameObject.SetActive(false);
        }

		if(collision.gameObject.CompareTag("Exit"))
        {

			SceneManager.LoadScene(5);
        }

		if(collision.gameObject.CompareTag("DeliveryLocation"))
        {

			collision.gameObject.tag = "Building";
        }
    }
}
