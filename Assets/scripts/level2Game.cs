/// <summary>
/// 
/// level2Game.cs
/// Developed by Aidan McCarthy
/// Student Number 20046537
/// Assignment: Basketball
/// Issues:
/// </summary>
using UnityEngine;
using System.Collections;

public class level2Game : MonoBehaviour {
	DragProjectile basketBall;//ball projectile
	 float time = 0.0f;//time
	 double mass;//mass
	 double area;//area
	 double cd;//cd?
	 double density;//density
	Vector3 shootingDirection;//shooting direction
	Vector3 initialVelocity;//initial velocity
	 bool isFiring;//firing
	float power;//strength
	public GameObject target;//target
	public GameObject ball;//ball
	int score;//level score
	int shootsTaken;//number of shots
	GameObject score1;//gui
	GameObject shotsTaken;//gui
	int previousLevel;//previous level
	int currentScore;//global level
	
	public AudioClip cheer;//cheering

	void Start () 
	{
		//sets variables
		mass = 20.0f;
		area = .2f;
		cd = .4f;
		density = 1.2f;
		previousLevel=PlayerPrefs.GetInt("previousLevel");
		score1=GameObject.Find("score1");
		shotsTaken=GameObject.Find("shots1");
		currentScore=PlayerPrefs.GetInt("currentScore");
	}
	
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space)){
			isFiring = true;
			shootingDirection = GameObject.Find("Main Camera").transform.forward;
			initialVelocity = shootingDirection*(power);//sets strengths
			basketBall = new DragProjectile(gameObject.transform.position.x, gameObject.transform.position.z, gameObject.transform.position.y,
			                                initialVelocity.x, initialVelocity.z,initialVelocity.y, 0.0, mass, area, density, cd);//creates projectile
			gameObject.transform.position = new Vector3((float)basketBall.GetX(), (float)basketBall.GetZ(), (float)basketBall.GetY());
		}
		if(isFiring){
			time+=Time.deltaTime/100;//slows down time
			basketBall.UpdateLocationAndVelocity(time);	//updates position and speed
			
			if (basketBall.GetZ() >= -1)
			{
				gameObject.transform.position = new Vector3((float)basketBall.GetX(), (float)basketBall.GetZ(), (float)basketBall.GetY());
			}
			else
			{
				if(distance(ball.transform.position,target.transform.position)<1)//hits
				{
					audio.PlayOneShot(cheer);//sound
					score+=2;//increases

				}
				isFiring=false;//false
				time=0;//sets
				resetBall();//reset ball
			}
		}

		if(shootsTaken==5)//load next level
		{
			previousLevel++;
			PlayerPrefs.SetInt("currentScore",currentScore+score);
			PlayerPrefs.SetInt("previousLevel",previousLevel);
			PlayerPrefs.Save();
			Application.LoadLevel("briefing");
		}
	}

 void resetBall()
	{
		shootsTaken++;
		shotsTaken.guiText.text=(""+(5-shootsTaken));
		PlayerPrefs.SetInt("shots",shootsTaken);
		score1.guiText.text=(score+"/10");
		basketBall = null;
		gameObject.transform.parent = Camera.main.transform;
		gameObject.transform.position = Camera.main.transform.TransformPoint(Vector3.forward * 2);
	}
	
	float distance(Vector3 v1,Vector3 v2)
	{
		float x1=v1.x;
		float x2=v2.x;
		float y1=v1.y;
		float y2=v2.y;
		float z1=v1.z;
		float z2=v2.z;
		float part1=Mathf.Pow(x2-x1,2);
		float part2=Mathf.Pow(y2-y1,2);
		float part3=Mathf.Pow(z2-z1,2);
		
		float distance=Mathf.Sqrt(part1+part2+part3);
		return distance;
		
	}
	
	void OnGUI() {
		
		power = GUI.HorizontalSlider(new Rect(125, 318, 100, 30), power, 0.0F, 25.0F);
	}
}
