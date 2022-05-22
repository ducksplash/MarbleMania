using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SeaMine : MonoBehaviour
{
    private Light MineLight;
    public GameObject Player;
    public GameObject TheMine;
    public GameObject TheMinePrefab;
    public GameObject CurrentMine;
	public Material MineTriggerMaterial;
	public float minEmiss;
	public float maxEmiss;
	static float t = 0.0f;
	public Color MineColor;
	public GameObject ExplosionPrefab;
	private GameObject InstantiatedExplosion;
	public float EffectiveBlastRadius;
	public float iandi;
	public bool MineExists;
	public Vector3 MineStartPos;
	
    private void Start()
    {
		
		MineStartPos = transform.position;
		MineExists = true;
		MineColor = new Color(0.8f,0f,0f,1f);

    }


	void OnTriggerEnter(Collider other)
	{
		if (other.transform.name.Contains("playervessel") && MineExists)
		{
		StartCoroutine(SplosionProcedure());
		
		
		other.transform.parent.parent.GetComponent<Boat>().ExitBoat();
		other.transform.parent.parent.GetComponent<Boat>().DestroyBoat();
		
		
		Player.GetComponent<DIE>().InstaDeath();
		Destroy(TheMine);
		
		
		Invoke("RespawnMine",1);

		}
		
		
		if (other.transform.name.Contains("enemyvessel") && MineExists)
		{
		StartCoroutine(EnemySplosionProcedure(other));
		Destroy(TheMine);
		
		
		Invoke("RespawnMine",1);

		}
		
		
	}

	
	void RespawnMine()
	{
		CurrentMine = Instantiate(TheMinePrefab, MineStartPos, Quaternion.identity);
		CurrentMine.transform.parent = transform;	
		TheMine = CurrentMine;
	}




    IEnumerator SplosionProcedure()
	{
        InstantiatedExplosion = Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);

		Player.GetComponent<SoundManager>().EXPLOSION();

			Vector3 direction = Player.transform.position - transform.position;
			Player.GetComponent<Rigidbody>().AddForce(direction.normalized * 100,ForceMode.Impulse);	
			Player.GetComponent<DIE>().DEATH();
			

		Destroy(InstantiatedExplosion,2);
		yield return new WaitForSeconds(1);

	}



    IEnumerator EnemySplosionProcedure(Collider theOther)
	{
        InstantiatedExplosion = Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);


			
			theOther.transform.parent.parent.GetComponent<PirateBoat>().DestroyBoat();
			
			//Vector3 direction = theOther.transform.position - transform.position;
			//theOther.transform.parent.GetComponent<Rigidbody>().AddForce(direction.normalized * 100,ForceMode.Impulse);	
			

		Destroy(InstantiatedExplosion,2);
		yield return new WaitForSeconds(1);

	}


	void Update()
	{
				 
		if (MineExists)
		{
			MineTriggerMaterial.SetColor("_EmissionColor", MineColor * Mathf.Lerp(minEmiss, maxEmiss, t));


			// .. and increase the t interpolater
			t += 1f * Time.deltaTime;

			// now check if the interpolator has reached 1.0
			// and swap maximum and minimum so game object moves
			// in the opposite direction.
			if (t > 1.0f)
			{
				float temp = maxEmiss;
				maxEmiss = minEmiss;
				minEmiss = temp;
				t = 0.0f;
			}
		}
		
		
	}








}