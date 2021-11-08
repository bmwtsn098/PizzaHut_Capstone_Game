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

	// Use this for initialization
	void Start()
	{

		player = GetComponent<Rigidbody>();
		color = GetComponent<Renderer>();

	}

	// Update is called once per frame
	void Update()
	{


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

			SceneManager.LoadScene(4);
        }

		if(collision.gameObject.CompareTag("DeliveryLocation"))
        {

			collision.gameObject.tag = "Building";
        }
    }
}
