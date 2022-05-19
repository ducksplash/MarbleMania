using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class MobileControls : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

	private string whatsit;
	
	private float horizontalMove = 0.0f;

	public GameObject ThisCamera;
	public float forwardsForce = 100f;
	public float jumpForce = 150f;
	[SerializeField] Transform focus = default;
	[SerializeField, Range(1f, 20f)] float distance = 5f;
	[SerializeField, Min(0f)] float focusRadius = 1f;
	[SerializeField, Range(0f, 1f)] float focusCentering = 0.5f;
	Vector2 orbitAngles = new Vector2(45f, 0f);
	[SerializeField, Range(-89f, 89f)] float minVerticalAngle = -30f, maxVerticalAngle = 60f;

	Vector3 focusPoint, previousFocusPoint;
	float lastManualRotationTime;

	// get joy
	public Image jsContainer;
	public Image jsCentre;
	public Image jsJump;
	public Button jumpButton;

	// get dir
	public Vector3 InputDirection;

	private float joyX;
	private float joyY;
	// get player

	public GameObject Player;
	public Transform PlayerTransform;
	public Rigidbody PlayerRB;
	public Vector3 offset;
	public Vector3 newtrans;

	private float DeadZoneRadius;





	void OnValidate()
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			if (maxVerticalAngle < minVerticalAngle)
			{
				maxVerticalAngle = minVerticalAngle;
			}
		}
	}

	void Awake()
	{


		if (PlayerStats.DeviceType == "MOBILE")
		{

			focusPoint = focus.position;
			ThisCamera.transform.localRotation = Quaternion.Euler(orbitAngles);

		}

	}



	void Start()
	{


		if (PlayerStats.DeviceType == "MOBILE")
		{


			PlayerTransform = Player.transform;
			PlayerRB = Player.GetComponent<Rigidbody>();





			InputDirection = Vector3.zero;

			// we'll do the rest of this later as 'device simulator' still reports as desktop to SystemInfo
			if (SystemInfo.deviceType != DeviceType.Handheld)
			{
				whatsit = "MOBILE";
			}
			else
			{
				whatsit = "phone";
			}



			Debug.Log(whatsit);


			InputDirection = Vector3.zero;


			PlayerRB.drag = 0.6f;
			PlayerRB.angularDrag = 0.01f;
			PlayerRB.mass = 10f;
		}
	}





	public void OnDrag(PointerEventData ped)
	{
		if (PlayerStats.DeviceType == "MOBILE")
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
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			OnDrag(eventData);

			if (PlayerStats.InWater)
			{
				PlayerRB.drag = 3f;
				PlayerRB.angularDrag = 1f;
				PlayerRB.mass = 6f;
			}
			else
			{
				PlayerRB.drag = 0.6f;
				PlayerRB.angularDrag = 0.01f;
				PlayerRB.mass = 10f;
			}
		}
	}


	public void OnEndDrag(PointerEventData eventData)
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			InputDirection = Vector3.zero;
			joyX = 0.0f;
			joyY = 0.0f;
			jsCentre.rectTransform.anchoredPosition = Vector3.zero;

			if (Movement.onTheGround)
			{
				PlayerRB.drag = 4f;
			}
		}
	}







	void FixedUpdate()
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			MovePlayer();


			if (Movement.Jumping)
			{
				Debug.Log("jump jump jump");
				Player.GetComponent<SoundManager>().JUMP();
				PlayerRB.AddForce(0, jumpForce, 0);
				Movement.onTheGround = false;
				Movement.Jumping = false;
			}
		}
	}


public void jump()
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			if (Movement.onTheGround)
			{
				Movement.Jumping = true;
			}
		}
	}


void MovePlayer()
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			if (joyX != 0f || joyY != 0f)
			{
				var moveForce = ThisCamera.transform.forward * PlayerStats.BallSpeed;
				PlayerRB.AddForce(moveForce);
			}
		}
	}


	void LateUpdate()
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{

			UpdateFocusPoint();
			Quaternion lookRotation;

			if (ManualRotation())
			{
				ConstrainAngles();
				lookRotation = Quaternion.Euler(orbitAngles);
			}
			else
			{
				lookRotation = ThisCamera.transform.localRotation;
			}
			Vector3 lookDirection = lookRotation * Vector3.forward;
			Vector3 lookPosition = focusPoint - lookDirection * distance;
			ThisCamera.transform.SetPositionAndRotation(lookPosition, lookRotation);

		}


	}

	bool ManualRotation()
	{

		if (!PlayerStats.GamePaused && PlayerStats.DeviceType == "MOBILE")
		{



			if (joyX > -0.01f && joyX < 0.01f)
			{
				joyX = 0;
			}

			if (joyY > -0.01f && joyY < 0.01f)
			{
				joyY = 0;
			}

				horizontalMove = joyX;


			//
			Debug.Log(joyX);
			Debug.Log(joyY);
			//


			Vector2 input = new Vector2(0, 0);

			input = new Vector2(
				-joyY,
				-horizontalMove
			);

			const float e = 0.001f;
			if (input.x < -e || input.x > e || input.y < -e || input.y > e)
			{
				orbitAngles += PlayerStats.BallSpeed * Time.smoothDeltaTime * input;
				lastManualRotationTime = Time.smoothDeltaTime;
				return true;
			}
			return false;
		}
		else
		{
			return false;
		}
	}


	void UpdateFocusPoint()
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			previousFocusPoint = focusPoint;
			Vector3 targetPoint = focus.position;
			if (focusRadius > 0f)
			{
				float distance = Vector3.Distance(targetPoint, focusPoint);
				if (distance > focusRadius)
				{
					focusPoint = Vector3.Lerp(
						targetPoint, focusPoint, focusRadius / distance
					);
				}
				if (distance > 0.01f && focusCentering > 0f)
				{
					focusPoint = Vector3.Lerp(
						targetPoint, focusPoint,
						Mathf.Pow(0.5f - focusCentering, Time.smoothDeltaTime)
					);
				}
			}
			else
			{
				focusPoint = targetPoint;
			}
		}
	}

	void ConstrainAngles()
	{
		if (PlayerStats.DeviceType == "MOBILE")
		{
			orbitAngles.x =
			Mathf.Clamp(orbitAngles.x, minVerticalAngle, maxVerticalAngle);

			if (orbitAngles.y < 0f)
			{
				orbitAngles.y += 360f;
			}
			else if (orbitAngles.y >= 360f)
			{
				orbitAngles.y -= 360f;
			}
		}

		static float GetAngle(Vector2 direction)
		{
			float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
			return direction.x < 0f ? 360f - angle : angle;
		}
	}
}


