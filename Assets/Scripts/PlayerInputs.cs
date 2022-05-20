using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;




public class PlayerInputs : MonoBehaviour
{
	
	private Dictionary<KeyCode, string> InputDict;

	public TextMeshProUGUI ForwardText;
	public TextMeshProUGUI BackwardText;
	public TextMeshProUGUI LeftText;
	public TextMeshProUGUI RightText;
	public TextMeshProUGUI JumpText;
	public TextMeshProUGUI PauseText;
	public TextMeshProUGUI RearviewText;
	public TextMeshProUGUI RestartText;



    void Awake()
    {
		

		
		
		
    }

	public string FriendlyKeyName(KeyCode ThisKey)
	{

		string str = ThisKey.ToString();
		//var nuString = str.Substring(str.IndexOf('.') + 1);
		return str;

	}

    void Start()
    {
			
		ForwardText.text = FriendlyKeyName(PlayerStats.InputForUP);
			
			
		
		Dictionary<int,KeyCode> InputDict = new Dictionary<int,KeyCode>()
		{
			{1,KeyCode.UpArrow},
			{2,KeyCode.DownArrow},
			{3,KeyCode.LeftArrow},
			{4,KeyCode.RightArrow},
			{5,KeyCode.A},
			{6,KeyCode.B},
			{7,KeyCode.C},
			{8,KeyCode.D},
			{9,KeyCode.E},
			{10,KeyCode.F},
			{11,KeyCode.G},
			{12,KeyCode.H},
			{13,KeyCode.I},
			{14,KeyCode.J},
			{15,KeyCode.K},
			{16,KeyCode.L},
			{17,KeyCode.M},
			{18,KeyCode.N},
			{19,KeyCode.O},
			{20,KeyCode.P},
			{21,KeyCode.Q},
			{22,KeyCode.R},
			{23,KeyCode.S},
			{24,KeyCode.T},
			{25,KeyCode.U},
			{26,KeyCode.V},
			{27,KeyCode.W},
			{28,KeyCode.X},
			{29,KeyCode.Y},
			{30,KeyCode.Z},
			{31,KeyCode.Keypad0},
			{32,KeyCode.Keypad1},
			{33,KeyCode.Keypad2},
			{34,KeyCode.Keypad3},
			{35,KeyCode.Keypad4},
			{36,KeyCode.Keypad5},
			{37,KeyCode.Keypad6},
			{38,KeyCode.Keypad7},
			{39,KeyCode.Keypad8},
			{40,KeyCode.Keypad9},
			{41,KeyCode.Alpha0},
			{42,KeyCode.Alpha1},
			{43,KeyCode.Alpha2},
			{44,KeyCode.Alpha3},
			{45,KeyCode.Alpha4},
			{46,KeyCode.Alpha5},
			{47,KeyCode.Alpha6},
			{48,KeyCode.Alpha7},
			{49,KeyCode.Alpha8},
			{50,KeyCode.Alpha9},
			{51,KeyCode.RightAlt},
			{52,KeyCode.LeftAlt},
			{53,KeyCode.LeftControl},
			{54,KeyCode.RightControl},

		};	
		
		

    }

}
