using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class portalin : MonoBehaviour
{
	
	public GameObject Player;
	public int PortalNumber;
	
	private bool IsTravelling = false;
	

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name.Contains("PLAYER") && !IsTravelling)
		{
			// we're just disabling gravity here and then making a noise. 

			Debug.Log(PortalNumber+" gotportal");
			IsTravelling = true;
			PlayerStats.STOP = true;
			StartCoroutine(TravelTimeout());
			other.gameObject.GetComponent<SoundManager>().PORTAL();
			other.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,-6000,0));

		}



	}
	IEnumerator TravelTimeout()
	{

		Debug.Log("follow up");
		yield return new WaitForSeconds(1f);
		IsTravelling = false;
		PlayerStats.STOP = false;


	}




}
