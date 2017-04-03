using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour {

    public GameObject ball;
    public Text LeftPointsText;
    public Text RightPointsText;

    private LevelManager _levelManager;
	// Use this for initialization
	protected void Start ()
	{
	    _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        SpawnBall();
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}

    public void SpawnBall() {

        if (ScoreController.leftPoints >= 5 || ScoreController.rightPoints >= 5)
        {
            _levelManager.LoadLevel("GameOver");
            return;
        }

        ball = Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
