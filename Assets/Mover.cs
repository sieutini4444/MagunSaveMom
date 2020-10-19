using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using System.Text;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 40f, maxspeed = 3, jumpPow = 300f;
    public bool grounded = true, faceright = true, doublejump = false;

    public GameObject playerr;
    public Rigidbody2D r2;
    public Animator anim;

    // Use this for initialization
    void Start()
    {
        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            playerr.transform.position = (new Vector2(-5, 0));
        }
        anim.SetBool("Ground", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                grounded = false;
                doublejump = true;
                r2.AddForce(Vector2.up * jumpPow);
            }
            else
            {
                if (doublejump)
                {
                    doublejump = false;
                    r2.velocity = new Vector2(r2.velocity.x, 0);
                    r2.AddForce(Vector2.up * jumpPow * 0.8f);
                }
            }
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        r2.transform.Translate(Vector2.right * h/10f);
        //r2.AddForce(Vector2.right*h*speed);
        if (h!=0) {
            anim.SetFloat("speed", 2);
        } else anim.SetFloat("speed", 0);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        if (h > 0 && !faceright){
            Flip();
        }

        if (h < 0 && faceright){
            Flip();
        }
    }

    public void Flip()
    {
        faceright = !faceright;
        Vector3 Scale;
        Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
