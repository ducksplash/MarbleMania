using System.Collections;
using UnityEngine;
 
 
public class RotatingCheckpoint : MonoBehaviour
{
	


	
	
	
	void FixedUpdate()
	{
	
			transform.Rotate(new Vector3 (0, 5, 0) * (Time.smoothDeltaTime * 8));


		
	}
	

	
}
