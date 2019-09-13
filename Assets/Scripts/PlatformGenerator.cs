using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fix platform spacing.
// TODO: Further update platform spacing to take into account player movespeed.

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

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;


    void Start()
    {
        minHeight = transform.position.y; // Platform generator starts here, but not forced, just happens to.
        maxHeight = maxHeightPoint.position.y;
    }

    void FixedUpdate()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            platformChoice = Random.Range(0, pools.Length);
            //platform = pools.pooledObject[platformChoice];
            heightChange = transform.position.y + Random.Range(-maxHeightChange, maxHeightChange);
            heightChange = Mathf.Max(Mathf.Min(maxHeight, heightChange), 0);


            transform.position = new Vector3(
                transform.position.x + (platformWidth / 2) + distanceBetween,
                //transform.position.y,
                heightChange,
                transform.position.z);
            //Instantiate(platform, transform.position, transform.rotation);

            platform = (GameObject)pools[platformChoice].GetPooledObject();
            platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

            platform.transform.position = transform.position;
            platform.transform.rotation = transform.rotation;
            platform.SetActive(true);

            // Move transform along so as to avoid overlaps; I did -something- wrong here, but eh.
            transform.position = new Vector3(
                transform.position.x + (platformWidth / 2),
                transform.position.y,
                transform.position.z);
        }
    }
}
