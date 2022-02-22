using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeHandler : MonoBehaviour
{
	public GameObject Player;
	Rigidbody PlayerRB;
	

	void Start()
	{
		
		PlayerRB = Player.GetComponent<Rigidbody>();
		
	}
	
	
	
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionStay(Collision collision)
    {		
			if (collision.gameObject.name.Contains("PLAYER"))
			{
				PlayerRB.velocity = 200 * (PlayerRB.velocity.normalized);
			}
		
    }

    

		
	
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionExit(Collision collision)
    {

    }
	
	
}
