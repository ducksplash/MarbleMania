using System.Collections;
using UnityEngine;
 
 
public class RotatingCollectable : MonoBehaviour
{
	


	
	
	
	void FixedUpdate()
	{
	
			gameObject.transform.Rotate(new Vector3 (0, 15, 0) * (Time.smoothDeltaTime * 8));


		
	}
	

	
}
