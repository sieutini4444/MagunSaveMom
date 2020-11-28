using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    float waitNextLV = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= waitNextLV + 1.5f && waitNextLV!=0) {
            Application.LoadLevel("Lv2");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win") {
            waitNextLV = Time.time;
        }
    }
}
