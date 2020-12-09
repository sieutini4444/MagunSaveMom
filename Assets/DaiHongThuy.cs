using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaiHongThuy : MonoBehaviour
{

    public float speed = 0f;
    public GameObject daiHongThuy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Destroy(this.gameObject);
            daiHongThuy.SetActive(true);
        }
    }
}
