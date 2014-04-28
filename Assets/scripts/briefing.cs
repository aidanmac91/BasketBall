/// <summary>
/// 
/// briefing.cs
/// Developed by Aidan McCarthy
/// Student Number 20046537
/// Assignment: Basketball
/// Issues:
/// </summary>
using UnityEngine;
using System.Collections;

public class briefing : MonoBehaviour {
	
	public string text = "";//string to be displayed
	public int previousLevel;//what was the previous level
	public int score;//game score
	// Use this for initialization
	void Start () {
		previousLevel=PlayerPrefs.GetInt("previousLevel");//gets previous level
		score=PlayerPrefs.GetInt("score");//gets game score
		switch(previousLevel)//which was the previous level
		{
		case 1://level 1
			text="The player needs to throws the ball and hit 10 different targets (bins). " +
				"\nThe ball needs to bounce twice before it reaches the target " +
				"\n(i.e., hit the target after the second rebound)." +
				"\n 1 point is allocated to the player every time s/he hits a target. " +
				"\nThe player avails of 10 balls.\n The maximum score for this level is 10.";
			break;
		case 2://level 2
			text="Level 2: The player avails of 5 balls and needs to \n" +
				"perform two-points shots from five different locations. " +
				"\nDrag effect needs to be considered for the airborne trajectory and rebound is authorized. " +
				"\nEach successfulshot is awarded 2 points for a maximum score of 10 points";
			break;
		case 3://level
			text="Level 3: The player needs to perform five successful\n" +
				"three-point shots (6.7 meters from the hoop), \n" +
				"each are worth three points. " +
				"\nThese shots need to be performed from three predefined locations. " +
				"\nThe trajectory of the airborne object may be subject to drag and random wind force." +
				"\nThe maximum score for this level is 15. " +
				"\nRebounds are not allowed.";
			break;
		case 4:
			text="Level 4: The player needs to perform five successful \n" +
				"three-point shots (6.7 meters from the hoop), " +
				"\neach are worth three points. " +
				"\nThese shots need to be performed from three predefined locations. " +
				"\nThe trajectory of the airborne object may be subject to drag,\n" +
				"spinning effects and random wind force." +
				"\nThe maximum score for this level is 15. " +
				"\nRebounds are not allowed.";
			break;

		case 5://final scene
			print (score);
			if(score>27)//won
			{
				text="Game Over YOU WON";
			}
			else//lost
			{
				text="GAME OVER YOU LOST";
			}

			break;
		}
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnGUI() {

		GUIStyle myStyle = new GUIStyle(GUI.skin.textField);//style
		myStyle.alignment = TextAnchor.MiddleCenter;//alignment

		text = GUI.TextArea(new Rect(130, 10, 500, 300), text, 500,myStyle);//text area

		if (GUI.Button(new Rect(350, 320, 90, 30), "Next Level"))//button
		{
			switch(previousLevel)//which level to load
		{
			case 0:
			break;
			case 1:
			Application.LoadLevel("level1");
			break;
			case 2:
				Application.LoadLevel("level2");
			break;
			case 3:
				Application.LoadLevel("level3");
			break;
			case 4:
				Application.LoadLevel("level4");
			break;
			case 5:
				Application.LoadLevel("mainMenu");
				break;

			}
		}
	}
}
