using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkeletonScript : MonoBehaviour
{
    [SerializeField]
    private int damage = 2;
    private float xPosition = 0;
    private bool facingRight = true;
    private bool detectedBefore = false;
    Vector3 stageDimensions;
    // Start is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveToThePlayer();
        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(horzExtent, Screen.height, 0));

        if (stageDimensions.x > transform.position.x +2)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        other.GetComponent<Player>().TakeDamage(damage);
    //        // gamePlayManager.UpdatePlayerLife();
    //    }
    //}


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Exit if we have already done some damage
            if (detectedBefore)
            {
                return;
            }
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        { 
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
        if (xPosition == 0)
        {
            xPosition = transform.position.x;
        }
        float difference = xPosition - transform.position.x;

        if (difference < 0)
        {
            difference = Math.Abs(difference);
        }

        if (difference < 3)
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
        if (difference > 3)
        {
            Flip();
            xPosition = 0;
        }
    }
}
