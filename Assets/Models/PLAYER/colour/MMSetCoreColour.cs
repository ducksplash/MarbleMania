
using UnityEngine;
using UnityEngine.UI;

public class MMSetCoreColour : MonoBehaviour
{
    public Material CoreMaterial;

    public GameObject theCoreColorPickerObject;
	private CoreColorPicker thisCoreColorPicker;
	
	public GameObject UIObject;

    private void Start()
    {

		// fill player with middlebit

		UIObject.GetComponent<GameStart>().DoSwapMesh(PlayerStats.PlayerMiddleBit);



        var coltmp = new Color(0, 0, 0);
        if (PlayerPrefs.GetString("CoreColor") != "")
        {
            ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("CoreColor"), out coltmp);
        }
        else
        {
            coltmp = PlayerStats.PlayerMiddleColor;
        }




        CoreMaterial.SetColor("_Color", coltmp);		
        CoreMaterial.SetColor("_EmissionColor", coltmp);
		
		thisCoreColorPicker = theCoreColorPickerObject.GetComponent<CoreColorPicker>();
		
        thisCoreColorPicker.onColorChanged += OnColorChanged;
    }

    public void OnColorChanged(Color c)
    {
        CoreMaterial.SetColor("_Color", c);		
        CoreMaterial.SetColor("_EmissionColor", c * 6f);
        string colorString = ColorUtility.ToHtmlStringRGB(c);
        PlayerPrefs.SetString("CoreColor", colorString);

        PlayerStats.PlayerMiddleColor = c;
    }

    private void OnDestroy()
    {
        if (thisCoreColorPicker != null)
            thisCoreColorPicker.onColorChanged -= OnColorChanged;
    }
}