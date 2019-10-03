using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Better powerup management lol

public class PowerUpManager : MonoBehaviour
{
    private bool doublePoints;
    private bool invulnerable;
    private float duration;
    private bool isActive;

    private ScoreManager scoreMgr;
    private PlayerController playerCtrl;

    public void Start()
    {
        scoreMgr = FindObjectOfType<ScoreManager>();
        playerCtrl = FindObjectOfType<PlayerController>();
    }

    public void Awake()
    {
        DeactivatePowers();
    }

    public void ActivatePower(bool points, bool invul, float timeSet)
    {
        doublePoints = points;
        invulnerable = invul;
        duration = timeSet;
        isActive = true;
        scoreMgr.pointsPerSecond = points ? scoreMgr.pointsPerSecond *= 2 : 1;
        playerCtrl.isInvulnerable = invul ? true : false;
    }

    public void DeactivatePowers()
    {
        scoreMgr.pointsPerSecond = 1;
        playerCtrl.isInvulnerable = false;
        isActive = false;
    }

    public void Update()
    {
        if (isActive)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
            } else
            {
                DeactivatePowers();
            }
        }
    }
}
