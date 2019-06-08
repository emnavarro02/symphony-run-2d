using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public AudioClip audioLevelManager;
    public AudioClip audioLevel1;
    public AudioClip audioLevel2;
    public AudioClip audioLevel3;
    public AudioClip audioLevel4;
    public AudioClip dieMusic;

    public AudioClip GetAudioLevel1()
    {
        return audioLevel1;
    }

    public AudioClip DieMusicAudio()
    {
        return dieMusic;
    }
}
