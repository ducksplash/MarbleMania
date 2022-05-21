using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class SingleSign : MonoBehaviour
{

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name.Contains("PLAYER"))
		{

			if (gameObject.name.Contains("sign-"))
			{

				other.gameObject.GetComponent<SoundManager>().OTHER();

				other.GetComponent<Score>().Add(15, "silent");


				var signText = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
				var mytext = signText.GetComponent<TextMeshProUGUI>().text;



				other.gameObject.GetComponent<Toast>().NewToast(mytext);

				transform.parent.GetComponent<TutorialSigns>().HideSigns();

				var thisSignNumber = int.Parse(string.Join("", transform.name.ToCharArray().Where(Char.IsDigit)));


				transform.parent.GetComponent<TutorialSigns>().ShowNextSign(thisSignNumber);


				
			}
		}
	}


}