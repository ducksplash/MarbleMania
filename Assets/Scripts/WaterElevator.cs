using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class WaterElevator : MonoBehaviour
{
	
	public ParticleSystem WaterJet;
	public GameObject Player;
	private Rigidbody PlayerRB;
	public GameObject TransportLaunchPad;
	public Transform PlayerLock;
	public float LaunchForce;
	private bool Wooshed;

	void Start()
	{
	
		PlayerRB = Player.GetComponent<Rigidbody>();
		
		
	}
	
	
	
	void OnCollisionEnter(Collision other)
    {   
		
		 foreach(ContactPoint contact in other.contacts)
         {
             var colName = contact.thisCollider.name;
	
			if (colName.Contains("TransportLandingPad"))
			{				
				if (other.transform.name.Contains("PLAYER"))
				{
					Invoke("ReleasePlayer",0f);
			
				}	
				
			}
			
			if (colName.Contains("TransportLaunchPad"))
			{	
			
				if (other.gameObject.name.Contains("PLAYER"))
				{
				PlayerStats.STOP = true;

					if (!Wooshed)
					{
						Player.GetComponent<SoundManager>().WOOSH();
						Wooshed = true;
					}

					PlayerRB.velocity = Vector3.zero;
				PlayerRB = Player.GetComponent<Rigidbody>();
				
								
				Player.transform.position = PlayerLock.position;			
				
				ElevatePlayer();
				}
			}
         }
    }
	
	
	void ElevatePlayer()
	{
		

        PlayerRB.mass = 0.1f;
        PlayerRB.AddForce(0, LaunchForce, 0);
		Wooshed = false;

	}
	
	
	void ReleasePlayer()
	{
		

        PlayerRB.mass = 10f;
        PlayerRB.drag = 0.3f;
		PlayerStats.STOP = false;
	}
	
}
