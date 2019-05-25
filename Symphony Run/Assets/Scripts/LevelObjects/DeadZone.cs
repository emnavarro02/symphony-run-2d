using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //
    private GameManager gameManager;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("muriooo");
            collision.GetComponent<Player>().Die();

            dead = true;
            gameManager.EndLevel(dead);
            //GetComponent<Player>().D;
            //Destroy(gameObject);
        }
    }
}
