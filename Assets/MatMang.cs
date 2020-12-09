using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatMang : MonoBehaviour
{
    public Text textHP, textYouWin;
    public Mover Player;
    public Animator anim;
    public float checkhurt;

    public GameObject amthanh;
    // Start is called before the first frame update
    void Start()
    {
        textHP.text = "❤❤❤";
       
       // Debug.Log(textHP.text.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - checkhurt >= 0.5 && checkhurt != 0)
        {
            anim.SetBool("hurt", false);
            checkhurt = 0;
            amthanh.gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Monster") || collision.gameObject.tag=="chet")
        {
            if (textHP.text.Length == 1)
            {
                string HPconlai = textHP.text.Substring(1, textHP.text.Length - 1);
                textHP.text = HPconlai;
                textYouWin.gameObject.SetActive(true);
                textYouWin.text = "YOU LOSE";
                textYouWin.enabled = true;
                anim.SetBool("hurt", true);
                amthanh.gameObject.SetActive(true);
                Application.LoadLevel("GameOver");
            }
            else if (textHP.text.Length > 1)
            {
                string HPconlai = textHP.text.Substring(1, textHP.text.Length - 1);
                textHP.text = HPconlai;
                anim.SetBool("hurt", true);
                amthanh.gameObject.SetActive(true);
                checkhurt = Time.time;
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
        if (collision.gameObject.tag == ("chet")) {
            if (textHP.text.Length >= 1)
            {
                transform.position = (new Vector2(-5, 0));
            }
        }
    }
}
