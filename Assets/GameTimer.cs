using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    void Update()
    {
        int t = Convert.ToInt32(Time.realtimeSinceStartup);
        gameObject.GetComponent<Text>().text = Convert.ToString((t - (t % 60)) / 60) + ":" + (t%60).ToString("D2");


    }
}
