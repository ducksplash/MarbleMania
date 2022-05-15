using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class StoneParent: MonoBehaviour
{


	public GameObject stoneprefab;
	private GameObject InstantiatedStone;


	public void ReplenishStone(Vector3 stoneposition)
    {





		StartCoroutine(CreateSteppingStone(stoneposition));




	}

	IEnumerator CreateSteppingStone(Vector3 stoneposition)
	{
		yield return new WaitForSeconds(4);

		InstantiatedStone = Instantiate(stoneprefab, stoneposition, Quaternion.identity);
		InstantiatedStone.transform.parent = transform;
		// correct odd 90degree issue
		InstantiatedStone.transform.Rotate(-90, 0, 0);

		Debug.Log("replen");

	}
}
