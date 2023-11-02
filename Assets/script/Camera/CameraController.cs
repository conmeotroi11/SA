using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{


    private Camera mainCamera; 
    public float zoomedInSize = 4f; 
    public float defaultSize = 5f;
    [Range(0.0f, 1.0f)]
    public float zoomSpeed;

    public List<PlayerMovement> playerToFollow = new List<PlayerMovement>();


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