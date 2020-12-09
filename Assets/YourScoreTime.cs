using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YourScoreTime : MonoBehaviour
{
    public Text HighScore;
    public Text OverScore;
    public Text OverTime;
    // Start is called before the first frame update
    void Start()
    {
        //if (PlayerPrefs.GetString("highScore") == null)
        //{
            //PlayerPrefs.SetString("highScore", "1");
        //}     
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(PlayerPrefs.GetString("score")) > int.Parse(PlayerPrefs.GetString("highScore"))) { 
            PlayerPrefs.SetString("highScore",PlayerPrefs.GetString("score"));
        }
        HighScore.text = PlayerPrefs.GetString("highScore");
        OverScore.text = PlayerPrefs.GetString("score");
        OverTime.text = PlayerPrefs.GetString("time");
    }
}
