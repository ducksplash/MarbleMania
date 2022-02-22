
using UnityEngine;
using UnityEngine.UI;

public class SetCoreColour : MonoBehaviour
{
    public Material CoreMaterial;

    public GameObject theCoreColorPickerObject;
	private CoreColorPicker thisCoreColorPicker;

    private void Start()
    {

		// fill player with middlebit

		gameObject.transform.parent.parent.GetComponent<PauseMenu>().DoSwapMesh(PlayerStats.PlayerMiddleBit);
		
		
        CoreMaterial.SetColor("_Color", PlayerStats.PlayerMiddleColor);		
        CoreMaterial.SetColor("_EmissionColor", PlayerStats.PlayerMiddleColor);
		
		thisCoreColorPicker = theCoreColorPickerObject.GetComponent<CoreColorPicker>();
		
        thisCoreColorPicker.onColorChanged += OnColorChanged;
    }

    public void OnColorChanged(Color c)
    {
        CoreMaterial.SetColor("_Color", c);		
        CoreMaterial.SetColor("_EmissionColor", c * 6f);
		
		PlayerStats.PlayerMiddleColor = c;
    }

    private void OnDestroy()
    {
        if (thisCoreColorPicker != null)
            thisCoreColorPicker.onColorChanged -= OnColorChanged;
    }
}