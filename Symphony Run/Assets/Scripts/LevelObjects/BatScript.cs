﻿using System.Collections;
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
    private int yPosition = 0;
    private bool facingRight = true;
    private GamePlayManager gamePlayManager;

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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamage(damage);
            // gamePlayManager.UpdatePlayerLife();
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
