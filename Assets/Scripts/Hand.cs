using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hand : MonoBehaviour
{

    public Animator HandAnimator;
    public Animator PlayerAnimator;
    public Transform DetectorBit;
    public GameObject Player;
    public Transform PlayerTransform;
    private float DetectionDistance = 1f;
    private bool finished = false;
    public SphereCollider PlayerCollider;
    private Rigidbody rb;
    private Camera ThisCamera;
    
    void Start()
    {
        
        HandAnimator.GetComponent<Animator>();
        PlayerAnimator.GetComponent<Animator>();
        ThisCamera = Camera.main;
        PlayerCollider.GetComponent<SphereCollider>();
        rb = Player.GetComponent<Rigidbody>();
        PlayerTransform = Player.transform;

        PlayerStats.STOP = false;

    }

    
    private void Update()
    {
        if (Vector3.Distance(DetectorBit.transform.position, PlayerTransform.position) < DetectionDistance)
        {
            if (!finished)
            {                
                PlayerStats.STOP = true;
                Handimator();

            }
        }
    }
    

    void SinkPlayer()
    {
        
        Player.GetComponent<Toast>().NewToast("yoink");
        Player.GetComponent<SoundManager>().SQUISH();

        Invoke("IdlePlayer",0.5f);

        Player.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
		
		Player.GetComponent<ShieldScript>().RemoveShield();
    }
    
    
    void IdlePlayer()
    {
        
        PlayerCollider.enabled = true;
        PlayerAnimator.enabled = false;
        Player.GetComponent<DIE>().InstaDeath();
        //And unfreeze before restoring velocities
        rb.constraints = RigidbodyConstraints.None;
        PlayerStats.STOP = false;
        Player.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
        Player.transform.GetChild(0).transform.localPosition = new Vector3(0f, 0f, 0f);
    }
    
    
    public void Handimator()
    {
        if (!finished)
        {        
            
            finished = true;  
            if (Vector3.Distance(DetectorBit.transform.position, PlayerTransform.position) < DetectionDistance)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.AddForce(0, -1000, 0);
                rb.constraints = RigidbodyConstraints.FreezeAll;
                PlayerCollider.enabled = false;
                HandAnimator.SetTrigger("Grab");
                Invoke("SinkPlayer",0.5f);
            
            }
                       
        }

    }
    
    
    
    
}
