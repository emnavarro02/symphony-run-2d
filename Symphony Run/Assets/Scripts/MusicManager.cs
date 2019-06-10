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
    [SerializeField]
    private AudioClip aeCollectClef;
    [SerializeField]
    private AudioClip aeCollectNote;
    [SerializeField]
    private AudioClip aeEndLevel;

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
            case 5:
                return dieMusic;
            case 99:
                return aeEndLevel;
            default: throw new System.ArgumentOutOfRangeException();
        }
    }


    public AudioClip GetAeEndLevel()
    {
        return aeEndLevel;
    }

    public AudioClip GetAeCollectClef()
    {
        return aeCollectClef;
    }

    public AudioClip getAeCollectNote()
    {
        return aeCollectNote;
    }

    public AudioClip GetAudioLevel1()
    {
        return audioLevel1;
    }

    public AudioClip GetAudioLevel2()
    {
        return audioLevel2;
    }


    public AudioClip GetAudioLevel3()
    {
        return audioLevel3;
    }

    public AudioClip GetAudioLevelManager()
    {
        return audioLevelManager;
    }

    public AudioClip DieMusicAudio()
    {
        return dieMusic;
    }


}
