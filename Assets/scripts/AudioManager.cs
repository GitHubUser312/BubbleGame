using UnityEngine;
using System;
using UnityEngine.Audio;
using NUnit.Framework;
using System.Collections.Generic;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // optional but recommended
    }

    public void Play(string name)
    {
        //AudioSource source = audioSources[name];
        //source.Play();
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound '{name}' not found!");
            return;
        }

        AudioSource.PlayClipAtPoint(s.audioClip, transform.position);
    }
}
