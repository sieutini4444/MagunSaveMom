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
        Debug.Log(textHP.text.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (textHP.text.Length == 0)
        {
            textYouWin.gameObject.SetActive(true);
            textYouWin.text = "YOU LOSE";
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag==("Monster") )
        {
            if (!anim.GetBool("isAttack") && !anim.GetBool("isStrike"))
            {
                if (textHP.text.Length >= 1)
                {
                    textHP.text = textHP.text.Substring(1);
                    StartCoroutine(fall(2));
                }
                else
                {
                    textYouWin.gameObject.SetActive(true);
                    textYouWin.text = "YOU LOSE";
                }
            }
            else
            {
                collision.gameObject.SetActive(false);
            }
        }
        else { }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    IEnumerator fall(int timedelay)
    {
        yield return new WaitForSeconds(timedelay);
        yield return 0;

    }
}
