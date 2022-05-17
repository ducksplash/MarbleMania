using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsPirateHat : MonoBehaviour
{
	public GameObject theHat;
	private MeshRenderer hatMesh;
	
	
	void Start()
	{
		hatMesh = theHat.GetComponent<MeshRenderer>();

		if (PlayerStats.HatOnFella)
        {
			hatMesh.enabled = true;
        }
		else
        {
			hatMesh.enabled = false;
		}

	}





	public void AddHat()
	{				

		if (!hatMesh.enabled)
		{

			hatMesh.enabled = true;
		}
		else
        {
			hatMesh.enabled = false;
		}

	}



}
