using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: More complex score increases.
public class PickUp : MonoBehaviour
{
    public float scoreAdd;
    public float scoreMult;
    private ScoreManager scoreManager;
    private AudioSource pickupSound;
    
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        pickupSound = GameObject.Find("CoinSound").GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (pickupSound.isPlaying)
            {
                pickupSound.Stop();
            }
            pickupSound.Play();
            scoreManager.IncreaseScore(scoreAdd);
            this.gameObject.SetActive(false);
        }
    }
}
