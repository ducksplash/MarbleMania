using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WaterMine : MonoBehaviour
{
    private Light MineLight;
    public GameObject Player;
	public GameObject Shark;
	public Material MineTriggerMaterial;
	public float minEmiss;
	public float maxEmiss;
	static float t = 0.0f;
	public Color MineColor;
	public GameObject ExplosionPrefab;
	private GameObject InstantiatedExplosion;
	public bool playerInRange;
	public bool sharkInRange;
	public float EffectiveBlastRadius;
	public float iandi;
	
	
    private void Start()
    {

		MineColor = new Color(0.8f,0f,0f,1f);

    }


	void OnTriggerEnter(Collider other)
	{
		if (other.transform.name.Contains("PLAYER"))
		{
		Debug.Log("mine");
		Player.GetComponent<DIE>().InstaDeath();
		StartCoroutine(SplosionProcedure());
		Destroy(gameObject);
		}
		
		
		
		if (other.transform.name.Contains("Shark"))
		{
		Debug.Log("mine");
		
		StartCoroutine(SplosionProcedure());
		Shark.GetComponent<WeeShark>().SetDead();
		
		
		Player.GetComponent<Score>().Add(2000,"RuddyShark");
		
		Destroy(gameObject);
		}
		
	}



    IEnumerator SplosionProcedure()
	{		
		Player.GetComponent<SoundManager>().EXPLOSION();
        InstantiatedExplosion = Instantiate(ExplosionPrefab, gameObject.transform.position, Quaternion.identity);



		if (playerInRange)
		{
			Debug.Log("forceplayer");
			Vector3 direction = Player.transform.position - transform.position;
			Player.GetComponent<Rigidbody>().AddForce(direction.normalized * 100,ForceMode.Impulse);	
			Player.GetComponent<DIE>().DEATH();
			
		}

		if (sharkInRange)
		{
			Debug.Log("forceshark");
			Vector3 direction = Shark.transform.position - transform.position;
			Shark.GetComponent<Rigidbody>().AddForce(direction.normalized * 100,ForceMode.Impulse);
			
			

		}


		Destroy(InstantiatedExplosion,2);
		yield return new WaitForSeconds(1);

	}


	void Update()
	{
		
	
		
		
		
		
		
		
				if (Vector3.Distance(transform.position, Player.transform.position) < EffectiveBlastRadius)
				{
					playerInRange = true;
				}
				else
				{
					playerInRange = false;
				}
		
				if (Vector3.Distance(transform.position, Shark.transform.position) < EffectiveBlastRadius)
				{
					sharkInRange = true;
				}
				else
				{
					sharkInRange = false;
				}
				 
				 
				 
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