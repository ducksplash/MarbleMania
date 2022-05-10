using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{


	private PlayerStats PlayerStatsScript;
	public TextMeshProUGUI PlayerScoreGUIText;
	public TextMeshProUGUI PlayerDeathsGUIText;



	void Start()
	{
		PlayerStatsScript = gameObject.GetComponent<PlayerStats>();
		gameObject.GetComponent<SoundManager>().BootAudio();





		PlayerScoreGUIText.text = PlayerStats.PlayerScore.ToString();
		PlayerDeathsGUIText.text = PlayerStats.PlayerDeaths.ToString();
	}




	public void QuitToDesktop()
	{
		
		Application.Quit();

	}

	public void ToMainMenu()
	{

		gameObject.GetComponent<SoundManager>().MenuBackward();
		SceneManager.LoadScene("mainmenu");

	}

	public void ToCredits()
	{

		gameObject.GetComponent<SoundManager>().MenuBackward();
		SceneManager.LoadScene("credits");

	}


}