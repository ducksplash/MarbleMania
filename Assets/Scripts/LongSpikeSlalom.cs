using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LongSpikeSlalom : MonoBehaviour
{
	private Animator spikeAnim;
	private Transform SpikePlate;
	public Transform Player;
	private float detDist = 50f;
	private bool doneSpike = false;
	
	
	void Start()
	{
		
		spikeAnim = gameObject.GetComponent<Animator>();
		
	}
	


	void Update()
	{

			 if (Vector3.Distance(transform.position, Player.position) < detDist)
			 {
				if (!doneSpike)
				{
					StartCoroutine(DoSpike());
				}
			 }	

	}


	IEnumerator DoSpike()
	{
		spikeAnim.SetTrigger("spike");
		doneSpike = true;
		
		yield return new WaitForSeconds(3f);
		
		spikeAnim.SetTrigger("idle");
		doneSpike = false;
		
	}


}
