using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	
	public bool LevelOver;
	public static bool LevelComplete;
	public static int ContestedScore;
	public bool LevelFailed;
	
	public TextMeshProUGUI LevelEndMessage;
	
	public CanvasGroup LevelStartScreen;
	public CanvasGroup LevelEndScreen;
	public CanvasGroup TimerUpScreen;
	public CanvasGroup PausedPanel;
	public CanvasGroup HUDGUI;
	public CanvasGroup RestartScreen;
	public CanvasGroup AudioScreen;
	public CanvasGroup DifficultyScreen;
	public CanvasGroup ControlScreen;
	public CanvasGroup KeyboardScreen;
	public CanvasGroup CustomScreen;
	public static CanvasGroup ThisAudioScreen;
	public static CanvasGroup ThisDifficultyScreen;
	public static CanvasGroup ThisControlScreen;
	public static CanvasGroup ThisKeyboardScreen;
	public static CanvasGroup ThisCustomScreen;
	public static TextMeshProUGUI ThisPlayerTimeLeftText;
	public static TextMeshProUGUI ThisPlayerScoreTotalText;
	public static TextMeshProUGUI TheLevelEndHeaderText;
	public static TextMeshProUGUI ThisPlayerScoreSubtotalText;
	public static TextMeshProUGUI ThisPlayerDeathsText;
	public static TextMeshProUGUI ThisPlayerTimeMultiplierText;
	public static CanvasGroup ThisPausedPanel;
	public static CanvasGroup ThisTimerUpScreen;
	public static CanvasGroup ThisLevelEndScreen;
	public static CanvasGroup ThisHUDGUI;
	public TextMeshProUGUI ThisLevelStartText;
	public TextMeshProUGUI ThisLevelTimeText;
	public TextMeshProUGUI PlayerDeathsText;
	public TextMeshProUGUI TotalScoreText;
	public TextMeshProUGUI PlayerTimeLeftText;
	public TextMeshProUGUI LevelEndHeaderText;
	public TextMeshProUGUI ScoreSubtotalText;
	public TextMeshProUGUI TimeMultiplierText;
	public static bool TimeUpTriggered;
	
	private Camera ThisCamera;
	public Camera LevelCamera;
	private Animator ThisCameraAnimator;
	public Animator StartLevelAnimator;
	private CameraFade ThisCameraFade;
	
	public TextMeshProUGUI TimeUpDeaths;
	public TextMeshProUGUI TimeUpSubScore;
	public TextMeshProUGUI TimeUpFinalScore;
	public Rigidbody PlayerRb;
	
	public TextMeshProUGUI LevelStartLevelText;
	public TextMeshProUGUI LevelStartLevelNameText;
	public TextMeshProUGUI LevelStartTimeText;
	public TextMeshProUGUI LevelStartScoreText;
	public TextMeshProUGUI LevelStartDeathsText;
	
	
	public CanvasGroup NextButton;
	
	
	public AudioSource inGameAudioBGM;
	public AudioSource inGameAudioSFX;
	
	public Animator TimerUpAnimator;
	private CameraFade _cameraFade;




	void Start()
    {

		Cursor.lockState = CursorLockMode.None;
	    LevelOver = false;
		LevelComplete = false;
		LevelFailed = false;
		ContestedScore = 0;
		ThisTimerUpScreen = TimerUpScreen.GetComponent<CanvasGroup>();
		LevelCamera.GetComponent<Camera>();
		ThisPausedPanel = PausedPanel.GetComponent<CanvasGroup>();
		ThisAudioScreen = AudioScreen.GetComponent<CanvasGroup>();
		ThisDifficultyScreen = DifficultyScreen.GetComponent<CanvasGroup>();
		ThisControlScreen = ControlScreen.GetComponent<CanvasGroup>();
		ThisKeyboardScreen = KeyboardScreen.GetComponent<CanvasGroup>();
		ThisCustomScreen = CustomScreen.GetComponent<CanvasGroup>();
		ThisPlayerDeathsText = PlayerDeathsText.GetComponent<TextMeshProUGUI>();
		ThisPlayerTimeLeftText = PlayerTimeLeftText.GetComponent<TextMeshProUGUI>();
		TheLevelEndHeaderText = LevelEndHeaderText.GetComponent<TextMeshProUGUI>();
		ThisPlayerScoreTotalText = TotalScoreText.GetComponent<TextMeshProUGUI>();
		ThisPlayerScoreSubtotalText = ScoreSubtotalText.GetComponent<TextMeshProUGUI>();
		ThisHUDGUI = HUDGUI.GetComponent<CanvasGroup>();

		
		ThisLevelEndScreen = LevelEndScreen.GetComponent<CanvasGroup>();
		ThisPlayerTimeMultiplierText = TimeMultiplierText.GetComponent<TextMeshProUGUI>();
		ThisCamera = Camera.main;


		// initialise some level variables here
		PlayerStats.LevelSelect(int.Parse(SceneManager.GetActiveScene().name));

		LevelCamera.enabled = true;
		PlayerStats.GamePaused = true;
		
		
		BootFluffer();
    }

	
	public void BootFluffer()
	{
		
		
		
			Cursor.lockState = CursorLockMode.None;
		if (!PlayerStats.MainMenu)
		{
			LevelStartLevelText.text = SceneManager.GetActiveScene().name;
			LevelStartLevelNameText.text = PlayerStats.LevelName;
			LevelStartTimeText.text = PlayerStats.PlayerTime.ToString();	
			LevelStartScoreText.text = PlayerStats.PlayerScore.ToString();	
			LevelStartDeathsText.text = PlayerStats.PlayerDeaths.ToString();	


			PlayerStats.DoGameMode(PlayerStats.Difficulty);
			
			
			// default inputs
			
			
			// we can allow users to set these themselves later
			PlayerStats.InputForUP = KeyCode.UpArrow;
			PlayerStats.InputForDOWN = KeyCode.DownArrow;
			PlayerStats.InputForLEFT =  KeyCode.LeftArrow;
			PlayerStats.InputForRIGHT =  KeyCode.RightArrow;
			PlayerStats.InputForJUMP = KeyCode.Space;
			PlayerStats.InputForPAUSE =  KeyCode.E;
			PlayerStats.InputForREARVIEW =  KeyCode.I;
			PlayerStats.InputForRESTART =  KeyCode.R;

		}
		
	}



	public void StartNewGame()
	{	
		
		StartLevel(PlayerStats.CurrentLevel);
		Timer.TimerRunning = true;	
		LevelCamera.enabled = false;
		PlayerStats.GamePaused = false;	
		PlayerStats.CurrentLevel = int.Parse(SceneManager.GetActiveScene().name);
		gameObject.GetComponent<SoundManager>().BGMON();
		gameObject.GetComponent<SoundManager>().BootAudio();

		//Cursor.lockState = CursorLockMode.Locked;


		//inGameAudioBGM.volume = SoundManager.BGMVolume;
		//inGameAudioSFX.volume = SoundManager.SFXVolume;

		//Time.timeScale = 1;	
	}
	
	
	
	
	
	
	public static void CloseAllStatic()
	{
		
		ThisPausedPanel.alpha = 0.0f;
		ThisPausedPanel.blocksRaycasts = false;
		
		ThisTimerUpScreen.alpha = 0.0f;
		ThisTimerUpScreen.blocksRaycasts = false;	

		
		ThisAudioScreen.alpha = 0.0f;
		ThisAudioScreen.blocksRaycasts = false;
		
		ThisDifficultyScreen.alpha = 0.0f;
		ThisDifficultyScreen.blocksRaycasts = false;	
		
		ThisControlScreen.alpha = 0.0f;
		ThisControlScreen.blocksRaycasts = false;
		
		ThisKeyboardScreen.alpha = 0.0f;
		ThisKeyboardScreen.blocksRaycasts = false;
		
		ThisCustomScreen.alpha = 0.0f;
		ThisCustomScreen.blocksRaycasts = false;

		
	}
	
	
	
	void CloseAll()
	{
		
		PausedPanel.alpha = 0.0f;
		PausedPanel.blocksRaycasts = false;
		
		TimerUpScreen.alpha = 0.0f;
		TimerUpScreen.blocksRaycasts = false;	

		
		AudioScreen.alpha = 0.0f;
		AudioScreen.blocksRaycasts = false;
		
		DifficultyScreen.alpha = 0.0f;
		DifficultyScreen.blocksRaycasts = false;	
		
		ControlScreen.alpha = 0.0f;
		ControlScreen.blocksRaycasts = false;
		
		KeyboardScreen.alpha = 0.0f;
		KeyboardScreen.blocksRaycasts = false;
		
		CustomScreen.alpha = 0.0f;
		CustomScreen.blocksRaycasts = false;

		
	}
	
	
	
	public static void LevelEnded(float timeleft)
	{

		LevelComplete = true;
		PlayerStats.STOP = true;

		Cursor.lockState = CursorLockMode.None;

		LevelManager.CloseAllStatic();
		
		ThisHUDGUI.alpha = 0.0f;

		
		ThisLevelEndScreen.alpha = 1.0f;
		ThisLevelEndScreen.blocksRaycasts = true;
		
		ThisPlayerDeathsText.text = PlayerStats.PlayerDeaths.ToString();	
		ThisPlayerTimeLeftText.text = timeleft.ToString("N0");
		
		
		var TimeMultiplier = int.Parse(SceneManager.GetActiveScene().name);
	


	
		ThisPlayerScoreSubtotalText.text = PlayerStats.PlayerScore.ToString();	
		
	
		
		ThisPlayerTimeMultiplierText.text = "x"+TimeMultiplier.ToString();
		
		
		var intTimeBonus = (TimeMultiplier * Mathf.RoundToInt(timeleft));
		
		
		var TotalToAdd = (intTimeBonus * TimeMultiplier);
							
		
		ThisPlayerScoreTotalText.text = (PlayerStats.PlayerScore+TotalToAdd).ToString();
		
		PlayerStats.PlayerScore += TotalToAdd;
		ContestedScore = TotalToAdd;
		TheLevelEndHeaderText.text = "Level Complete";
	
	}

	public void TimerUp()
	{
		gameObject.GetComponent<SoundManager>().TIMERUP();

		Cursor.lockState = CursorLockMode.None;

		TimeUpTriggered = true;
		
		CloseAll();
		
		HUDGUI.alpha = 0.0f;
		
		
		LevelStartScreen.alpha = 0.0f;
		LevelStartScreen.blocksRaycasts = false;
		
		LevelEndScreen.alpha = 0.0f;
		LevelEndScreen.blocksRaycasts = false;
		
		NextButton.alpha = 0.0f;
		NextButton.blocksRaycasts = false;
		
		ThisTimerUpScreen.alpha = 1.0f;
		ThisTimerUpScreen.blocksRaycasts = true;	

		
		TimeUpDeaths.text = PlayerStats.PlayerDeaths.ToString();	
		
		PlayerStats.Playing = false;
		TimerUpAnimator.SetTrigger("TimerUp");	

		
	
	
		TimeUpSubScore.text = (PlayerStats.PlayerScore + PlayerStats.PlayerScoreThisLevel).ToString();	
				
		var PointsSubtotal = (PlayerStats.PlayerScoreThisLevel+PlayerStats.PlayerScore);		
				
		// calculate deaths here, and at GameEnd
		var DeathTax = PlayerStats.PlayerDeaths * 10;
		
		
		var TotalToAdd = (PointsSubtotal - DeathTax);
				
				
		
		TimeUpFinalScore.text = (TotalToAdd).ToString();
		

		PlayerStats.PlayerScore = TotalToAdd;		
			
		TheLevelEndHeaderText.text = "Out Of Time!";
		
		
		
		
	}

	
	
	
	
	public void NextLevel()
	{
		var nextLevel = PlayerStats.CurrentLevel+1;
		PlayerStats.Playing = false;
		SceneManager.LoadScene(nextLevel);
		
	}




	public void RestartLevel()
	{
		ThisHUDGUI.alpha = 0.0f;
		StartCoroutine(ThisCamera.GetComponent<CameraFade>().DoFlatBlack());
		StartCoroutine(ResetLevel());
		PausedPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		PausedPanel.GetComponent<CanvasGroup>().alpha = 0.0f;
		LevelEndScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		LevelEndScreen.GetComponent<CanvasGroup>().alpha = 0.0f;
		TimerUpScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		TimerUpScreen.GetComponent<CanvasGroup>().alpha = 0.0f;
		RestartScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		RestartScreen.GetComponent<CanvasGroup>().alpha = 0.0f;

	}

	public IEnumerator ResetLevel()
	{
		yield return new WaitForSeconds(0.8f);	
		LevelStartScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		LevelStartScreen.GetComponent<CanvasGroup>().alpha = 0.0f;		
		PlayerStats.DEAD = false;
		PlayerStats.shielded = false;
		LevelManager.TimeUpTriggered = false;
		CollisionHandler.GoalTriggered = false;
		PlayerStats.Playing = false;
        if (LevelComplete)
        {
			PlayerStats.PlayerScore -= PlayerStats.PlayerScoreThisLevel;
			PlayerStats.PlayerScore -= ContestedScore;

		}
		PlayerStats.PlayerScoreThisLevel = 0;	
		Timer.TimerRunning = false;	
		PlayerStats.ScoreMultiplier	= 1;
		CheckPoint.ResetCheckpoint();
		PlayerRb.velocity = Vector3.zero;
        PlayerRb.angularVelocity = Vector3.zero;
		gameObject.transform.position = new Vector3(Movement.SpawnX,Movement.SpawnY,Movement.SpawnZ);
		SceneManager.LoadScene(PlayerStats.CurrentLevel);
		
		
		
	}
	
	
	public void StartLevel(int levelNumber)
	{
        Cursor.lockState = CursorLockMode.Locked;
		var thislevelNumber = levelNumber.ToString();
		StartLevelAnimator.SetTrigger("StartLevel");		
		PausedPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		PausedPanel.GetComponent<CanvasGroup>().alpha = 0.0f;		
		LevelEndScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		LevelEndScreen.GetComponent<CanvasGroup>().alpha = 0.0f;		
		TimerUpScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		TimerUpScreen.GetComponent<CanvasGroup>().alpha = 0.0f;		
		PlayerStats.PlayerScoreThisLevel = 0;	
		PlayerStats.Playing = true;
		PlayerStats.STOP = false;
		PlayerStats.shielded = false;
		PlayerStats.ScoreMultiplier = 1;
		CheckPoint.ResetCheckpoint();
		
	}
	
	
	
	public void ResetAll()
	{

		LevelStartScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		LevelStartScreen.GetComponent<CanvasGroup>().alpha = 0.0f;		
		PausedPanel.GetComponent<CanvasGroup>().blocksRaycasts = false;
		PausedPanel.GetComponent<CanvasGroup>().alpha = 0.0f;		
		LevelEndScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		LevelEndScreen.GetComponent<CanvasGroup>().alpha = 0.0f;		
		TimerUpScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
		TimerUpScreen.GetComponent<CanvasGroup>().alpha = 0.0f;	
		PlayerStats.DEAD = false;
		PlayerStats.shielded = false;
		LevelManager.TimeUpTriggered = false;
		CollisionHandler.GoalTriggered = false;
		PlayerStats.Playing = true;			
		PlayerStats.PlayerScoreThisLevel = 0;
		Timer.TimerRunning = false;	
		PlayerStats.ScoreMultiplier	= 1;
		PlayerStats.PlayerScore = 0;	
		PlayerStats.PlayerDeaths = 0;	
		PlayerStats.CurrentLevel = 0;		
		CheckPoint.ResetCheckpoint();
		SceneManager.LoadScene(PlayerStats.CurrentLevel);

	}
}
