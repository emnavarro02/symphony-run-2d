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
    // Start is called before the first frame update
    void Start()

    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveToThePlayer();
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

            //Set the other detectedBefore variable to true
            //DamageStatus dmStat = other.gameObject.GetComponent<DamageStatus>();
            //if (dmStat)
            //{
            //    dmStat.detectedBefore = true;
            //}
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            //detectedBefore =truee
            // Put damage/or code to run once below

        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Reset on exit?
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
            //if (facingRight) {
            Flip();
            //}
            xPosition = 0;
        }
    }
}
