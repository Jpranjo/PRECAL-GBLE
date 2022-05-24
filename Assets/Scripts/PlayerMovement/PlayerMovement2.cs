using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects; //Ground Objects
    public float checkRadius;

    private bool isJumping = false;
    private Rigidbody2D rigidBody2D;
    private Vector2 moveVelocity;
    private float moveInput;
    private bool facingRight = true;
    private bool isGrounded;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator    = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        ProcessInput();
        
        
    }

    void FixedUpdate()
    {
        //Check if Player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
        
        // rigidBody2D.MovePosition(rigidBody2D.position + moveVelocity * Time.fixedDeltaTime);
        //Move
        Move();
    }

    private void ProcessInput()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            
        }

    }

    private void Move()
    {
        rigidBody2D.velocity= new Vector2(moveInput * speed, rigidBody2D.velocity.y);
        if (isJumping && isGrounded)
        {
            rigidBody2D.AddForce(new Vector2(0f, jumpForce));
        }
        isJumping = false;

        //Animate
        Animate();
        //Animator
        animator.SetFloat("xVelocity", Mathf.Abs(rigidBody2D.velocity.x));
    }

    private void Animate()
    {
        if (moveInput > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (moveInput < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    
}
