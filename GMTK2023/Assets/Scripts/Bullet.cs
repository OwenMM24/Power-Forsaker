using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;

    void Awake()
    {
        //when the bullet is spawned it starts going right based off of local rotation
        gameObject.GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.right) * bulletSpeed, ForceMode2D.Impulse);
        //destroys bullet after set amount of time
        Invoke("Destroy", 2);
    }


    private void Destroy()
    {
        //destroys bullet
        Destroy(gameObject);
    }
}
