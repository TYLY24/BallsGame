using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Music;
    public AudioSource Sfx;
    public AudioClip BgmMusic;
    void Start()
    {
        Music.clip=BgmMusic;
        Music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
