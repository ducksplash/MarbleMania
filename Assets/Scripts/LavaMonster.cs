using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class LavaMonster : MonoBehaviour
{
	
	public GameObject Player;
	private Transform PlayerTransform;
	private Rigidbody PlayerRB;
	public Animator LavamonAnimator;
	public Transform LavamonTransform;
	public Rigidbody LavamonRB;
	public float LavamonRunDistance;
	public float LavamonJumpDistance;
	public float MinComfyDistance;
	private bool DebounceAnimation;
    public static bool BeingJumpedOn;
	

	void Start()
	{
		PlayerTransform = Player.GetComponent<Transform>();
		PlayerRB = Player.GetComponent<Rigidbody>();
		DebounceAnimation = false;
		BeingJumpedOn = false;
	}
	
	
	
	private void LateUpdate()
	{		
		if (Vector3.Distance(LavamonTransform.position, PlayerTransform.position) > MinComfyDistance)
		{
			//
		}
			
			
			if (Vector3.Distance(LavamonTransform.position, PlayerTransform.position) < LavamonRunDistance)
			{		
				//var moveForce = LavamonTransform.forward * PlayerStats.EnemyMoveSpeed;
					
					if (!DebounceAnimation)
					{	
						//LavamonRB.AddForce(moveForce);
					
						DebounceAnimation = true;
						LavamonAnimator.SetTrigger("Walking");
					}
			}
			else
			{
				DebounceAnimation = false;
				LavamonAnimator.SetTrigger("Idle");
			}
		
		
		
		
			if (Vector3.Distance(LavamonTransform.position, PlayerTransform.position) < LavamonJumpDistance)
			{	
				if (!DebounceAnimation)
				{
					DebounceAnimation = true;
					LavamonAnimator.SetTrigger("JumpSmash");
				}
					
			}
			else
			{
				DebounceAnimation = false;
				LavamonAnimator.SetTrigger("Idle");
			}		
		
		
		
		
		
		
		
		
		
		
	}
	
    // void FlattenPlayer()
    // {
        

        // Player.GetComponent<DIE>().DEATH();
        // Player.GetComponent<Toast>().NewToast("squish");
        // Player.GetComponent<SoundManager>().SQUISH();
        // Invoke("IdlePlayer",0.5f);
    // }
    
    
    // void IdlePlayer()
    // {
        // Player.transform.GetChild(0).transform.localPosition = new Vector3(0f, 0f, 0f);
        // PlayerRB.constraints = RigidbodyConstraints.None;
        // LavamonRB.constraints = RigidbodyConstraints.None;

    // }



    
    // public void JumpOnPlayer()
    // {		
		// if (!BeingJumpedOn)
		// {
			// BeingJumpedOn = true;
			// LavamonAnimator.SetTrigger("Idle");
			// PlayerRB.velocity = Vector3.zero;
			// PlayerRB.angularVelocity = Vector3.zero;
			// PlayerRB.velocity = new Vector3(0,0,0);
			// PlayerRB.AddForce(0, -1000, 0);
			// PlayerRB.constraints = RigidbodyConstraints.FreezeAll;
			
			// Invoke("FlattenPlayer",0.5f);
		// }
    // }
    
	
}
