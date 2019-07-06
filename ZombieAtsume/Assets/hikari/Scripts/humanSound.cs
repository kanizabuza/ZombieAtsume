using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanSound : MonoBehaviour
{
    private AudioSource aSource;
    public AudioClip aClip;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        aSource.clip = aClip;
    }

    public void soundPlay() {
        aSource.Stop();
        aSource.Play();
    }
}
