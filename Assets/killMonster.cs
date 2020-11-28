using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killMonster : MonoBehaviour
{
    public Text textScoreKill;
    // Start is called before the first frame update
    void Start()
    {
        //textScoreKill.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.SetActive(false);
            int score = int.Parse(textScoreKill.text);
            textScoreKill.text = (score + 10).ToString();
        }
    }
}
