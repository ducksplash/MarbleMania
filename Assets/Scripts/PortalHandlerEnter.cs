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
			other.gameObject.GetComponent<SoundManager>().PORTAL();
			StartCoroutine(TravelTimeout());


		}




		if (other.gameObject.name.Contains("playervessel") && !IsTravelling)
		{
			IsTravelling = true;
			Target.GetComponent<MeshCollider>().enabled = false;
			Player.transform.position = Target.transform.position;
			other.gameObject.GetComponentInParent<Boat>().ExitBoat();
			other.gameObject.GetComponentInParent<Boat>().DestroyBoat();
			Player.GetComponent<SoundManager>().PORTAL();

			StartCoroutine(TravelTimeout());

			Debug.Log("got boat");

		}


	}
	IEnumerator TravelTimeout()
	{
		
		yield return new WaitForSeconds(1f);
		Target.GetComponent<MeshCollider>().enabled = true;
		IsTravelling = false;
		
		
	}


	
    
}
