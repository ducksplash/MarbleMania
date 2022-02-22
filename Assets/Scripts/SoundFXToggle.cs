using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
 
public class SoundFXToggle : MonoBehaviour
{
   public Toggle myToggle;
   
   
   public void ValueChanged()
    {
		
    }
 
    public void ChangeToggle()
    {
        myToggle.isOn = !myToggle.isOn;
    }
 
}