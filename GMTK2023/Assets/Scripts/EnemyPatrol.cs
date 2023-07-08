//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidbody;

    [SerializeField] float LRange;
    [SerializeField] float RRange;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > RRange)
            transform.localScale = new Vector2(-1f, transform.localScale.y);   

        else if (transform.position.x < LRange)
            transform.localScale = new Vector2(1f, transform.localScale.y);
        


        if (IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed, 0);
        }

    }

    bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

}
