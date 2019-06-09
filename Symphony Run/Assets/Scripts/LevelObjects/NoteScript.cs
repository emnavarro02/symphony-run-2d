using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    private GamePlayManager gamePlayManager;
    private MusicManager musicManager;

    private void Awake()
    {
        gamePlayManager = FindObjectOfType<GamePlayManager>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            MusicController.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.getAeCollectNote());
            gamePlayManager.IncreaseNotes();
            Destroy(gameObject);
        }
    }
}
