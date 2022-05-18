using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MobileControls : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	private string whatsit;


	// get joy
	public Image jsContainer;
	public Image jsCentre;
	public Image jsJump;


	// get dir
	public Vector3 InputDirection;

	private float joyX;
	private float joyY;




	void Start()
	{


		InputDirection = Vector3.zero;

		// we'll do the rest of this later as 'device simulator' still reports as desktop to SystemInfo
		if (SystemInfo.deviceType != DeviceType.Handheld)
		{
			whatsit = "pc";
		}
		else
		{
			whatsit = "phone";
		}



		Debug.Log(whatsit);
	}






	public void OnDrag(PointerEventData ped)
	{
		Debug.Log("drag");

		Vector2 position = Vector2.zero;

		RectTransformUtility.ScreenPointToLocalPointInRectangle
				(jsContainer.rectTransform,
				ped.position,
				ped.pressEventCamera,
				out position);

		position.x = (position.x / jsContainer.rectTransform.sizeDelta.x);
		position.y = (position.y / jsContainer.rectTransform.sizeDelta.y);

		float x = (jsContainer.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
		float y = (jsContainer.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

		joyX = x;
		joyY = y;


		InputDirection = new Vector3(x, y, 0);
		InputDirection = (InputDirection.magnitude > 1) ? InputDirection.normalized : InputDirection;

		jsCentre.rectTransform.anchoredPosition = new Vector3(InputDirection.x * (jsContainer.rectTransform.sizeDelta.x / 3)
															   , InputDirection.y * (jsContainer.rectTransform.sizeDelta.y) / 3);

	}

	public void OnBeginDrag(PointerEventData eventData)
	{


	}


	public void OnEndDrag(PointerEventData eventData)
	{
		InputDirection = Vector3.zero;
		joyX = 0.0f;
		joyY = 0.0f;
		jsCentre.rectTransform.anchoredPosition = Vector3.zero;
	}









}
