using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	
public float forwardsForce = 100f;
public float jumpForce = 150f;
private bool onTheGround;
public Rigidbody rb;
public GameObject myPrefab;
public float destroyDelay = 0f;
private GameObject InstantiatedSmash;
public GameObject MarbleBit;
public GameObject Player;
public static float SpawnX;
public static float SpawnY;
public static float SpawnZ;
public static float SpawnXorig;
public static float SpawnYorig;
public static float SpawnZorig;
public bool Jumping = false;
private Camera _camera;
private Animator ThisCameraAnimator;


void Awake()
{
	
	_camera = Camera.main;
	//ThisCameraAnimator = _camera.GetComponent<Animator>();

	SpawnXorig = Player.transform.position.x;
	SpawnYorig = Player.transform.position.y;
	SpawnZorig = Player.transform.position.z;
	
	SpawnX = SpawnXorig;
	SpawnY = SpawnYorig;
	SpawnZ = SpawnZorig;	
	
	Debug.Log(SpawnXorig);
	Debug.Log(SpawnYorig);
	Debug.Log(SpawnZorig);
	
	//ThisCameraAnimator.SetTrigger("DoUnfade");

}




void Update() 
{

	
	if (Input.GetKey(PlayerStats.InputForUP) || Input.GetKey(KeyCode.W))
    {	
		if (PlayerStats.InWater)
		{
			rb.drag = 3f;	
			rb.angularDrag = 1f;	
			rb.mass = 6f;
		}
		else
		{
			rb.drag = 0.6f;
			rb.angularDrag = 0.01f;
			rb.mass = 10f;
		}
	}
	
	if (onTheGround && (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)))
    {
		rb.drag = 4f;			
	}	
	
	
	
	if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
    {
		if (PlayerStats.InWater)
		{
			rb.drag = 3f;
			rb.angularDrag = 1f;
			rb.mass = 6f;
		}
		else
		{
			rb.drag = 0.6f;
			rb.angularDrag = 0.01f;
			rb.mass = 10f;
		}
	}
	
	if (onTheGround && (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)))
    {
		rb.drag = 4f;			
	}	
	
	
	

    //JumpPlayer();
	if (!PlayerStats.FlightMode)
	{
		if ((Input.GetKeyDown(PlayerStats.InputForJUMP) || Input.GetKeyDown(KeyCode.RightShift)) && onTheGround && !PlayerStats.GamePaused)
		{
				Jumping = true;
		}
	}
	else
	{
		if ((Input.GetKey(PlayerStats.InputForJUMP) || Input.GetKey(KeyCode.RightShift)) && PlayerStats.FlightMode)
		{
			Vector3 movement = new Vector3 (0, 0.1f, 0f);
			gameObject.transform.position += movement * Time.deltaTime * PlayerStats.BallSpeed;
		}
	}
	
	if (Input.GetKey(KeyCode.RightControl) && PlayerStats.FlightMode)
	{
		Vector3 movement = new Vector3 (0, 0.1f, 0f);
		gameObject.transform.position -= movement * Time.deltaTime * PlayerStats.BallSpeed;
	}
	
}







void FixedUpdate()
{    

MovePlayer();
		
    if (Jumping)
    {
		
				gameObject.GetComponent<SoundManager>().JUMP();
				rb.AddForce(0, jumpForce, 0);	
				onTheGround = false;
				Jumping = false;
    }
	
	
	
}





void MovePlayer() 
{
	
	if (!PlayerStats.DEAD && !WeeBeastie.BeingEaten && PlayerStats.Playing && !PlayerStats.GamePaused && !PlayerStats.STOP)
	{
	
		if (!PlayerStats.FlightMode)
		{
			if (Input.GetKey(PlayerStats.InputForUP) || Input.GetKey(KeyCode.W))
			{
				var moveForce = _camera.transform.forward * PlayerStats.BallSpeed;
				rb.AddForce(moveForce);
			}
			
			
			
			if (Input.GetKey(PlayerStats.InputForDOWN) || Input.GetKey(KeyCode.S))
			{
				var moveForce = _camera.transform.forward * (PlayerStats.BallSpeed/2);		
				rb.AddForce(-moveForce);
			}
		}
		else
		{
			if (Input.GetKey(PlayerStats.InputForUP) || Input.GetKey(KeyCode.W))
			{			
				
				gameObject.transform.Translate(_camera.transform.forward / 2);
			}	
			
			
			if (Input.GetKey(PlayerStats.InputForDOWN) || Input.GetKey(KeyCode.S))
			{			
				
				gameObject.transform.Translate(-_camera.transform.forward / 2);
			}	
		}
		
	}
	
	
}


	
 void OnCollisionEnter(Collision other)
     {
         if (other.gameObject.layer == 3)
         {
            onTheGround = true;
			
			if (!PlayerStats.DEAD)
			{
				gameObject.GetComponent<SoundManager>().LAND();
			}
         }
		 		 
				 
				 
				 
		 
	//	 if (other.relativeVelocity.magnitude > 70)
	//	 {
	//		gameObject.GetComponent<Toast>().NewToast("shattered");
	//		gameObject.GetComponent<ShieldScript>().RemoveShield();
	//		gameObject.GetComponent<DIE>().DEATH();
	//	 }
		 
     }	
	
 void OnCollisionStay(Collision other)
     {
         if (other.gameObject.layer == 3)
         {
             onTheGround = true;
         }
     }	
	
 void OnCollisionExit(Collision other)
     {

        onTheGround = false;
		
    }


	
	
	
}

