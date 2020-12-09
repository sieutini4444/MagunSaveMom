using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhimDiChuyen : MonoBehaviour
{
    //public Animator anim;
    public Mover playerr;
    float h=0;
    float timeRate = 0;
    float k;
    float rate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Player Cround
     
    }

    public void Jumpp() {
        if (!playerr.anim.GetBool("dash"))
        {
            if (playerr.grounded)
            {
                playerr.grounded = false;
                playerr.doublejump = true;
                playerr.r2.AddForce(Vector2.up * playerr.jumpPow);
            }
            else
            {
                if (playerr.doublejump)
                {
                    playerr.doublejump = false;
                    playerr.r2.velocity = new Vector2(playerr.r2.velocity.x, 0);
                    playerr.r2.AddForce(Vector2.up * playerr.jumpPow * 0.8f);
                }
            }
        }
    }

    public void Croundd() {
        playerr.checkCround = true;
    }

    public void CrounddStop()
    {
        playerr.checkCround = false;
    }

    public void Tien() {
        playerr.har = 1;
    }
    public void TienLuiStop()
    {
        playerr.har = 0;
    }

    public void Lui() {
        playerr.har = -1;
    }


    public void SkillA() {
        playerr.checkAttack = true;
    }
    public void SkillAStop() {
        playerr.checkAttack = false;
    }

    public void SkillS() {
        if (!playerr.anim.GetBool("dash") && playerr.countSkill.numOfFire >= 1)
        {

            playerr.anim.SetBool("isSkill", true);
            if (playerr.faceright && Time.time > timeRate && playerr.anim.GetBool("sword") == true)
            {
                timeRate = Time.time + playerr.fireRate;
                Instantiate(playerr.fire, playerr.fireSp.position, playerr.fireSp.rotation);
            }
            else
            {
                if (Time.time > timeRate && playerr.anim.GetBool("sword") == true)
                {
                    timeRate = Time.time + playerr.fireRate;
                    Instantiate(playerr.fire2, playerr.fireSp2.position, playerr.fireSp2.rotation);
                }
            }
            string num = playerr.countSkill.skillFire.text.ToString();
            int numnum = int.Parse(num) - 1;
            
            playerr.countSkill.skillFire.text=(numnum.ToString());
        }
        else
        {
            playerr.anim.SetBool("isSkill", false);
        }
    }

    public void skillD() {
        if (playerr.countSkill.countStrike == 0)
        {
            playerr.checkStrike = true;
        }        
    }
    public void skillDStop() {
        playerr.checkStrike = false;
    }

    public void Dash() {
        playerr.checkDash = true;
        /*if (playerr.grounded && (playerr.har!=0 || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            
        }
        else { 
            playerr.checkDash = true;
        }    */  
    }
    public void DashStop() {
        playerr.checkDash = false;
    }
}

