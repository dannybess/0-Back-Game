using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {
	
	float timeLeft;
	// Use this for initialization
	void Start () {
		timeLeft = 2.0f;
	}
	
	void FixedUpdate()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0.0)
		{
			Application.LoadLevel(0);
		}
	}
}