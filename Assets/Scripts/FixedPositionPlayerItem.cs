using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class FixedPositionPlayerItem : MonoBehaviour
{

	public Transform child;

	void FixedUpdate()
	{
		this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, this.transform.parent.rotation.z * -1.0f);
	}


}
