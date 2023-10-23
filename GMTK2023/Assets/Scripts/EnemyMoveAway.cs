using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveAway : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform attackPoint;
    float fireDirection = 0f;

    RaycastHit2D WallCheckHit;

    [SerializeField] float checkDistance = 3f;
    Rigidbody2D myRigidbody;
    [SerializeField] float moveSpeed = 1.5f;

    [SerializeField] float shotTime = 3f;
    float shotTimer;

    GameObject player;

    void Awake()
    {
        shotTimer = shotTime;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;

        if(Mathf.Abs(player.transform.position.x - transform.position.x) <= checkDistance)
        {
            if (player.transform.position.x < transform.position.x)
            {
                myRigidbody.velocity = new Vector2(moveSpeed, 0f);
                transform.localScale = new Vector2(-1f, 1f);
                fireDirection = 180f;
            }

            else if (player.transform.position.x > transform.position.x)
            {
                myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
                transform.localScale = new Vector2(1f, 1f);
                fireDirection = 0f;
            }
            if(shotTimer < 0f)
            {
                Shoot();
            }
        }

        else
            myRigidbody.velocity = new Vector2(0f, 0f);
    }


    void Shoot()
    {
        Instantiate(bullet, attackPoint.position, Quaternion.Euler(0, 0, fireDirection));
        shotTimer = shotTime;
    }
}
