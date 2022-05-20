using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;
 public class EnemyPirate : MonoBehaviour
 {
 
     public Transform Player;
	 public bool enemyDead = false;
	 public float enemySpawnX;
	 public float enemySpawnY;
	 public float enemySpawnZ;
	 private Vector3 enemyRespawnLanding;
	 Rigidbody rb;
	void Start()
	{
		
		enemySpawnX = gameObject.transform.position.x;
		enemySpawnY = gameObject.transform.position.y;
		enemySpawnZ = gameObject.transform.position.z;
		
		enemyRespawnLanding = new Vector3(enemySpawnX,enemySpawnY,enemySpawnZ);
		rb = gameObject.GetComponent<Rigidbody>();
		
	}
 
 
 	 
 }