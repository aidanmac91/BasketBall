/// <summary>
/// 
/// moveScriptLevel2.cs
/// Developed by Aidan McCarthy
/// Student Number 20046537
/// Assignment: Basketball
/// Issues:
/// </summary>
using UnityEngine;
using System.Collections;

public class moveScriptLevel2 : MonoBehaviour {
	string score1;
	Vector3 position;
	// Use this for initialization
	void Start () {
		score1=GameObject.Find("score1").guiText.text;
	}
	
	// Update is called once per frame
	void Update () {
		//updates position
		position.y=0;
		if(score1=="0/10")
		{
			position.x=27;
			position.z=0;

		}else if(score1=="2/10"){
			position.x=40;
			position.z=-25;
		}
		else if(score1=="4/10"){
			position.x=27;
			position.z=15;
		}
		else if(score1=="6/10"){
			position.x=27;
			position.z=-15;
		}
		else if(score1=="8/10"){
			position.x=40;
			position.z=25;
		}

		gameObject.transform.position=position;
	}
}
