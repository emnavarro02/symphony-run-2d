using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int notesScore = 0;

    private int claveScore = 0;

    private int playerLife = 0;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private AudioClip dieMusic;

    [SerializeField]
    private AudioClip firstLevelMusic;

    private AudioSource myAudioSource;
    // Start is called before the first frame update

    private Player player;

    [SerializeField]
    private GameObject[] hearts;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        player = FindObjectOfType<Player>();
        Scene scene = SceneManager.GetActiveScene();

        Debug.Log(scene.buildIndex);
        playCorrespondingMusic(scene.buildIndex);
        DontDestroyOnLoad(gameObject);
    }

    private void playCorrespondingMusic(int level)
    {
        if (level==1)
        {
            PlayFirstLevelMusic();
        }
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

        //myAudioSource.PlayOneShot(dieMusic);
        myAudioSource.Stop();
        myAudioSource.PlayOneShot(dieMusic);
        //StartCoroutine(PlayDieMusicUntilTheEnd());
    }

    public void PlayFirstLevelMusic()
    {
        //myAudioSource
        myAudioSource.PlayOneShot(firstLevelMusic);
        print("music played");
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
        yield return new WaitWhile(() => myAudioSource.isPlaying);
        //do something
    }

    public void ManageLifes()
    {
        playerLife= player.getPlayerLife();
        if (playerLife == 5)
        {
            hearts[6].SetActive(false);

        }
        if (playerLife == 4)
        {
            hearts[7].SetActive(false);
        }
        if (playerLife == 3)
        {
            hearts[3].SetActive(false);
        }
        if (playerLife == 2)
        {
            hearts[4].SetActive(false);
        }
        if (playerLife == 1)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i == 1)
                {
                    hearts[i].SetActive(true);
                }
                else
                {
                    hearts[i].SetActive(false);
                }
            }
        }
        if (playerLife == 0)
        { 
            hearts[1].SetActive(false);
        }
    }
}
