using System.Collections;
using UnityEngine;
 
 
public class MainMenuRotatingPlatform : MonoBehaviour
{
	


	
	
	
	void FixedUpdate()
	{
	
			gameObject.transform.Rotate(new Vector3 (0, 3, 0) * (Time.smoothDeltaTime * 7));


		
	}
	

	
}
