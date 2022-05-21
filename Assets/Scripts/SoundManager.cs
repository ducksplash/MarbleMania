using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
			
	// BGM
	public AudioSource BGMAudioSource;
	public AudioSource SFXAudioSource;
	public static bool BGMVolumeChanged;
	public static bool SFXVolumeChanged;
	
	// ATTACHED TO CAMERA
	
	
	// SFX 
	public static float BGMVolume;
	public static float SFXVolume;

	public AudioClip PortalNoiseClip;
	public AudioClip OtherCollectable;
	public AudioClip CrackedBallClip1;
	public AudioClip CrackedBallClip2;
	public AudioClip CrackedBallClip3;
	public AudioClip CrackedBallClip4;
	public AudioClip SmashedBallClip;
	public AudioClip PoppedShieldClip;
	public AudioClip LandingMarbleClip;
	public AudioClip JumpingMarbleClip;
	public AudioClip MenuBackwardsClip;
	public AudioClip MenuForwardsClip;
	public AudioClip ItemPickupClip;
	public AudioClip CheckPointClip;
	public AudioClip SquishClip;
	public AudioClip ButtonClickClip;
	public AudioClip PlasticCollideClip;
	public AudioClip WallCollideClip;
	public AudioClip LevelCompleteClip;
	public AudioClip TimerUpClip;
	public AudioClip EnemySpottedClip;
	public AudioClip SplashClip;
	public AudioClip SharkSpotted;
	public AudioClip MunchSound;
	public AudioClip Woosh;
	public AudioClip Melt;


	public AudioClip ExplosionClip;


	// ATTACHED TO PLAYER




	void Start()
	{
		

	}
	
	
	
	
	
	
	
	public void BootAudio()
	{
		

		SFXVolume = 0.6f;
		SFXAudioSource.volume = SFXVolume;
		
		BGMVolume = 0.1f;
		BGMAudioSource.volume = BGMVolume;		
		
				
		
	}
		
	
	public void BGMON()
	{

		if (PlayerStats.Playing && !PlayerStats.MainMenu && PlayerStats.SoundBGMEnabled)
		{
			BGMAudioSource.Play();
		}

	}
		
	
	
	public void BGMOFF()
	{

		//PlayerStats.SoundBGMEnabled = false;
		
		
		BGMAudioSource.Stop();
		
	}	
	
	public void DoBGMVolume(float sliderValue)
	{
		BGMVolumeChanged = true;
		BGMAudioSource.volume = sliderValue;
		BGMVolume = sliderValue;
	}
	
	public void DoSFXVolume(float sliderValue)
	{
		SFXVolumeChanged = true;
		SFXAudioSource.volume = sliderValue;
		SFXVolume = sliderValue;
		
	}
	
		
	
	public void ENEMYSMASH(GameObject TheEnemy)
	{
		if (PlayerStats.SoundFXEnabled)
		{
			TheEnemy.GetComponent<AudioSource>().PlayOneShot(SmashedBallClip, SFXVolume);
		}
		
	}







	public void ICEMELT()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(Melt, SFXVolume);
		}

	}






	public void WOOSH()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(Woosh, SFXVolume);
		}

	}








	public void NOM()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(MunchSound, SFXVolume);
		}

	}






	public void SHARK()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(SharkSpotted, SFXVolume);
		}

	}






	public void SPLASH()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(SplashClip, SFXVolume);
		}

	}




	public void OTHER()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(OtherCollectable, SFXVolume);
		}

	}






	public void PORTAL()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(PortalNoiseClip, SFXVolume);
		}

	}




	public void CRACK1()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(CrackedBallClip1, SFXVolume);
		}

	}





	public void CRACK2()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(CrackedBallClip2, SFXVolume);
		}

	}





	public void CRACK3()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(CrackedBallClip3, SFXVolume);
		}

	}





	public void CRACK4()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(CrackedBallClip4, SFXVolume);
		}

	}


	public void SMASH()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(SmashedBallClip, SFXVolume);
		}

	}

	public void POP()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(PoppedShieldClip, SFXVolume);
		}

	}

	public void EXPLOSION()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(ExplosionClip, SFXVolume);
		}

	}

	public void LAND()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(LandingMarbleClip, SFXVolume);
		}
		
	}
	
	public void PICKUP()
	{
		
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(ItemPickupClip, SFXVolume);
		}
		
	}
	
	
	public void SQUISH()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(SquishClip, SFXVolume);
		}
		
	}
	
	
	public void CLICK()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(ButtonClickClip, SFXVolume);
		}
		
	}	
		
	
	public void PLASTICCOLLIDE()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(PlasticCollideClip, SFXVolume);
		}
		
	}
	
	
	public void WALLCOLLIDE()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(WallCollideClip, SFXVolume);
		}
		
	}
	
	
	public void CHECKPOINT()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(CheckPointClip, SFXVolume);
		}
		
	}
	
	public void MenuForward()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(MenuForwardsClip, SFXVolume);
		}
		
	}
	
	public void MenuBackward()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(MenuBackwardsClip, SFXVolume);
		}
		
	}
	
	
	public void JUMP()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(JumpingMarbleClip, SFXVolume);
		}
		
	}
	
	
	
	public void VOID()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(SmashedBallClip, SFXVolume);
		}
		
	}
	
	
	
	public void LEVELCOMPLETE()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(LevelCompleteClip, SFXVolume);
		}
		
	}
	
	
	public void TIMERUP()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(TimerUpClip, SFXVolume);
		}
		
	}
	
	
	public void ENEMYSPOTTED()
	{
		if (PlayerStats.SoundFXEnabled)
		{
			SFXAudioSource.PlayOneShot(EnemySpottedClip, SFXVolume);
		}
		
	}
	
	

}
