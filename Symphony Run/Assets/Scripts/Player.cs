﻿/**
 * Created by Emerson Navarro
 * 05/10/2019
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private GameManager gameManager;
    private Rigidbody2D characterController; // The character RigidBody component 

    [SerializeField]
    private float gravityForce = 9.8f;    // Gravity   
    private float ySpeed;                 // Jump speed resultant
    
    [SerializeField]
    private float gravityModifier = 50f;  // Apply different gravity based on the hangTimer
    [SerializeField]
    private float hangTime = 0.3f;        // Controls the maximum high the character can reach
    private float hangTimer;              // Controls how much time the jump button is pressed

    private float forwardSpeed;           // Controls the current Player's moviment speed in the "X" direction
        
    [SerializeField]
    private Transform groundCheck;   // Placeholder used to identify if the player is on ground
    [SerializeField]
    private Transform frontCheck;    // Placeholder used to identify if the player is hitting a wall

    [SerializeField]
    private float groundCheckRadius = 0.01f;  

    [SerializeField]
    private LayerMask whatIsGround;  // Layer Mask Ground (8); 
   
    [SerializeField]
    private float runSpeed = 3f;     // Changes the speed to the player to run

    [SerializeField]
    private float lerpTime = 1f;     // Amount of time that it takes from the current speed till the runSpeed

    
    [SerializeField]
    private int jumpForce = 8;       // Initial jump force. Affects ySpeed.
    [SerializeField]
    private int onWall;              // Check if the player is hitinhg a wall

    private bool facingRight = true; // Check if the players sprite is facing to the right direction.

    //[SerializeField]
    //private bool onGround;           // Check if the player is on Ground

    [SerializeField]
    private int onGround;

    private Collider2D[] results = new Collider2D[1]; // Used by the method OverlapPointNonAlloc to determine if there is a colision between the Overlap point and platform 

    [SerializeField]
    private float life = 6f;

    private bool isAlive = true;

    private Animator myAnimator;

    void Start()
    {
        characterController = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        CustomGravity();
       
        IsJumping();
        ForwardMovement();
        SpeedApply();
    }

    private void FixedUpdate()
    {
        
        CheckIfIsOnGround();
        GroundLanding();
        CheckWallCollisions();
        
    }

    void CheckIfIsOnGround()
    {
        //onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        onGround = Physics2D.OverlapPointNonAlloc(groundCheck.position, results, whatIsGround);
        //print("Is Grounded?: "+ onGround);
    }

    void CheckWallCollisions()
    {
        onWall = Physics2D.OverlapPointNonAlloc(frontCheck.position, results, whatIsGround);
    }

    void CustomGravity()
    {
        ySpeed = characterController.velocity.y;
        ySpeed -= gravityForce * Time.deltaTime;
    }

    private void IsJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnimator.SetBool("onGround", false);
            //Debug.Log("isJumping");
            if (onGround > 0)
            {
                //Debug.Log("Is on Ground. Jump");
                Jump();
            }
            else
            {
                //Debug.Log("is jumping but not on ground");
                if (onWall > 0 )
                {
                    //Debug.Log("Colliding with wall");
                    WallJump();
                }
            }
        }
    }

    

    private void Jump()
    {
        if (onGround > 0)
        {
            hangTimer = hangTime;
            ySpeed = jumpForce;
        }
        else
        {
            if (hangTimer > 0)
            {
                hangTimer -= Time.deltaTime;
                ySpeed += gravityModifier * hangTimer * Time.deltaTime;
            }
        }
    }

    void ForwardMovement()
    {
        if (onGround > 0)
        {
            if (forwardSpeed <= runSpeed - .1f || forwardSpeed >= runSpeed + .1f)
            {
                forwardSpeed = Mathf.Lerp(forwardSpeed, runSpeed, lerpTime);
            }
            else
            {
                forwardSpeed = runSpeed;
            }
        }
    }

    void SpeedApply()
    {
        characterController.velocity = new Vector2(forwardSpeed, characterController.velocity.y); // Controls the speed in the X direction
        characterController.velocity = new Vector2(characterController.velocity.x, ySpeed);       // Controls the speed in the Y direction
    }

    void WallJump()
    {
        Flip();
        forwardSpeed = forwardSpeed * -1;
        transform.rotation = Quaternion.Euler(new Vector2(0, transform.rotation.eulerAngles.y));
        hangTimer = hangTime;
        ySpeed = jumpForce;
        GroundLanding();
    }

    void Flip()
     {
        Vector3 rotation = transform.localEulerAngles;
        rotation.y += 180f;
        transform.localEulerAngles = rotation;
        facingRight = !facingRight;
    }

    void GroundLanding()
    {
        if (onGround > 0)
        {
            myAnimator.SetBool("onGround", true);
            if (!facingRight)
            {
               
                Flip();
            }
        }
    }

    public void TakeDamage(float damage)
    {
        if (isAlive)
        {

            life -= damage;
            gameManager.ManageLifes();
            if (life < 0)
            {
                life = 0;
            }

            if (life == 0)
            {
                Die();
            }
        }
    }

    public float getPlayerLife()
    {
        return life;
    }

    public void Die()
    {


        gameManager.PlayDieMusic();

        Destroy(gameObject);
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
    }

   
}
