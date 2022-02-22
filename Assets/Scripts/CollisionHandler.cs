using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
	public Material GoalSwapMaterial;
	public Transform shield;
	public static bool GoalTriggered;
	public Animator LevelEndAnimator;
	public int ExtraTime;
	private Camera ThisCamera;
	private Animator ThisCameraAnimator;
	private GameObject Player;
	
	
	void Start()
	{
		Player = GameObject.FindWithTag("Player");
		
		GoalTriggered = false;
		ThisCamera = Camera.main;
		ThisCameraAnimator = ThisCamera.GetComponent<Animator>();
		//LevelEndAnimator.GetComponent<Animator>();
	}
	
	
	
	
    //Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
		
		if (!PlayerStats.GamePaused)
		{
		
			if (collision.transform.GetComponent<ShieldScript>())
			{
				if (!PlayerStats.shielded)
				{
					if (!PlayerStats.DEAD && collision.gameObject.name.Equals("PLAYER"))
					{


						if (gameObject.name.Contains("spikes") && !collision.transform.GetComponent<ShieldScript>().amnesty)
						{
							
							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("ouch");
							collision.transform.GetComponent<DIE>().DEATH();

						}

						if (gameObject.name.Contains("VOID"))
						{

							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("bai");
							collision.transform.GetComponent<DIE>().InstaDeath();

						}

						if (gameObject.name.Contains("LAVA"))
						{

							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("bai");
							collision.transform.GetComponent<DIE>().InstaDeath();

						}
						
						
						if (gameObject.name.Contains("LongSpike"))
						{

							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("skewered");
							collision.transform.GetComponent<DIE>().DEATH();

						}
						
						
						if (gameObject.name.Contains("bigbit"))
						{

							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("watch those rocks!");
							collision.transform.GetComponent<DIE>().DEATH();

						}
						
						
						if (gameObject.name.Contains("Cylinder"))
						{

							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("on point");
							collision.transform.GetComponent<DIE>().DEATH();

						}

						
						if (gameObject.name.Contains("ActionRock"))
						{

							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("down pompeii");
							collision.transform.GetComponent<DIE>().DEATH();

						}


						if (gameObject.name.Contains("EnemyBall") &&
							!collision.transform.GetComponent<ShieldScript>().amnesty)
						{
							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("ow");
							collision.transform.GetComponent<DIE>().DEATH();

						}

						if (gameObject.name.Contains("EnemyPirate") &&
							!collision.transform.GetComponent<ShieldScript>().amnesty)
						{
							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("ow");
							collision.transform.GetComponent<DIE>().DEATH();

						}

						if (gameObject.name.Contains("WALL") || gameObject.name.Contains("wall"))
						{
							collision.gameObject.GetComponent<SoundManager>().WALLCOLLIDE();
						}

						if (gameObject.name.Contains("funnel"))
						{
							collision.gameObject.GetComponent<SoundManager>().PLASTICCOLLIDE();
						}

						if (gameObject.name.Contains("cannonball"))
						{
							collision.gameObject.GetComponent<Toast>().NewToast("cannon fodder");
							collision.transform.GetComponent<DIE>().DEATH();
						}

						if (gameObject.name.Contains("EnemyBall") &&
							!collision.transform.GetComponent<ShieldScript>().amnesty)
						{
							collision.gameObject.GetComponent<SoundManager>().SMASH();
							collision.gameObject.GetComponent<Toast>().NewToast("rekt");
							collision.transform.GetComponent<DIE>().DEATH();

						}
					}
				}
			}

		}

    }

    
    void OnTriggerEnter(Collider other)
    {
		
			if (other.gameObject.name.Contains("PLAYER"))
			{

			if (gameObject.name.Equals("GOAL") && !GoalTriggered)
			{
				
			other.gameObject.GetComponent<SoundManager>().LEVELCOMPLETE();

			GoalTriggered = true;
			
			
			PlayerStats.PlayerScore += PlayerStats.PlayerScoreThisLevel;	
			
			LevelEndAnimator.SetTrigger("LevelEnd");
			LevelManager.LevelEnded(Timer.timeRemaining);
			
			
			
			Timer.TimerRunning = false;		
				
				gameObject.GetComponent<MeshRenderer>().material = GoalSwapMaterial;			
			}
			
			
			if (gameObject.name.Contains("CollectableShield"))
			{
				
				other.gameObject.GetComponent<SoundManager>().PICKUP();
				if (!PlayerStats.shielded)
				{
					other.GetComponent<ShieldScript>().AddShield();
				}
				
				
				other.GetComponent<Score>().Add(10,"CollectableShield");
				
				Destroy(gameObject);
			}		
			
			
			if (gameObject.name.Contains("CollectableTime"))
			{
				
				other.gameObject.GetComponent<SoundManager>().PICKUP();
				Timer.timeRemaining += (float)ExtraTime;
		
				other.GetComponent<Score>().Add(ExtraTime,"Add Seconds");
				Destroy(gameObject);
			}	
			
			
			if (gameObject.name.Contains("Collectable2x"))
			{
				
				other.gameObject.GetComponent<SoundManager>().PICKUP();
				PlayerStats.ScoreMultiplier = 2;
				
				other.GetComponent<Score>().Add(10,"2x Score");
				Destroy(gameObject);
			}	
			
			
			if (gameObject.name.Contains("wooosh"))
			{
				
				
				other.gameObject.GetComponent<Toast>().NewToast("see you next week");
			}			
			
			
			if (gameObject.name.Contains("exitlobby"))
			{
				
				
				other.gameObject.GetComponent<Toast>().NewToast("good luck out there :)");
			}	
			
			


		}
		
		
		if (gameObject.name.Contains("bugzapper") && !other.gameObject.name.Contains("PLAYER"))
		{
			
			if (other.gameObject.name.Contains("WeeBeastie"))
			{
				
				Player.GetComponent<Score>().Add(500,"WeeBeastie");
				Destroy(other.gameObject);
				
			}
				
				
		}	
		
		
		
	}
	
	
	
	
}
