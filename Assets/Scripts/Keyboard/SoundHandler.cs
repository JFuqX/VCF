using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    public AudioClip keyClickLight;
    public AudioClip keyClickHeavy;
    private AudioSource clickSource;

    // Start is called before the first frame update
    void Start()
    {
        clickSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayKeyClickLight()
    {
        clickSource.PlayOneShot(keyClickLight);
    }

    public void PlayKeyClickHeavy()
    {
        clickSource.PlayOneShot(keyClickHeavy);
    }
}
