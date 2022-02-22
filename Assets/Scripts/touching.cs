using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touching : MonoBehaviour
{
	




    void OnCollisionEnter(Collision collision)
    {
		
		Debug.Log(collision.transform.name);

    }



}
