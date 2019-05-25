using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaveScript : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            gameManager.IncreaseClaves();
            Destroy(gameObject);
        }
    }
}
