﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTime : MonoBehaviour
{
    public Text textTimeScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textTimeScore.text = Mathf.Round(Time.time).ToString();
    }
}