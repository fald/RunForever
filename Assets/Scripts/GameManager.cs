using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartLocation;

    public PlayerController player;
    private Vector3 playerStartLocation;

    //public GameObject[] initialPlatforms;
    //public GameObject platforms;
    public Transform platforms;

    void Start()
    {
        platformStartLocation = platformGenerator.position;
        playerStartLocation = player.transform.position;
    }

    void Update()
    {
        
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCoroutine");
    }

    public IEnumerator RestartGameCoroutine()
    {
        // could set player inactive then active after, but why. just lower the kill zone.
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        /*
        player.transform.position = playerStartLocation;
        platformGenerator.position = platformStartLocation;
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
        */
    }
}
