using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaveScript : MonoBehaviour
{
    private GamePlayManager gamePlayManager;
    // Start is called before the first frame update
    void Awake()
    {
        gamePlayManager = FindObjectOfType<GamePlayManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            gamePlayManager.IncreaseClaves();
            Destroy(gameObject);
        }
    }
}
