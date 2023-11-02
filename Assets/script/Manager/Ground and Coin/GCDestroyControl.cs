using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GCDestroyControl : MonoBehaviour
{
    protected void Update()
    {
        if (transform.position.x < ManagerSingleton.instance.destroyPoint.transform.position.x 
            ||!ManagerSingleton.instance.playerActive 
            ||ManagerSingleton.instance.checkReset.transform.position.x == 1)
        {
            gameObject.SetActive(false);
        }
    }
}
