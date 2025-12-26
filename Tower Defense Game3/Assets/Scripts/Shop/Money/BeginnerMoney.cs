using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginnerMoney : MonoBehaviour
{
    public int beginnerMoney=0;
    public static int Beginnermoney = 0;
    void Start()
    {
        gameObject.GetComponent<Text>().text = beginnerMoney.ToString();
        Beginnermoney = beginnerMoney;
    }

}
