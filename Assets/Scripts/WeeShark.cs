using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;


public class WeeShark : MonoBehaviour
{
	
	public bool AteByShark;
	public GameObject Player;
	private Transform PlayerTransform;
	private Rigidbody PlayerRB;
	public float SharkVisionDistance;
	public GameObject WeeSharkObject;
	private WeeShark WeeSharkScript;
	private Rigidbody WeeSharkRB;
	public Vector3 startPos;
	public Vector3 lastPos;
	public Vector3 nextPos;
	public bool IsSwimming;
	public float sharkspeed;
	public Transform[] points;
	public int posi;
	private IEnumerator TheCurrentCoroutine;
	public bool OnPatrol;
	public bool OnAttack;
	private Animator SharkAni;
	public bool SharkEating;
	private Collider PlayerCollider;
	public Collider NoseCollider;
	private bool IsDead;
	public Material SharkEyes;
	private Color SharkEyeColor;
	public bool PlayerSpotted;
	
	
	
	
	
	void Start()
	{
		SharkEyeColor = new Color(0,0,0,0);
		posi = 0;
		IsSwimming = true;
		OnPatrol = true;
		SharkEating = false;
		WeeSharkScript = WeeSharkObject.GetComponent<WeeShark>();
		WeeSharkRB = WeeSharkObject.GetComponent<Rigidbody>();
		SharkAni = WeeSharkObject.GetComponentInChildren<Animator>();
		PlayerTransform = Player.transform;
		PlayerRB = Player.GetComponent<Rigidbody>();
		PlayerCollider = Player.GetComponent<SphereCollider>();
		startPos = gameObject.transform.position;
		lastPos = startPos;
		nextPos = points[0].position;
		TheCurrentCoroutine = SharkSwim(nextPos);
		StartCoroutine(TheCurrentCoroutine);
        SharkEyes.SetColor("_EmissionColor", new Color(1f,0f,0f,2f));	
	}
	
	
	
	    
	
	void OnTriggerEnter(Collider other)
	{
		
		if (!IsDead)
		{
		
		//Debug.Log(other.transform.name);
		if (other.transform.name.Contains("Waypoint"))
		{
			if (posi < points.Length-1)
			{
				posi += 1;
				nextPos = points[posi].position;
				IsSwimming = true;
				StopCoroutine(TheCurrentCoroutine);
				TheCurrentCoroutine = SharkSwim(nextPos);
				StartCoroutine(TheCurrentCoroutine);

				
			}
			else
			{
				
				StopCoroutine(TheCurrentCoroutine);
				posi = 0;
				nextPos = points[posi].position;
				TheCurrentCoroutine = SharkSwim(nextPos);
				StartCoroutine(TheCurrentCoroutine);
				
			}
		}	
		}






		
	}
	
	
	
	void OnCollisionEnter(Collision other)
	{
		if (!IsDead)
		{
			foreach (ContactPoint contact in other.contacts)
			{
				var colName = contact.thisCollider.name;

				if (colName.Contains("nose"))
				{
					if (other.transform.name.Contains("PLAYER"))
					{
						NoseCollider.enabled = false;
						StopCoroutine(TheCurrentCoroutine);
						TheCurrentCoroutine = EatPlayer();
						StartCoroutine(TheCurrentCoroutine);

					}

				}

			}
		}
        else
        {
			foreach (ContactPoint contact in other.contacts)
			{
				if (other.transform.name.Contains("PLAYER"))
				{

					other.gameObject.GetComponent<SoundManager>().PICKUP();

					other.gameObject.GetComponent<Score>().Add(250, "CollectedShark");

					PlayerStats.HatOnFella = true;

					Destroy(gameObject);

				}
			}
        }
	}
	
	
	public void SetDead()
	{
		
		IsDead = true;
		StopCoroutine(TheCurrentCoroutine);
		OnPatrol = false;
		OnAttack = false;
		SharkEating = false;
		WeeSharkRB.useGravity = true;
		WeeSharkRB.mass = 10f;
		SharkAni.SetTrigger("dead");	
        SharkEyes.SetColor("_EmissionColor", SharkEyeColor);	
	}
	
	
	
