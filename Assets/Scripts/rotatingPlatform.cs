using System.Collections;
using UnityEngine;
 
 
public class RotatingPlatform : MonoBehaviour
{






	void FixedUpdate()
	{

		gameObject.transform.Rotate(new Vector3(0, 0, 8) * (Time.fixedDeltaTime * 2));



	}



	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name.Contains("PLAYER"))
        {

		collision.transform.parent = gameObject.transform;
        }
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.name.Contains("PLAYER"))
		{
			Debug.Log("exi");
			collision.transform.parent = null;
		}
	}





}
