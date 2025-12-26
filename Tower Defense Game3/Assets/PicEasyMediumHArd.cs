using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicEasyMediumHArd : MonoBehaviour
{
    public List<GameObject> Buttons = new List<GameObject>();
    public static List<GameObject> stars = new List<GameObject>();
    public int mapIndex;
    public void Start()
    {
        if (!gameObject.active)
            return;
        LoadAnotherScene.ForceSojdan = 1;
        for (int i=0;i< Buttons.Count;i++)
        {
            if (database.MAP[mapIndex] >= (i) * 3)
            {
                Buttons[i].GetComponent<SpriteRenderer>().color = LoadAnotherScene.White;
            }
            else
            {
                Buttons[i].GetComponent<SpriteRenderer>().color = LoadAnotherScene.NoChooseEasyButton;
            }
            LoadAnotherScene.csillagosztasesSzintAlatti(database.MAP[mapIndex], Buttons[i],i);
        }
        for (int i = Buttons.Count-1; i >=0; i--)
        {
            if (database.MAP[mapIndex] >= (i) * 3)
            {
                LoadAnotherScene.ForceSojdan = i + 1;
                Buttons[i].GetComponent<SpriteRenderer>().color = LoadAnotherScene.EasymhPicColor;
                break;
            }
        }
    }
    public void EasyMediumHard(int index)
    {
        if (index*3 > database.MAP[mapIndex])
            return;
        for (int i = 0; i < Buttons.Count; i++)
        {
            if (database.MAP[mapIndex] >= (i) * 3)
            {
                Buttons[i].GetComponent<SpriteRenderer>().color = LoadAnotherScene.White;
            }
            else
            {
                Buttons[i].GetComponent<SpriteRenderer>().color = LoadAnotherScene.NoChooseEasyButton;
            }
        }
        Buttons[index].GetComponent<SpriteRenderer>().color = LoadAnotherScene.EasymhPicColor;
       LoadAnotherScene.ForceSojdan = index+1;
    }
}
