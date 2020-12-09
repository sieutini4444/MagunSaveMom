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

    public CapsuleCollider2D capColli;
    public CapsuleCollider2D miniCaplli;

    public CountSkill countSkill;

    bool checkPause=false;
    public GameObject backg;
    public GameObject CanvasPause;

    public float h, har;
    public bool checkCround, checkDash, checkAttack, checkStrike;
    // Use this for initialization
    void Start()
    {
        h = 0;
        har = 0;
        checkCround = false;
        checkDash = false;
        checkAttack = false;
        checkStrike = false;

        r2 = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Dung thoi gian");
            Time.timeScale = 0f;
            backg.GetComponent<AudioSource>().Pause();
            CanvasPause.gameObject.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.R)) {
            playerr.transform.position = (new Vector2(-5, 0));
        }
        anim.SetBool("Ground", grounded);

        //Player Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) && !anim.GetBool("dash"))
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

        //Player Cround
        if ((Input.GetKey(KeyCode.DownArrow)||checkCround==true) && grounded)
        {
            anim.SetBool("crouch", true);
            anim.SetFloat("speed", 0);
            capColli.enabled = false;
            miniCaplli.enabled = true;
        }
        else if (checkCround == false) {
                anim.SetBool("crouch", false);
                if (!anim.GetBool("dash"))
                {
                    capColli.enabled = true;
                    miniCaplli.enabled = false;
                }
            }

        //Player Dash
        if ((checkDash == true || Input.GetKeyDown(KeyCode.LeftShift)) && grounded 
            && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            anim.SetBool("dash", true);
            timeRate = Time.time;
            checkDash = false;
        }
        if (anim.GetBool("dash"))
        {
            capColli.enabled = false;
            miniCaplli.enabled = true;
        }
        else {
            if (!(grounded))
            {
                capColli.enabled = true;
                miniCaplli.enabled = false;
            }            
        }
            
        if (anim.GetBool("dash") && Time.time >= timeRate + 0.7f)
        {
            anim.SetBool("dash", false);
            checkDash = false;
        }      
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        
        //Player Attack
        if ((checkAttack || Input.GetKey(KeyCode.A)) && !anim.GetBool("dash") && !anim.GetBool("hurt"))
        {
            if (anim.GetBool("sword") == true)
            {
                anim.SetBool("isAttack", true);
                boxAttack.SetActive(true);
                timeRate = Time.time;
            }
        }
        else  if (!anim.GetBool("isStrike"))
            {
                anim.SetBool("isAttack", false);
                boxAttack.SetActive(false);
            }
        
        //Player Skill
        if (Input.GetKey(KeyCode.S) && !anim.GetBool("dash") && countSkill.numOfFire>=1)
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

        //Player Strike
        float vitri = playerr.transform.position.x;
        if ((checkStrike || Input.GetKeyDown(KeyCode.D)) && anim.GetBool("sword") == true && !anim.GetBool("dash") && countSkill.countStrike==0)
        {
            checkStrike = false;
            gameObject.GetComponent<AudioSource>().Play();
            if (faceright)
            {
                m = 2;
            }
            else m = -2;
            anim.SetBool("isStrike", true);
            boxAttack.SetActive(true);
            playerr.transform.position = new Vector2(vitri + m, playerr.transform.position.y);               
            k = Time.time;
        }

        if (anim.GetBool("isStrike") && Time.time >= k + 0.5f)
        {
            checkStrike = false;
            anim.SetBool("isStrike", false);
            boxAttack.SetActive(false);
        }

        if ((h > 0 || har>0) && !faceright)
        {
            Flip();
        }
        if ((h < 0 || har<0) && faceright)
        {
            Flip();
        }
        if (h!=0 && !anim.GetBool("crouch")) {
            anim.SetFloat("speed", 2);
            r2.transform.Translate(Vector2.right * h / 10f);
        } else if (h== 0 && !anim.GetBool("crouch") && har!=0)
                    {
                        anim.SetFloat("speed", 2);
                        r2.transform.Translate(Vector2.right * har / 10f);
                    }
                    else anim.SetFloat("speed", 0);

        if (r2.velocity.x > maxspeed)
            r2.velocity = new Vector2(maxspeed, r2.velocity.y);
        if (r2.velocity.x < -maxspeed)
            r2.velocity = new Vector2(-maxspeed, r2.velocity.y);

        
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
