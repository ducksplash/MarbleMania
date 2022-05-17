using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;



public class PlayerStats : MonoBehaviour
{
	
	// PLAYER VARS

	public static bool DEAD = false;
	public static int PlayerScore;
	public static int PlayerDeaths;
	public static int CurrentLevel;
	public static int PlayerDamage;
	public static float PlayerTime;
	public static bool shielded;
	public static int PlayerScoreThisLevel;
	public static string GlobalCondition;
	public static bool Playing;
	public static int ScoreMultiplier = 1;
	public static bool resetUI = false;
	public static string LevelName;
	public static int Difficulty;
	public static bool GamePaused;
	public static bool SoundFXEnabled;
	public static bool SoundBGMEnabled;
	public static int GameMode; // 0 normal, 1 easy, 2 hard.
	public static bool MainMenu;
	public static bool STOP;
	public static float CameraSpeed;
	public static float BallSpeed;
	public static bool FlightMode;
	public static bool InWater;
	public static bool HatOnFella = false;


	public static Color32 PlayerColor;
	public static Color32 PlayerMiddleColor;
	
	
	
	// ENEMY VARS
	public static float EnemyMoveSpeed;
	public static float EnemyVisionDistance;
	public static float EnemyRespawnTime;

	
	// IMPUTS
	
	public static KeyCode InputForUP;
	public static KeyCode InputForDOWN;
	public static KeyCode InputForLEFT;
	public static KeyCode InputForRIGHT;
	public static KeyCode InputForJUMP;
	public static KeyCode InputForPAUSE;
	public static KeyCode InputForREARVIEW;
	public static KeyCode InputForRESTART;
	
	
	
	// LEVEL VARS
	public static float TimeLevel1 = 120f;
	public static float TimeLevel2 = 200f;
	public static float TimeLevel3 = 200f;
	public static float TimeLevel4 = 1999f;
	public static float TimeLevel5 = 1999f;
	public static float TimeLevel6 = 1999f;
	public static float TimeLevel7 = 1999f;
	public static float TimeLevel8 = 1999f;
	public static float TimeLevel9 = 1999f;
	public static float TimeLevel10 = 1999f;
	
	
	public TextMeshProUGUI PlayerScoreGUIText;
	public TextMeshProUGUI PlayerDeathsGUIText;

	public static Dictionary<int, Dictionary<string,float>> LevelDict;
	public static Dictionary<string,Texture> PlayerPrefabMeshDict;
	public static string PlayerMiddleBit;
	
	
	
	void Awake()
	{
		LevelDict = new Dictionary<int, Dictionary<string,float>>();	
		PlayerPrefabMeshDict = new Dictionary<string,Texture>();			
		initialiseLevelDictionary();	
		initialisePlayerMeshPrefabDictionary();	
		
		CameraSpeed = 200f;
		BallSpeed = 200f;
		PlayerDamage = 0;
		
		PlayerStats.SoundFXEnabled = true;
		PlayerStats.SoundBGMEnabled = true;
		if (String.IsNullOrEmpty(PlayerMiddleBit))
		{
		PlayerMiddleBit = "default";
		}
		
		
		
		
		// colours
		var ThisIsBlack = new Color32(0,0,0,0);
		
		if (PlayerColor.Equals(ThisIsBlack))
		{
			PlayerColor = new Color32(200,200,200,255);
		}
		
		
		if (PlayerMiddleColor.Equals(ThisIsBlack))
		{
			PlayerMiddleColor = new Color32(200,200,200,255);
		}
		
		
	}

	



	public void DoBallSpeed(float sliderValue)
	{
		
		BallSpeed = sliderValue * 300;

		
	}
	
	
	public void DoCameraSpeed(float sliderValue)
	{
		
		CameraSpeed = sliderValue * 300;
		
	}
	
	
	public static void DoGameMode(int GameMode)
	{
		
		if (GameMode == 0)
		{
			Difficulty = 0;
			EnemyMoveSpeed = 28;
			EnemyVisionDistance = 40;
			EnemyRespawnTime = 5;
		}	
		
		if (GameMode == 1)
		{
			Difficulty = 1;
			EnemyMoveSpeed = 38;
			EnemyVisionDistance = 50;
			EnemyRespawnTime = 3;
		}
		
		if (GameMode == 2)
		{
			Difficulty = 2;
			EnemyMoveSpeed = 48;
			EnemyVisionDistance = 60;
			EnemyRespawnTime = 1;
		}
		
		
	}
	
	
	
	
	
