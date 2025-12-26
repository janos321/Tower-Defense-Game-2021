using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emenyCount : MonoBehaviour
{
    private int count = 0;
    void Start()
    {
        gameObject.GetComponent<Text>().text = "0";
    }
    void Update()
    {
        count = AllGameObject.AllEnemys.Count;
        gameObject.GetComponent<Text>().text = count.ToString();
    }
}
