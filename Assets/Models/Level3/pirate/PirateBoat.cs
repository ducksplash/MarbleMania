using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PirateBoat : MonoBehaviour
{

	public GameObject Player;
	public GameObject TheBoat;
	private Rigidbody PlayerRB;
	public float BoatForce;
	public Rigidbody BoatRB;
	private bool InBoat;
	public ParticleSystem Rains;
	public bool BoatIntact;
	public Vector3 BoatStartPos;
	public GameObject BoatPrefab;
	public GameObject CurrentBoat;
	public bool PlayerSpotted = false;
	private Light CrookLight;
	public Material CrookLightMaterial;
	public Color CrookLightSpottedColor;
	public GameObject CannonBallPrefab;
	public Color CrookLightStartColor;
	private bool CannonEngaged;
	private bool PlayerInRange;
	private GameObject InstantiatedCannonball;
	private int CannonBallTimeout;
	private Transform CannonDirection;
	private Transform CannonBallTarget;
	public int DamageLevel;
	public Mesh IntactBoatMesh;
	public Mesh DamagedBoatMeshOne;
	public Mesh DamagedBoatMeshTwo;
	public float PirateVisionDistance;
	public float MinimumCannonDistance;

	void Start()
    {
		
		CurrentBoat = TheBoat;
		CrookLight = CurrentBoat.GetComponentInChildren<Light>();
		BoatStartPos = transform.position;
		BoatIntact = true;
		CrookLightMaterial.SetColor("_EmissionColor", CrookLightStartColor);
		CannonDirection = TheBoat.transform.Find("CannonballDir");
		CannonBallTarget = TheBoat.transform.Find("CannonballTarget");

	}
	
	
	
	
void OnTriggerEnter(Collider other)
	{
		
		
	if (BoatIntact)
	{
		Debug.Log("bump player");
		
		
		if (other.gameObject.name.Contains("PLAYER"))
		{
			Debug.Log("bumpity");
		}		

	}	
}


	


	void FixedUpdate()
	{
		if (!PlayerStats.GamePaused && BoatIntact)
		{
	
	
			Vector3 direction = Player.transform.position - TheBoat.transform.position;

			Quaternion rotation = Quaternion.LookRotation(direction);

			rotation *= Quaternion.FromToRotation(Vector3.left, Vector3.back);

			TheBoat.transform.rotation = rotation;

	
	

					
			if (Vector3.Distance(TheBoat.transform.position, Player.transform.position) < PirateVisionDistance && !PlayerSpotted)
			{
				CrookLightMaterial.SetColor("_EmissionColor", CrookLightSpottedColor);
				Player.transform.GetComponent<SoundManager>().ENEMYSPOTTED();
				CrookLight.GetComponent<Light>().color = CrookLightSpottedColor;
				PlayerSpotted = true;
			}
			
			if (Vector3.Distance(TheBoat.transform.position, Player.transform.position) > PirateVisionDistance && PlayerSpotted)
			{
				CrookLightMaterial.SetColor("_EmissionColor", CrookLightStartColor);
				CrookLight.GetComponent<Light>().color = CrookLightStartColor;
				PlayerSpotted = false;
			}
			
			
				
			if (Vector3.Distance(TheBoat.transform.position, Player.transform.position) > MinimumCannonDistance && Vector3.Distance(TheBoat.transform.position, Player.transform.position) < PirateVisionDistance)
			{
				if (!CannonEngaged)
				{
					StartCoroutine(FireCannon());
				}
			}		
			else
			{
				if (CannonEngaged)
				{
					StopCoroutine(FireCannon());
					CannonEngaged = false;
				}
			}
		}
		
	}



	IEnumerator FireCannon()
	{
		
		CannonEngaged = true;
		
		while (CannonEngaged)
		{
		InstantiatedCannonball = Instantiate(CannonBallPrefab, CannonDirection.position, Quaternion.identity);
		InstantiatedCannonball.transform.parent = CannonDirection.transform;
		StartCoroutine(DestroyCannonball());
		
		
		Vector3 direction = CannonBallTarget.position - InstantiatedCannonball.transform.position;
		var moveForce = direction * 450;
		InstantiatedCannonball.GetComponent<Rigidbody>().AddForce(moveForce);

			Player.GetComponent<SoundManager>().EXPLOSION();

			Debug.Log("Fire!");			
			
		yield return new WaitForSeconds(2);
		}
		

		yield return null;
		
	}
	
	IEnumerator DestroyCannonball()
	{
		yield return new WaitForSeconds(2);
		Destroy(InstantiatedCannonball);	
	}
	

    void LateUpdate()
    {
		if (BoatIntact)
		{
			if (Vector3.Distance(TheBoat.transform.position, Player.transform.position) < PirateVisionDistance)
			{
				Vector3 direction = Player.transform.position - TheBoat.transform.position;
			
				var moveForce = direction * 2.5f;
				BoatRB.AddForce(moveForce);
			}	
		}		
    }
	
	public void DestroyBoat()
	{
		if (BoatIntact)
		{
			BoatIntact = false;
			CannonEngaged = false;
			PlayerSpotted = false;
			Destroy(TheBoat);
			Invoke("RespawnBoat",3);
		}
		
	}
	

	void RespawnBoat()
	{
		CurrentBoat = Instantiate(BoatPrefab, BoatStartPos, Quaternion.identity);
		CurrentBoat.transform.parent = transform;
		BoatIntact = true;
		TheBoat = CurrentBoat;
		CrookLight = CurrentBoat.GetComponentInChildren<Light>();
		BoatRB = TheBoat.GetComponent<Rigidbody>();
		CannonDirection = TheBoat.transform.Find("CannonballDir");
		CannonBallTarget = TheBoat.transform.Find("CannonballTarget");

	}
	

}
