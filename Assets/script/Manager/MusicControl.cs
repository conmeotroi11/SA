using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    private AudioSource audioS;
    public AudioClip[] songs;
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
            // Chuyển sang bài hát tiếp theo
            int nextSongIndex = (GetCurrentSongIndex() + 1) % songs.Length;
            PlaySong(nextSongIndex);
        }
    }

    void ShuffleAndPlayRandomSong()
    {
        // Sắp xếp ngẫu nhiên danh sách các bài hát
        for (int i = 0; i < songs.Length; i++)
        {
            int randomIndex = Random.Range(i, songs.Length);
            // Hoán đổi songs[i] và songs[randomIndex]
            AudioClip temp = songs[i];
            songs[i] = songs[randomIndex];
            songs[randomIndex] = temp;
        }

        // Phát bài hát đầu tiên (bây giờ là một bài hát ngẫu nhiên)
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