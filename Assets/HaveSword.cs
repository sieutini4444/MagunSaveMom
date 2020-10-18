using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaveSword : MonoBehaviour
{
    public Text textYouWin;
    public GameObject sword;

    // Start is called before the first frame update
    void Start()
    {
        textYouWin.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            textYouWin.enabled = true;
            sword.SetActive(false);
        }
    }
}
