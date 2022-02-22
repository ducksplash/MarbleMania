using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TheCleaner : MonoBehaviour
{
	
	
	void Start()
	{
		
		StartCoroutine(DestroyThat());
		
	}
	
    
    
	IEnumerator DestroyThat()
	{
		
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
		
	}
    
}
