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
    public bool facingRight;
    private Rigidbody2D rb;
    private bool isJumping = false;
    private float jumpTimer;
    private Player player;
    private TimeManager timeManager;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = timeToJump;
        player = gameObject.GetComponent<Player>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        if (timeManager == null)
            throw new Exception("Must have gameObject with Type 'TimeManager'");
        facingRight = true;

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!timeManager.isTimeStopped)
        {

            if(!player.isDead && !player.isSafe)
            {
                if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
                {
                    Move(false);
                    facingRight = false;
                }
                else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
                {
                    Move(true);
                    facingRight = true;
                }
            }
        
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping && isGrounded())
            {
                isJumping = true;
                jumpTimer = timeToJump;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
                jumpTimer = 0;
            }
        }
    }

    void FixedUpdate()
    {
        if (!player.isDead)
        {
            if (Input.GetKey(KeyCode.Space) && isJumping)
                Jump();
            
        }
    }
    private void Jump()
    {
        if (jumpTimer > 0)
        {
            rb.AddForce((transform.up*jumpForce), ForceMode2D.Force);
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
            transform.position += new Vector3(speed, 0, 0)*Time.deltaTime;
        else
            transform.position -= new Vector3(speed, 0, 0)*Time.deltaTime;
    }

}
