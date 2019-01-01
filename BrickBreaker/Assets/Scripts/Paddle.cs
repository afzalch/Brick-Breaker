using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	// Configuration parameters
	[SerializeField] float screenWidthInUnits = 16f;
	[SerializeField] float minX = 1.3f;
	[SerializeField] float maxX = 14.7f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //gets mouse position when on screen and converts to games Units
		float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        //sets position of paddle to only be the x-val of the mouse 
        //position and enforces the y-val always stays constant
        Vector2 paddlePos = new Vector2 (transform.position.x,0.25f);
		paddlePos.x = Mathf.Clamp(mousePos,minX,maxX); //used to enforce a limit on paddle position
        //used to change the position of the transform component of the paddle due to it being called in the 
        //paddle object
		transform.position = paddlePos;
	}
}
