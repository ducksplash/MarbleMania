using System.Collections;
using UnityEngine;
 
 
public class Fan : MonoBehaviour
{
	public Transform FanBlades;
	public Animator Fanimator;
	public GameObject Player;
	private Transform PlayerTransform;
	public GameObject TheFan;
	public bool FanActivated;
	public Material FanButtonREDMaterial;
	public Material FanButtonBLACKMaterial;
	private Rigidbody rb;
	private float FanDirection;
    int DetectionDistance = 16;
	private float forwardsForce = 40f;
	private Fan _fan;


	void Start()
	{
		_fan = gameObject.GetComponentInChildren<Fan>();

		PlayerTransform = Player.transform;
		rb = Player.GetComponent<Rigidbody>();
		
		FanDirection = TheFan.transform.eulerAngles.y;
		
	}
	
	
	
	void Update()
	{
		
		if (FanActivated)
		{
			
         if (Vector3.Distance(TheFan.transform.position, PlayerTransform.position) < DetectionDistance)
         {	
			FanBlades.transform.Rotate (new Vector3 (200, 0, 0) * (Time.smoothDeltaTime * 7));
			GaleForce();
			
		 }
			
			
		}
		
	}
	
	
	
	
	
	IEnumerator FanimateUP()
	{
		
		Fanimator.SetTrigger("Active");

		yield return new WaitForSeconds(2);
		
	}
	
	
	IEnumerator FanimateDOWN()
	{
		
		Fanimator.SetTrigger("Down");

		yield return new WaitForSeconds(2);
				
		Fanimator.SetTrigger("Idle");
		
		
	}
	
	
	
	
	
	
	
	void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.name.Contains("PLAYER") || other.gameObject.name.Contains("shield") )
		{

			if (gameObject.name.Contains("FANBUTTON"))
			{
				
				if (!FanActivated)
				{
					
					FanActivated = true;
					gameObject.GetComponent<MeshRenderer>().material = FanButtonREDMaterial;
					
					Player.GetComponent<SoundManager>().CLICK();
					StartCoroutine(FanimateUP());
					
					StartCoroutine(StopFans(other.gameObject));					
					
					
				}
			}
		}
	
	}
		
		
		public IEnumerator StopFans(GameObject ThePlayer)
		{
			yield return new WaitForSeconds(3);
			FanActivated = false;
			gameObject.GetComponent<MeshRenderer>().material = FanButtonBLACKMaterial;
					
			StartCoroutine(FanimateDOWN());
			
		}
		
		
		
		
		
		
		
		
		
		public void GaleForce()
		{
			
			if (_fan.FanActivated)
			{
				if (FanDirection.ToString().Contains("180"))
				{
					rb.AddForce(-forwardsForce, 0, 0);	
				}
				else
				{
					rb.AddForce(forwardsForce, 0, 0);	
				}
			}
		}
	
}
