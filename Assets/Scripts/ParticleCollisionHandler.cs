using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class ParticleCollisionHandler : MonoBehaviour
{
	
	private ParticleSystem part;
	private bool DidTheDeath = false;
	
	
	void Start()
	{
		
			part = gameObject.GetComponent<ParticleSystem>();
		
	}
	
	

	
	void OnParticleCollision(GameObject other)
    {   
		
		if (other.gameObject.name.Contains("PLAYER") && !DidTheDeath)
		{

			if (gameObject.name.Contains("FLAMES"))
			{
				DidTheDeath = true;
				other.gameObject.GetComponent<SoundManager>().SMASH();
				other.gameObject.GetComponent<Toast>().NewToast("cooked");
				other.transform.GetComponent<DIE>().DEATH();
			}
		}

    }
	
	
	
	
}
