using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarCounterSinglePLayer : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Text>().text = database.STC.ToString();
    }
}
