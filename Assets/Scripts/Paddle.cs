using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	 public bool autoPlay = false;
	 
	 private Ball ball;
	 
	 public float minX = 1.18f;
	 public float maxX = 14.8f;
	
	 void Start() {
	 
	 	ball = GameObject.FindObjectOfType<Ball>();
	 
	 }

	// Update is called once per frame
	void Update () {
	
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	
	}
	
	void MoveWithMouse() {
		
		Vector3 paddlePos = new Vector3(minX, this.transform.position.y, 0);
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		
		this.transform.position = paddlePos;
	
	}
	
	void AutoPlay() {
		
		Vector3 paddlePos = new Vector3(8.2f, this.transform.position.y, 0);
		
		Vector3 ballPos = ball.transform.position;
		
		paddlePos.x = Mathf.Clamp(ballPos.x, minX, maxX);
		
		this.transform.position = paddlePos;
	
	}
}
