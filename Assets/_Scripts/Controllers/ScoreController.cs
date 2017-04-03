using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public const string LEFT_SIDE = "Left";
    public const string RIGHT_SIDE = "Right";

    public static int leftPoints;
    public static int rightPoints;

    public Text LeftScoreText;
    public Text RightScoreText;


    private void Start()
    {
        Reset();
    }

    public void Score(string side, int points)
    {
        if (side == LEFT_SIDE)
        {
            leftPoints += points;
            LeftScoreText.text = leftPoints.ToString();
        }
        else if (side == RIGHT_SIDE)
        {
            rightPoints += points;
            RightScoreText.text = rightPoints.ToString();
        }
    }

    public void Reset()
    {
        leftPoints = 0;
        rightPoints = 0;
    }
}
