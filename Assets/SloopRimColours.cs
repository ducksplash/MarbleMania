using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SloopRimColours : MonoBehaviour
{

    [SerializeField] Renderer randerObject;
    [SerializeField] float seconds;
    float timer = 0.0f;
    bool blueToGreen = true;
    bool greenToRed = false;
    bool redToBlue = false;

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime / seconds;

        if (blueToGreen == true && greenToRed == false && redToBlue == false)
        {

            var col = Color.Lerp(Color.blue, Color.green, timer);

            randerObject.material.SetColor("_EmissionColor", col * 1f);
            randerObject.material.SetColor("_Color", col);
            randerObject.material.EnableKeyword("_EMISSION");


            if (timer >= 1.0f)
            {
                timer = 0.0f;
                blueToGreen = false;
                greenToRed = true;
            }
        }

        if (greenToRed == true && blueToGreen == false && redToBlue == false)
        {

            var col = Color.Lerp(Color.green, Color.red, timer);

            randerObject.material.SetColor("_EmissionColor", col * 1f);
            randerObject.material.SetColor("_Color", col);
            randerObject.material.EnableKeyword("_EMISSION");



            if (timer >= 1.0f)
            {
                timer = 0.0f;
                greenToRed = false;
                redToBlue = true;
            }
        }

        if (redToBlue == true && greenToRed == false && blueToGreen == false)
        {

            var col = Color.Lerp(Color.red, Color.blue, timer);

            randerObject.material.SetColor("_EmissionColor", col * 1f);
            randerObject.material.SetColor("_Color", col);
            randerObject.material.EnableKeyword("_EMISSION");


            if (timer >= 1.0f)
            {
                timer = 0.0f;
                redToBlue = false;
                blueToGreen = true;
            }
        }
    }
}
