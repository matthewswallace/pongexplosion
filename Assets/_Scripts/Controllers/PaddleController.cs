using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    public bool autoPlay = false;
    public bool isAI = false;
    private float moveSpeed = 0.5f;
    private BallController ball;
    private bool catchBall = false;
    private bool holdingBall = false;
    private int aIHitCount = 1;

	void Start ()
	{
	    FindBall();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    var moveRate = Time.deltaTime * 2f;
	    if (!isAI)
	    {
	        if (Input.GetKeyDown(KeyCode.UpArrow)) {
	            if (moveSpeed < -moveSpeed) {
	                moveSpeed = -moveSpeed;
	            }
                InvokeRepeating("MovePaddle", 0.000001f, moveRate);
	        }

	        if (Input.GetKeyDown(KeyCode.DownArrow)) {
	            if (moveSpeed > -moveSpeed) {
	                moveSpeed = -moveSpeed;
	            }
	            InvokeRepeating("MovePaddle", 0.00001f, moveRate);
	        }

	        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
	            CancelInvoke("MovePaddle");
	        }

	        if (Input.GetKeyDown(KeyCode.Space))
	        {
	            catchBall = true;
	        }

	        if (Input.GetKeyUp(KeyCode.Space))
	        {
	            catchBall = false;

	            if (ball && holdingBall)
	            {
	                holdingBall = false;
	                ball.Throw();

	            }
	        }
	    }
	    else
	    {
	        AutoPlayLevel();
	    }

	}


    void OnTriggerEnter2D(Collider2D col)
    {
        ball = col.gameObject.GetComponent<BallController>();

        if (catchBall && ball && !holdingBall)
        {
            holdingBall = true;
            ball.Caught(this);
        }

        if(isAI)
        {
            aIHitCount++;
            print(aIHitCount);
        }

    }


    void AutoPlayLevel()
    {


        if (ball)
        {

           if( (aIHitCount % 5) != 0)
            {
                Vector3 paddlePos = new Vector3(-8.5f, transform.position.y);
                Vector3 ballPos = ball.transform.position;
                paddlePos.y = Mathf.Clamp(ballPos.y, -4.5f, 4.5f);
                transform.position = paddlePos;
            }
            
        }
        else
        {
            if(aIHitCount % 5 == 0 )
            {
                aIHitCount++;
            }
            FindBall();
            
        }
    }

    private void FindBall()
    {
        ball = GameObject.FindObjectOfType<BallController>();
    }
    void MovePaddle()
    {
        Vector3 paddlePos = transform.position;
        float newY = paddlePos.y += moveSpeed;
        paddlePos.y = Mathf.Clamp (newY, -4.5f, 4.5f);

        transform.position = paddlePos;
    }

}
