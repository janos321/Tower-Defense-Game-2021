using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCounter : MonoBehaviour
{
    public int beginnerHeart = 0;
    public static int BeginnerHeart = 0;
    public static int MaxBeginnerHeart = 0;
    public static GameObject HeartText;

    void Start()
    {
        MaxBeginnerHeart = beginnerHeart;
        HeartText = gameObject;
        gameObject.GetComponent<Text>().text = beginnerHeart.ToString();
        BeginnerHeart = beginnerHeart;
    }
}
