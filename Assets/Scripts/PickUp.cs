using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: More complex score increases.
public class PickUp : MonoBehaviour
{
    public float scoreAdd;
    public float scoreMult;
    private ScoreManager scoreManager;
    
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            scoreManager.IncreaseScore(10);
            this.gameObject.SetActive(false);
        }
    }
}
