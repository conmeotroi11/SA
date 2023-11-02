using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{


    private Camera mainCamera; 
    [SerializeField] private float zoomedInSize = 4.5f;
    [SerializeField] private float defaultSize = 5f;
    
    [Range(0.0f, 1.0f)]
    [SerializeField] private float zoomSpeed;

    [SerializeField] private List<PlayerMovement> playerToFollow = new List<PlayerMovement>();

    


    void Start()
    {
        mainCamera = Camera.main;
      
    }

    void LateUpdate()
    {
        CameraZoom();
    }

    void CameraZoom()
    {
        foreach (PlayerMovement player in playerToFollow)
        {
            if (player.isGround && ManagerSingleton.instance.isPlay)
            {
                mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoomedInSize, zoomSpeed * Time.deltaTime);
            }
            else
            {
                mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, defaultSize, zoomSpeed * Time.deltaTime);
            }
        }    
           
    }
}