using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    private int notesScore = 0;
    private int claveScore = 0;
    private int clavesBonusScore = 0;

    [SerializeField]
    private int clavesNumberToBonus = 5;
    private int playerLife = 6;

    private Text scoreText;

    private Text clefText;

    [SerializeField]
    private GameObject[] hearts;

    private GameManager gameManager;
    private Player player;

    [SerializeField]
    private GameObject completeLevelUI;

    private void Awake()
    {
        MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<MusicManager>().GetAudioClip(SceneManager.GetActiveScene().buildIndex);
        MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
    }

    // Start is called before the first frame update
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();

        scoreText = GameObject.Find("Notes").GetComponent<Text>();
        clefText = GameObject.Find("Clef").GetComponent<Text>();
    }

    public void LevelComplete()
    {
        // print("Level Complete");
        MusicController.Instance.gameObject.GetComponent<AudioSource>().clip = FindObjectOfType<MusicManager>().GetSFXEffect(MusicManager.SFX_LEVEL_COMPLETE);
        MusicController.Instance.gameObject.GetComponent<AudioSource>().Play();
        completeLevelUI.SetActive(true);
        Invoke("CallEndLevel", 4);
    }

    public void CallEndLevel()
    {
        gameManager.EndLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncreaseNotes()
    {
        notesScore++;
        clavesBonusScore++;
       // Debug.Log("Scoreeee:" + notesScore);
        scoreText.text = "Notes: " + notesScore.ToString();
        //review
        gameManager.SetOverallNotesScore(notesScore);
        //Debug.Log("Score overal:" + gameManager.GetNotesScore().ToString());
        if (clavesBonusScore == clavesNumberToBonus)
        {
            playerLife = playerLife + 1;
            ManageLifes();
            clavesBonusScore = 0;
        }
    }

    public void IncreaseClaves()
    {
        claveScore++;
        //Debug.Log("score:" + claveScore);
        clefText.text = "Clefs: " + claveScore.ToString();

        gameManager.SetClafScore(claveScore);
    }

    public int UpdatePlayerLife(int damage)
    {
        playerLife -= damage;

        ManageLifes();

        gameManager.SetOverallPlayerLife(playerLife);

        return playerLife;
    }

    public int GetPLayerLife()
    {
        return playerLife;
    }

    public void ManageLifes()
    {
        //playerLife = player.getPlayerLife();
        if (playerLife == 5)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(true);
            hearts[4].SetActive(true);
            hearts[5].SetActive(true);
            hearts[6].SetActive(false);
            hearts[7].SetActive(true);
            hearts[8].SetActive(true);
            // hearts[9].SetActive(true);

        }
        if (playerLife == 4)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(true);
            hearts[4].SetActive(true);
            hearts[5].SetActive(true);
            hearts[6].SetActive(false);
            hearts[7].SetActive(false);
            hearts[8].SetActive(true);
            // hearts[9].SetActive(true);
        }
        if (playerLife == 3)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(false);
            hearts[4].SetActive(true);
            hearts[5].SetActive(true);
            hearts[6].SetActive(false);
            hearts[7].SetActive(false);
            hearts[8].SetActive(true);
            // hearts[9].SetActive(true);
        }
        if (playerLife == 2)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(false);
            hearts[4].SetActive(false);
            hearts[5].SetActive(true);
            hearts[6].SetActive(false);
            hearts[7].SetActive(false);
            hearts[8].SetActive(true);
            // hearts[9].SetActive(true);
        }
        if (playerLife == 1)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
            hearts[3].SetActive(false);
            hearts[4].SetActive(false);
            hearts[5].SetActive(true);
            hearts[6].SetActive(false);
            hearts[7].SetActive(false);
            hearts[8].SetActive(true);
            // hearts[9].SetActive(true);
        }
        if (playerLife == 0)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(true);
            hearts[3].SetActive(false);
            hearts[4].SetActive(false);
            hearts[5].SetActive(true);
            hearts[6].SetActive(false);
            hearts[7].SetActive(false);
            hearts[8].SetActive(true);
            // hearts[9].SetActive(true);
        }
    }

    private void NewMethod(int inactive)
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
}
