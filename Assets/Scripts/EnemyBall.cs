using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 public class EnemyBall : MonoBehaviour
 {
 
     public Transform Player;
	 public bool enemyDead = false;
	 public float enemySpawnX;
	 public float enemySpawnY;
	 public float enemySpawnZ;
	 private Vector3 enemyRespawnLanding;
	 Rigidbody rb;
	 private bool PlayerSpoted = false;
	void Start()
	{
		
		enemySpawnX = gameObject.transform.position.x;
		enemySpawnY = gameObject.transform.position.y;
		enemySpawnZ = gameObject.transform.position.z;
		
		enemyRespawnLanding = new Vector3(enemySpawnX,enemySpawnY,enemySpawnZ);
		rb = gameObject.GetComponent<Rigidbody>();
		
	}
 
 
 
     void Update()
     {
		 
		 if (!PlayerStats.GamePaused)
		 {
		 
			 transform.LookAt(Player);
	 
			 if (Vector3.Distance(transform.position, Player.position) < PlayerStats.EnemyVisionDistance)
			 {
	 
				var moveForce = transform.forward * PlayerStats.EnemyMoveSpeed;
				rb.AddForce(moveForce);
	 
				if (!PlayerSpoted)
				{
					Player.GetComponent<SoundManager>().ENEMYSPOTTED();
					gameObject.GetComponentInChildren<Light>().color = new Color32(255,0,0,255);
					PlayerSpoted = true;
				}

			 }		 
		 }
		 
     }
	 
	 
	 
	 
	void OnCollisionEnter(Collision collision)
    {
		
		
		 if (!PlayerStats.GamePaused)
		 {
		
		
		 if (collision.relativeVelocity.magnitude > 50 && !enemyDead)
		 {

			gameObject.GetComponent<SoundManager>().ENEMYSMASH(gameObject);
			
			
			transform.GetComponent<DIE>().ENEMYDEATH(gameObject, enemyRespawnLanding, Player);

		 }
				
		if (collision.transform.name.Contains("spikes") && !enemyDead)
		{
		
			
			gameObject.GetComponent<SoundManager>().ENEMYSMASH(gameObject);
			
			
			transform.GetComponent<DIE>().ENEMYDEATH(gameObject, enemyRespawnLanding, Player);
		}
		
				
		if (collision.transform.name.Contains("LongSpike") && !enemyDead)
		{	
			
			gameObject.GetComponent<SoundManager>().ENEMYSMASH(gameObject);
			
			
			transform.GetComponent<DIE>().ENEMYDEATH(gameObject, enemyRespawnLanding, Player);
		}
				
				
		if (collision.transform.name.Contains("PLAYER") && !PlayerStats.shielded)
			{
				Player.GetComponent<Score>().Add(50, "Enemy");


				transform.GetComponent<SphereCollider>().enabled = false;
		
			transform.GetComponent<DIE>().ENEMYDEATH(gameObject, enemyRespawnLanding, Player);
		}	
				
		if (collision.transform.name.Contains("VOID"))
		{

				transform.GetComponent<SphereCollider>().enabled = false;
		
			transform.GetComponent<DIE>().ENEMYDEATH(gameObject, enemyRespawnLanding, Player);
		}	
					
    }
	
	
	}
	
	
	
	
	void OnTriggerEnter(Collider other)
    {
	 
	 	if (other.transform.name.Contains("bugzapper"))
		{
		
			Player.GetComponent<Score>().Add(50,"EnemyPortal");
			
			transform.GetComponent<SphereCollider>().enabled = false;
		
			transform.GetComponent<DIE>().ENEMYDEATH(gameObject, enemyRespawnLanding, Player);
		}
	 
	}
 }