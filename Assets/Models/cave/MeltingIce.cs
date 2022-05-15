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
		if (!onIce && collision.gameObject.name.Equals("PLAYER"))
		{
			Debug.Log("on ice " + IceCube.name);

				float emissiveIntensity = 0.8f;
				Color emissiveColor = new Color32(0,0,50,255);


				Debug.Log("found bad");
				icecubeMaterials.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
				icecubeMaterials.SetColor("_Color", emissiveColor);
				icecubeMaterials.EnableKeyword("_EMISSION");


				StartCoroutine(DropIce());

			
		}
		else
        {
			float emissiveIntensity = 0.8f;
			Color emissiveColor = new Color32(0, 0, 50, 255);


			Debug.Log("found bad");
			icecubeMaterials.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
			icecubeMaterials.SetColor("_Color", emissiveColor);
			icecubeMaterials.EnableKeyword("_EMISSION");
		}
	}

	IEnumerator DropIce()
	{
		yield return new WaitForSeconds(1.5f);

		// animate melt here
		IceCube.GetComponent<BoxCollider>().isTrigger = true;

		meltani.SetTrigger("melt");



		StartCoroutine(DestroyIce());

	}


	IEnumerator DestroyIce()
	{
		yield return new WaitForSeconds(0.5f);
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
			Color emissiveColor = new Color32(10, 10, 10, 255);

			icecubeMaterials.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
			icecubeMaterials.SetColor("_Color", emissiveColor);
			icecubeMaterials.EnableKeyword("_EMISSION");
		}
	}

}
