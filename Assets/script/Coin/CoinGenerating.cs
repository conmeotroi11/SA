using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerating : MonoBehaviour
{
    public Objectpool coinPool;
    public float distanceBetweenCoins;

    public void SpawnCoin (Vector3 startPostion)
    {
        GameObject coin1 = coinPool.GetPooledObject();
        coin1.transform.position = startPostion;
        coin1.SetActive(true);

        GameObject coin2 = coinPool.GetPooledObject();
        coin2.transform.position = new Vector3(startPostion.x - distanceBetweenCoins,startPostion.y , startPostion.z);
        coin2.SetActive(true);

        GameObject coin3 = coinPool.GetPooledObject();
        coin3.transform.position = new Vector3(startPostion.x + distanceBetweenCoins, startPostion.y, startPostion.z);
        coin3.SetActive(true);
    }
}
