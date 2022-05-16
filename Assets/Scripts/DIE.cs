using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIE : MonoBehaviour
{
	
	private Rigidbody rb;
	public GameObject SmashedMarblePrefab;
	public GameObject EnemyPrefab;
	private GameObject InstantiatedSmash;
	private GameObject InstantiatedEnemySmash;
	public GameObject InnerbitBit;
	public GameObject SphereBit;
	public GameObject LightBit;
	private MeshRenderer MarbleBitMeshRenderer;
	private Light LightBitLight;
	private MeshRenderer InnerBitMeshRenderer;
	private Camera ThisCamera;
	public SoundManager GameSound;
	private bool DeathRecorded;
	private string[] phrases;


	public Material PlayerNoDamage;
	public Material Player1Damage;
	public Material Player2Damage;
	public Material Player3Damage;
	public Material Player4Damage;
	
	void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		
		ThisCamera = Camera.main;

		GameSound = gameObject.GetComponent<SoundManager>();
		
		DeathRecorded = false;

		phrases = new string[] { "dead", "rekt", "shattered", "in bits", "atomised", "disassembled", "gone", "you're done fam", "irreparable" };


	}


	public void DEATH()
	{
		
		
		if (PlayerStats.PlayerDamage == 0 && !PlayerStats.DEAD)
		{
			gameObject.GetComponent<SoundManager>().CRACK1();

			SphereBit.GetComponent<MeshRenderer>().material = Player1Damage;
			PlayerStats.PlayerDamage += 1;
			gameObject.GetComponent<Toast>().NewToast("careful now");
			LightBit.GetComponent<Light>().color = new Color32(255,255,0,1);
			
		}
		else if (PlayerStats.PlayerDamage == 1 && !PlayerStats.DEAD)
		{
			gameObject.GetComponent<SoundManager>().CRACK2();
			SphereBit.GetComponent<MeshRenderer>().material = Player2Damage;
			PlayerStats.PlayerDamage += 1;
			gameObject.GetComponent<Toast>().NewToast("watch it");
			LightBit.GetComponent<Light>().color = new Color32(255,70,0,1);
		}
		else if (PlayerStats.PlayerDamage == 2 && !PlayerStats.DEAD)
		{
			gameObject.GetComponent<SoundManager>().CRACK3();
			SphereBit.GetComponent<MeshRenderer>().material = Player3Damage;
			PlayerStats.PlayerDamage += 1;
			gameObject.GetComponent<Toast>().NewToast("that hurt");
			LightBit.GetComponent<Light>().color = new Color32(180,10,10,1);
		}
		else if (PlayerStats.PlayerDamage == 3 && !PlayerStats.DEAD)
		{
			gameObject.GetComponent<SoundManager>().CRACK4();
			SphereBit.GetComponent<MeshRenderer>().material = Player4Damage;
			PlayerStats.PlayerDamage += 1;
			gameObject.GetComponent<Toast>().NewToast("last legs");
			LightBit.GetComponent<Light>().color = new Color32(255,0,0,1);
		}
		else		
		{
			InstaDeath();
		}		
	}
	
	
	
	public void InstaDeath()
	{
		PlayerStats.DEAD = true;

		gameObject.GetComponent<SoundManager>().SMASH();

		MarbleBitMeshRenderer = SphereBit.GetComponent<MeshRenderer>();
		LightBitLight = LightBit.GetComponent<Light>();
		InnerBitMeshRenderer = InnerbitBit.GetComponent<MeshRenderer>();




		StartCoroutine(PlayerDebrisProcedure(SphereBit.transform.position));
		StartCoroutine(ThisCamera.GetComponent<CameraFade>().DoFadeOut(0.6f));
		StartCoroutine(KillAndTeleportPlayer());
		StartCoroutine(ThisCamera.GetComponent<CameraFade>().DoFadeIn(0.6f,1f));
		
		
		rb.velocity = new Vector3(0,0,0);
			

		rb.isKinematic = true;
		InnerBitMeshRenderer.enabled = false;
		MarbleBitMeshRenderer.enabled = false;
		LightBitLight.enabled = false;

		if (!DeathRecorded)
		{
			PlayerStats.PlayerDeaths ++;
			DeathRecorded = true;
			PlayerStats.PlayerDamage = 0;
			int rand = Random.Range(0, phrases.Length);
			gameObject.GetComponent<Toast>().NewToast(phrases[rand]);
			SphereBit.GetComponent<MeshRenderer>().material = PlayerNoDamage;

		}
		
		
			SphereBit.GetComponent<MeshRenderer>().material = PlayerNoDamage;
			LightBit.GetComponent<Light>().color = PlayerStats.PlayerColor;
	}
	
	
	
	

	public void ENEMYDEATH(GameObject thisEnemy, Vector3 RespawnLanding, Transform thisPlayer)
	{
		if (thisEnemy.GetComponent<EnemyBall>().enemyDead) return;
		Vector3 debrisPosition = thisEnemy.transform.position;
		thisEnemy.GetComponent<SphereCollider>().enabled = false;		
		
		
		
		
		thisEnemy.GetComponent<MeshRenderer>().enabled = false;
		thisEnemy.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
		thisEnemy.transform.GetChild(1).GetComponent<Light>().enabled = false;
		thisEnemy.GetComponent<EnemyBall>().enemyDead = true;

		StartCoroutine(EnemyDebrisProcedure(debrisPosition));
		StartCoroutine(DestroyEnemy(RespawnLanding,thisPlayer,thisEnemy,InstantiatedEnemySmash));

	}

		
	IEnumerator DestroyEnemy(Vector3 enemyRespawnLanding, Transform thePlayer,GameObject deadEnemy, GameObject debris)
	{


		yield return new WaitForSeconds(PlayerStats.EnemyRespawnTime);		
		
		var newEnemyBall = Instantiate(EnemyPrefab, enemyRespawnLanding, Quaternion.identity);
		newEnemyBall.GetComponent<EnemyBall>().Player = thePlayer;
		newEnemyBall.GetComponent<EnemyBall>().enemyDead = false;
		
		newEnemyBall.GetComponent<MeshRenderer>().enabled = true;
		newEnemyBall.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
		newEnemyBall.transform.GetChild(1).GetComponent<Light>().enabled = true;
		newEnemyBall.transform.GetChild(1).GetComponent<Light>().color = new Color32(0,80,100,255);
		newEnemyBall.transform.name = "EnemyBall";
		newEnemyBall.GetComponent<SphereCollider>().enabled = true;
		DestroyImmediate(gameObject, true);
		
	}
		
	IEnumerator PlayerDebrisProcedure(Vector3 debrisPos)
	{

		InstantiatedSmash = Instantiate(SmashedMarblePrefab, debrisPos, Quaternion.identity);

		Destroy(InstantiatedSmash,2);
		yield break;

	}
	
	

	IEnumerator EnemyDebrisProcedure(Vector3 debrisPos)
	{

		InstantiatedEnemySmash = Instantiate(SmashedMarblePrefab, debrisPos, Quaternion.identity);

		Destroy(InstantiatedEnemySmash,2);
		yield break;

	}
	

	IEnumerator KillAndTeleportPlayer()
	{
		MarbleBitMeshRenderer = SphereBit.GetComponent<MeshRenderer>();
		LightBitLight = LightBit.GetComponent<Light>();
		InnerBitMeshRenderer = InnerbitBit.GetComponent<MeshRenderer>();
		yield return new WaitForSeconds(1);	
		
		
		InnerBitMeshRenderer.enabled = true;
		MarbleBitMeshRenderer.enabled = true;
		LightBitLight.enabled = true;
		rb.isKinematic = false;
		PlayerStats.DEAD = false;
		gameObject.transform.position = new Vector3(Movement.SpawnX,Movement.SpawnY,Movement.SpawnZ);
		DeathRecorded = false;
		 
	}



}
