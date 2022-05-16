using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalHandler : MonoBehaviour
{
	
	public GameObject Player;
	
	public GameObject Target;
	
	private bool IsTravelling = false;
	

	
	
	void OnTriggerExit(Collider other)
	{
		
		if (other.gameObject.name.Contains("PLAYER") && !IsTravelling)
		{
			IsTravelling = true;
			Target.GetComponent<MeshCollider>().enabled = false;
			other.gameObject.GetComponent<SoundManager>().PORTAL();
			Player.transform.position = Target.transform.position;
			StartCoroutine(TravelTimeout());
			
		}
		
		
	}

	
	IEnumerator TravelTimeout()
	{
		
		yield return new WaitForSeconds(1f);
		Target.GetComponent<MeshCollider>().enabled = true;
		IsTravelling = false;
		
		
	}


	
    
}
