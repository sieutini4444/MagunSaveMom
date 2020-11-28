using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject bullet;

    public float fireRate;
    public float nextFire;
    public Transform bulletsp;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeToFire();
    }

    void CheckTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Vector2 x = new Vector2(transform.position.x - 2, transform.position.y);
            
            Instantiate(bullet, bulletsp.position, bulletsp.rotation);

            nextFire = Time.time + fireRate;
        }
    }

    
}
