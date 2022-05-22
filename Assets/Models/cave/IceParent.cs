using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class IceParent : MonoBehaviour
{


	public GameObject iceprefab;
	private GameObject InstantiatedIce;


	public void ReplenishIce(Vector3 theicelocation)
    {





		StartCoroutine(CreateIceBlock(theicelocation));




	}

	IEnumerator CreateIceBlock(Vector3 placetoplace)
	{
		yield return new WaitForSeconds(2);

		InstantiatedIce = Instantiate(iceprefab, placetoplace, Quaternion.identity);
		InstantiatedIce.transform.parent = transform;
		// correct odd 90degree issue
		InstantiatedIce.transform.Rotate(-90, 0, 0);


	}
}
