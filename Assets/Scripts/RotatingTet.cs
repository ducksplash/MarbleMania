using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class RotatingTet : MonoBehaviour
{
	
	private ParticleSystem part;
	
	void Start()
	{
		part = gameObject.GetComponent<ParticleSystem>();
	}
	
	
	void FixedUpdate()
	{
		gameObject.transform.Rotate(new Vector3 (0, 4, 0) * (Time.smoothDeltaTime * 7));
	}
	
	
	void OnParticleCollision(GameObject other)
    {   
		
		if (other.gameObject.name.Contains("PLAYER"))
		{

			if (gameObject.name.Contains("FLAMES"))
			{
				Debug.Log("we still use this?");
				other.transform.GetComponent<DIE>().DEATH();

				if (PlayerStats.shielded)
                {
					other.transform.GetComponent<ShieldScript>().RemoveShield();
					gameObject.GetComponent<SoundManager>().POP();
				}

			}
		}
    }
	
	
}
