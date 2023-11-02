using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleS;
    public float minTime = 2f; // Thời gian tối thiểu trước khi bắt đầu particle system
    public float maxTime = 5f; // Thời gian tối đa trước khi bắt đầu particle system

    public float duration;
    public float delay;
    public float randomWait;
    public bool hasStarted = false;

    private void Start()
    {
        StartCoroutine(PlayParticlesWithRandomDuration());
    }

    private IEnumerator PlayParticlesWithRandomDuration()
    {
        // Chờ một khoảng thời gian trước khi bắt đầu particle system
        randomWait = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomWait);
        hasStarted = true;

        while (true)
        {
            if (hasStarted)
            {
                // Tạo một khoảng thời gian ngẫu nhiên
                duration = Random.Range(minTime, maxTime);

                // Bật particle system
                particleS.Play();

                var audioSource = particleS.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    // Phát âm thanh nếu Audio Source tồn tại
                    audioSource.Play();
                }

                // Chờ cho đến khi particle system kết thúc
                yield return new WaitForSeconds(duration);

                // Tắt particle system
                particleS.Stop();

                if (audioSource != null)
                {
                    // Tắt âm thanh nếu Audio Source tồn tại
                    audioSource.Stop();
                }
            }

            // Chờ một khoảng thời gian ngẫu nhiên trước khi lặp lại
            delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);
        }
    }
}