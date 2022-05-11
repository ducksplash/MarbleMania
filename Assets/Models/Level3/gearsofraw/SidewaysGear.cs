using System.Collections;
using UnityEngine;
 
 
public class SidewaysGear : MonoBehaviour
{
	


	
	
	
	void FixedUpdate()
	{
	
			gameObject.transform.Rotate(new Vector3 (0, 0, 3) * (Time.fixedDeltaTime * 8));


		
	}




	private void OnCollisionEnter(Collision collision)
	{
		collision.transform.parent = transform;
	}

	private void OnCollisionExit(Collision collision)
	{
		collision.transform.parent = null;
	}






}
