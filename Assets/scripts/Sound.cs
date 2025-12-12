using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public AudioClip audioClip;

    public string name;

    [Range(0, 1)]
    public float volume; 
    [Range(0.1f, 3)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

}
