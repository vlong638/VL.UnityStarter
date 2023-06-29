using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scenes.VLGamingStudy0328
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource MusicSource { get; set; }
        public AudioSource MainSoundSource { get; set; }
        public AudioSource SecondSoundSource { get; set; }
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
            MainSoundSource.pitch = 0.5f;
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
            MainSoundSource.pitch = randomPitch;
            MainSoundSource.clip = clip;
            MainSoundSource.Play();
        }

        public void PlaySound(List<AudioClip> clips)
        {
            int randomIndex = Random.Range(0, clips.Count);
            var clip = clips[randomIndex];
            PlaySound(clip);
        }
        public void PlaySecondSound(AudioClip clip)
        {
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            SecondSoundSource.pitch = randomPitch;
            SecondSoundSource.clip = clip;
            SecondSoundSource.Play();
        }

        public void PlaySecondSound(List<AudioClip> clips)
        {
            int randomIndex = Random.Range(0, clips.Count);
            var clip = clips[randomIndex];
            PlaySecondSound(clip);
        }
    }
}