	void FixedUpdate()
	{
		if (!IsDead)
		{
	
		if (OnPatrol)
		{			
			
			if (Vector3.Distance(gameObject.transform.position, nextPos) > 5f && IsSwimming)
			{

			
			var targetRotation = Quaternion.LookRotation(nextPos - transform.position);
		 
			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.smoothDeltaTime);

			}	
		
		}
	
		if (OnAttack)
		{			
			
			if (Vector3.Distance(gameObject.transform.position, PlayerTransform.position) > 3f && PlayerStats.InWater)
			{

			var targetRotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
		 
			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 2f * Time.smoothDeltaTime);

			}	
		
		}
		
		
		if (Vector3.Distance(gameObject.transform.position, PlayerTransform.position) < (SharkVisionDistance - 2) && PlayerStats.InWater)
        {



			if (OnPatrol)
			{
				OnPatrol = false;
				OnAttack = true;

				PlayerSpotted = true;
				StartCoroutine(SawPlayer());

				StopCoroutine(TheCurrentCoroutine);
				TheCurrentCoroutine = AttackPlayer();
				StartCoroutine(TheCurrentCoroutine);				
			}
			
		}	



		if (Vector3.Distance(gameObject.transform.position, PlayerTransform.position) > SharkVisionDistance || !PlayerStats.InWater)
        {	
			
			if (OnAttack)
			{
				ResetShark();
			}
		}

		}
		
		
	}
	
	
	
	
	
	
	IEnumerator EatPlayer()
	{
		if (!IsDead)
		{
		if (!SharkEating)
		{
			SharkEating = true;	
			SharkAni.SetTrigger("eat");
			PlayerRB.velocity = Vector3.zero;
			PlayerRB.angularVelocity = Vector3.zero;
			PlayerRB.constraints = RigidbodyConstraints.FreezeAll;
			PlayerCollider.enabled = false;
			Player.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
			Player.GetComponent<ShieldScript>().RemoveShield();
			Player.GetComponent<SoundManager>().NOM();   
			yield return new WaitForSeconds(0.3f);
			Player.GetComponent<DIE>().InstaDeath();
			PlayerCollider.enabled = true;
			//And unfreeze before restoring velocities
			PlayerRB.constraints = RigidbodyConstraints.None;
			Player.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
			Player.transform.GetChild(0).transform.localPosition = new Vector3(0f, 0f, 0f);
			Invoke("ResetShark", 1f);
		}
		}
	}




	IEnumerator SharkSwim(Vector3 TheNextPosition)
	{
		while (Vector3.Distance(gameObject.transform.position, TheNextPosition) > 0f && IsSwimming)
		{
			yield return new WaitForSeconds(0.1f);
			WeeSharkRB.AddForce((TheNextPosition - gameObject.transform.position) * sharkspeed);
		}
		IsSwimming = false;
		yield return new WaitForSeconds(2);
	}





	IEnumerator SawPlayer()
	{

		PlayerTransform.gameObject.GetComponent<SoundManager>().SHARK();
		yield return new WaitForSeconds(2);
	}
	IEnumerator AttackPlayer()
	{
		
		while (Vector3.Distance(gameObject.transform.position, PlayerTransform.position) > 0.8f)
		{		
		yield return new WaitForSeconds(0.1f);
		WeeSharkRB.AddForce((PlayerTransform.position - gameObject.transform.position) * (sharkspeed * 6));
		}		
		
		
		yield return new WaitForSeconds(1f);
		
		
		
		
		
		Invoke("ResetShark", 0.5f);
	}
	
	
	void ResetShark()
	{
		OnPatrol = true;
		OnAttack = false;
		SharkEating = false; 
		PlayerSpotted = false;
		NoseCollider.enabled = true;
		StopCoroutine(TheCurrentCoroutine);
		TheCurrentCoroutine = SharkSwim(nextPos);
		StartCoroutine(TheCurrentCoroutine);	
		SharkAni.SetTrigger("idle");
		
	}
	
	
	
	
	
	
}
