using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSound : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
    }

    public Sound[] soundEffects;

    private float effectvolume = 0.5f;

    private Dictionary<string, AudioClip> soundEffectsDictionary;
    private AudioSource soundEffectsSource;

    void Awake()
    {
        soundEffectsSource = gameObject.GetComponent<AudioSource>();

        soundEffectsDictionary = new Dictionary<string, AudioClip>();

        foreach (var sound in soundEffects)
        {
            soundEffectsDictionary[sound.name] = sound.clip;
        }
    }

    void Start()
    {
        soundEffectsSource.volume = effectvolume;
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

    public void SetSoundEffectsVolume(float volume)
    {
        soundEffectsSource.volume = Mathf.Clamp(volume, 0f, 1f);
        effectvolume = volume;
    }
}
