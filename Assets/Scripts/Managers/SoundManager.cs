using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    bool musicEnabled;

    public bool MusicEnabled
    {
        get { return musicEnabled; }

        set
        {
            musicEnabled = value;
            UpdateMusic();
        }
    }
    public AudioClip BGSound { get => bgSound; set => bgSound = value; }
    public AudioClip MoveShapeSound { get => moveShapeSound; set => moveShapeSound = value; }
    public AudioClip DropSound { get => dropSound; set => dropSound = value; }
    public AudioClip GameOverSound { get => gameOverSound; set => gameOverSound = value; }
    public AudioClip ClearRowSound { get => clearRowSound; set => clearRowSound = value; }
    public bool FxEnabled { get => fxEnabled; set => fxEnabled = value; }
    public AudioClip TetrisSound { get => tetrisSound; set => tetrisSound = value; }
    public AudioClip ErrorSound { get => errorSound; set => errorSound = value; }
    public AudioClip LevelUp { get => levelUp; set => levelUp = value; }
    public float MusicVolume { get => musicVolume; 
        set
        {
            musicVolume = value;
            musicSource.volume = musicVolume;
        }
    }

    public float FxVolume { get => fxVolume; set => fxVolume = value; }
    public AudioSource MusicSource { get => musicSource; set => musicSource = value; }

    [SerializeField]
    bool fxEnabled = true;
    
    [SerializeField, Range(0f, 1f)]
    float musicVolume = 1.0f;
    
    [SerializeField, Range(0f, 1f)]
    float fxVolume = 1.0f;

    [SerializeField]
    AudioClip bgSound;

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
    AudioSource musicSource;

    [SerializeField]
    AudioClip tetrisSound;

    [SerializeField]
    AudioClip errorSound;

    [SerializeField]
    AudioClip levelUp;

    public Slider FxSlider;

    public Slider MusicSlider;

    private void Start()
    {
        BGSound = GetRandomClip();
        TurnMusic();
        PlayBackgroundMusic(BGSound);
    }

    private void Update()
    {
        
    }

    public void SetSliders()
    {
        FxSlider.value = FxVolume;
        MusicSlider.value = MusicVolume;
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

    public void TurnFx()
    {
        FxEnabled = !FxEnabled;
    }

    public AudioClip GetRandomClip()
    {
        return BackgroundSounds[Random.Range(0, BackgroundSounds.Length)];
    }

    public void PlayTetrisSound()
    {
        AudioSource.PlayClipAtPoint(TetrisSound, Camera.main.transform.position, 1);
    }

    public void PlaySound(AudioClip audioClip, float volume)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
    }
}
