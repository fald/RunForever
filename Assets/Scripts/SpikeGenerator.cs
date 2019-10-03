using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeGenerator : MonoBehaviour
{
    public ObjectPooler spikePool;
    private bool appear;
    private bool[] coinFlip = { true, false };

    public void SpawnSpikes(Vector2 startPos, int spikesPerPlatform, float distBetweenSpikes)
    {
        for (int i = 0; i < spikesPerPlatform; i++)
        {
            appear = coinFlip[Random.Range(0, coinFlip.Length)];
            if (appear)
            {
                GameObject spikeTrap = spikePool.GetPooledObject();
                spikeTrap.transform.position = startPos + Vector2.right * distBetweenSpikes * i;
                spikeTrap.SetActive(true);
            }
        }
    }
}
