using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    bool musicEnabled;

    [SerializeField]
    bool MusicEnabled
    {
        get { return musicEnabled; }

        set
        {
            musicEnabled = value;
            UpdateMusic();
        }
    }
    
    [SerializeField]
    bool fxEnabled = true;
    
    [SerializeField, Range(0f, 1f)]
    float musicVolume = 1.0f;
    
    [SerializeField]
    float fxVolume = 1.0f;

    [SerializeField]
    AudioClip clearRowSound;
    
    [SerializeField]
    AudioClip moveShapeSound;

    [SerializeField]
    AudioClip dropSound;

    [SerializeField]
    AudioClip gameOverSound;

    [SerializeField]
    AudioClip[] BackgroundSounds;

    [SerializeField]
    AudioClip BGSound;

    [SerializeField]
    AudioSource musicSource;

    private void Start()
    {
        BGSound = GetRandomClip();
        TurnMusic();
        PlayBackgroundMusic(BGSound);
    }

    private void Update()
    {
        
    }

    public void PlayBackgroundMusic(AudioClip audioClip)
    {
        if (!MusicEnabled || !audioClip || !musicSource)
        {
            return;
        }

        musicSource.Stop();
        musicSource.clip = audioClip;
        musicSource.volume = musicVolume;
        musicSource.loop = true;
        musicSource.Play();
    }

    void UpdateMusic()
    {
        if (musicSource.isPlaying != MusicEnabled)
        {
            if (MusicEnabled)
            {
                PlayBackgroundMusic(BGSound);
            }
            else
            {
                musicSource.Stop();
            }
        }
    }

    public void TurnMusic()
    {
        MusicEnabled = !MusicEnabled;
    }

    public AudioClip GetRandomClip()
    {
        return BackgroundSounds[Random.Range(0, BackgroundSounds.Length)];
    }
}
