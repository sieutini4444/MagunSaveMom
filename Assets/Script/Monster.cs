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
            Instantiate(bullet, transform.position, Quaternion.identity);

            nextFire = Time.time + fireRate;
        }
    }

    
}
