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
	
    
    private void FixedUpdate()
    {



	if (IsInRange && !DebounceRock)
	{

		
			StartCoroutine(CreateActionRockSlowly());
			DebounceRock = true;	
			
		
	}



	}
	
	
	public IEnumerator CreateActionRockSlowly()
	{
		
		
		yield return new WaitForSeconds(2.5f);
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
		
		

			RandomNumberForX = Random.Range(-25f,25f);
			RandomNumberForZ = Random.Range(-25f,25f);
			RockScaleMultiplier = 2f;
		
		
		var RandomPosition = new Vector3(transform.position.x+RandomNumberForX,transform.position.y,transform.position.z+RandomNumberForZ);
		
		ActionRock = Instantiate(ActionRockPrefab, RandomPosition, Quaternion.identity);

		ActionRock.GetComponent<FallingIceRock>().AestheticRock = false;
		ActionRock.name = "IceRock."+Random.Range(1,999999).ToString();	
		ActionRock.transform.localScale = ActionRock.transform.localScale * RockScaleMultiplier;	
		
	}


	
	
    
}
