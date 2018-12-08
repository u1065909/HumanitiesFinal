using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidController : MonoBehaviour {

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
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = timeToJump;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(false);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(true);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping && isGrounded())
        {
            isJumping = true;
            jumpTimer = timeToJump;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
            jumpTimer = 0;
        }
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow) && isJumping)
            Jump();
    }
    private void Jump()
    {
        print("Jump");
        if (jumpTimer > 0)
        {
            rb.AddForce((transform.up * jumpForce), ForceMode2D.Force);
        }
        jumpTimer -= Time.deltaTime;

    }
    private bool isGrounded()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheck.position, .1f, layer);
        return collider.Length != 0;
    }
    private void Move(bool isRight)
    {
        if (isRight)
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        else
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
    }
}
