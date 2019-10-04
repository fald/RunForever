using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Better powerup management lol
// TODO: Find out whats up with find object of type not working
// TODO: Indicator of buff + duration

public class PowerUpManager : MonoBehaviour
{
    private bool doublePoints;
    private bool invulnerable;
    private float duration;
    private bool isActive;

    public ScoreManager scoreMgr;
    public PlayerController playerCtrl;

    public void Start()
    {
        // some trouble with finding these for whatever reason
        scoreMgr = GameObject.Find("Canvas").GetComponentInChildren<ScoreManager>();
        //(ScoreManager) GameObject.Find("Canvas/Score Manager");
        playerCtrl = GameObject.Find("Player").GetComponentInChildren<PlayerController>();
            //FindObjectOfType<PlayerController>();
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
        // scoreMgr.pointsPerSecond = points ? scoreMgr.pointsPerSecond *= 2 : 1;
        scoreMgr.pointsPerSecond = points ? 2 : 1;
        playerCtrl.isInvulnerable = invul ? true : false;
    }

    public void DeactivatePowers()
    {
        doublePoints = false;
        invulnerable = false;
        duration = 0;
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
