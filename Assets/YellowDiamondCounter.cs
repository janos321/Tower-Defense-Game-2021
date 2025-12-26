using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YellowDiamondCounter : MonoBehaviour
{
    //public static int BeginnerYellowDiamond = 100;
    private void Awake()
    {
        gameObject.GetComponent<Text>().text = database.GDC.ToString();
    }

    public void YellowDIamonCoundChange(int MOney)
    {
        database.GDC -= MOney;
        gameObject.GetComponent<Text>().text = database.GDC.ToString();
        FajlDatabase.WriteIntoTxtFile();
    }

    private void Update()
    {
        if(database.GDC.ToString()!= gameObject.GetComponent<Text>().text)
        {
            gameObject.GetComponent<Text>().text = database.GDC.ToString();
        }
    }
}
