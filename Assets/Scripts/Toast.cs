using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class Toast : MonoBehaviour
{

	public TextMeshProUGUI ToastText;
	public Animator ToastAnimator;
	
	
	public void NewToast(string Slug)
	{
		StartCoroutine(DoToast(Slug));
	}
		
	IEnumerator DoToast(string ToastMessage)
	{
		
		ToastText.text = ToastMessage;
		ToastAnimator.SetTrigger("NewToast");	
		yield break;
	}
}
