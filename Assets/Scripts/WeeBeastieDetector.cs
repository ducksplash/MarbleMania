using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class WeeBeastieDetector : MonoBehaviour
{
	
	public static bool HasCollidedWithBeast;
	public GameObject WeeBeastieObject;
	private WeeBeastie WeeBeastieScript;
	void Start()
	{
		
		WeeBeastieScript = WeeBeastieObject.GetComponent<WeeBeastie>();
		
	}
	
	
	
    void OnTriggerEnter(Collider other)
    {
		if (!HasCollidedWithBeast)
		{
			if (!PlayerStats.DEAD && (other.gameObject.name.Contains("PLAYER") || other.gameObject.name.Contains("shield")))
			{
				if (!WeeBeastie.BeingEaten)
				{
					WeeBeastieScript.BeastEatPlayer();
				}		
			}
		}
	}
	
}
