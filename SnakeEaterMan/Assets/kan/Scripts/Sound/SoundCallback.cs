using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundCallback : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public bool IsSound()
    {
        bool isSound = false;

        if(audioSource.isPlaying)
        {
            isSound = true;
        }

        return isSound;
    }
}
