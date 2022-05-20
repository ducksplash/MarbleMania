using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
 
public class mouseClickedName : MonoBehaviour
{
	
	void FixedUpdate()
	{
     if( Input.GetMouseButtonDown(0) )
     {
         var thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

             Debug.Log(thisButton.name);
         
     }
	}
}