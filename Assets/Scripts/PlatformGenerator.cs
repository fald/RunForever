using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;
    public GameObject platform;
    public float distanceBetween;
    private float platformWidth;

    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;    
    }

    void FixedUpdate()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
