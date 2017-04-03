using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTriggerController : MonoBehaviour {

    public string WallLabel = "Left";

    private ScoreController _scoreController;

    private GameController _gameController;
	// Use this for initialization
	void Start ()
	{
	    _scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
	    _gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        _scoreController.Score(WallLabel, 1);
        _gameController.SpawnBall();
        Destroy(collision.gameObject);
    }
}
