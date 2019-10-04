using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public bool doublePoints;
    public bool invulnerable;
    public float duration;

    private PowerUpManager powerMgr;

    private void Start()
    {
        powerMgr = GameObject.FindObjectOfType<PowerUpManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            powerMgr.ActivatePower(doublePoints, invulnerable, duration);
        }
        gameObject.SetActive(false);
    }
}
