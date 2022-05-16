using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingVolcanicRock : MonoBehaviour
{
	
	private GameObject playerTarget;
	public GameObject ExplosionEffect;
	public GameObject DebrisPrefab;
	private GameObject InstantiatedDebris;
	private GameObject InstantiatedExplosion;
	public bool AestheticRock;
	public GameObject Player;




    private void Start()
    {
		Player = GameObject.FindWithTag("Player");
	}




    void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.name.Contains("slalom") || collision.gameObject.name.Contains("lavashard") || collision.gameObject.name.Contains("stone"))
		{
			ExplodeVolcanicRock();
		}
		else
		{
			KillRock(0);
		}
	}


	public void ExplodeVolcanicRock()
    {
		
		gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
					

			
			


		StartCoroutine(SplosionProcedure(transform.position));
		StartCoroutine(VolcanicRockDebrisProcedure(transform.position));


		// do something here, turn off the mesh or something to stop the comet effect.


		gameObject.GetComponent<MeshRenderer>().enabled = false;
		
		


		KillRock(3);
			

	}

    IEnumerator VolcanicRockDebrisProcedure(Vector3 debrisPos)
	{
		InstantiatedDebris = Instantiate(DebrisPrefab, debrisPos, Quaternion.identity);


		Destroy(InstantiatedDebris,2);
		yield break;

	}
    IEnumerator SplosionProcedure(Vector3 explosionPos)
	{
        InstantiatedExplosion = Instantiate(ExplosionEffect, explosionPos, ExplosionEffect.transform.rotation);
			Player.GetComponent<SoundManager>().EXPLOSION();


		Destroy(InstantiatedDebris,2);
		yield break;

	}
    
	public void KillRock(float dieTime)
	{
		
		Destroy(gameObject,dieTime);
		
	}
    
}
