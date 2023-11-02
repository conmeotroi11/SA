using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : GCDestroyControl
{
   

   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            ManagerSingleton.instance.currentCoin += 1;
            gameObject.SetActive(false);
            
        }
    }
}
