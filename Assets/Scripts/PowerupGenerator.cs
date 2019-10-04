using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupGenerator : MonoBehaviour
{
    public ObjectPooler pointPool;
    public ObjectPooler invulnerablePool;
    private bool appear;
    public float threshold_points;
    public float threshold_invulnerable;
    private float choice;
    private GameObject powerup;
    // sum(points) < 100

    public void SpawnPowerup(Vector2 position)
    {
        choice = Random.Range(0f, 1f);
        if (choice < threshold_points)
        {
            powerup = pointPool.GetPooledObject();
        } else if (choice < threshold_invulnerable)
        {
            powerup = invulnerablePool.GetPooledObject();
        } else
        {
            return;
        }
        powerup.transform.position = position;
        powerup.SetActive(true);
    }
}
