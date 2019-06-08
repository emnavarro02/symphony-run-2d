using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision");

        if (collision.CompareTag("Player"))
        {
            // Call endlevel
            gameManager.died = false;
            gameManager.EndLevel();
        }
    }
}
