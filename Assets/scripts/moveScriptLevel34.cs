/// <summary>
/// 
/// moveScriptLevel34.cs
/// Developed by Aidan McCarthy
/// Student Number 20046537
/// Assignment: Basketball
/// Issues:
/// </summary>
using UnityEngine;
using System.Collections;

public class moveScriptLevel34 : MonoBehaviour {
	Vector3 position;
	string score1;
	// Use this for initialization
	void Start () {
		score1=GameObject.Find("score1").guiText.text;
	}
	
	// Update is called once per frame
	void Update () {
		position.y=0;
		if(score1=="0/15")
		{
			position.x=16;
			position.z=0;
			
		}else if(score1=="3/15"){
			position.x=20;
			position.z=-25;
		}
		else if(score1=="6/15"){
			position.x=20;
			position.z=25;
		}
		else if(score1=="9/15"){
			position.x=34;
			position.z=-40;
		}
		else if(score1=="12/15"){
			position.x=34;
			position.z=40;
		}
		
		gameObject.transform.position=position;
	}
}

