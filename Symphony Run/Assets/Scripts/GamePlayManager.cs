using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{

    //[SerializeField]
    private int notesScore = 0;
    private int claveScore = 0;
    private int playerLife = 0;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text clefText;

    [SerializeField]
    private GameObject[] hearts;

    private GameManager gameManager;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();

        scoreText = GameObject.Find("Notes").GetComponent<Text>();
        clefText  = GameObject.Find("Clef").GetComponent<Text>(); 
    }

    public void IncreaseNotes()
    {
        notesScore++;
        Debug.Log("score:" + notesScore);
        UpdateTextElements();
        
        //review
        gameManager.setOverallNotesScore(notesScore);
    }

    public void IncreaseClaves()
    {
        claveScore++;
        Debug.Log("score:" + claveScore);
        UpdateTextElements();

        gameManager.setClafScore(claveScore);
    }

    public void UpdatePlayerLife()
    {
        playerLife = player.getPlayerLife();
        UpdateTextElements();

        gameManager.setOverallPlayerLife(playerLife);
    }

    private void UpdateTextElements()
    {
        scoreText.text = "Notes: " + notesScore.ToString() + " Claves: " + claveScore.ToString() + "Life: " + playerLife.ToString();
        Debug.Log("Notes: " + notesScore.ToString() + " Claves: " + claveScore.ToString() + "Life: " + player.getPlayerLife().ToString());
    }

    public void ManageLifes()
    {
        playerLife = player.getPlayerLife();
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
