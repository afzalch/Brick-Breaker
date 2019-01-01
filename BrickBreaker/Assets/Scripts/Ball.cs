using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	// configuration parameters
	[SerializeField] Paddle paddle1;
    [SerializeField] float xVel = 2f;
    [SerializeField] float yVel = 15f;
    [SerializeField] AudioClip[] ballSounds;


	// state
	Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references
    AudioSource myAudioSource;

    // Use this for initialization
    void Start () {
		paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted){
            LockBalltoPaddle();
            LaunchOnMouseClick();
        }
    }

	private void LaunchOnMouseClick(){
		if (Input.GetMouseButtonDown(0)){
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
		}
	}

	private void LockBalltoPaddle(){
		Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
		transform.position = paddlePos + paddleToBallVector;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
        }

    }
}
