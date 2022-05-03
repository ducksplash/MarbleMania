using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class ParticleCollisionHandler : MonoBehaviour
{
	
	private ParticleSystem part;
	private bool DidTheDeath = false;
	private string[] phrases;
	
	void Start()
	{
		
		part = gameObject.GetComponent<ParticleSystem>();
		
		phrases = new string[]{"hot stuff","burned","who is Kelvin?","cooked","baked","roasted","browned off"};


	}
	
	
	void OnParticleCollision(GameObject other)
	{

		if (other.gameObject.name.Contains("PLAYER") && !DidTheDeath)
		{

			if (gameObject.name.Contains("FLAMES"))
			{

				if (!PlayerStats.shielded && !other.gameObject.GetComponent<ShieldScript>().amnesty)
				{


					int rand = Random.Range(0, phrases.Length);
					Debug.Log("shieldless");

					DidTheDeath = true;
					other.gameObject.GetComponent<SoundManager>().SMASH();
					other.gameObject.GetComponent<Toast>().NewToast(phrases[rand]);
					other.transform.GetComponent<DIE>().DEATH();
					StartCoroutine(reset());
				}
			}

			if (gameObject.name.Contains("ASTEROIDS"))
			{

				if (!PlayerStats.shielded && !other.gameObject.GetComponent<ShieldScript>().amnesty)
				{


					int rand = Random.Range(0, phrases.Length);
					Debug.Log("shieldless");

					DidTheDeath = true;
					other.gameObject.GetComponent<SoundManager>().SMASH();
					other.gameObject.GetComponent<Toast>().NewToast(phrases[rand]);
					other.transform.GetComponent<DIE>().DEATH();
					StartCoroutine(reset());
				}
			}
		}
	}





	IEnumerator reset()
	{
		yield return new WaitForSeconds(1);
		DidTheDeath = false;
	}



}
