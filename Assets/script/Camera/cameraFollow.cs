using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private List<Transform> targets; 
    private float smooth = 0f; 

    private Vector3 velocity;

    void LateUpdate()
    {
        CFollow();
    }
    void CFollow()
    {
        if (targets.Count == 0)
        {
            return;
        }


        Vector3 averagePosition = Vector3.zero;
        foreach (Transform target in targets)
        {
            averagePosition += target.position;
        }



        Vector3 desiredPosition = averagePosition;
        desiredPosition.y = transform.position.y;
        desiredPosition.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smooth);
    }
}