using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    public float accel;
    public float decel;
    public float xSpeed;
    public float ySpeed;
    public Vector2 maxSpeed;
    //public float gravity;
    public float jumpHeight;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    public Rigidbody2D rb;

    public bool canWalk;
    public bool canJump;
    public bool canDoubleJump;
    public bool usedExtraJump;
    public bool canDash;
    public bool canWallJump;
    public bool canGroundPound;
    public bool canGlide;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        canWalk = true;
        canJump = true;
        canDoubleJump = true;
        usedExtraJump = false;
        canDash = true;
        canWallJump = true;
        canGroundPound = true;
        canGlide = true;
    }

    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        //ySpeed = 0;

        if (canWalk)
        {
            if (Mathf.Abs(xAxis) != 0)
            {
                xSpeed += accel * xAxis;
            }
            else
            {
                xSpeed += decel * Sign(-xSpeed);
                if (Mathf.Abs(xSpeed) <= decel)
                {
                    xSpeed = 0;
                }
            }
        }
        

        if (Mathf.Abs(xSpeed) > maxSpeed.x * Mathf.Abs(xAxis))
        {
            xSpeed = maxSpeed.x * Sign(xAxis);
        }

        rb.velocity = new Vector2(xSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            usedExtraJump = false;
            if (Input.GetButtonDown("Jump") && canJump)
            {
                rb.velocity = new Vector2(xSpeed, Mathf.Sqrt(jumpHeight * -2f * (Physics2D.gravity.y * rb.gravityScale)));
            }
        }
        else
        {
            if (Input.GetButtonDown("Jump") && canDoubleJump && !usedExtraJump)
            {
                usedExtraJump = true;
                rb.velocity = new Vector2(xSpeed, Mathf.Sqrt(jumpHeight * -2f * (Physics2D.gravity.y * rb.gravityScale)));
            }
        }
        

        
    }

    int Sign(float var)
    {
        if (var < 0)
        {
            return -1;
        }
        else if (var > 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    //allows for the player ground check sphere to be seen in the editor
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }
}
