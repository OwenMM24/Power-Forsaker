using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject turretBullet;
    [SerializeField] Transform attackPoint;
    Vector3 position;

    [SerializeField] float fireRate = 3;
    float bulletAmount;
    float timeBetweenQuickShots = 0.2f;
    float burstAmount = 3;
    float fireDirection = 0f;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        InvokeRepeating("PreShot", fireRate, fireRate);
    }

    void PreShot()
    {

        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(-1f, 1f);
            fireDirection = 180f;
        }
        else
        {
            transform.localScale = new Vector2(1f, 1f);
            fireDirection = 0f;
        }
        Instantiate(turretBullet, attackPoint.position, Quaternion.Euler(0, 0, fireDirection));

        for (int x = 1; x <= burstAmount; x++)
        {   
            Invoke("Shoot", timeBetweenQuickShots * x);
        }
    }

    void Shoot()
    {
        Instantiate(turretBullet, attackPoint.position, Quaternion.Euler(0, 0, fireDirection));
    }
}
