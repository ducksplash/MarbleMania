using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VolcanicRock : MonoBehaviour
{
	
	private GameObject playerTarget;
	public bool AestheticRock;
	
	void Start()
	{
		if (AestheticRock)
		{
			Invoke("KillRock",10f);
		}
	}
	
    
    
	public void KillRock()
	{
		
		Destroy(gameObject);
		
	}
    
}
