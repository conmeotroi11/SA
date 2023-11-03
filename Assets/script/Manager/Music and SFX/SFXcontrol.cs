using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXcontrol : MonoBehaviour
{
    private AudioSource audioS;
    private float musicVolume = 1f;
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioS.volume = musicVolume;
    }
    public void MusicVolume(float vol)
    {
        musicVolume = vol;
    }
}
