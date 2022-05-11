using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundmusic : MonoBehaviour
{
    [SerializeField] GameStats _gamestats;
    [SerializeField] AudioClip _heavy;
    private AudioSource myAudio;
    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_gamestats.isGameActive && !myAudio.isPlaying)
            myAudio.PlayOneShot(_heavy);
    }
}
