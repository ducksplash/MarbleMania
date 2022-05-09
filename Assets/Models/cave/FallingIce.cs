using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallingIce : MonoBehaviour
{
	
	public float ballForce;
    private bool IsInRange = false;
	public GameObject player;
	public GameObject ActionRockPrefab;
    private GameObject ActionRock;
    private bool DebounceRock = false;
	
    
    private void Update()
    {



	if (IsInRange && !DebounceRock)
	{
		if (gameObject.name.Contains("IceLauncher"))
		{
		
			StartCoroutine(CreateActionRockQuickly());
			DebounceRock = true;
		}
		else
		{
		
			StartCoroutine(CreateActionRockSlowly());
			DebounceRock = true;	
			
		}
	}



	}
	
	
	public IEnumerator CreateActionRockSlowly()
	{
		
		
		yield return new WaitForSeconds(0.25f);
		CreateActionRock();
		DebounceRock = false;
		
		
		
	}
	
	public IEnumerator CreateActionRockQuickly()
	{
		
		
		yield return new WaitForSeconds(0.05f);
		CreateActionRock();
		DebounceRock = false;
		
		
		
	}
    
	
    void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name.Contains("PLAYER"))
		{
			IsInRange = true;
		}
	}
    
	
    void OnTriggerExit(Collider other)
    {
		if (other.gameObject.name.Contains("PLAYER"))
		{
			IsInRange = false;
		}
	}
	
	

	public void CreateActionRock()
	{			
	
		var RandomNumberForX = 0f;
		var RandomNumberForZ = 0f;
		var RockScaleMultiplier = 1f;
		
		
		if (gameObject.name.Contains("IceLauncher"))
		{
			RandomNumberForX = Random.Range(-150f,150f);
			RandomNumberForZ = Random.Range(-150f,150f);
			RockScaleMultiplier = 4f;
			
		}
		else
		{
			RandomNumberForX = Random.Range(-25f,25f);
			RandomNumberForZ = Random.Range(-25f,25f);
			RockScaleMultiplier = 1f;
		}
		
		var RandomPosition = new Vector3(transform.position.x+RandomNumberForX,transform.position.y,transform.position.z+RandomNumberForZ);
		
		ActionRock = Instantiate(ActionRockPrefab, RandomPosition, Quaternion.identity);

		ActionRock.GetComponent<FallingIceRock>().AestheticRock = false;
		ActionRock.name = "IceRock."+Random.Range(1,999999).ToString();	
		ActionRock.transform.localScale = ActionRock.transform.localScale * RockScaleMultiplier;	
		
	}


	
	
    
}
