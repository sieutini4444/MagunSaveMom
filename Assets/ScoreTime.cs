using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{
    public Text textTimeScore;
    public Transform Playerr;
    public float k;
    // Start is called before the first frame update
    void Start()
    {
        k = Mathf.Round(Time.time);

    }

    // Update is called once per frame
    void Update()
    {
        textTimeScore.text = Mathf.Round(Time.time - k).ToString();
        PlayerPrefs.SetString("time", textTimeScore.text);
    }
}
