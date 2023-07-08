using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    Rigidbody2D rb;

    public float accel = .3f;
    public float decel = .1f;
    float xSpeed;
    float ySpeed;
    public Vector2 maxSpeed = new Vector2(7f, 99f);
    public float jumpHeight = 2f;

    bool isGrounded = false;
    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    public bool canWalk = true;
    public bool canJump = true;
    public bool canDoubleJump = true;
    bool usedExtraJump = false;
    public bool canDash = true;
    public bool canWallJump = true;
    public bool canGroundPound = true;
    public bool canGlide = true;
    public float defaultGravityScale;
    public float newGravityScale = .3f;
    public float maxGlideYVelocity = 5f;

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

        defaultGravityScale = rb.gravityScale;
    }

    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal"); //variable that represents horizontal input

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

        //caps the speed of the player on both axes
        if (Mathf.Abs(xSpeed) > maxSpeed.x * Mathf.Abs(xAxis))
        {
            xSpeed = maxSpeed.x * Sign(xAxis);
        }
        if (Mathf.Abs(ySpeed) > maxSpeed.y)
        {
            ySpeed = maxSpeed.y * Sign(ySpeed);
        }
        if ((Input.GetButton("Extra") && canGlide) && (Mathf.Abs(ySpeed) > maxGlideYVelocity))
        {
            ySpeed = maxGlideYVelocity * Sign(ySpeed);
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

            if (Input.GetButton("Extra") && canGlide && rb.velocity.y < -1f)
            {
                rb.gravityScale = newGravityScale;
            }
            else
            {
                rb.gravityScale = defaultGravityScale;
            }
        }
    }

    //proper sign method that makes 0 act like 0
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
