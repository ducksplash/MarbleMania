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
	public int FinScoreGross;
	public int FinScoreNet;
	public int FinDeaths;
	public int DeathTax;

	void Start()
	{

		DeathTax = 10;


		PlayerStatsScript = gameObject.GetComponent<PlayerStats>();
		gameObject.GetComponent<SoundManager>().BootAudio();

		FinScoreNet = PlayerStats.PlayerScore;

		FinDeaths = PlayerStats.PlayerDeaths;

		FinScoreNet = (PlayerStats.PlayerScore - (PlayerStats.PlayerDeaths * DeathTax));


		PlayerScoreGUIText.text = FinScoreNet.ToString();
		PlayerDeathsGUIText.text = FinDeaths.ToString();
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