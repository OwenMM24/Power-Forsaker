using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    public float accel;
    public float decel;
    public float xSpeed;
    public float ySpeed;
    public Vector2 maxSpeed;
    public float gravity;
    public float jumpHeight;
    
    void Update()
    {
        
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

    public void Move(Vector2 dir, bool grounded = false)
    {
        if (Mathf.Abs(dir.x) != 0)
        {
            xSpeed += accel * dir.x;
        }
        else
        {
            xSpeed += decel * Sign(-xSpeed);
            if (Mathf.Abs(xSpeed) <= decel)
            {
                xSpeed = 0;
            }
        }
		
        if (gravity == 0)
        {
            if (Mathf.Abs(dir.y) != 0)
            {
                ySpeed += accel * dir.y;
            }
            else
            {
                ySpeed += decel * Sign(-ySpeed);
                if (Mathf.Abs(ySpeed) <= decel)
                {
                    ySpeed = 0;
                }
            }
        }

        /*
        ySpeed += /*(accel * dir.y) +*//* gravity;

        if (grounded)
        {
            ySpeed = 0;
        }
        */

        if (Mathf.Abs(xSpeed) > maxSpeed.x * Mathf.Abs(dir.x))
        {
            xSpeed = maxSpeed.x * Sign(dir.x);
        }

        if ((Mathf.Abs(ySpeed) > maxSpeed.y) && gravity != 0)
        {
            ySpeed = maxSpeed.y * Sign(dir.y);
        }
        else if ((Mathf.Abs(ySpeed) > maxSpeed.y * Mathf.Abs(dir.y)) && gravity == 0)
        {
            ySpeed = maxSpeed.y * Sign(dir.y);
        }
		
        transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
    }
}
