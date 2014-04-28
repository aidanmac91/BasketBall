/// <summary>
/// 
/// mainMenu.cs
/// Developed by Aidan McCarthy
/// Student Number 20046537
/// Assignment: Basketball
/// Issues:
/// </summary>
using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	//public string text = "";
	public int previousLevel;
	// Use this for initialization
	void Start () {
		//resets 
		PlayerPrefs.SetInt("score",0);
		PlayerPrefs.SetInt("shots",0);
		PlayerPrefs.SetInt("previousLevel",0);
		PlayerPrefs.SetInt("currentScore", 0);
		previousLevel=PlayerPrefs.GetInt("previousLevel");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI() {
		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);
		myStyle.alignment = TextAnchor.MiddleCenter;
		
		if (GUI.Button(new Rect(320, 120, 90, 30), "Next Level"))
		{
			previousLevel++;
			PlayerPrefs.SetInt("previousLevel",previousLevel);
			PlayerPrefs.Save();
			Application.LoadLevel("briefing");
		}

		if (GUI.Button(new Rect(320, 170, 90, 30), "Quit"))
		{
			Application.Quit();
		}
	}
}
