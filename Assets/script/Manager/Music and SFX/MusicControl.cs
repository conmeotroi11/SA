using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField] private AudioClip[] songs;
    private float musicVolume = 1f;

    void Start()
    {
        audioS = GetComponent < AudioSource>();
        ShuffleAndPlayRandomSong();
    }

    void Update()
    {
        audioS.volume = musicVolume;
        if (!audioS.isPlaying)
        {
            int nextSongIndex = (GetCurrentSongIndex() + 1) % songs.Length;
            PlaySong(nextSongIndex);
        }
    }

    void ShuffleAndPlayRandomSong()
    {
      
        for (int i = 0; i < songs.Length; i++)
        {
            int randomIndex = Random.Range(i, songs.Length);
          
            AudioClip temp = songs[i];
            songs[i] = songs[randomIndex];
            songs[randomIndex] = temp;
        }

        
        PlaySong(0);
    }

    int GetCurrentSongIndex()
    {
        for (int i = 0; i < songs.Length; i++)
        {
            if (audioS.clip == songs[i])
            {
                return i;
            }
        }
        return -1;
    }

    void PlaySong(int songIndex)
    {
        audioS.clip = songs[songIndex];
        audioS.Play();
    }

    public void MusicVolume(float vol)
    {
        musicVolume = vol;
    }
}