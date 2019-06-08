using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private GamePlayManager gamePlayManager;

    private void Awake()
    {

        gamePlayManager = FindObjectOfType<GamePlayManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            gamePlayManager.IncreaseNotes();
            Destroy(gameObject);
        }
    }
}
