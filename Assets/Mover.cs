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
    public GameObject boxAttack;

    public GameObject fire,fire2;
    public Transform fireSp,fireSp2;
    public float fireRate;
    private float timeRate;

    public float m,k;

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

    [System.Obsolete]
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (anim.GetBool("sword") == true)
            {
                anim.SetBool("isAttack", true);
                boxAttack.SetActive(true);
                k = Time.time;
            }
        }
        else {
         
                anim.SetBool("isAttack", false);
                boxAttack.SetActive(false);
        }/*
        if (Time.time >= k + 0.3f)
        {
            anim.SetBool("isAttack", false);
            boxAttack.SetActive(false);
        }
        */
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isSkill", true);
            if (faceright && Time.time > timeRate && anim.GetBool("sword")==true)
            {
                timeRate = Time.time + fireRate;
                Instantiate(fire, fireSp.position, fireSp.rotation);
            }
            else
            {
                if (Time.time > timeRate && anim.GetBool("sword") == true)
                {
                    timeRate = Time.time + fireRate;
                    Instantiate(fire2, fireSp2.position, fireSp2.rotation);
                }
            }
        }
        else
        {
            anim.SetBool("isSkill", false);
        }

        float vitri = playerr.transform.position.x;
        if (Input.GetKeyDown(KeyCode.D) && anim.GetBool("sword") == true)
        {
                if (faceright)
                {
                    m = 1;
                }
                else m = -1;
                anim.SetBool("isStrike", true);
                playerr.transform.position = new Vector2(vitri + m, playerr.transform.position.y);
                boxAttack.SetActive(true);
                k = Time.time;
        }

        if (anim.GetBool("isStrike") && Time.time >= k + 0.2f)
        {
            anim.SetBool("isStrike", false);
            boxAttack.SetActive(false);
            playerr.transform.position = new Vector2(vitri - m, playerr.transform.position.y);
        }

        float h = Input.GetAxis("Horizontal");
        r2.transform.Translate(Vector2.right * h/10f);
  
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
