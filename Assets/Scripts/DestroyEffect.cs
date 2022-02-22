using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	void Start()
	{
		
		Invoke("killSplosion",1f);
		
	}

	public void killSplosion()
	{
		Destroy(gameObject);
	}

}
