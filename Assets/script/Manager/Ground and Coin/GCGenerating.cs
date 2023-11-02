using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GCGenerating : MonoBehaviour
{
    [SerializeField] private GameObject groundSpawn;
    [SerializeField] private Transform groundSpawnPoint;
    [SerializeField] private Objectpool thePoolObject;

    private float groundWidth =22f;

    [SerializeField] private float disanceBetween;
    private float maxDisance = 5f;
    private float minDisance =8f;

   

    private float maxHight = 2.5f;
    private float minHight = 1f;
    private float hightGround;

    public CoinGenerating theCoinGenerating;
    [SerializeField] private float randomCoinY;
    private float maxY = -3f;
    private float minY = -1f;

    [SerializeField] private float randomCoinX;
    private float maxX= 0f;
    private float minX = 20f;

    [SerializeField] private float RandomCoinNumber;

  

   

 

   
    void Update()
    {
        if(ManagerSingleton.instance.isPlay)
        {
            Spawn();
        }
        
       
    }
    void Spawn()
    {
        if(transform.position.x < groundSpawnPoint.position.x)
        {
            disanceBetween = Random.Range(minDisance, maxDisance);
            hightGround = Random.Range(maxHight, minHight);
            randomCoinY = Random.Range(maxY, minY);
            randomCoinX = Random.Range(maxX, minX);
            transform.position = new Vector3(transform.position.x + groundWidth + disanceBetween,  hightGround, transform.position.z);
           

            GroundPool();
            CoinPool();
        }    
       
    }
    void GroundPool()
    {
        GameObject newGround = thePoolObject.GetPooledObject();
        newGround.transform.position = transform.position;
        newGround.transform.rotation = transform.rotation;
        newGround.SetActive(true);
    }
    void CoinPool()
    {
        if (Random.Range(0f, 100f) < RandomCoinNumber)
        {
            theCoinGenerating.SpawnCoin(new Vector3(transform.position.x + randomCoinX, randomCoinY, transform.position.z));
        }
    }
   
}

