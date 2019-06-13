using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioLevelManager;
    [SerializeField]
    private  AudioClip audioLevel1;
    [SerializeField]
    private AudioClip audioLevel2;
    [SerializeField]
    private AudioClip audioLevel3;
    [SerializeField]
    private AudioClip audioLevel4;
    [SerializeField]
    private AudioClip dieMusic;

/// <summary>
/// SFX Sound effects
/// </summary>
    [SerializeField]
    private AudioClip sfxCollectedClefs;
    [SerializeField]
    private AudioClip sfxRegularNotes;
    [SerializeField]
    private AudioClip sfxLevelComplete;
    [SerializeField]
    private AudioClip sfxJump;
    [SerializeField]
    private AudioClip sfxDamaged;

    public const string SFX_JUMP = "jump";
    public const string SFX_DAMAGED = "damaged";
    public const string SFX_SPECIAL_NOTES = "clefs";
    public const string SFX_REGULAR_NOTES = "notes";
    public const string SFX_LEVEL_COMPLETE = "sfx_level_complete";



    public AudioClip GetAudioClip(int levelIndex)
    {
        switch (levelIndex)
        {
            case 0:
                return audioLevelManager;
            case 1:
                return audioLevel1;
            case 2:
                return audioLevel2;
            case 3:
                return audioLevel3;
            case 4:
                return audioLevel4;
            case 6:
                return dieMusic;
            default: throw new System.ArgumentOutOfRangeException();
        }
    }

    public AudioClip GetSFXEffect(string name)
    {
        switch (name)
        {
            case SFX_JUMP:
                return sfxJump;
            case SFX_DAMAGED:
                return sfxDamaged;
            case SFX_SPECIAL_NOTES:
                return sfxCollectedClefs;
            case SFX_REGULAR_NOTES:
                return sfxRegularNotes;
            case SFX_LEVEL_COMPLETE:
                return sfxLevelComplete;
            default: throw new System.ArgumentOutOfRangeException();
        }
    }


    //public AudioClip getAeCollectNote()
    //{
    //    return sfxRegularNotes;
    //}

    //public AudioClip GetAudioLevel1()
    //{
    //    return audioLevel1;
    //}

    //public AudioClip GetAudioLevel2()
    //{
    //    return audioLevel2;
    //}


    //public AudioClip GetAudioLevel3()
    //{
    //    return audioLevel3;
    //}

    //public AudioClip GetAudioLevelManager()
    //{
    //    return audioLevelManager;
    //}

    //public AudioClip DieMusicAudio()
    //{
    //    return dieMusic;
    //}


}
