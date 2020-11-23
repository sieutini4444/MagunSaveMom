using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public float nextLv = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        //Sau 1.5s se chuyen sang level 2
        if (Time.time >= nextLv + 1.5 && nextLv > 0) {
            Application.LoadLevel("Lv2");
            nextLv = 0;
        };
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Win")
        {
            nextLv = Time.time;
        }      
    }
}
