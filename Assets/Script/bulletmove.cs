using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bulletmove : MonoBehaviour
{

    public float speed ;
    public Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody.velocity = new Vector2(rigidbody.position.x, rigidbody.position.y) * speed*-1/10;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
