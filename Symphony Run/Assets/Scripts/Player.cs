using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D characterController;

    [SerializeField]
    private float gravityForce;     // Gravity   
    private float ySpeed;
    public float gravityModifier;

    [SerializeField]
    private float forwardSpeed;     // Player's forward moviment to 

    [SerializeField]
    public Transform groundCheck;

    [SerializeField]
    public float groundCheckRadius;

    [SerializeField]
    public LayerMask whatIsGround;

    [SerializeField]
    public int jumpForce;

    public float hangTime;
    public float hangTimer;

    public Quaternion myRotation;

    public float runSpeed;

    public float lerpTime;

    public float Timer;
    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<Rigidbody2D>();
        myRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        CustomGravity();
        isGrounded();
        Jump();
       // GroundLanding();
        ForwardMovement();
        SpeedApply();

    }

    void isGrounded()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void CustomGravity()
    {
        ySpeed = characterController.velocity.y;
        ySpeed -= gravityForce * Time.deltaTime;
    }

    private void Jump()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("JUMP");
            if (onGround)
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
    }

    void ForwardMovement()
    {
        Timer = Time.deltaTime;
        if (onGround)
        {
            if (forwardSpeed <= runSpeed - .1f || forwardSpeed >= runSpeed + .1f)
            {
                forwardSpeed = Mathf.Lerp(forwardSpeed, runSpeed, lerpTime);
                // Debug.Log("Forward Speed: " + forwardSpeed);
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
        characterController.velocity = new Vector2(characterController.velocity.x, ySpeed);                        // Controls the speed in the Y direction
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colision");
    }

    //void WallJump(Collider2D  )
    // {

    //Debug.Log("HIT");
    // Check with the player is on the ground 
    // and if the player is colliding with a wall
    //if (!onGround && hitSent.normal.y < 0.1f)
    //{
    //    if (Input.GetButtonDown("Fire1"))
    //    {
    //        // Change the character direction
    //        transform.forward = hitSent.normal;
    //        transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
    //        forwardSpeed = runSpeed;
    //        hangTimer = hangTime;
    //        ySpeed = jumpForce;
    //    }
    //}
    // }

}
