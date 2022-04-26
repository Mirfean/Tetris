using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    bool musicEnabled = true;
    
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
    AudioClip BGSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
