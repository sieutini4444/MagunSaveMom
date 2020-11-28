using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetFire : MonoBehaviour
{
    public Text textFireCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int k = int.Parse(textFireCount.text);
            k = k + 3;
            textFireCount.text = k.ToString();
            Destroy(this.gameObject);
        }     
    }

}
