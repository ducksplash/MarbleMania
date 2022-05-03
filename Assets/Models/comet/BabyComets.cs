using System.Collections;
using UnityEngine;
 
 
public class BabyComets : MonoBehaviour
{
    void FixedUpdate()
	{
		transform.Rotate(new Vector3 (0.7f, 0.5f, 1) * (Time.smoothDeltaTime * 8));
	}
}
