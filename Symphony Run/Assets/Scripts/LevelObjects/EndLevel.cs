using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private GameManager gameManager;
    private MusicManager musicManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");

        if (collision.CompareTag("Player"))
        {
            MusicController.Instance.gameObject.GetComponent<AudioSource>().Stop();
            gameManager.died = false;
            gameManager.EndLevel();
        }
    }
}
