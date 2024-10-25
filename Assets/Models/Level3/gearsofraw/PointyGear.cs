using System.Collections;
using UnityEngine;
 
 
public class PointyGear : MonoBehaviour
{
	
	void FixedUpdate()
	{
		gameObject.transform.Rotate(new Vector3 (0, 0, 8) * (Time.fixedDeltaTime * 8));
	}


	private void OnCollisionEnter(Collision collision)
	{
		collision.transform.parent = gameObject.transform;
	}

	private void OnCollisionExit(Collision collision)
	{
		collision.transform.parent = null;
	}


}
