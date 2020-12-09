using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rereplace : MonoBehaviour
{
    Vector2 x;
    // Start is called before the first frame update
    void Start()
    {
        x = new Vector2 (transform.position.x,transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "chet") {
            transform.position=x;
          
        }
    }
}
