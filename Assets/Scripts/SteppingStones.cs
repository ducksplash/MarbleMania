using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class SteppingStones : MonoBehaviour
{
	
	public bool onStone;
	public GameObject steppingStone;
	public bool isCursed;
	public Rigidbody stoneRB;
	private Material steppingStoneMats;

	void Start()
	{

		steppingStone = gameObject;
		steppingStoneMats = GetComponent<Renderer>().material;


		stoneRB = gameObject.GetComponent<Rigidbody>();
		isCursed = GetRandomBool();

		
	}

    bool GetRandomBool()
    {
        int randomNumber = Random.Range(0, 100);
        return (randomNumber % 2 == 0) ? true : false;
    }

    void OnCollisionEnter(Collision collision)
	{
		if (!onStone)
		{
			Debug.Log("onstone " + steppingStone.name);

			if (isCursed)
            {
				float emissiveIntensity = 0.8f;
				Color emissiveColor = new Color32(255,0,0,255);


				Debug.Log("found bad");
				steppingStoneMats.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
				steppingStoneMats.SetColor("_Color", emissiveColor);
				steppingStoneMats.EnableKeyword("_EMISSION");


				StartCoroutine(DropStone());

			}
			else
			{
				float emissiveIntensity = 0.8f;
				Color emissiveColor = new Color32(0, 60, 0, 255);

				Debug.Log("found good");
				steppingStoneMats.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
				steppingStoneMats.SetColor("_Color", emissiveColor);
				steppingStoneMats.EnableKeyword("_EMISSION");

			}
		}
	}

	IEnumerator DropStone()
	{
		yield return new WaitForSeconds(1);

		float emissiveIntensity = 0.6f;
		Color emissiveColor = new Color32(10, 10, 10, 255);

		steppingStoneMats.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
		steppingStoneMats.SetColor("_Color", emissiveColor);
		steppingStoneMats.EnableKeyword("_EMISSION");
		stoneRB.useGravity = true;
		stoneRB.isKinematic = false;
		StartCoroutine(DestroyStone());

	}


	IEnumerator DestroyStone()
	{
		yield return new WaitForSeconds(1);

		Destroy(steppingStone);

	}




	void OnCollisionExit(Collision collision)
	{
		if (!onStone)
		{

			float emissiveIntensity = 0.6f;
			Color emissiveColor = new Color32(10, 10, 10, 255);

			steppingStoneMats.SetColor("_EmissionColor", emissiveColor * emissiveIntensity);
			steppingStoneMats.SetColor("_Color", emissiveColor);
			steppingStoneMats.EnableKeyword("_EMISSION");
		}
	}

}
