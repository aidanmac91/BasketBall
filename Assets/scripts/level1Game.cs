/// <summary>
/// 
/// level1Game.cs
/// Developed by Aidan McCarthy
/// Student Number 20046537
/// Assignment: Basketball
/// Issues:
/// </summary>
using UnityEngine;
using System.Collections;

public class level1Game : MonoBehaviour {


	Vector3 initialPosition;//position of ball
	Vector3 initialVelocity;//velocity of ball
	float time=0.0f;//time
	bool isFiring=false;//is ball fired
	Vector3 newVector;//vector of ball
	int numberOfBounce=0;//number of bounces
	float speedY;//speed of ball
	float e=0.8f;//e
	public GameObject target;//target
	public GameObject ball;//ball
	float timeToHitGround=0f;//time for the ball to hit the ground
	float power;//strength
	float gravity=9.81f;//gravity
	int score;//level score
	int shootsTaken;//number of shots
	GameObject score1;//gui score
	GameObject shotsTaken;//gui shots taken
	Vector3 shootingDirection;//direction of shooting
	public AudioClip bounce;//bounce sound
	public AudioClip cheer;//cheering
	int previousLevel;//what was previous level
	 int currentScore;//global score
	void Start () {

		previousLevel=PlayerPrefs.GetInt("previousLevel");//sets variable perviousLevel
		currentScore=PlayerPrefs.GetInt("currentScore");//sets variable perviousLevel
		initialPosition = ball.transform.position;//sets initialPostion
		score=0;//sets score
		score1=GameObject.Find("score1");//gets gui
		shotsTaken=GameObject.Find("shots1");//gets gui

		//randomly sets position of target
		Vector3 randomPosition=target.transform.position;
		randomPosition.x=Random.Range(-45.0f,45.0f);
		randomPosition.z=Random.Range(-45.0f,45.0f);
		target.transform.position=randomPosition;
	
	}
	
	// Update is called once per frame
	void Update () {
		//int currentScore= PlayerPrefs.GetInt("score");
		if(Input.GetKeyUp(KeyCode.Space))//space pressed
		{
			isFiring=!isFiring;//toggle
			shootingDirection = GameObject.Find("Main Camera").transform.forward;//gets direction
			initialVelocity = shootingDirection*power;//sets velocity
		}
		
		if(isFiring)//fire ball
		{
			time += Time.deltaTime;
			//sets x,y,z
			float x = (initialPosition.x)+(initialVelocity.x*time);//+ initialVelocity*time - (0.5f*friction*9.81f*time*time); 
			float y= (initialPosition.y)+(initialVelocity.y*time)+(-0.5f*gravity*time*time);
			float z=(initialPosition.z)+(initialVelocity.z*time);
			Vector3 newVector;
			//sets speedY
			speedY= -(gravity*time)+initialVelocity.y;

			//updates ball info
			newVector.x=x;
			newVector.y=y;
			newVector.z=z;
			ball.transform.position =newVector;


			//ball fired and hits ground
			if(speedY<0 && ball.transform.position.y<0)
			{
				audio.PlayOneShot(bounce);//sound
				initialVelocity.y=-speedY*e;//redirect
				time=0;//resets
				initialPosition=ball.transform.position;//resets
				numberOfBounce++;//increases
			}

			//works out when ball will hit ground
			if(numberOfBounce==2)
			{

				float a=(-0.5f*gravity);
				float b= initialVelocity.y;
				float c= initialPosition.y;

				timeToHitGround=((-b)-Mathf.Sqrt((b*b)-(4*a*c)))/(2*a);

			}

			if(time<timeToHitGround)//time is less than time to hit ground
			{
				if(numberOfBounce==2)//correct number of bounces
				{
					if(distance(ball.transform.position,target.transform.position)<0.5)
					{
						audio.PlayOneShot(cheer);//sound
						score++;//increases
						//randomly sets position of target
						Vector3 randomPosition=target.transform.position;
						randomPosition.x=Random.Range(-45.0f,45.0f);
						randomPosition.z=Random.Range(-45.0f,45.0f);
						target.transform.position=randomPosition;
						resetBall();
					}
				}
			}

			if(numberOfBounce>2)//miss
			{
				resetBall();
			}
		}

		if(shootsTaken==10)//finish level
		{
			previousLevel++;//increase previousLevel
			PlayerPrefs.SetInt("currentScore",currentScore+score);//updates global score
			PlayerPrefs.SetInt("previousLevel",previousLevel);//updates previous level
			PlayerPrefs.Save();//saves
			Application.LoadLevel("briefing");//loads new level
		}

	}


	//resets balls
	void resetBall()
	{
		shootsTaken++;//increase
		shotsTaken.guiText.text=(""+(10-shootsTaken));//update gui
		//moves ball to position
		gameObject.transform.parent = Camera.main.transform;
		transform.position = Camera.main.transform.TransformPoint(Vector3.forward * 2);
		isFiring=false;//toggle
		time=0;//resets time
		numberOfBounce=0;//resets
		initialPosition=Camera.main.transform.TransformPoint(Vector3.forward * 2);//resets initialPosition
		score1.guiText.text=(score+"/10");//updates gui
	}

	//distance between two vectors
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

	//slider gui
	void OnGUI() {

		power = GUI.HorizontalSlider(new Rect(125, 318, 100, 30), power, 0.0F, 25.0F);
	}
}
