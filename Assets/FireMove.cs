using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireMove : MonoBehaviour
{
    public Rigidbody2D rf2;
    public float speed=10f;
    public GameObject[] fgameObjects;

    public Text textScore;
    public string txt;

    // Start is called before the first frame update
    void Start()
    {
        rf2 = gameObject.GetComponent<Rigidbody2D>();
        fgameObjects = GameObject.FindGameObjectsWithTag("ScoreNum");
        txt = fgameObjects[0].GetComponent<Text>().text;
        Debug.Log("Day la " + txt);
    }

    // Update is called once per frame
    void Update()
    {
            rf2.velocity = (Vector2.right)*speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Debug.Log(collision.gameObject.tag);
            Destroy(this.gameObject);
            if (collision.gameObject.tag == "Monster")
            {
                collision.gameObject.SetActive(false);
                int k = int.Parse(fgameObjects[0].GetComponent<Text>().text);
                fgameObjects[0].GetComponent<Text>().text = (k + 10).ToString();
            }
        }
    }
}
