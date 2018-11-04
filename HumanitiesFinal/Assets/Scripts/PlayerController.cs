using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float speed;
    public Transform groundCheck;
    public LayerMask layer;
    public string jumpThroughLayer;
    public string playerLayer;
    public float timeToJump;
    public float jumpForce;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private float jumpTimer;
    private Player player;

    // Use this for initialization
    void Start ()
    {
        print(layer.value);
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = timeToJump;
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.isDead)
            Destroy(this);
        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
            Move(false);
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
            Move(true);
    
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && isGrounded())
        {
            isJumping = true;
            jumpTimer = timeToJump;
        }
            
        if (Input.GetKey(KeyCode.Space) && isJumping)
            Jump();
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            jumpTimer = 0;
        }
        if(rb.velocity.y > 0)
        {
            gameObject.layer = LayerMask.NameToLayer(jumpThroughLayer);
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer(playerLayer);
        }
        //Debug.DrawRay(transform.position, -Vector3.up);
	}

    
    private void Jump()
    {
        if (jumpTimer > 0)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Force);
        }
        jumpTimer -= Time.deltaTime;
            
    }

    private bool isGrounded()
    {
        Collider2D[] collider= Physics2D.OverlapCircleAll(groundCheck.position, .1f,layer);
        return collider.Length != 0;
    }
    private void Move(bool isRight)
    {
        if (isRight)
            transform.position += new Vector3(speed, 0, 0);
        else
            transform.position -= new Vector3(speed, 0, 0);
    }

}
