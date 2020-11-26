using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UndeathAttack : MonoBehaviour
{
    public GameObject bullet;

    public float fireRate;
    public float nextFire;

    public Animator animator;
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
            animator.SetTrigger("Attack");
            nextFire = Time.time + fireRate;
        }
    }
}
