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

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            // MusicController.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.getAeCollectNote());
            MusicController.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.GetSFXEffect(MusicManager.SFX_REGULAR_NOTES));
            gamePlayManager.IncreaseNotes();
            Destroy(gameObject);
        }
    }
}
