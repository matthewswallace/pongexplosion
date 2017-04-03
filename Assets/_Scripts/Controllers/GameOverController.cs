using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{

    public Text LeftPlayerText;
    public Text RightPlayerText;
    public Text LeftPlayerScore;
    public Text RightPlayerScore;


    private LevelManager _levelManager;

	// Use this for initialization
	void Start ()
	{
	    _levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
	    LeftPlayerScore.text = ScoreController.leftPoints.ToString();
	    RightPlayerScore.text = ScoreController.rightPoints.ToString();

	    if (ScoreController.leftPoints > ScoreController.rightPoints)
	    {
	        LeftPlayerText.color = Color.green;
	        RightPlayerText.color = Color.red;
	    } else if (ScoreController.leftPoints < ScoreController.rightPoints)
	    {
	        LeftPlayerText.color = Color.red;
	        RightPlayerText.color = Color.green;
	    }


	}

    public void GoToMainMenu()
    {

        _levelManager.LoadLevel("StartMenu");

    }

}
