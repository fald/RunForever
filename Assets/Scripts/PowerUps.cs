using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool doublePoints;
    public bool invulnerable;
    public float duration;

    public PowerUpManager powerMgr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            powerMgr.ActivatePower(doublePoints, invulnerable, duration);
        }
        gameObject.SetActive(false);
    }
}
