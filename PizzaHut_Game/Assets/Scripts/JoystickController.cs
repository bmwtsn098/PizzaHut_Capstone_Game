using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

	private Image background;
	private Image joystick;
	private Vector3 inputvector;

	private void Start()
	{

		background = GetComponent<Image>();
		joystick = transform.GetChild(0).GetComponent<Image>();

	}

	public virtual void OnPointerDown(PointerEventData ped)
	{

		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped)
	{

		inputvector = Vector3.zero;
		joystick.rectTransform.anchoredPosition = Vector3.zero;
	}

	public virtual void OnDrag(PointerEventData ped)
	{

		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background.rectTransform, ped.position, ped.pressEventCamera, out pos))
		{

			pos.x = (pos.x / background.rectTransform.sizeDelta.x);
			pos.y = (pos.y / background.rectTransform.sizeDelta.y);

			inputvector = new Vector3(pos.x * 2 + 1, 0, pos.y * 2 - 1);
			inputvector = (inputvector.magnitude > 1.0f) ? inputvector.normalized : inputvector;

			joystick.rectTransform.anchoredPosition = new Vector3(inputvector.x * (background.rectTransform.sizeDelta.x / 3), inputvector.z * (background.rectTransform.sizeDelta.y / 3));

		}
	}

	public float Horizontal()
	{

		if (inputvector.x != 0)
		{

			return inputvector.x;
		}
		else
		{
			return Input.GetAxis("Horizontal");
		}
	}

	public float Vertical()
	{

		if (inputvector.z != 0)
		{

			return inputvector.z;
		}
		else
		{
			return Input.GetAxis("Vertical");
		}
	}
}