using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
	

	public CanvasGroup SettingsScreen;
	public CanvasGroup AudioScreen;
	public CanvasGroup DifficultyScreen;
	public CanvasGroup ControlScreen;
	public CanvasGroup KeyboardSettings;
	public CanvasGroup MainMenuScreen;
	public CanvasGroup LevelSelectScreen;
	private PlayerStats PlayerStatsScript;
   	private GameObject BGMToggle;
	private GameObject SFXToggle;
	private GameObject BGMSlider;
	private GameObject SFXSlider;
	public CanvasGroup CustomiseScreen;
	
	public GameObject MeshListScrollViewContents;
	private bool CustomiserButtonsDone;
	
	// swap the guts
	public GameObject MarbleInnerBit;
	
	public GameObject ChangeMeshButton;
	private string MeshName;
	private Image MeshThumbnail;
	
	
	void Start()
	{
		
		CustomiserButtonsDone = false;
		
		PlayerStatsScript = gameObject.GetComponent<PlayerStats>();
	
	
		gameObject.GetComponent<SoundManager>().BootAudio();
	
		BGMSlider = GameObject.Find("BGMSlider");
		
		BGMSlider.GetComponent<Slider>().value = SoundManager.BGMVolume;

		
		SFXSlider = GameObject.Find("SFXSlider");
		
		SFXSlider.GetComponent<Slider>().value = SoundManager.SFXVolume;	
		
		
	}



	public void GameBoot()
	{
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.MainMenu = false;
		SceneManager.LoadScene("1");
	}


	public void DoCredits()
	{
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.MainMenu = false;
		SceneManager.LoadScene("credits");
	}


	public void QuitToDesktop()
	{
		
		Application.Quit();		
		
	}

	public void ToMainMenu()
	{
	
		gameObject.GetComponent<SoundManager>().MenuBackward();
		CloseAllScreens();

		MainMenuScreen.alpha = 1f;
		MainMenuScreen.blocksRaycasts = true;  
		
	}



	
	public void SettingsMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		//Time.timeScale = 0;


		CloseAllScreens();

		SettingsScreen.alpha = 1f;
		SettingsScreen.blocksRaycasts = true;  
	}
	
   
	
	public void AudioMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		//Time.timeScale = 0;


		CloseAllScreens();

		AudioScreen.alpha = 1f;
		AudioScreen.blocksRaycasts = true;  
	}
	
	
	public void DifficultyMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		PlayerStats.GamePaused = true;
		//Time.timeScale = 0;


		CloseAllScreens();

		DifficultyScreen.alpha = 1f;
		DifficultyScreen.blocksRaycasts = true;  
	}
	
	
	public void ControlMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		//Time.timeScale = 0;


		CloseAllScreens();

		ControlScreen.alpha = 1f;
		ControlScreen.blocksRaycasts = true;  
	}
	
	
	public void KeysMenu()
	{
		
		gameObject.GetComponent<SoundManager>().MenuForward();
		//Time.timeScale = 0;


		CloseAllScreens();

		KeyboardSettings.alpha = 1f;
		KeyboardSettings.blocksRaycasts = true;  
	}
		
	
	
	public void BGMVolume(float sliderValue)
	{	

			gameObject.GetComponent<SoundManager>().DoBGMVolume(sliderValue);		
		
	}
	
	
	
	public void SFXVolume(float sliderValue)
	{

			gameObject.GetComponent<SoundManager>().DoSFXVolume(sliderValue);	
					
	}
	
	
	
	
	public void SetBallSpeed(float sliderValue)
	{

			PlayerStatsScript.DoBallSpeed(sliderValue);	
				
	}
	
	
	
	
	
	public void SetCameraSpeed(float sliderValue)
	{		

			PlayerStatsScript.DoCameraSpeed(sliderValue);	
					
	}
	
		
	
	public void DoEasyMode()
	{
		PlayerStats.DoGameMode(0);
	}
	
	public void DoStandardMode()
	{
		PlayerStats.DoGameMode(1);
	}	
	
	public void DoHardMode()
	{
		PlayerStats.DoGameMode(2);
	}	

	



   public void CloseAllScreens()
   {
	   // turn off all pages
		SettingsScreen.blocksRaycasts = false;  	
		SettingsScreen.alpha = 0f;		  
		AudioScreen.alpha = 0f;
		AudioScreen.blocksRaycasts = false;
		DifficultyScreen.alpha = 0f;
		DifficultyScreen.blocksRaycasts = false;
		ControlScreen.alpha = 0f;
		ControlScreen.blocksRaycasts = false;
		KeyboardSettings.alpha = 0f;
		KeyboardSettings.blocksRaycasts = false;
		MainMenuScreen.alpha = 0f;
		MainMenuScreen.blocksRaycasts = false;
		LevelSelectScreen.alpha = 0f;
		LevelSelectScreen.blocksRaycasts = false;
		CustomiseScreen.alpha = 0f;
		CustomiseScreen.blocksRaycasts = false;

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
		
		

		CloseAllScreens();

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
	
}