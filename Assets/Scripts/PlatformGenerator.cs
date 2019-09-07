using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;
    public GameObject platform;
    private float platformWidth;

    private float distanceBetween;
    public float distanceMin;
    public float distanceMax;

    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;    
    }

    void FixedUpdate()
    {
        distanceBetween = Random.Range(distanceMin, distanceMax);

        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
