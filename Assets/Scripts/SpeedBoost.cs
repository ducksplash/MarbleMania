using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{

	public GameObject SpeedBoosterPrefab;
	public GameObject InitialSpeedBooster;
	public GameObject InstantiatedSpeedBooster;
	private bool IsFirstRun;

	public GameObject SpeedBoosterPip1;
	public GameObject SpeedBoosterPip2;
	public GameObject SpeedBoosterPip3;
	

	public Material SpeedBoosterBright;
	public Material SpeedBoosterDark;
	
	private bool DoColourChange;
	private bool ColoursChanging;

	void Start()
	{
		
		IsFirstRun = true;
		DoColourChange = true;
		ColoursChanging = false;
		
	}
	
	
	void Update()
	{
		
		if (DoColourChange)
		{
			if (!ColoursChanging)
			{
				StartCoroutine(ChangeTheColours());
			}
			
		}
		
		
	}

	IEnumerator ChangeTheColours()
	{

		var DesignatedObject = InitialSpeedBooster;

		if (IsFirstRun)
		{
			DesignatedObject = InitialSpeedBooster;
		}
		else
		{
			DesignatedObject = InstantiatedSpeedBooster;
		}

		var State = 1;
		ColoursChanging = true;
		yield return new WaitForSeconds(0.2f);		
		
		if (State == 1 && DoColourChange && ColoursChanging)
		{
		DesignatedObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = SpeedBoosterBright;
		DesignatedObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = SpeedBoosterDark;
		DesignatedObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = SpeedBoosterDark;
		
		State = 2;
		}
		
		yield return new WaitForSeconds(0.2f);	
		
		if (State == 2 && DoColourChange && ColoursChanging)
		{
		DesignatedObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = SpeedBoosterDark;
		DesignatedObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = SpeedBoosterBright;
		DesignatedObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = SpeedBoosterDark;
		
		State = 3;
		}
		
		yield return new WaitForSeconds(0.2f);
		
		
		if (State == 3 && DoColourChange && ColoursChanging)
		{
		DesignatedObject.transform.GetChild(2).GetComponent<MeshRenderer>().material = SpeedBoosterDark;
		DesignatedObject.transform.GetChild(1).GetComponent<MeshRenderer>().material = SpeedBoosterDark;
		DesignatedObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = SpeedBoosterBright;
		
		State = 1;
		}
		
		ColoursChanging = false;
		
		
		
		
	}

    void OnTriggerEnter(Collider other)
    {

		if (other.gameObject.name.Equals("PLAYER"))
		{

			if (other.gameObject.name.Contains("PLAYER"))
			{
				other.gameObject.GetComponent<Rigidbody>().velocity = 100 * (other.gameObject.GetComponent<Rigidbody>().velocity.normalized);
				
				
				if (IsFirstRun)
				{
					IsFirstRun = false;
					DoColourChange = false;
					Destroy(InitialSpeedBooster,0.1f);
					StartCoroutine(ReplenishSpeedBooster());
				}
				else
				{
					DoColourChange = false;
					Destroy(InstantiatedSpeedBooster,0.1f);
					StartCoroutine(ReplenishSpeedBooster());
				}				
				
				
			}
			

		}

	}


	public IEnumerator ReplenishSpeedBooster()
	{
		
		yield return new WaitForSeconds(3f);
		
		InstantiatedSpeedBooster = Instantiate(SpeedBoosterPrefab, transform.position, transform.rotation);
		
		DoColourChange = true;
		
		

	}

}
