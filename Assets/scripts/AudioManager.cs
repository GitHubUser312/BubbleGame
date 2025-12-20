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
        DontDestroyOnLoad(gameObject); 
    }
    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning($"Sound '{name}' not found!");
            return;
        }

        AudioSource.PlayClipAtPoint(s.audioClip, transform.position);
    }
}
