using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Fix platform spacing. Rolling check for platform sizes to determine spacing?
// TODO: Further update platform spacing to take into account player movespeed.
// TODO: Better coin placement
// TODO: Coin placement bug; might be fixed by above todo. 'transform.position assign attempt for 'Coin(Clone)' is not valid. Input position is { NaN, NaN, 0.000000 }."
// TODO: Better spike placement
// TODO: For placement, can probably set coin/spike parents to current platform when chosen.

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

    public CoinGenerator coinGenerator;
    public SpikeGenerator spikeGenerator;

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

            Vector2 startPos = new Vector2(
                platform.transform.position.x - platformWidth / 2,
                platform.transform.position.y + platform.GetComponent<BoxCollider2D>().size.y);
            coinGenerator.SpawnCoins(startPos, platformChoice + 1, platformWidth / Mathf.Max(1, platformChoice));
            spikeGenerator.SpawnSpikes(startPos + 1 * Vector2.right, 3, 2);

            // Move transform along so as to avoid overlaps; I did -something- wrong here, but eh.
            transform.position = new Vector3(
                transform.position.x + (platformWidth / 2),
                transform.position.y,
                transform.position.z);
        }
    }
}
