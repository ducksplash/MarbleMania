using UnityEngine;

public class Boat : MonoBehaviour
{

	public GameObject Player;
	public GameObject TheBoat;
	private Rigidbody PlayerRB;
	public Transform PlayerLock;
	public float BoatForce;
	public Camera MainCam;
	public Rigidbody BoatRB;
	private bool InBoat;
	public ParticleSystem Rains;
	public bool BoatIntact;
	public Vector3 BoatStartPos;
	public GameObject BoatPrefab;
	public GameObject CurrentBoat;
	public int DamageLevel;
	public GameObject DamageableVessel;
	
	
	
    void Start()
    {
		DamageLevel = 0;
		BoatStartPos = transform.position;
		BoatIntact = true;
		
		PlayerRB = Player.GetComponent<Rigidbody>();
		InBoat = false;
		
		Rains = TheBoat.transform.Find("rains").GetComponent<ParticleSystem>();
		PlayerLock = TheBoat.transform.Find("seat");
		
    }
	
	
	
	
void OnTriggerEnter(Collider other)
	{
		
		
	if (!InBoat && BoatIntact)
	{
		
		
		if (other.gameObject.name.Contains("PLAYER"))
		{
			Debug.Log("grab player");
			PlayerStats.STOP = true;
			PlayerRB.velocity = Vector3.zero;
			PlayerRB.isKinematic = true;
			PlayerRB.useGravity = false;
			Player.transform.parent = TheBoat.transform;
			Rains.Play();	
			Player.transform.position = PlayerLock.position;			
			InBoat = true;
		}
		
		
				
		// if (other.gameObject.name.Contains("cannonball"))
		// {
			// Debug.Log("cannonball");
		// }
		
	}	
}

    void OnCollisionEnter(Collision collision)
    {
		Debug.Log(gameObject.name);
		Debug.Log(collision.gameObject.name);
		if (collision.gameObject.name.Contains("cannonball"))
		{
			Debug.Log("cannonball");
			DamageLevel = 1;
			var dmgVesselOne = Resources.Load<Mesh>("boatmeshes/dasboot-dmg1");
			
			DamageableVessel.GetComponent<MeshFilter>().mesh = dmgVesselOne;
			//var meshImageZero = Resources.Load<Texture>("playermeshimages/default");
			
			
			
			
		}
		
	}
	

public void ExitBoat()
{
	PlayerStats.STOP = false;
	PlayerRB.isKinematic = false;
	PlayerRB.useGravity = true;
	Player.transform.parent = null;
	Rains.Stop();				
	InBoat = false;	
	Debug.Log("all this happened");
}





void MoveBoat() 
{
	
	if (InBoat)
	{
	
		if (Input.GetKey(PlayerStats.InputForUP) || Input.GetKey(KeyCode.W))
		{
			var moveForce = MainCam.transform.forward * (PlayerStats.BallSpeed/2);
			BoatRB.AddForce(moveForce);
		}
		
		
		
		if (Input.GetKey(PlayerStats.InputForDOWN) || Input.GetKey(KeyCode.S))
		{
			var moveForce = MainCam.transform.forward * (PlayerStats.BallSpeed/2);		
			BoatRB.AddForce(-moveForce);
		}

		
	}
	
	
}


	void FixedUpdate()
	{
		
		
		MoveBoat();
		
	}


    void LateUpdate()
    {
		
		if (InBoat)
		{
			Vector3 upAxis = Vector3.up;
			
			TheBoat.transform.rotation = Quaternion.LookRotation(Vector3.Cross(upAxis, Vector3.Cross(upAxis, MainCam.transform.right)), upAxis);
		}
		
    }
	
	public void DestroyBoat()
	{
		Destroy(TheBoat);
		Invoke("RespawnBoat",1);
		
	}
	
	void RespawnBoat()
	{
		CurrentBoat = Instantiate(BoatPrefab, BoatStartPos, Quaternion.identity);
		CurrentBoat.transform.parent = transform;
		TheBoat = CurrentBoat;
		Rains = TheBoat.transform.Find("rains").GetComponent<ParticleSystem>();
		BoatRB = TheBoat.GetComponent<Rigidbody>();
		PlayerLock = TheBoat.transform.Find("seat");
		
	}
	

}
