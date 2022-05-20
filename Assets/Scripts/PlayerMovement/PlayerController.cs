using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rigidBody2D;
    private Vector2 moveVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Move
        moveVelocity = moveInput.normalized * speed;
    }

    void FixedUpdate()
    {
        rigidBody2D.MovePosition(rigidBody2D.position + moveVelocity * Time.fixedDeltaTime);
    }
}
