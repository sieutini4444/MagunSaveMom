using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NenNuoc : MonoBehaviour
{

    //public DraMove DraM;
    public GameObject Dra;
    public float k = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= k + 0.75f && k!=0)
        {
            Dra.GetComponent<CapsuleCollider2D>().isTrigger = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Water"))
        {
            //DraM.setPL(1);
            Dra.GetComponent<DraMove>().setPL(1);
            k = Time.time;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
