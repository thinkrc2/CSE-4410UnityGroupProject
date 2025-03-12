using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    
    [SerializeField] AudioSource soundSource;
    [SerializeField] AudioSource music1Source;
    [SerializeField] string introBGMusic;
    [SerializeField] string levelBGMusic;

    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }


    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }

    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }


    public ManagerStatus status { get; private set; }

    public void Startup()
    {
        Debug.Log("Audio Manager starting...");

        // initialize music sources here
        soundVolume = 1f;

        status = ManagerStatus.Started;
    }

    public void PlayIntroMusic()
    {
        PlayMusic(Resources.Load($"Music/{introBGMusic}") as AudioClip);
    }

    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load($"Music/{levelBGMusic}") as AudioClip);
    }

    public void PlayMusic(AudioClip clip)
    {
        music1Source.clip = clip;
        music1Source.Play();
    }

    public void StopMusic()
    {
        music1Source.Stop();
    }
}