using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxController : MonoBehaviour
{
    private Transform cam;
    private Vector3 camStartPos;
    private float distanceCam;

    [SerializeField] private GameObject[] backgrounds;
    private Material[] mat;
    private float[] backSpeed;

    private float farthestBack;

    [Range(0f,0.5f)]
    [SerializeField] private float parallaxSpeed = 0.11f;

    void Start()
    {
        cam = Camera.main.transform;
        camStartPos = cam.position;  

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i< backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate (int backCount)
    {
        for (int i = 0;i < backCount;i++)
        {
            if ((backgrounds[i].transform.position.z - cam.position.z)>farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }
        for (int i = 0;i< backCount;i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - cam.position.z) / farthestBack;
        }
    }

    
    void LateUpdate()
    {
        distanceCam = cam.position.x - camStartPos.x;
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);
        for (int i = 0;i<backgrounds.Length;i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distanceCam, 0) * speed);
        }
    }
}
