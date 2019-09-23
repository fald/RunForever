using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: randomize coins appearing at all

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPool;
    private bool appear;
    private bool[] coinFlip = { true, false };

    public void SpawnCoins(Vector2 startPos, int coinsPerPlatform, float distBetweenCoins)
    {
        for (int i = 0; i < coinsPerPlatform; i++)
        {
            appear = coinFlip[Random.Range(0, coinFlip.Length)];
            if (appear)
            {
                GameObject coin = coinPool.GetPooledObject();
                coin.transform.position = startPos + (Vector2.right * distBetweenCoins * i);
                coin.SetActive(true);
            }
        }
        
    }
}
