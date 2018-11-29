using UnityEngine.Audio;
using System;
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource source;
    public Sound[] sounds;
    public static bool isCreated;
    // Use this for initialization
    void Awake()
    {
        if (!isCreated)
        {
            DontDestroyOnLoad(gameObject);
            isCreated = true;
        }
        source.clip = clip;
    }

    private void Start()
    {
        source.Play();
    }
}
