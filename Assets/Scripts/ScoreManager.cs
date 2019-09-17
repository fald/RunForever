using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// TODO: Better font
// TODO: fix score increase
public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public float score;
    public float highScore;

    public float pointsPerSecond;
    public bool scoreIncreasing;

    void Start()
    {
        
    }

    void Update()
    {
        if (scoreIncreasing)
        {
            score += pointsPerSecond * Time.deltaTime;
        }

        if (score > highScore)
        {
            highScore = score;
        }

        scoreText.text = "Score: " + score.ToString("F1");
        highScoreText.text = "High Score: " + highScore.ToString("F1");
    }
}
