using UnityEngine;

public class BoatCollision : MonoBehaviour
{

	public int DamageLevel;
	private Mesh DMG1Mesh;
	private Mesh DMG2Mesh;



	void Start()
    {
		DamageLevel = 0;
		DMG1Mesh = Resources.Load<Mesh>("boatmeshes/dasboot-dmg1");
		DMG2Mesh = Resources.Load<Mesh>("boatmeshes/dasboot-dmg2");


	}




	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.name.Contains("cannonball") || other.gameObject.name.Contains("IceRock"))
		{

			DamageLevel += 1;

			if (DamageLevel == 1)
			{
				gameObject.transform.GetChild(0).GetComponent<MeshFilter>().mesh = DMG1Mesh;
			}



			if (DamageLevel == 2)
			{
				gameObject.transform.GetChild(0).GetComponent<MeshFilter>().mesh = DMG2Mesh;
			}




			if (DamageLevel > 2)
			{
				DamageLevel = 0;
				gameObject.transform.parent.GetComponent<Boat>().ExitBoat();

				// don't try to do things after this line, future me.
				gameObject.transform.parent.GetComponent<Boat>().DestroyBoat();
			}
		}

		if (other.gameObject.name.ToLower().Contains("portal"))
		{

		}
	}



}
