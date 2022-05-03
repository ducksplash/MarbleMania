using UnityEngine;
using System.Collections.Generic;

public class LightFlickerEffect : MonoBehaviour {
	
    public new Light light;
    private Material[] theLightMats;
	
    public float minIntensity = 0f;
	
    public float maxIntensity = 0.2f;
	
    public int smoothing = 5;

    Queue<float> smoothQueue;
    float lastSum = 0;

    public void Reset() {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start() {
		
		light = gameObject.GetComponent<Light>();
		
         smoothQueue = new Queue<float>(smoothing);
    }

    void Update()
	{



			while (smoothQueue.Count >= smoothing) {
				lastSum -= smoothQueue.Dequeue();
			}

			var thisLightParent = light.transform.parent.gameObject;
				
			theLightMats = thisLightParent.GetComponent<Renderer>().materials;


			var litLiteCol = light.color;

			float newVal = Random.Range(minIntensity, maxIntensity);
			smoothQueue.Enqueue(newVal);
			lastSum += newVal;

			light.intensity = lastSum / (float)smoothQueue.Count;
			
			for (int i = 0; i < theLightMats.Length; i++)
			{
			
				if (theLightMats[i].name.ToLower().Contains("bulb") || theLightMats[i].name.ToLower().Contains("tube"))
				{
					theLightMats[i].SetColor("_EmissionColor", litLiteCol * ((lastSum / (float)smoothQueue.Count) / 16));
					theLightMats[i].SetColor("_Color", litLiteCol);
				}
			}
		
		
		
		
    }

}