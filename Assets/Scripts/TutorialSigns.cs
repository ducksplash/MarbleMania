using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
 
public class TutorialSigns: MonoBehaviour
{
	public GameObject[] signs;
	public Transform NextSign;
	public int totalSigns;
	void Start()
	{
		totalSigns = signs.Length;


		//HideSigns();
	}

	public void HideSigns()
	{
		var iter = 0;

		while (iter < totalSigns)
		{
			signs[iter].GetComponent<CanvasGroup>().alpha = 0;
			iter++;
		}
	}

	public void ShowNextSign(int lastsign)
    {


		if (lastsign+1 < totalSigns)
        {
			signs[lastsign + 1].GetComponent<CanvasGroup>().alpha = 1;
		}
		else
        {
			Destroy(gameObject);
        }

	}

}
