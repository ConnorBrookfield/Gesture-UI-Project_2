using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // === Variables === //
    public Sound[] sounds;

    // === Awake Method === //
    // Loops through all the sounds added and their properties.
    void Awake()
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.audioMixer; 
        }
    }

    // === Play Method === //
    // Finds the SoundClip with the inputted name in the Array of Sounds and plays it.
    // Allows the user to Change volume of the Soundclip in game.
    // Displays Error message if the Audio file cannot be found.
    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = s.volume;

        if(s == null)
        {
            Debug.LogWarning("Sound: '" + name + "' was not found!");
            return;
        }

        s.source.Play();
    }
}