	public void initialisePlayerMeshPrefabDictionary()
	{
		
			
		// insert prefabs.
		// this holds the prefab name and thumbnail icon
		
		
		// create a dictionary called the name of the level.
		// add the level name [string] and the time [float]
		// then add it to the existing LevelDict
		
		
		var meshZero = Resources.Load<Mesh>("playermeshes/default");
		var meshImageZero = Resources.Load<Texture>("playermeshimages/default");
		
		
		PlayerPrefabMeshDict.Add(meshZero.name,meshImageZero);	
		
		
		
			
		var meshOne = Resources.Load<Mesh>("playermeshes/ada");
		var meshImageOne = Resources.Load<Texture>("playermeshimages/ada");
		
		
		PlayerPrefabMeshDict.Add(meshOne.name,meshImageOne);	
		
		
		
			
		var meshTwo = Resources.Load<Mesh>("playermeshes/diamond");
		var meshImageTwo = Resources.Load<Texture>("playermeshimages/diamond");
		
		
		PlayerPrefabMeshDict.Add(meshTwo.name,meshImageTwo);	
		
		
		
			
		var meshThree = Resources.Load<Mesh>("playermeshes/duck");
		var meshImageThree = Resources.Load<Texture>("playermeshimages/duck");
		
		
		PlayerPrefabMeshDict.Add(meshThree.name,meshImageThree);	
		
		
		
		
			
		var meshFour = Resources.Load<Mesh>("playermeshes/heart");
		var meshImageFour = Resources.Load<Texture>("playermeshimages/heart");
		
		
		PlayerPrefabMeshDict.Add(meshFour.name,meshImageFour);	
		
		
		
			
		var meshFive = Resources.Load<Mesh>("playermeshes/shamrock");
		var meshImageFive = Resources.Load<Texture>("playermeshimages/shamrock");
		
		
		PlayerPrefabMeshDict.Add(meshFive.name,meshImageFive);

		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshSix = Resources.Load<Mesh>("playermeshes/skull");
		var meshImageSix = Resources.Load<Texture>("playermeshimages/skull");


		PlayerPrefabMeshDict.Add(meshSix.name, meshImageSix);




		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshSeven = Resources.Load<Mesh>("playermeshes/cat");
		var meshImageSeven = Resources.Load<Texture>("playermeshimages/cat");


		PlayerPrefabMeshDict.Add(meshSeven.name, meshImageSeven);


		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshEight = Resources.Load<Mesh>("playermeshes/hamster");
		var meshImageEight = Resources.Load<Texture>("playermeshimages/hamster");


		PlayerPrefabMeshDict.Add(meshEight.name, meshImageEight);

		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshNine = Resources.Load<Mesh>("playermeshes/ethereum");
		var meshImageNine = Resources.Load<Texture>("playermeshimages/ethereum");


		PlayerPrefabMeshDict.Add(meshNine.name, meshImageNine);

		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshTen = Resources.Load<Mesh>("playermeshes/btc");
		var meshImageTen = Resources.Load<Texture>("playermeshimages/btc");


		PlayerPrefabMeshDict.Add(meshTen.name, meshImageTen);


		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshEleven = Resources.Load<Mesh>("playermeshes/ltc");
		var meshImageEleven = Resources.Load<Texture>("playermeshimages/ltc");


		PlayerPrefabMeshDict.Add(meshEleven.name, meshImageEleven);


		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshTwelve = Resources.Load<Mesh>("playermeshes/trx");
		var meshImageTwelve = Resources.Load<Texture>("playermeshimages/trx");


		PlayerPrefabMeshDict.Add(meshTwelve.name, meshImageTwelve);

		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshThirteen = Resources.Load<Mesh>("playermeshes/pepe");
		var meshImageThirteen = Resources.Load<Texture>("playermeshimages/pepe");


		PlayerPrefabMeshDict.Add(meshThirteen.name, meshImageThirteen);

		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshFourteen = Resources.Load<Mesh>("playermeshes/sparkle");
		var meshImageFourteen = Resources.Load<Texture>("playermeshimages/sparkle");


		PlayerPrefabMeshDict.Add(meshFourteen.name, meshImageFourteen);

		// one of these needs:
		// a prefab for meshNumber
		// a prefab for icon (texture)
		// a consecutive name.

		var meshFifteen = Resources.Load<Mesh>("playermeshes/trex");
		var meshImageFifteen = Resources.Load<Texture>("playermeshimages/trex");


		PlayerPrefabMeshDict.Add(meshFifteen.name, meshImageFifteen);
	}
	
	
	
	
	public void initialiseLevelDictionary()
	{
		
		// insert levels.
		// this holds the name and time allowed for completion
		
		
		// create a dictionary called the name of the level.
		// add the level name [string] and the time [float]
		// then add it to the existing LevelDict
		
		Dictionary<string,float> LevelOne = new Dictionary<string,float>()
		{
			{"Tutorial", TimeLevel1}
		};
		
		LevelDict.Add(1,LevelOne);
		
		
		//
		
		
		Dictionary<string,float> LevelTwo = new Dictionary<string,float>()
		{
			{"Planet Water", TimeLevel2}
		};	

		LevelDict.Add(2,LevelTwo);
			
				
		//
		
		
		Dictionary<string,float> LevelThree = new Dictionary<string,float>()
		{
			{"Planet Fire", TimeLevel3}
		};	

		LevelDict.Add(3,LevelThree);
			
		
		
		
	}
	
	
	void Update()
	{
		
		if (CollisionHandler.GoalTriggered || LevelManager.TimeUpTriggered || !Playing )
		{
			GlobalCondition = "HALT";
		}
		else
		{
			GlobalCondition = "PLAY";
		}
		
		
		
		var ScoreToDisplay = PlayerScoreThisLevel + PlayerScore;
		
		
		if (Playing && !PlayerStats.MainMenu)
		{

			PlayerScoreGUIText.text = ScoreToDisplay.ToString();
			PlayerDeathsGUIText.text = PlayerDeaths.ToString();

		}
	}
	
	
	
	
	
	public static void LevelSelect(int levelNumber)
	{
		

				foreach (KeyValuePair<string, float> Item in LevelDict[levelNumber])
				{

				Debug.Log("LVL: "+Item.Key);
				Debug.Log("TIME: "+Item.Value);
				
				PlayerStats.PlayerTime = Item.Value;
				Timer.timeRemaining = Item.Value;
				PlayerStats.LevelName = Item.Key;
				
				}
				
				
			
	}
}
