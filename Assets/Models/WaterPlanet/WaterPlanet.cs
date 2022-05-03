using System.Collections;
using UnityEngine;


public class WaterPlanet : MonoBehaviour
{

	void FixedUpdate()
	{
		transform.Rotate(new Vector3(0.1f, 0.1f, 0.1f) * (Time.smoothDeltaTime * -5));


	}
}
