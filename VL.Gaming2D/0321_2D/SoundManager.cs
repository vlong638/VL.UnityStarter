using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public AudioSource effectSource;
    public AudioSource musicSource;
    public static SoundManager instance = null;

    public void PlaySingle(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }
    public void PlaySingle(AudioClip[] clips)
    {
        effectSource.clip = clips[Random.Range(0, clips.Length)];
        effectSource.Play();
    }


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {

    }

    void Update()
    {

    }
}