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
        textScoreKill.text = PlayerPrefs.GetString("score");
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
            int score = 0;
            try {  score = int.Parse(textScoreKill.text); }
            catch
            {
                 score = 0;
            }
           
            textScoreKill.text = (score + 10).ToString();
            PlayerPrefs.SetString("score",textScoreKill.text);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Monster"))
        {
            collision.gameObject.SetActive(false);
            int score = 0;
            try { score = int.Parse(textScoreKill.text); }
            catch
            {
                score = 0;
            }

            textScoreKill.text = (score + 10).ToString();
            PlayerPrefs.SetString("score", textScoreKill.text);
        }
    }
}
