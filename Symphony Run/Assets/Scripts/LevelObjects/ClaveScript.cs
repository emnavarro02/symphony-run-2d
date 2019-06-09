using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaveScript : MonoBehaviour
{
    private GamePlayManager gamePlayManager;
    private MusicManager musicManager;
    

    void Awake()
    {
        gamePlayManager = FindObjectOfType<GamePlayManager>();
        musicManager = FindObjectOfType<MusicManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            MusicController.Instance.gameObject.GetComponent<AudioSource>().PlayOneShot(musicManager.GetAeCollectClef());
            gamePlayManager.IncreaseClaves();
            Destroy(gameObject);
        }
    }
}