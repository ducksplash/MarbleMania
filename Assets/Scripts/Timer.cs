using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static float timeRemaining;
    public static bool TimerRunning = false;
	public TextMeshProUGUI CountDownTimer;
	public string LevelName;

	
    private void Start()
    {
		
        
		CountDownTimer.GetComponent<TMPro.TextMeshProUGUI>();
		//timeRemaining = PlayerStats.TimerSelect();
			

		
    }

    void FixedUpdate()
    {
        if (TimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.fixedDeltaTime;
                DisplayTime();
            }
            else
            {
                gameObject.GetComponent<LevelManager>().TimerUp();
                timeRemaining = 0;
                TimerRunning = false;
            }
        }
    }

    void DisplayTime()
    {
        CountDownTimer.text = timeRemaining.ToString("N0");
    }
	
	

	
	
	
	
}