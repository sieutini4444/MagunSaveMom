using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatMang : MonoBehaviour
{
    public Text textHP, textYouWin;
    public Mover Player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        textHP.text = "❤❤❤";
       // Debug.Log(textHP.text.Length);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Monster"))
        {
            if (textHP.text.Length == 1)
            {
                string HPconlai = textHP.text.Substring(1, textHP.text.Length - 1);
                textHP.text = HPconlai;
                textYouWin.gameObject.SetActive(true);
                textYouWin.text = "YOU LOSE";
                textYouWin.enabled = true;
            }
            else if (textHP.text.Length > 1)
            {
                string HPconlai = textHP.text.Substring(1, textHP.text.Length - 1);
                textHP.text = HPconlai;
                Debug.Log(textHP.text.Length);
                Debug.Log(gameObject.tag.ToString());
            }
        }
        if (collision.gameObject.tag == "Win")
        {
            textYouWin.gameObject.SetActive(true);
            textYouWin.text = "VICTORY";
            textYouWin.enabled = true;
            collision.gameObject.SetActive(false);
            Debug.Log(textYouWin.text.ToString());
        }
    }
}
