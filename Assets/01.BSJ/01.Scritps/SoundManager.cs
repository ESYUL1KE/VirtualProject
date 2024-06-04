using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public Sound[] backgroundMusic;
    public Sound[] soundEffects;

    private float bgmvolume = 0.5f;
    private float effectvolume = 0.5f;

    private Dictionary<string, AudioClip> backgroundMusicDictionary;
    private Dictionary<string, AudioClip> soundEffectsDictionary;
    private AudioSource backgroundMusicSource;
    private AudioSource soundEffectsSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // AudioSource add
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        soundEffectsSource = gameObject.AddComponent<AudioSource>();

        backgroundMusicDictionary = new Dictionary<string, AudioClip>();
        soundEffectsDictionary = new Dictionary<string, AudioClip>();

        foreach (var sound in backgroundMusic)
        {
            backgroundMusicDictionary[sound.name] = sound.clip;
        }

        foreach (var sound in soundEffects)
        {
            soundEffectsDictionary[sound.name] = sound.clip;
        }

        // BGM loop
        backgroundMusicSource.loop = true;
    }

    void Start()
    {
        PlayBackgroundMusic("BGM");
        backgroundMusicSource.volume = bgmvolume;
        soundEffectsSource.volume = effectvolume;
    }

    public void PlayBackgroundMusic(string musicName)
    {
        if (backgroundMusicDictionary.ContainsKey(musicName))
        {
            backgroundMusicSource.clip = backgroundMusicDictionary[musicName];
            backgroundMusicSource.Play();
        }
        else
        {
            Debug.LogWarning("Background music: " + musicName + " not found");
        }
    }

    public void StopBackgroundMusic()
    {
        backgroundMusicSource.Stop();
    }

    public void PlaySoundEffect(string effectName)
    {
        if (soundEffectsDictionary.ContainsKey(effectName))
        {
            soundEffectsSource.PlayOneShot(soundEffectsDictionary[effectName]);
        }
        else
        {
            Debug.LogWarning("Sound effect: " + effectName + " not found");
        }
    }

    public void StopSoundEffects()
    {
        soundEffectsSource.Stop();
    }

    public void SetBackgroundMusicVolume(float volume)
    {
        backgroundMusicSource.volume = Mathf.Clamp(volume, 0f, 1f);
        bgmvolume = volume;
    }

    public void SetSoundEffectsVolume(float volume)
    {
        soundEffectsSource.volume = Mathf.Clamp(volume, 0f, 1f);
        effectvolume = volume;
    }
}
