using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
	
	private PaddleController _paddle;
	private bool hasStarted = false;
    private Vector3 paddleLastKnownPosition;
    private Vector3 difference;

	// Use this for initialization
	void Start () {

        InvokeRepeating("StartBall", 2f, 1f);

	}
	
	// Update is called once per frame
	void Update () {


	    if (_paddle)
	    {

	        HoldToPaddle();
            paddleLastKnownPosition = _paddle.transform.position / Time.deltaTime;
        }
		
	}

 



    private void HoldToPaddle()
    {
        Vector3 ballPos = new Vector3(transform.position.x, transform.position.y);
        ballPos.y = _paddle.transform.position.y;
        transform.position = ballPos;

    }

    void StartBall()
    {
        float[] choicesX = { -10f, 10};
        float[] choicesY = { -5f, 5f };

        float xValue = choicesX[Random.Range(0, choicesX.Length)];
        float yValue = choicesY[Random.Range(0, choicesY.Length)];

        GetComponent<Rigidbody2D>().velocity = new Vector2(xValue, yValue);
       CancelInvoke("StartBall");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.1f), Random.Range(0f, 0.1f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }

    //let's the ball know that it's caught when the space bar is held down and it colides with the paddle
    //after ball is caught I will eventually set the ball on fire. This will shoot the ball faster
    //on the next hit the other player has to catch the ball
    //if not it explodes and the player that threw the flaming ball gets 2 points rather than one
    public void Caught(PaddleController paddle)
    {
        _paddle = paddle;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        HoldToPaddle();
    }


    //throw ball when space bar is let go
    public void Throw()
    {
        float xVelocity = -10f;
        float yVelocity = 5f;
        
        if (_paddle.transform.position.x < 0f)
        {
            xVelocity = -xVelocity;
        }
        var currentPosition = _paddle.transform.position / Time.deltaTime;
        print(paddleLastKnownPosition.y + " : " + currentPosition.y);
        if (paddleLastKnownPosition.y < currentPosition.y)
        {
            yVelocity = 5f;
        } else 
        {
            yVelocity = -5f;
        }



        GetComponent<Rigidbody2D>().velocity = new Vector2(xVelocity, yVelocity);
        _paddle = null;
    }
}
