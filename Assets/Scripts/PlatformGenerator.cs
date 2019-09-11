using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public int message;

    public Transform generationPoint;

    private GameObject platform;
    //public GameObject[] platforms;
    private int platformChoice;
    private float platformWidth;

    private float distanceBetween;
    public float distanceMin;
    public float distanceMax;

    public ObjectPooler[] pools;

    void Start()
    {
    }

    void FixedUpdate()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            platformChoice = Random.Range(0, pools.Length);
            //platform = pools.pooledObject[platformChoice];

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            //Instantiate(platform, transform.position, transform.rotation);

            platform = (GameObject)pools[platformChoice].GetPooledObject();
            platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

            platform.transform.position = transform.position;
            platform.transform.rotation = transform.rotation;
            platform.SetActive(true);
            
        }
    }
}
