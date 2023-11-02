using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleS;
    [SerializeField] private float minTime = 2f; 
    [SerializeField] private float maxTime = 5f; 

    [SerializeField] private float duration;
    [SerializeField] private float delay;
    [SerializeField] private float randomWait;
    [SerializeField] private bool hasStarted = false;

    private void Start()
    {
        StartCoroutine(PlayParticlesWithRandomDuration());
    }

    private IEnumerator PlayParticlesWithRandomDuration()
    {
       
        randomWait = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(randomWait);
        hasStarted = true;

        while (true)
        {
            if (hasStarted)
            {
                
                duration = Random.Range(minTime, maxTime);

              
                particleS.Play();

                var audioSource = particleS.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                 
                    audioSource.Play();
                }

              
                yield return new WaitForSeconds(duration);

               
                particleS.Stop();

                if (audioSource != null)
                {
                  
                    audioSource.Stop();
                }
            }

            
            delay = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(delay);
        }
    }
}