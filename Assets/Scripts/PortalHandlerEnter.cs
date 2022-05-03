using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PortalHandlerEnter : MonoBehaviour
{
	
	public GameObject Player;
	
	public GameObject Target;
	
	private bool IsTravelling = false;
	

	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.name.Contains("PLAYER") && !IsTravelling)
		{
			IsTravelling = true;
			Target.GetComponent<MeshCollider>().enabled = false;
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
