using System.Collections;
using UnityEngine;
 
 
public class Comet : MonoBehaviour
{

	public Transform TargetTransform;
	public Transform CometTransform;

    void FixedUpdate()
	{
		CometTransform.Rotate(new Vector3 (0.7f, 0.5f, 1) * (Time.smoothDeltaTime * 8));

		var step = 0.5f * Time.deltaTime; 

		transform.position = Vector3.MoveTowards(transform.position, TargetTransform.position, step);
	}
}
