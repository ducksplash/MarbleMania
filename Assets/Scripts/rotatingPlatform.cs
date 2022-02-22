using System.Collections;
using UnityEngine;
 
 
public class rotatingPlatform : MonoBehaviour
{
	


	
	
	
	void Update()
	{
	
			gameObject.transform.Rotate(new Vector3 (0, 4, 0) * (Time.smoothDeltaTime * 7));


		
	}
	

	
}
