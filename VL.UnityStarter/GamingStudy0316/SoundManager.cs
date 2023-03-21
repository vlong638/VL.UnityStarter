using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SoundSource;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    public static SoundManager instance = null;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        SoundSource.pitch = 0.5f;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    public void StopMusic()
    {
        MusicSource.Stop();
    }

    public void PlaySound(AudioClip clip)
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        SoundSource.pitch = randomPitch;
        SoundSource.clip = clip;
        SoundSource.Play();
    }

    public void PlaySound(List<AudioClip> clips)
    {
        int randomIndex = Random.Range(0, clips.Count);
        var clip = clips[randomIndex];
        PlaySound(clip);
    }
}