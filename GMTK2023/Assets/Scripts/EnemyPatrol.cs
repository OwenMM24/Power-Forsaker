//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;

    Rigidbody2D myRigidbody;
    RaycastHit2D WallCheckHit;

    [SerializeField] float checkDistance = 1f;

    [SerializeField] float LRange;
    [SerializeField] float RRange;

    float health = 1;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
  
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > RRange)
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);   

        else if (transform.position.x < LRange)
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), transform.localScale.y);
        


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

    public void UpdateHealth(float damage)
    {
        health -= damage; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }


    }

}
