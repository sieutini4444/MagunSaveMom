using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHP : MonoBehaviour
{
    public Text textHP;
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
            string k = (textHP.text);
            string k2 = k.Substring(0, 1);
            textHP.text = (k+k2).ToString();
            Destroy(this.gameObject);
        }
    }
}
