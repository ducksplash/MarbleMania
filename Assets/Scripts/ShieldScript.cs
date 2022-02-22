using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
	public GameObject theShield;
	public bool amnesty = false;
	private MeshRenderer shieldMesh;
	private SphereCollider shieldCollider;
	Rigidbody rb;
	
	
	void Start()
	{
		shieldMesh = theShield.GetComponent<MeshRenderer>();
		shieldCollider = theShield.GetComponent<SphereCollider>();
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	
	
	
	
	    void OnCollisionEnter(Collision collision)
		{

			if (collision.gameObject.name.Contains("spikes") && PlayerStats.shielded)
			{
				RemoveShield();
				
				gameObject.GetComponent<SoundManager>().POP();
				gameObject.GetComponent<Toast>().NewToast("Careful Now");
			}	
			
			
			if (collision.gameObject.name.Contains("VOID") && PlayerStats.shielded)
			{
				RemoveShield();
				
				gameObject.GetComponent<SoundManager>().POP();
				gameObject.GetComponent<Toast>().NewToast("i can't help you anymore soz");
			}	
			
			if (collision.gameObject.name.Contains("LAVA") && PlayerStats.shielded)
			{
				RemoveShield();
				
				gameObject.GetComponent<SoundManager>().POP();
				gameObject.GetComponent<Toast>().NewToast("i can't help you anymore soz");
			}	
				
				
			if (collision.gameObject.name.Contains("EnemyBall") && PlayerStats.shielded)
			{
				RemoveShield();

				gameObject.GetComponent<SoundManager>().POP();
				gameObject.GetComponent<Score>().Add(100,"Enemy");
			}
			
			
			
			if (collision.gameObject.name.Contains("WALL") || gameObject.name.Contains("wall"))
			{
				gameObject.GetComponent<SoundManager>().WALLCOLLIDE();
			}

			if (collision.gameObject.name.Contains("funnel"))
			{
				gameObject.GetComponent<SoundManager>().PLASTICCOLLIDE();
			}
			
			
			if (collision.gameObject.name.Contains("WeeBeastie") && PlayerStats.shielded)
			{
				RemoveShield();
				
				gameObject.GetComponent<SoundManager>().POP();
				gameObject.GetComponent<Toast>().NewToast("you're on your own, soz.");
			}
	
		}



	public void AddShield()
	{				

		PlayerStats.shielded = true;	
		

		shieldMesh.enabled = true;
		while (!shieldMesh.enabled)
		{
			
			shieldMesh.enabled = true;
		}
		shieldCollider.enabled = true;
		
	}

	public void RemoveShield()
	{				
		if (PlayerStats.shielded)
		{
			amnesty = true;
		}

		PlayerStats.shielded = false;	

		Camera camera = Camera.main;
		var moveForce = camera.transform.forward * (20/2);		
		rb.AddForce(-moveForce);
		shieldMesh.enabled = false;
		shieldCollider.enabled = false;
		StartCoroutine(EndAmnesty());
		
	}


	
	IEnumerator EndAmnesty()
	{
		yield return new WaitForSeconds(0.5f);	
		amnesty = false;
	
		
		
	}
	


}
