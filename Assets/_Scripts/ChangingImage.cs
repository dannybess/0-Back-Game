using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class ChangingImage : MonoBehaviour {
	
	private Vector2 fingerStart;
	private Vector2 fingerEnd;
	public Texture[] myTextures = new Texture[5];
	public int maxTextures;
	public int arrayPos = 0;
	public int startIndex;
	public int currentIndex;
	public bool start;
	public bool firstStart = true;
	public float timeLeft = 2.0f;
	public bool isClicked = false;
	public bool yClickedTrue;
	public bool yClickedFalse;
	public bool nClickedTrue;
	public bool nClickedFalse;
	public float minSwipeDistY;	
	public float minSwipeDistX;	
	private Vector2 startPos;
	public bool swipeRight;
	public bool swipeLeft;
	public bool firstTouch;

	void detectSwipe() {
		{
			if (Input.touchCount > 0) 
				
			{
				
				Touch touch = Input.touches[0];
				
				if (Input.touchCount == 1) {

					firstTouch = true;

				}
				
				switch (touch.phase) 
					
				{
					
				case TouchPhase.Began:
					
					startPos = touch.position;
					
					break;
					
					
					
				case TouchPhase.Ended:

					
					float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
					
					if (swipeDistHorizontal > minSwipeDistX) 
						
					{
						
						float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
						
						if (swipeValue > 0) {

							swipeRight = true;

						}
							else if (swipeValue < 0) {
								
							swipeLeft = true;
						}
					}
					break;
				}
			}
		}






	}
	
	void Awake() {
		
		DontDestroyOnLoad(GameObject.Find("Quad"));
		
	}


	void Start (){
		if (firstStart == true) {
			maxTextures = myTextures.Length - 1;
			startIndex = Random.Range (0, maxTextures);
			GetComponent<Renderer> ().material.mainTexture = myTextures [startIndex];
			Debug.Log("in start");
			start = true;
		}
	}



	
	void FixedUpdate () {
		timeLeft -= Time.deltaTime;
		
		if (yClickedTrue == true) {
			if (timeLeft < 0.0f) {
				if (Random.Range (0, (Random.Range(5, 7))) == 1) {
					currentIndex = startIndex;
					isClicked = false;
					yClickedTrue = false;

				} else {
					currentIndex = Random.Range (0, maxTextures);
					isClicked = false;
					yClickedTrue = false;

				}					
			}
		}
		
		
		if (yClickedFalse == true) {
			if (timeLeft < 0.0f) {
				if (Random.Range (0, (Random.Range(5, 7))) == 1) {
					currentIndex = startIndex;
					isClicked = false;
					yClickedFalse = false;

				} else {
					currentIndex = Random.Range (0, maxTextures);
					isClicked = false;
					yClickedFalse = false;

				}
				
			}
			
		}
		
		
		if (nClickedTrue == true) {
			if (timeLeft < 0.0) {
				Debug.Log ("what up ");
				if (Random.Range (0, (Random.Range(5, 7))) == 1) {
					currentIndex = startIndex;
					isClicked = false;
					nClickedTrue = false;

				} else {
					currentIndex = Random.Range (0, maxTextures);
					isClicked = false;
					nClickedTrue = false;

				}
				
			}
			
		}
		
		
		if (nClickedFalse == true) {
			if (timeLeft < 0.0) {
				Debug.Log ("what up ");
				if (Random.Range (0, (Random.Range(5, 7))) == 1) {
					currentIndex = startIndex;
					isClicked = false;
					nClickedFalse = false;

				} else {
					currentIndex = Random.Range (0, maxTextures);
					isClicked = false;
					nClickedFalse = false;

				}

				
			}
			
		}
		
	}

	void Update() {

		detectSwipe ();


		if (start == true) {
			if (firstTouch == true) {
				currentIndex = Random.Range (0, maxTextures);
				start = false;
				swipeRight = false;
				firstTouch = false;

			}
		} else {
			if (isClicked == false) {
				if (swipeRight == true) {
					
					swipeRight = false;

					isClicked = true;
					
					
					if (startIndex == currentIndex) {
						Application.LoadLevel (1);

						timeLeft = 2.0f;
						
						yClickedTrue = true;
						
						
					} else {
						
						Application.LoadLevel (2);
						
						timeLeft = 2.0f;
						
						yClickedFalse = true;
						
					}
					
				}
				
			}
			
			
			if (isClicked == false) {
				if (swipeLeft == true) {

					swipeLeft = false; 

					isClicked = true;
					
					if (startIndex != currentIndex) {
						
						Application.LoadLevel (1);
						
						timeLeft = 2.0f;
						
						nClickedTrue = true;
						
						
					} else {
						
						Application.LoadLevel (2);
						
						timeLeft = 2.0f;
						
						nClickedFalse = true;
						
						
						
					}
					
				}
				
			}
			
			GetComponent<Renderer> ().material.mainTexture = myTextures [currentIndex];
			
			
		}
	}
	
}