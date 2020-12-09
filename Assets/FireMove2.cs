using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMove2 : MonoBehaviour
{
    public Rigidbody2D rf2;
    public float speed = 10f;
    public GameObject[] fgameObjects;

    public Text textScore;
    public string txt;

    // Start is called before the first frame update
    void Start()
    {
        rf2 = gameObject.GetComponent<Rigidbody2D>();
        fgameObjects = GameObject.FindGameObjectsWithTag("ScoreNum");
        txt = fgameObjects[0].GetComponent<Text>().text;
   
    }

    // Update is called once per frame
 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int k;
        if (collision.gameObject.tag == "Monster")
        {
            collision.gameObject.SetActive(false);
            k = int.Parse(PlayerPrefs.GetString("score"));
            PlayerPrefs.SetString("score", (k + 10).ToString());
            //  fgameObjects[0].GetComponent<Text>().text = (k+10).ToString();

            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Untagged")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rf2.velocity = (Vector2.left)*speed;
    }

  

}
