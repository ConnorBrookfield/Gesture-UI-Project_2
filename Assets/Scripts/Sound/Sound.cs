using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    // === Public Variables === //
    public string name;
    public AudioClip clip;
    [Range(0.1f, 3f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch;
    public bool loop;
    public AudioMixerGroup audioMixer;

    [HideInInspector]
    public AudioSource source;
    
}
