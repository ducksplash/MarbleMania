using System.Collections;
using UnityEngine;
 
 
public class MainMenuRotatingPlatform : MonoBehaviour
{
	


	
	
	
	void Update()
	{
	
			gameObject.transform.Rotate(new Vector3 (0, 3, 0) * (Time.smoothDeltaTime * 7));


		
	}
	

	
}
