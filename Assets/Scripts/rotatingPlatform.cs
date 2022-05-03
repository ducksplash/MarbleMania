using System.Collections;
using UnityEngine;
 
 
public class RotatingPlatform : MonoBehaviour
{
	


	
	
	
	void Update()
	{
	
			gameObject.transform.Rotate(new Vector3 (0, 0, 4) * (Time.smoothDeltaTime * 7));


		
	}
	

	
}
