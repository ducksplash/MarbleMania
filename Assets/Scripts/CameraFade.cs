using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    // get image
    public Image CameraBlackoutPanel;
    public Color bgCol;

    void Start()
    {


        
        StartCoroutine(DoFadeIn(0.6f,0));
        
        


    }
    
    public IEnumerator DoFadeOut(float fadeTime)
    {
        var colorAlpha = 0f;
        CameraBlackoutPanel.enabled = true;
        
        while (colorAlpha < 1.0)
        {
            yield return new WaitForSeconds(fadeTime/20);
			
            colorAlpha += 0.05f;

            CameraBlackoutPanel.color = new Color(0,0,0,colorAlpha);
        }
        
    }
	
	

    public IEnumerator DoFlatBlack()
    {
		CameraBlackoutPanel.enabled = true;
		CameraBlackoutPanel.color = new Color(0,0,0,1);
        yield return new WaitForSeconds(0);
    }


    public IEnumerator DoFadeIn(float fadeTime, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Color c = CameraBlackoutPanel.color;
		
        var colorAlpha = 1f;
        while (colorAlpha > 0)
        {
            yield return new WaitForSeconds(fadeTime/10);
			
            colorAlpha -= 0.1f;

            CameraBlackoutPanel.color = new Color(0,0,0,colorAlpha);

        }
        
        CameraBlackoutPanel.enabled = false;
    }
    
    public IEnumerator FadeInFadeOut(float fadeTime)
    {
        var colorAlpha = 0f;
        CameraBlackoutPanel.enabled = true;
        
        while (colorAlpha < 1.0)
        {
            yield return new WaitForSeconds(fadeTime/20);
			
            colorAlpha += 0.05f;

            CameraBlackoutPanel.color = new Color(0,0,0,colorAlpha);
        }

        StartCoroutine(DoFadeIn(0.8f, 1f));
    }

}
