using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    //
    // private GameManager gameManager;
    // private bool dead = false;

    // Start is called before the first frame update
    private void Start()
    {
        // gameManager = FindObjectOfType<GameManager>(); ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {

            print("Fell in a hole");
            collision.GetComponent<Player>().Die();

            // dead = true;

            // Debug.Log(" luego del delay");
            // gameManager.died = false;
            // gameManager.EndLevel();
            // GetComponent<Player>().D;
            // Destroy(gameObject);
        }
    }


}
