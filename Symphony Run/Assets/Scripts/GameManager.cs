using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int notesScore = 0;

    private int claveScore = 0;

    private float playerLife = 0;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private AudioClip dieMusic;

    [SerializeField]
    private AudioClip firstLevelMusic;

    private AudioSource myAudioSource;
    // Start is called before the first frame update

    private Player player;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
    }

    public void IncreaseNotes()
    {
        notesScore++;

        Debug.Log("score:" + notesScore);
        UpdateGeneralScores();
    }

    public void IncreaseClaves()
    {
        claveScore++;

        Debug.Log("score:" + notesScore);
        UpdateGeneralScores();
    }

    public void UpdatePlayerLife()
    {
        playerLife = player.getPlayerLife();
        UpdateGeneralScores();
    }

    private void UpdateGeneralScores()
    {
        scoreText.text = "Notes: " + notesScore.ToString() + " Claves: " + claveScore.ToString() + "Life: " + playerLife.ToString();
        Debug.Log("Notes: " + notesScore.ToString() + " Claves: " + claveScore.ToString() + "Life: " + player.getPlayerLife().ToString());
    }

    public void PlayDieMusic()
    {
        Debug.Log("llega");
        myAudioSource.PlayOneShot(dieMusic);
    }

    public void PlayFirstLevelMusic()
    {
        //myAudioSource
        //myAudioSource.PlayOneShot(firstLevelMusic);
        StartCoroutine(PlayDieMusicUntilTheEnd());

    }

    public void EndLevel(bool died)
    {
        if (!died)
        {
            //if collected all the claves, unlock next level
            if (claveScore >= 3)
            {
                //unlock next levels
                PlayerPrefs.SetInt("Level2", 1); // Key: LevelName, Value: 1=unlocked / 0=locked
            }
            
            if (PlayerPrefs.GetInt("Level1_score") < claveScore)
            {
                // Get score to show stars.
                PlayerPrefs.SetInt("Level1_score", claveScore);
            }

        }

        SceneManager.LoadScene(0);
    }

    IEnumerator PlayDieMusicUntilTheEnd()
    {
        myAudioSource.PlayOneShot(firstLevelMusic);

        //yield return new WaitWhile(() => source.isPlaying);
        yield return new WaitWhile(() => myAudioSource.isVirtual);
        //do something
    }
}
