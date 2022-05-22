using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class WaterWorks : MonoBehaviour
{
 
	public GameObject Player;
	private Rigidbody PlayerRB;
	
	public Volume WaterVolume;
	public LensDistortion WaterEffect;
	public float minimumDistortion;
    public float maximumDistortion;
	static float t = 0.0f;
	
	
	
	void Start()
	{
		WaterVolume.profile.TryGet(out WaterEffect);
		
		
		PlayerRB = Player.GetComponent<Rigidbody>();
		
		
	}
 
 
 
	void Update()
	{
		
		//WaterEffect.intensity.value = LDValue;
		
		
		
        WaterEffect.intensity.value = Mathf.Lerp(minimumDistortion, maximumDistortion, t);

        // .. and increase the t interpolater
        t += 1f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximumDistortion;
            maximumDistortion = minimumDistortion;
            minimumDistortion = temp;
            t = 0.0f;
        }
		
		
		
		
		
		
	}
 
 
 
	void OnTriggerEnter(Collider other)
	{
		
		if (other.transform.name.Contains("PLAYER"))
		{
			
			PlayerStats.InWater = true;
			other.GetComponent<Rigidbody>();
				
		}
	}
 
 
	void OnTriggerExit(Collider other)
	{
		if (other.transform.name.Contains("PLAYER"))
		{
			PlayerStats.InWater = false;
		}
		
	}
 
 
 
 
}
