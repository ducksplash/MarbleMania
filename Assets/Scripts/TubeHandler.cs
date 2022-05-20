using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeHandler : MonoBehaviour
{
	public GameObject Player;
	Rigidbody PlayerRB;
	private bool Wooshed;

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
			if (!Wooshed)
			{
				Player.GetComponent<SoundManager>().WOOSH();
				Wooshed = true;

				StartCoroutine(UnWoosh());
			}
			collision.transform.parent = gameObject.transform;

		}

	}

    
	IEnumerator UnWoosh()
    {
		yield return new WaitForSeconds(5);

		Wooshed = false;

    }
		
	
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionExit(Collision collision)
    {
		collision.transform.parent = null;

	}


}
