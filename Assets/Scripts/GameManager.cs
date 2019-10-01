using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// TODO: Game reset needs to keep track of high score, so fix that to do so.

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartLocation;

    public PlayerController player;
    private Vector3 playerStartLocation;

    private ScoreManager scoreManager;

    public DeathMenu deathCanvas;

    //public GameObject[] initialPlatforms;
    //public GameObject platforms;
    public Transform platforms;

    void Start()
    {
        platformStartLocation = platformGenerator.position;
        playerStartLocation = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        //StartCoroutine("RestartGameCoroutine");
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        deathCanvas.gameObject.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /*
    public IEnumerator RestartGameCoroutine()
    {
        // could set player inactive then active after, but why. just lower the kill zone.
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        PlayerPrefs.SetFloat("highScore", scoreManager.highScore);

        yield return new WaitForSeconds(0.5f);

        // unfortunately, not great for keeping track of high score; boo.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*
        for (int i = 0; i < platforms.transform.childCount; i++)
        {
            if (i == 0 || i == 1)
            {
                platforms.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                platforms.GetChild(i).gameObject.SetActive(false);
            }
        }

        player.transform.position = playerStartLocation;
        platformGenerator.position = platformStartLocation;
        player.gameObject.SetActive(true);
        scoreManager.score = 0;
        scoreManager.scoreIncreasing = true;
        * /
    }
    */
}
