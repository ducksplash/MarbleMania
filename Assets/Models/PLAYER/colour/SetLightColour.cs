
using UnityEngine;
using UnityEngine.UI;

public class SetLightColour : MonoBehaviour
{
    public Light previewGraphic;

    public GameObject theLightColorPicker;
	private LightColorPicker thisLightColorPicker;

    private void Start()
    {

        var coltmp = new Color(0, 0, 0);
        if (PlayerPrefs.GetString("CoreColor") != "")
        {
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("CoreColor"), out coltmp);
            Debug.Log("stored in prefs");
        }
        else
        {
            coltmp = PlayerStats.PlayerMiddleColor;
        }


		previewGraphic.color = coltmp;

        thisLightColorPicker = theLightColorPicker.GetComponent<LightColorPicker>();
		
        thisLightColorPicker.onColorChanged += OnColorChanged;
    }

    public void OnColorChanged(Color c)
    {
        previewGraphic.color = c;
		PlayerStats.PlayerColor = c;
        string colorString = ColorUtility.ToHtmlStringRGB(c);

        PlayerPrefs.SetString("CoreColor", colorString);


    }

    private void OnDestroy()
    {
        if (thisLightColorPicker != null)
            thisLightColorPicker.onColorChanged -= OnColorChanged;
    }
}