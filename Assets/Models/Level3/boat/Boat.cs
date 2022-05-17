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
	public AudioSource RainSound;
	public bool BoatIntact;
	public Vector3 BoatStartPos;
	public GameObject BoatPrefab;
	public GameObject CurrentBoat;
	
    void Start()
    {
		BoatStartPos = transform.position;
		
		PlayerRB = Player.GetComponent<Rigidbody>();
		InBoat = false;

		Rains = TheBoat.transform.Find("rains").GetComponent<ParticleSystem>();
		RainSound = TheBoat.transform.Find("rains").GetComponent<AudioSource>();
		PlayerLock = TheBoat.transform.Find("seat");
    }
	
	
	
	
void OnTriggerEnter(Collider other)
	{


		if (!InBoat && !PlayerStats.DEAD)
		{

			if (other.gameObject.name.Contains("PLAYER"))
			{
				Debug.Log("grab player");
				PlayerStats.STOP = true;
				PlayerRB.velocity = Vector3.zero;
				PlayerRB.isKinematic = true;
				RainSound.Play();
				PlayerRB.useGravity = false;
				Player.transform.parent = TheBoat.transform;
				Rains.Play();
				Player.transform.position = PlayerLock.position;
				InBoat = true;
			}
		}

		if (InBoat)
		{

		}


	}

    void OnCollisionEnter(Collision collision)
    {
		if (collision.gameObject.name.Contains("cannonball"))
		{
			Debug.Log("cannon ball");

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
	RainSound.Stop();
	Debug.Log("all this happened");
	}


	public void DestroyBoat()
	{
		Destroy(TheBoat);
		Invoke("RespawnBoat", 1);

	}

	public void RespawnBoat()
	{
		CurrentBoat = Instantiate(BoatPrefab, BoatStartPos, Quaternion.identity);
		CurrentBoat.transform.parent = transform;
		TheBoat = CurrentBoat;
		Rains = TheBoat.transform.Find("rains").GetComponent<ParticleSystem>();
		RainSound = TheBoat.transform.Find("rains").GetComponent<AudioSource>();
		BoatRB = TheBoat.GetComponent<Rigidbody>();
		PlayerLock = TheBoat.transform.Find("seat");

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
	

}
