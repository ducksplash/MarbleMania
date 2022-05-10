using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
	public void ToMainMenu()
	{

		gameObject.GetComponent<SoundManager>().MenuBackward();
		SceneManager.LoadScene("mainmenu");

	}



}