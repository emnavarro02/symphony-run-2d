using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BatScript : MonoBehaviour
{

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private float life = 50f;
    // Start is called before the first frame update
   

    private Rigidbody2D myRigidbody2D;

    [SerializeField]
    private float xPosition = 0;
    private bool facingRight = true;
    private bool detectedBefore = false;
    private GamePlayManager gamePlayManager;
   
    Vector3 stageDimensions;

    private void Start()
    {
        gamePlayManager = FindObjectOfType<GamePlayManager>();
    }

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveToThePlayer();
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(horzExtent, Screen.height, 0));

        if (stageDimensions.x  > transform.position.x+2)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("detected before: "+detectedBefore);
            if (detectedBefore)
            {
                return;
            }

            other.GetComponent<Player>().TakeDamage(damage);
            // gamePlayManager.UpdatePlayerLife();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Reset on exit?
            Debug.Log("collision exit");
            detectedBefore = true;
        }
    }

    private void Flip()
    {
        Vector3 myRotation = transform.localEulerAngles;
        myRotation.y += 180f;
        transform.localEulerAngles = myRotation;
        facingRight = !facingRight;
    }

    public void moveToThePlayer()
    {
        if (xPosition==0)
        {
            xPosition = transform.position.x;
        }
        float difference = xPosition - transform.position.x;

        if (difference<0)
        {
            difference = Math.Abs(difference);
        }

        if (difference<3)
        {
            if (facingRight)
            {
                transform.position = new Vector2(transform.position.x + (-1f * Time.deltaTime), transform.position.y);
            }
            else
            {
                transform.position = new Vector2(transform.position.x + (1f * Time.deltaTime), transform.position.y);
            }

        }
        if (difference>3)
        {
            //if (facingRight) {
                Flip();
            //}
            xPosition = 0;
        }
    }
}
