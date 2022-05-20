using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireBallVertical : MonoBehaviour
{
	
	private bool rockUp = false;
	public float ballForce = 300;
    Rigidbody ballRB;
	private bool isOnLava = true;
	
	
	
    void Start()
    {
        
		ballRB = gameObject.GetComponent<Rigidbody>();

    }

    
    private void FixedUpdate()
    {

		if (!rockUp)
		{
			rockUp = true;
			StartCoroutine(MakeJump());
			
		}
		


    }
    

	void OnCollisionEnter(Collision collision)
    {
		
		if (collision.gameObject.name.Contains("LAVA"))
		{
			isOnLava = true;
		}
		else
		{
			isOnLava = false;
		}
	}



    IEnumerator MakeJump()
	{
		if (isOnLava)
		{
			ballRB.AddForce(Random.Range(-230f,320f), ballForce, Random.Range(-230f,320f));
		}

			yield return new WaitForSeconds(Random.Range(3f,8f));
		
		rockUp = false;
		
	}
    
    
}
