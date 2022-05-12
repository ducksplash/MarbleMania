using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class Toast : MonoBehaviour
{

	// refactoring this code
	// get the parent item of these and nothing else;
	// we'll create both of these
	// we could use code to move the text instead of an animation
	// public TextMeshProUGUI ToastText;
	// public Animator ToastAnimator;
	public GameObject TMPrefab;
	private GameObject InstantiatedTMP;
	private TextMeshProUGUI TMPText;
	private Animator TMPAnimator;
	public Transform ToastParentTransform;
	
	// do new stuff
	// let's make the font changeable in the inspector
	public TMP_FontAsset ToastFont;

	private bool toasting;


	
	public void NewToast(string Slug)
	{
		// we probably don't need a coroutine here but 
		// we'll hold onto it for now, it works and
		// only needs a wee string for food
		StartCoroutine(DoToast(Slug));
	}
		
	IEnumerator DoToast(string ToastMessage)
	{

		if (!toasting)
		{ 
		InstantiatedTMP = Instantiate(TMPrefab, transform.position, Quaternion.identity);

		TMPText = InstantiatedTMP.GetComponent<TextMeshProUGUI>();
		TMPAnimator = InstantiatedTMP.GetComponent<Animator>();

		TMPText.text = ToastMessage;

		InstantiatedTMP.transform.SetParent(ToastParentTransform);






		TMPAnimator.enabled = true;

		TMPAnimator.SetTrigger("NewToast");

		toasting = true;

		StartCoroutine(DestroyToast(InstantiatedTMP));
		}
		else
        {
			// wait and go back around
			StartCoroutine(QueueMe(ToastMessage));
		}



		yield break;
	}



	IEnumerator QueueMe(string ToastMessage)
	{
		yield return new WaitForSeconds(0.2f);

		StartCoroutine(DoToast(ToastMessage));


	}



	IEnumerator DestroyToast(GameObject ThisToast)
	{
		yield return new WaitForSeconds(0.5f);

		toasting = false;

		yield return new WaitForSeconds(2f);
		Destroy(ThisToast);

	}


}
