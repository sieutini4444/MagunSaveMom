using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    public Rigidbody2D rbody;
    public float timedelay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(fall());
        }
    }

    IEnumerator fall()
    {
        yield return new WaitForSeconds(timedelay);
        rbody.bodyType = RigidbodyType2D.Dynamic;
        yield return 0;

    }

}
