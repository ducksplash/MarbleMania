using System.Collections;
using UnityEngine;


public class LavaPlanet : MonoBehaviour
{

	void FixedUpdate()
	{
		transform.Rotate(new Vector3(0.1f, -0.1f, -0.1f) * (Time.smoothDeltaTime * 6), Space.World);


	}
}
