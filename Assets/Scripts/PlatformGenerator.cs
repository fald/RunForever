using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public Transform generationPoint;

    public GameObject platform;
    public GameObject[] platforms;
    private int platformChoice;
    private float platformWidth;

    private float distanceBetween;
    public float distanceMin;
    public float distanceMax;

    public ObjectPooler pooler;

    void Start()
    {
    }

    void FixedUpdate()
    {
        distanceBetween = Random.Range(distanceMin, distanceMax);
        platformChoice = Random.Range(0, platforms.Length);
        platform = platforms[platformChoice];
        platformWidth = platform.GetComponent<BoxCollider2D>().size.x;


        if (transform.position.x < generationPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            Instantiate(platform, transform.position, transform.rotation);
           /* Pooler stuff 
            GameObject newPlatform = (GameObject)pooler.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            */
        }
    }
}
