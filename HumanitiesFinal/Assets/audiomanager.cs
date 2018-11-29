using UnityEngine.Audio;
using System;
using UnityEngine;

public class audiomanager : MonoBehaviour
{

    public Sound[] sounds;

    // Use this for initialization
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }

    private void Start()
    {
        Play("Theme");
    }
    public void Play(string name)
    {
        Array.Find(sounds, sound => sound.name == name);
       
    }
}
