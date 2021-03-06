﻿/// <summary>
/// 
/// level4Game.cs
/// Developed by Aidan McCarthy
/// Student Number 20046537
/// Assignment: Basketball
/// Issues:
/// </summary>
using UnityEngine;
using System.Collections;

public class level4Game : MonoBehaviour {
	SpinProjectile basketBall;
	 float time = 0.0f;
	 double mass;
	 double area;
	 double cd;
	 double density;
	Vector3 shootingDirection;
	Vector3 initialVelocity;
	 bool isFiring;
	float power;
	public GameObject target;
	public GameObject ball;
	float windX;
	float windY;
	float radius;
	float omega;
	float rx;
	float ry;
	float rz;
	
	public AudioClip cheer;//cheering

	
	int score=0;
	int shootsTaken;
	GameObject score1;
	GameObject shotsTaken;
	int previousLevel;
	int currentScore;
	
	void Start () 
	{
		mass = 20.0f;
		area = .2f;
		cd = .4f;
		density = 1.2f;
		rz=0.7f;
		omega=50f;
		radius=0.5f;
			previousLevel=PlayerPrefs.GetInt("previousLevel");
		currentScore=PlayerPrefs.GetInt("currentScore");
		score1=GameObject.Find("score1");
		shotsTaken=GameObject.Find("shots1");


	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			isFiring = true;
			shootingDirection = GameObject.Find("Main Camera").transform.forward;
			initialVelocity = shootingDirection*(power);
			windX=Random.Range(0,20);
			windY=Random.Range(0,20);
			basketBall = new SpinProjectile(gameObject.transform.position.x, gameObject.transform.position.z, gameObject.transform.position.y,
			                                initialVelocity.x, initialVelocity.z,initialVelocity.y, 0.0, mass, area, density, cd,windX,windY,rx,ry,rz,omega,radius);
			gameObject.transform.position = new Vector3((float)basketBall.GetX(), (float)basketBall.GetZ(), (float)basketBall.GetY());
		}
		if(isFiring){
			time+=Time.deltaTime/100;
			basketBall.UpdateLocationAndVelocity(time);	
			
			if (basketBall.GetZ() >= -1)
			{
				gameObject.transform.position = new Vector3((float)basketBall.GetX(), (float)basketBall.GetZ(), (float)basketBall.GetY());
			}
			else{
				if(distance(ball.transform.position,target.transform.position)<1)
				{
					audio.PlayOneShot(cheer);//sound
					score+=3;//increases
				}
				isFiring=false;
				time=0;
				resetBall();
			}
			if(shootsTaken==5)
			{
				previousLevel++;
				PlayerPrefs.SetInt("currentScore",currentScore+score);
				PlayerPrefs.SetInt("previousLevel",previousLevel);
				PlayerPrefs.Save();
				Application.LoadLevel("briefing");
			}
		}
	}
	
	void resetBall(){
		print ("hit");
		shootsTaken++;
		shotsTaken.guiText.text=(""+(5-shootsTaken));
		PlayerPrefs.SetInt("shots",shootsTaken);
		score1.guiText.text=(score+"/15");
		basketBall = null;
		transform.parent = Camera.main.transform;
		transform.position = Camera.main.transform.TransformPoint(Vector3.forward * 2);
	}
	
	float distance(Vector3 v1,Vector3 v2)
	{
		float x1=v1.x;
		float x2=v2.x;
		float y1=v1.y;
		float y2=v2.y;
		float z1=v1.z;
		float z2=v2.z;
		float part1=Mathf.Pow(x2-x1,2);//*(x2-x1);
		float part2=Mathf.Pow(y2-y1,2);
		float part3=Mathf.Pow(z2-z1,2);
		
		float distance=Mathf.Sqrt(part1+part2+part3);
		return distance;
		
	}
	
	void OnGUI() {
		
		power = GUI.HorizontalSlider(new Rect(125, 318, 100, 30), power, 0.0F, 25.0F);
		rx = GUI.HorizontalSlider(new Rect(125, 338, 100, 30), power, 0.0F, 1.0F);
		ry = GUI.HorizontalSlider(new Rect(125, 358, 100, 30), power, 0.0F, 1.0F);
	}
}