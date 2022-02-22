using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EruptingVolcano : MonoBehaviour
{
	
	public float ballForce;
    Rigidbody ballRB;
	private bool IsInRange = false;
	public GameObject player;
	private GameObject VolcanicRock;
	private GameObject ActionRock;
	private bool DebounceRock = false;
	public GameObject[] TheseRocks;
	
	
	
	

	
	
    
    private void Update()
    {

		if (Input.GetKeyUp(KeyCode.M))
		{
			CreateAestheticRock();
		}


    if (IsInRange && !DebounceRock)
	{
		
		
		StartCoroutine(CreateAestheticRockSlowly());
		DebounceRock = true;
		
	}
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
	


	
	public IEnumerator CreateAestheticRockSlowly()
	{
		yield return new WaitForSeconds(0.5f);
		CreateAestheticRock();
		DebounceRock = false;
	}



	public void CreateAestheticRock()
	{
		
		var RandomNumberForX = Random.Range(-5000f,8000f);
		var RandomNumberForZ = Random.Range(-5000f,8000f);
		
		var TheRockRandomNumber = Random.Range(0,6);
		
		
		
		VolcanicRock = Instantiate(TheseRocks[TheRockRandomNumber], transform.position, Quaternion.identity);
		//VolcanicRock.transform.parent = gameObject.transform;
		VolcanicRock.name = "VolcanicRock."+Random.Range(1,999999).ToString();
		VolcanicRock.GetComponent<VolcanicRock>().AestheticRock = true;
		VolcanicRock.GetComponent<Rigidbody>().AddForce(0+RandomNumberForX, ballForce, 0+RandomNumberForZ);	



		
	}


	
	
    
}
