using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
							
							collision.transform.GetComponent<DIE>().DEATH();

						}

						if (gameObject.name.Contains("VOID"))
						{

							collision.transform.GetComponent<DIE>().InstaDeath();

						}

						if (gameObject.name.Contains("LAVA") && !collision.transform.GetComponent<ShieldScript>().amnesty)
						{

							collision.transform.GetComponent<DIE>().InstaDeath();

						}
						
						
						if (gameObject.name.Contains("LongSpike") && !collision.transform.GetComponent<ShieldScript>().amnesty)
						{

							collision.transform.GetComponent<DIE>().DEATH();

						}
						
						
						
						if (gameObject.name.Contains("Cylinder") && !collision.transform.GetComponent<ShieldScript>().amnesty)
						{

							collision.transform.GetComponent<DIE>().DEATH();

						}


						if (gameObject.name.Contains("ActionRock") && !collision.transform.GetComponent<ShieldScript>().amnesty)
						{

							collision.transform.GetComponent<DIE>().DEATH();

						}


						if (gameObject.name.Contains("PoleAxeBlade") && !collision.transform.GetComponent<ShieldScript>().amnesty)
						{

							collision.transform.GetComponent<DIE>().DEATH();

						}


						if (gameObject.name.Contains("EnemyBall") &&
							!collision.transform.GetComponent<ShieldScript>().amnesty)
						{

							collision.transform.GetComponent<DIE>().DEATH();

						}
						if (gameObject.name.Contains("EnemyPirate") &&
							!collision.transform.GetComponent<ShieldScript>().amnesty)
						{
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
				
				
				other.GetComponent<Score>().Add(15,"CollectableShield");
				
				Destroy(gameObject);
			}


			if (gameObject.name.Contains("CollectableTime"))
			{

				other.gameObject.GetComponent<SoundManager>().PICKUP();
				Timer.timeRemaining += (float)ExtraTime;

				other.GetComponent<Score>().Add(ExtraTime, "Add Seconds");
				Destroy(gameObject);
			}




			if (gameObject.name.Contains("sign-"))
			{

				other.gameObject.GetComponent<SoundManager>().OTHER();

				other.GetComponent<Score>().Add(15, "silent");


				var signText = gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
				var mytext = signText.GetComponent<TextMeshProUGUI>().text;



				other.gameObject.GetComponent<Toast>().NewToast(mytext);


				Destroy(gameObject);
			}
			if (gameObject.name.Contains("Collectable2x"))
			{

				other.gameObject.GetComponent<SoundManager>().PICKUP();
				PlayerStats.ScoreMultiplier = 2;

				other.GetComponent<Score>().Add(15, "2x Score");
				Destroy(gameObject);
			}


			if (gameObject.name.Contains("hamster"))
			{

				other.gameObject.GetComponent<SoundManager>().PICKUP();

				other.GetComponent<Score>().Add(2000, "FoundHamster");
				Destroy(gameObject);
			}




			if (gameObject.name.Contains("duck"))
			{

				other.gameObject.GetComponent<SoundManager>().PICKUP();

				other.GetComponent<Score>().Add(3000, "FoundDuck");
				Destroy(gameObject);
			}




			if (gameObject.name.Contains("Collectable-C"))
			{

				other.gameObject.GetComponent<SoundManager>().PICKUP();

				other.GetComponent<Score>().Add(1000, "FoundGod");
				Destroy(gameObject);
			}


			// end collectables





			if (gameObject.name.Contains("wooosh"))
			{				
				other.gameObject.GetComponent<Toast>().NewToast("see you next week");
			}			
			
			
			if (gameObject.name.Contains("exitlobby"))
			{
				
				
				other.gameObject.GetComponent<Toast>().NewToast("good luck out there :)");
			}	
			

		}
		
		
		if (gameObject.name.Contains("bugzapper") || gameObject.name.Contains("VOID") && !other.gameObject.name.Contains("PLAYER"))
		{
			
			if (other.gameObject.name.Contains("WeeBeastie"))
			{
				
				Player.GetComponent<Score>().Add(500,"WeeBeastie");
				Destroy(other.gameObject);
				
			}
				
				
		}	
		
		
		
	}
	
	
	
	
}
