using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bulletmove : MonoBehaviour
{

    public float speed ;
    public Rigidbody2D rigidbody;
    public float huong=1;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody.velocity = new Vector2(rigidbody.position.x, rigidbody.position.y) * speed*-1/20;
        rigidbody.velocity = Vector2.right*speed*10*huong;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
