using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int notesScore = 0;

    private int claveScore = 0;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private AudioClip dieMusic;

    private AudioSource myAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void IncreaseNotes()
    {
        notesScore++;
        scoreText.text = "Notes: " + notesScore.ToString()+" Claves: " + claveScore.ToString();
        Debug.Log("score:" + notesScore);
    }

    public void IncreaseClaves()
    {
        claveScore++;
        scoreText.text = "Notes: " + notesScore.ToString() + " Claves: " + claveScore.ToString();
        Debug.Log("score:" + notesScore);
    }

    public void PlayDieMusic()
    {
        myAudioSource.PlayOneShot(dieMusic);
    }

    public void EndLevel()
    {
       //if collected all the claves, unlock next level
       if (claveScore >= 3)
        {
            //unlock next levels
            PlayerPrefs.SetInt("Level2", 1); // Key: LevelName, Value: 1=unlocked / 0=locked
        }
        // Get score to show stars.
        PlayerPrefs.SetInt("Level1_score", claveScore);
        SceneManager.LoadScene(0);
    }
}
