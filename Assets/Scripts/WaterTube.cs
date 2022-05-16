using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class WaterTube : MonoBehaviour
{
	
	public ParticleSystem WaterJet;
	public GameObject Player;
	private Rigidbody PlayerRB;
	public Transform PlayerLockBottom;
	public Transform PlayerLockTop;
	public float LaunchForce;
	void Start()
	{
	
		PlayerRB = Player.GetComponent<Rigidbody>();
		
		
	}
	
	
	
	void OnTriggerEnter(Collider other)
    {   
		if (gameObject.name.Contains("bottom"))
		{
			Debug.Log("w");
		}
		if (other.gameObject.name.Contains("PLAYER"))
		{
		PlayerStats.STOP = true;
		
		PlayerRB.velocity = Vector3.zero;
		PlayerRB = Player.GetComponent<Rigidbody>();
		Debug.Log("wooosh");
		
	
			
		Player.transform.position = PlayerLockBottom.position;			
		
		ElevatePlayer();
		}
    }
	
	
	void ElevatePlayer()
	{
		

        PlayerRB.mass = 0.1f;
        PlayerRB.AddForce(0, LaunchForce, 0);
		Player.GetComponent<SoundManager>().WOOSH();

		Invoke("ReleasePlayer",0.5f);
	}
	
	
	
	
	void ReleasePlayer()
	{
		

        PlayerRB.mass = 10f;
        PlayerRB.drag = 0.3f;
		PlayerStats.STOP = false;
	}
	
}
