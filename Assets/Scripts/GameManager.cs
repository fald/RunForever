using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartLocation;

    public PlayerController player;
    private Vector3 playerStartLocation;

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
        player.transform.position = playerStartLocation;
        platformGenerator.position = platformStartLocation;
    }
}
