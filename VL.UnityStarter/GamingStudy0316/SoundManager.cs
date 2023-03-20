using UnityEngine;

public class SoundManager
{
    public AudioSource MusicSource;
    public AudioSource SoundSource;
    public float lowPitchRange = .95f;              
    public float highPitchRange = 1.05f;            

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.loop = true;
        MusicSource.Play();
    }

    public void StopMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Stop();
    }

    public void PlaySingle(AudioClip clip)
    {
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        SoundSource.pitch = randomPitch;
        SoundSource.clip = clip;
        SoundSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        var clip = clips[randomIndex];
        PlaySingle(clip);
    }
}