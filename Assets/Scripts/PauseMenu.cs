using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
   
	public CanvasGroup PausedScreen;
	public CanvasGroup TheMainGUICanvas;
	public CanvasGroup LevelStartScreen;
	public CanvasGroup LevelEndPane;
	public CanvasGroup TimeUpPane;
	public CanvasGroup QuitPanel;
	public CanvasGroup SettingsScreen;
	public CanvasGroup AudioScreen;
	public CanvasGroup CustomiseScreen;
	public CanvasGroup DifficultyScreen;
	public CanvasGroup ControlScreen;
	public CanvasGroup KeyboardSettings;
	public CanvasGroup RestartScreen;
	
	public TextMeshProUGUI PlayerScoreText;
	public TextMeshProUGUI PlayerDeathsText;
	public TextMeshProUGUI PlayerLevelText;
	public TextMeshProUGUI PlayerTimeLeftText;
	
	
	public GameObject UIObject;
	public PlayerStats PlayerStatsScript;
	
	public Camera theAssCam;
	public CanvasGroup assCamCanvas;
	public CanvasGroup assCamXLCanvas;
   	private GameObject BGMToggle;
	private GameObject SFXToggle;
	private GameObject DiffEasyToggle;
	private GameObject DiffNormalToggle;
	private GameObject DiffHardToggle;
	private GameObject BGMSlider;
	private GameObject SFXSlider;
	private GameObject BallSpeedSlider;
	private GameObject CamSpeedSlider;
	
	
	public GameObject MeshListScrollViewContents;
	private bool CustomiserButtonsDone;
	
	// swap the guts
	public GameObject MarbleInnerBit;
	
	public GameObject ChangeMeshButton;
	private string MeshName;
	private Image MeshThumbnail;
	
	
 
	public float tapSpeed = 0.5f; //in seconds
 
	private float lastTapTime = 0;
	
	
    private int cameraState = 0;
   

   
   
   
   void Start()
   {
	   
	   
		Debug.Log("Pause Menu Start");
		lastTapTime = 0;
		
		CustomiserButtonsDone = false;
		PlayerStatsScript = UIObject.GetComponent<PlayerStats>();
	   
		BGMSlider = GameObject.Find("BGMSliderIG");
		
		BGMSlider.GetComponent<Slider>().value = SoundManager.BGMVolume;

		
		SFXSlider = GameObject.Find("SFXSliderIG");
		
		SFXSlider.GetComponent<Slider>().value = SoundManager.SFXVolume;	
	   
	   
	   
	   
		BallSpeedSlider = GameObject.Find("IGBallSpeed");
		
		BallSpeedSlider.GetComponent<Slider>().value = PlayerStats.BallSpeed;
	   
	   
	   
	   
		CamSpeedSlider = GameObject.Find("IGCamSpeed");
		
		CamSpeedSlider.GetComponent<Slider>().value = PlayerStats.CameraSpeed;



		
		SFXSlider = GameObject.Find("SFXSliderIG");
		
		SFXSlider.GetComponent<Slider>().value = SoundManager.SFXVolume;	
		
		
		DoResume();	   
		
		
		if (PlayerStats.Difficulty == 0)
		{
			
		DiffEasyToggle = GameObject.Find("EasyToggle");
		DiffEasyToggle.GetComponent<Toggle>().isOn = true;	
			
		DiffNormalToggle = GameObject.Find("NormalToggle");
		DiffNormalToggle.GetComponent<Toggle>().isOn = false;	
			
		DiffHardToggle = GameObject.Find("HardToggle");
		DiffHardToggle.GetComponent<Toggle>().isOn = false;			
			
		}
		
		if (PlayerStats.Difficulty == 1)
		{
			
		DiffEasyToggle = GameObject.Find("EasyToggle");
		DiffEasyToggle.GetComponent<Toggle>().isOn = false;	
			
		DiffNormalToggle = GameObject.Find("NormalToggle");
		DiffNormalToggle.GetComponent<Toggle>().isOn = true;	
			
		DiffHardToggle = GameObject.Find("HardToggle");
		DiffHardToggle.GetComponent<Toggle>().isOn = false;			
			
		}
		
		if (PlayerStats.Difficulty == 2)
		{
			
		DiffEasyToggle = GameObject.Find("EasyToggle");
		DiffEasyToggle.GetComponent<Toggle>().isOn = false;	
			
		DiffNormalToggle = GameObject.Find("NormalToggle");
		DiffNormalToggle.GetComponent<Toggle>().isOn = false;	
			
		DiffHardToggle = GameObject.Find("HardToggle");
		DiffHardToggle.GetComponent<Toggle>().isOn = true;			
			
		}
		

		
		
   }
   


   
   
   void Update()
   {
	   // countdown
		PlayerTimeLeftText.text = Timer.timeRemaining.ToString("N0");
	   
	   
	   
	   
		if (Input.GetKeyUp(PlayerStats.InputForPAUSE) || Input.GetKeyUp(KeyCode.Escape) && !PlayerStats.STOP)
		{
		   if (PlayerStats.Playing)
		   {
				OpenPauseScreen();
		   }
		}
	   
	   
	   
		if (Input.GetKeyUp(PlayerStats.InputForREARVIEW) || Input.GetKeyUp(KeyCode.V) && !PlayerStats.STOP)
		{
		   if (PlayerStats.Playing)
		   {
			DoAssCam();
		   }
		}	 




			if (Input.GetKeyUp(PlayerStats.InputForRESTART) && !PlayerStats.STOP)
			{
				if (PlayerStats.Playing)
				{
					DoRestartLevel();
				}
			}


			if(Input.GetKeyDown(KeyCode.KeypadPeriod) && !PlayerStats.STOP)
			{
 
				if((Time.time - lastTapTime) < tapSpeed)
				{
 
					if (!PlayerStats.FlightMode)
					{
						PlayerStats.FlightMode = true;
						gameObject.GetComponent<Rigidbody>().mass = 0.01f;
						gameObject.GetComponent<Rigidbody>().isKinematic = true;
					}
					else
					{
						PlayerStats.FlightMode = false;
						gameObject.GetComponent<Rigidbody>().mass = 10f;
						gameObject.GetComponent<Rigidbody>().isKinematic = false;
					}
				}
 
			lastTapTime = Time.time;
 
			}
 
		

	   
	}
   
   
   
   public void DoAssCam()
   {
	   
	  	if (cameraState == 0)
		{
			theAssCam.enabled = true;
			assCamCanvas.alpha = 1.0f;
			cameraState = 1;
		}
		else if (cameraState == 1)
		{
			assCamCanvas.alpha = 0.0f;
			assCamXLCanvas.alpha = 1.0f;
			cameraState = 2;
		}
		else
		{
			theAssCam.enabled = false;
			assCamCanvas.alpha = 0.0f;
			assCamXLCanvas.alpha = 0.0f;
			cameraState = 0;
		}
		    
	   
   }
   
   
   
   public void CloseAll()
   {
	   // turn off all pages
		SettingsScreen.blocksRaycasts = false;  	
		SettingsScreen.alpha = 0f;		      
		TheMainGUICanvas.blocksRaycasts = false;
		TheMainGUICanvas.alpha = 0f;
		PausedScreen.alpha = 0f;
		PausedScreen.blocksRaycasts = false;
		QuitPanel.alpha = 0f;
		QuitPanel.blocksRaycasts = false;
		LevelEndPane.alpha = 0f;
		LevelEndPane.blocksRaycasts = false;
		LevelStartScreen.alpha = 0f;
		LevelStartScreen.blocksRaycasts = false;
		TimeUpPane.alpha = 0f;
		TimeUpPane.blocksRaycasts = false;
		AudioScreen.alpha = 0f;
		AudioScreen.blocksRaycasts = false;
		DifficultyScreen.alpha = 0f;
		DifficultyScreen.blocksRaycasts = false;
		CustomiseScreen.alpha = 0f;
		CustomiseScreen.blocksRaycasts = false;
		ControlScreen.alpha = 0f;
		ControlScreen.blocksRaycasts = false;
		KeyboardSettings.alpha = 0f;
		KeyboardSettings.blocksRaycasts = false;
		RestartScreen.alpha = 0f;
		RestartScreen.blocksRaycasts = false;

   }
   
   
   
   
   
   
   public void OpenPauseScreen()
   {
	   if (!PlayerStats.GamePaused)
	   {
		   
		gameObject.GetComponent<SoundManager>().MenuForward();
        Cursor.lockState = CursorLockMode.None;

		CloseAll();
		
		
		PausedScreen.alpha = 1f;
		PausedScreen.blocksRaycasts = true;
		
		
		// Do stats
		
		PlayerScoreText.text = PlayerStats.PlayerScore.ToString();
		PlayerDeathsText.text = PlayerStats.PlayerDeaths.ToString();
		PlayerLevelText.text = SceneManager.GetActiveScene().name;
		
		
		
		
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;
	   }
	   else
	   { 
   
			Cursor.lockState = CursorLockMode.None;
			PlayerStats.GamePaused = false;
			DoResume();
	   }
   }
   
	
	public void QuitMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;
		
		

		CloseAll();
		
		
		
		QuitPanel.alpha = 1.0f;
		QuitPanel.blocksRaycasts = true;
		
		
	}
	
   
	
	public void SettingsMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAll();

		SettingsScreen.alpha = 1f;
		SettingsScreen.blocksRaycasts = true;  
	}
	
  
	
	public void AudioMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAll();

		AudioScreen.alpha = 1f;
		AudioScreen.blocksRaycasts = true;  
	}
	
	
	public void DifficultyMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAll();

		DifficultyScreen.alpha = 1f;
		DifficultyScreen.blocksRaycasts = true;  
	}
	
	
	public void ControlMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAll();

		ControlScreen.alpha = 1f;
		ControlScreen.blocksRaycasts = true;  
	}
	
	
	public void KeysMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAll();

		KeyboardSettings.alpha = 1f;
		KeyboardSettings.blocksRaycasts = true;  
	}
		
	
	
	public void BGMVolume(float sliderValue)
	{	
		if (PlayerStats.GamePaused)
		{
			gameObject.GetComponent<SoundManager>().DoBGMVolume(sliderValue);		
		}
	}
	
	
	
	public void SFXVolume(float sliderValue)
	{
		if (PlayerStats.GamePaused)
		{
			gameObject.GetComponent<SoundManager>().DoSFXVolume(sliderValue);	
		}			
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	public void SetBallSpeed(float sliderValue)
	{
		if (PlayerStats.GamePaused)
		{
			UIObject.GetComponent<PlayerStats>().DoBallSpeed(sliderValue);	
		}		
	}
	
	
	
	
	
	public void SetCameraSpeed(float sliderValue)
	{		
		if (PlayerStats.GamePaused)
		{
			UIObject.GetComponent<PlayerStats>().DoCameraSpeed(sliderValue);	
		}			
	}
	
	
	
	
	 
	
	public void CustomMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;

		if (!CustomiserButtonsDone)
		{

			var itty = 0;
			foreach(KeyValuePair<string,Texture> entry in PlayerStats.PlayerPrefabMeshDict)
			{
				
			
				
				var buttonPosition = new Vector3(MeshListScrollViewContents.transform.localPosition.x,MeshListScrollViewContents.transform.localPosition.y,MeshListScrollViewContents.transform.localPosition.z);
				
				var thisChangeMeshButton = Instantiate(ChangeMeshButton, buttonPosition, Quaternion.identity);
				thisChangeMeshButton.transform.SetParent(MeshListScrollViewContents.transform,false);
				
				thisChangeMeshButton.GetComponentInChildren<RawImage>().texture = entry.Value;
				
				thisChangeMeshButton.GetComponent<Button>().onClick.AddListener(delegate {DoSwapMesh(entry.Key);});
				Debug.Log(entry.Key);
				itty += 1;
				CustomiserButtonsDone = true;
			}
		}
		
		

		CloseAll();

		CustomiseScreen.alpha = 1f;
		CustomiseScreen.blocksRaycasts = true;  
	}
	
   
	
	public void DoSwapMesh(string selectedMesh)
	{
			
		var getSelectedMesh = Resources.Load<Mesh>("playermeshes/"+selectedMesh);
		MarbleInnerBit.GetComponent<MeshFilter>().mesh = getSelectedMesh;
		PlayerStats.PlayerMiddleBit = selectedMesh;
		Debug.Log(PlayerStats.PlayerMiddleBit);
	}
	
	
	
	public void DoEasyMode()
	{
		PlayerStats.DoGameMode(0);
	}
	
	
	public void DoHardMode()
	{
		PlayerStats.DoGameMode(1);
	}	
	
	public void DoStandardMode()
	{
		PlayerStats.DoGameMode(2);
	}	
	

	
	
	public void DoQuitToMenu()
	{
		
		PlayerStats.DEAD = false;
		PlayerStats.shielded = false;
		LevelManager.TimeUpTriggered = false;
		CollisionHandler.GoalTriggered = false;
		PlayerStats.Playing = false;			
		PlayerStats.PlayerScoreThisLevel = 0;
		Timer.TimerRunning = false;	
		PlayerStats.ScoreMultiplier	= 1;
		PlayerStats.PlayerScore = 0;	
		PlayerStats.PlayerDeaths = 0;	
		PlayerStats.CurrentLevel = 0;	
		//PlayerStats.Difficulty = 1;		
		CheckPoint.ResetCheckpoint();
		
		PlayerStats.MainMenu = true;
		PlayerStats.GamePaused = false;
		//Time.timeScale = 0;
		SceneManager.LoadScene("mainmenu");
		PlayerStats.PlayerMiddleBit = "default";	
		
		PlayerStats.PlayerColor = new Color32(200,200,200,255);
		PlayerStats.PlayerMiddleColor = new Color32(200,200,200,255);
	}
	
	public void DoQuitToDesktop()
	{
		
		Application.Quit();			
		
	}
	
	public void DoRestartLevel()
	{
        Cursor.lockState = CursorLockMode.None;
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAll();

		RestartScreen.alpha = 1f;
		RestartScreen.blocksRaycasts = true;  	
		
	}	
	
	
	public void DoReturnToPause()
	{

		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAll();

		PausedScreen.alpha = 1f;
		PausedScreen.blocksRaycasts = true;  	
		
	}
	
	
	
	public void DoResume()
	{
		
		if (PlayerStats.Playing)
		{
		Debug.Log("Pause DoResume");
			Cursor.lockState = CursorLockMode.Locked;
			PlayerStats.GamePaused = false;
			gameObject.GetComponent<SoundManager>().MenuBackward();
		}

		CloseAll();
		
		
		TheMainGUICanvas.alpha = 1f;
		TheMainGUICanvas.blocksRaycasts = true;  

		
		Time.timeScale = 1;
		
		
	}
   
   
}
