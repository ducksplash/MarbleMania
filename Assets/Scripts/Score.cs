using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
	
	public void Add(int scoreForThis, string doType)
	{
		
		var ScoreForThat = (scoreForThis * PlayerStats.ScoreMultiplier);
		
		

		
		// TOAST HERE
		if (doType.Equals("Enemy"))
		{
			gameObject.GetComponent<Toast>().NewToast("Enemy Down +"+ScoreForThat+" Points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}
		
		if (doType.Equals("CollectableShield"))
		{
			gameObject.GetComponent<Toast>().NewToast("Shields Up");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
			
		}
		
		if (doType.Equals("Add Seconds"))
		{
			gameObject.GetComponent<Toast>().NewToast("+"+scoreForThis+" Seconds");
			PlayerStats.PlayerScoreThisLevel += 15;
		}
		
		
		if (doType.Equals("2x Score"))
		{
			gameObject.GetComponent<Toast>().NewToast("2x Score");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}


		if (doType.Equals("Spiked"))
		{
			gameObject.GetComponent<Toast>().NewToast("Enemy Got Piked; +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}


		if (doType.Equals("RuddyShark"))
		{
			gameObject.GetComponent<Toast>().NewToast("Bumped The Shark; +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}


		if (doType.Equals("CollectedShark"))
		{
			gameObject.GetComponent<Toast>().NewToast("Collectable Shark; +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}

		if (doType.Equals("EnemyPortal"))
		{
			gameObject.GetComponent<Toast>().NewToast("Portal Trap; +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}

		if (doType.Equals("EnemyVoid"))
		{
			gameObject.GetComponent<Toast>().NewToast("Enemy Voided; +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}

		if (doType.Equals("WeeBeastie"))
		{
			gameObject.GetComponent<Toast>().NewToast("WeeBeastie was sent to Tartarus; +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}

		if (doType.Equals("FoundGod"))
		{
			gameObject.GetComponent<Toast>().NewToast("Collectable GOD found!; +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}


		if (doType.Equals("FoundHamster"))
		{
			gameObject.GetComponent<Toast>().NewToast("Collectable Hamster found! +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}



		if (doType.Equals("FoundDuck"))
		{
			gameObject.GetComponent<Toast>().NewToast("Collectable Duck found! +" + ScoreForThat + " points");
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}



		// silent 'no toast' cos it's happening elsewhere
		if (doType.Equals("silent"))
		{
			PlayerStats.PlayerScoreThisLevel += ScoreForThat;
		}





	}
}
