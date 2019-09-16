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
        score += pointsPerSecond * Time.deltaTime;

        scoreText.text = "Score: " + score;
        highScoreText.text = "High Score: " + highScore;
    }
}
