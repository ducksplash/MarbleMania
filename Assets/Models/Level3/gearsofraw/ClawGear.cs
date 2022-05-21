using System.Collections;
using UnityEngine;


public class ClawGear : MonoBehaviour
{

	private string GearState;
	private bool CoroutineStarted;



	private void Start()
	{
		GearState = "DOWN";
		CoroutineStarted = false;
	}



	void FixedUpdate()
	{

		gameObject.transform.Rotate(new Vector3(0, 0, 8) * (Time.fixedDeltaTime * 8));


		if (!CoroutineStarted)
		{
			StartCoroutine(RaiseAndLower());

			CoroutineStarted = true;

		}


	}




    private void OnCollisionEnter(Collision collision)
	{
		collision.transform.parent = transform;
	}

    private void OnCollisionExit(Collision collision)
    {
		collision.transform.parent = null;
	}







    public IEnumerator RaiseAndLower()
	{

		if (GearState == "DOWN")
		{
			var ii = 200;

			while (ii > 0)
			{
				yield return new WaitForSeconds(0.01f);
				gameObject.transform.Translate(new Vector3(0, 0, 1f) * (Time.fixedDeltaTime));
				ii--;
			}
			GearState = "UP";
		}



		if (GearState == "UP")
		{
			var ii = 200;

			while (ii > 0)
			{
				yield return new WaitForSeconds(0.01f);
				gameObject.transform.Translate(new Vector3(0, 0, -1f) * (Time.fixedDeltaTime));
				ii--;
			}
			GearState = "DOWN";

		}



		yield return new WaitForSeconds(1f);
		CoroutineStarted = false;


	}


}