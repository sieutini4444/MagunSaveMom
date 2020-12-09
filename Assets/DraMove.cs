using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class DraMove : MonoBehaviour
{

    public float firetime = 0;

    public GameObject dra;
    public Animator anim;
    public GameObject fire2;
    public GameObject sung;
    public Transform firesp;
    public GameObject bat;
    public GameObject next;
    public int phunlua = 0;
    public Text txtBoss;
    public GameObject playerr;
    public int checkDie;
    float wait = 0;

    // Use this for initialization
    public void setPL(int n)
    {
        this.phunlua = n;
    }
    void Start()
    {

        checkDie = 0;
        txtBoss.text = "3";
        anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        txtBoss.text = (3 - checkDie).ToString();
        if (Mathf.Round(Time.time) % 8 == 0 && Mathf.Round(Time.time) != 0 && phunlua == 0)
        {
            anim.SetBool("DraAttack", true);
            firetime = Time.time;
            Instantiate(fire2, firesp.position, firesp.rotation);
        }

        if (Time.time - firetime >= 1f)
        {
            anim.SetBool("DraAttack", false);
            firetime = Time.time;
        }
        if (Time.time % 10 <= 0.1f)
        {
            bat.transform.position = new Vector2(4, 7);
            bat.SetActive(true);

        }

        if (Mathf.Abs(playerr.transform.position.x - dra.transform.position.x) <= 3)
        {
            anim.SetFloat("speed", 0);
            anim.SetBool("DraStrike", true);
            sung.gameObject.SetActive(true);
        }
        else
        {
            if (phunlua == 1)
            {
                //anim.SetFloat("speed", 1);
                anim.SetBool("DraStrike", false);
            }
        }

        if (Time.time >= wait + 1f && wait != 0)
        {
            gameObject.SetActive(false);
            next.GetComponent<BoxCollider2D>().isTrigger = false;

        }
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BoxAttack"))
        {
            checkDie = checkDie + 1;
            if (checkDie == 3)
            {
                anim.SetFloat("speed", 0);
                anim.SetBool("DraDie", true);
                wait = Time.time;
            }

        }
    }


}

