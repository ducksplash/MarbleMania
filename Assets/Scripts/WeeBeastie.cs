using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class WeeBeastie : MonoBehaviour
{
	
	public GameObject Player;
	public Animator PlayerAnimator;
	private Transform PlayerTransform;
	private Rigidbody PlayerRB;
    public float DetectionDistance;
	public Animator BeastAnimator;
	public Transform BeastTransform;
	public Rigidbody BeastRB;
	public float BeastVisionDistance;
	public float BeastRunDistance;
	public float MinComfyDistance;
	private bool DebounceAnimation;
    public static bool BeingEaten;
    public SphereCollider PlayerCollider;
    public SphereCollider DetectorCollider;
	public float weebeastiespeed;
	

	void Start()
	{
		PlayerTransform = Player.GetComponent<Transform>();
		PlayerRB = Player.GetComponent<Rigidbody>();
		DebounceAnimation = false;
		BeingEaten = false;
		PlayerCollider = Player.GetComponent<SphereCollider>();
	}
	
	
	
	private void LateUpdate()
	{		
		if (Vector3.Distance(BeastTransform.position, PlayerTransform.position) > MinComfyDistance)
		{
			BeastTransform.LookAt(PlayerTransform);	
		}
			
			
		if (Vector3.Distance(BeastTransform.position, PlayerTransform.position) < BeastVisionDistance)
        {	
			
			if (Vector3.Distance(BeastTransform.position, PlayerTransform.position) < BeastRunDistance)
			{	
				
				
				if (!DebounceAnimation)
				{
					DebounceAnimation = true;
					BeastAnimator.SetTrigger("getdown");
					BeastAnimator.SetTrigger("run");
				}				
				
				
				
				if (!BeingEaten)
				{
					var moveForce = BeastTransform.forward * weebeastiespeed;
					BeastRB.AddForce(moveForce);
					
					
					
					if (Vector3.Distance(BeastTransform.position, PlayerTransform.position) < 2)
					{				
						//DebounceAnimation = true;
						BeastAnimator.SetTrigger("getup");
						BeastAnimator.SetTrigger("idle");
						
					}

				}

				
				
				
				
			}
			else
			{
				if (DebounceAnimation)
				{
					DebounceAnimation = false;
					BeastAnimator.ResetTrigger("idle");
					BeastAnimator.SetTrigger("getup");
					BeastAnimator.SetTrigger("idle");
				}
			}
		}
	}
	
	
    void EatPlayer()
    {
        

		PlayerAnimator.enabled = true;
        Player.GetComponent<Toast>().NewToast("nom");
        Player.GetComponent<SoundManager>().SQUISH();
        Invoke("IdlePlayer",0.5f);
    }
    
    
    void IdlePlayer()
    {
        Player.GetComponent<DIE>().InstaDeath();
		//BeastAnimator.SetTrigger("idle");		
        //And unfreeze before restoring velocities
        Player.transform.GetChild(0).transform.localPosition = new Vector3(0f, 0f, 0f);
        PlayerAnimator.enabled = false;
        PlayerRB.constraints = RigidbodyConstraints.None;
        BeastRB.constraints = RigidbodyConstraints.None;
        PlayerCollider.enabled = true;		
		PlayerAnimator.SetTrigger("Idle");
		Invoke("ResetBeast",1.5f);

    }

    public void ResetBeast()
    {

		WeeBeastieDetector.HasCollidedWithBeast = false;
		BeingEaten = false;	
		BeastAnimator.ResetTrigger("getup");
		BeastAnimator.ResetTrigger("run");
		BeastAnimator.ResetTrigger("getdown");
		BeastAnimator.ResetTrigger("idle");
		DebounceAnimation = false;
		BeastAnimator.enabled = false;
		BeastAnimator.enabled = true;
		WeeBeastieDetector.HasCollidedWithBeast = false;
		
	}

    
    public void BeastEatPlayer()
    {		
		if (!BeingEaten)
		{
			BeingEaten = true;
			WeeBeastieDetector.HasCollidedWithBeast = true;
			BeastAnimator.SetTrigger("eatplayer");
			PlayerRB.velocity = Vector3.zero;
			PlayerRB.angularVelocity = Vector3.zero;
			PlayerRB.velocity = new Vector3(0,0,0);
			PlayerRB.AddForce(0, -1000, 0);
			PlayerRB.constraints = RigidbodyConstraints.FreezeAll;
			
			
			
			BeastRB.velocity = Vector3.zero;
			BeastRB.angularVelocity = Vector3.zero;
			BeastRB.velocity = new Vector3(0,0,0);
			BeastRB.AddForce(0, -1000, 0);
			BeastRB.constraints = RigidbodyConstraints.FreezeAll;
			
			PlayerCollider.enabled = false;
			PlayerAnimator.SetTrigger("GetAte");
			Invoke("EatPlayer",0.5f);
		}
    }
    
	
}
