using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDetroys : MonoBehaviour
{
    public float timeout = 5;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeout);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

}
