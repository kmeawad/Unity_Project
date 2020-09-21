using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float downForce;
    private float moveInput;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isRight = true;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisgrounded; 

    private int extraJumps;
    public int extraJumpValue = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisgrounded); // anything in radius will decide if character is on ground 

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 && isRight == false) Flip();
        if (moveInput < 0 && isRight == true) Flip();
        
    }


    // Update is called once per frame
    void Update()
    {
    
        if (isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }

        // Use extra jumps
        if (Input.GetKeyDown(KeyCode.W) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }

        // Move up when on ground
        if (Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        // Move down when in air
        if (Input.GetKeyDown(KeyCode.S)  && isGrounded == false)
        {
            rb.velocity = Vector2.down * downForce;
        }

        
    }
    private void Flip()
    {
        // If isRight is true make it false and vice versa
        isRight = !isRight;

        // Multiply the player's x local scale by -1 to flip
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
