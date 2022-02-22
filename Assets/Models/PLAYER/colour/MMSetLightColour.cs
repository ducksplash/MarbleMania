
using UnityEngine;
using UnityEngine.UI;

public class MMSetLightColour : MonoBehaviour
{
    public Light previewGraphic;

    public GameObject theLightColorPicker;
	private LightColorPicker thisLightColorPicker;

    private void Start()
    {
		previewGraphic.color = PlayerStats.PlayerColor;
        //previewGraphic.color = colorPicker.color;
		thisLightColorPicker = theLightColorPicker.GetComponent<LightColorPicker>();
		
        thisLightColorPicker.onColorChanged += OnColorChanged;
    }

    public void OnColorChanged(Color c)
    {
        previewGraphic.color = c;
		PlayerStats.PlayerColor = c;
    }

    private void OnDestroy()
    {
        if (thisLightColorPicker != null)
            thisLightColorPicker.onColorChanged -= OnColorChanged;
    }
}