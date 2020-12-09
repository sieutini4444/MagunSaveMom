using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountSkill : MonoBehaviour
{
    public Text skillFire;
    public Text skillStrike;
    public Animator anim;

    private float timeRate;
    public float fireRate;

    public int numOfFire;
    public float kz;
    public int countStrike;
    string str;
    // Start is called before the first frame update
    void Start()
    {
        skillFire.text = "3";
        skillStrike.text = "0s";
        
    }

    // Update is called once per frame
    void Update()
    {
        numOfFire = int.Parse(skillFire.text);
        str = countStrike.ToString();
        if (kz > 0) {
            if (Time.time - kz >= 1) {
                kz = Time.time;
              
                countStrike = int.Parse(str);
                if (countStrike >= 1) {
                    str = (countStrike - 1).ToString();
                    countStrike = int.Parse(str);
                    skillStrike.text = str+"s";
                }
                if (countStrike == 0) {
                    str = (countStrike).ToString();
                    skillStrike.text = str+"s";
                    kz = 0;
                }              
            }
        }  
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S) && !anim.GetBool("dash"))
        {
            anim.SetBool("isSkill", true);
            if (Time.time > timeRate && anim.GetBool("sword") == true)
            {
                timeRate = Time.time + fireRate;
                numOfFire = int.Parse(skillFire.text);
                if (numOfFire >= 1)
                {
                    skillFire.text = (numOfFire - 1).ToString();
                }
            }
        }

        if ((Input.GetKeyDown(KeyCode.D) || anim.GetBool("isStrike")) && anim.GetBool("sword") == true && !anim.GetBool("dash") && skillStrike.text=="0s")
        {
            skillStrike.text = "10s";
            countStrike = 10;
            kz = Time.time;                    
        }
    }
}
