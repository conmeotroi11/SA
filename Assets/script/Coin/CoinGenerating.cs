using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerating : MonoBehaviour
{
    [SerializeField] private Objectpool coinPool;
    [SerializeField] private float distanceBetweenCoins = 1f;
    [SerializeField] private int numberOfCoinsToSpawn = 3;


    public void SpawnCoin(Vector3 startPosition)
    {
        for (int i = 0; i < numberOfCoinsToSpawn; i++)
        {
            GameObject coin = coinPool.GetPooledObject();
            coin.transform.position = new Vector3(startPosition.x + i * distanceBetweenCoins, startPosition.y, startPosition.z);
            coin.SetActive(true);
        }
    }
}
    