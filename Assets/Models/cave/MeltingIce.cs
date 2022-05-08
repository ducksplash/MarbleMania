using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class MeltingIce : MonoBehaviour
{
	
	public bool onIce;
	public GameObject IceCube;
	private Material icecubeMaterials;
	public Animator meltani;
	void Start()
	{

		IceCube = gameObject;
		icecubeMaterials = GetComponent<Renderer>().material;
		meltani = GetComponent<Animator>();


	}


	void OnCollisionEnter(Collision collision)
	{
		if (!onIce)
		{
			Debug.Log("onstone " + IceCube.name);

				float emissiveIntensity = 0.8f;
				Color emissiveColor = new Color32(0,255,255,255);


				Debug.Log("found bad");
				icecubeMaterials.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
				icecubeMaterials.SetColor("_Color", emissiveColor);
				icecubeMaterials.EnableKeyword("_EMISSION");


				StartCoroutine(DropIce());

			
		}
	}

	IEnumerator DropIce()
	{
		yield return new WaitForSeconds(1);

		// animate melt here

		meltani.SetTrigger("melt");



		StartCoroutine(DestroyIce());

	}


	IEnumerator DestroyIce()
	{
		yield return new WaitForSeconds(2);
		// do another coroutine to reconstitute the ice cube... maybe? If we can be arsed.
		// don't try to do anything after destroy fella ;)

		gameObject.GetComponentInParent<IceParent>().ReplenishIce(transform.position);
		Destroy(IceCube);

		
	}




	void OnCollisionExit(Collision collision)
	{
		if (!onIce)
		{

			float emissiveIntensity = 0.0f;

		}
	}

}
