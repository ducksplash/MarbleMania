using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	public float CheckPointX;
	public float CheckPointY;
	public float CheckPointZ;
	


	void Start()
	{
		
		CheckPointX = gameObject.transform.position.x;
		CheckPointY = gameObject.transform.position.y;
		CheckPointZ = gameObject.transform.position.z;
		
		
	}



    void OnTriggerEnter(Collider other)
    {

		if (other.gameObject.name.Equals("PLAYER"))
		{


			other.gameObject.GetComponent<SoundManager>().CHECKPOINT();
			Vector3 thisv3 = new Vector3(CheckPointX, CheckPointY, CheckPointZ);
			Vector3 thatv3 = new Vector3(Movement.SpawnX, Movement.SpawnY, Movement.SpawnZ);

			if (thisv3 == thatv3) return;
			other.gameObject.GetComponent<Toast>().NewToast("checkpoint");

			Movement.SpawnX = CheckPointX;
			Movement.SpawnY = CheckPointY;
			Movement.SpawnZ = CheckPointZ;
			
			Destroy(gameObject,0.1f);
		}

	}



	public static void ResetCheckpoint()
	{
		Movement.SpawnX = Movement.SpawnXorig;
		Movement.SpawnY = Movement.SpawnYorig;
		Movement.SpawnZ = Movement.SpawnZorig;
	}



	void FixedUpdate()
	{


		transform.Rotate(new Vector3(0, 10, 0) * (Time.smoothDeltaTime * 10));



	}

}
