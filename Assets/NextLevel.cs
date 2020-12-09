using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    float waitNextLV = 0;
    int lv;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= waitNextLV + 1f && waitNextLV!=0) {
            if(lv==1) Application.LoadLevel("Lv2");
            if(lv==2) Application.LoadLevel("Lv3");
            if(lv==3) Application.LoadLevel("win");
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win") {
            waitNextLV = Time.time;
            lv = 1;
        }
        if(collision.gameObject.tag == "lv3")
        {
            waitNextLV = Time.time;
            lv = 2;
        }
        if (collision.gameObject.tag == "final")
        {
            waitNextLV = Time.time;
            lv = 3;
        }

    }
}
