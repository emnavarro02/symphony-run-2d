using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    private GameManager gameManager;
    private MusicManager musicManager;

    private bool levelComplete = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!levelComplete)
            {
                levelComplete = true;
                gameManager.died = false;
                FindObjectOfType<GamePlayManager>().LevelComplete();
            }

        }
    }
}
