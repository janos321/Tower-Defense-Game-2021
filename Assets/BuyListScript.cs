using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyListScript : MonoBehaviour
{
    public static int index = 0;
    public static int BuyMOney = 10;
    public static GameObject gameobjectt;
    private int buy;
    public static Vector3 Bulist;
    private void Start()
    {
        Bulist = gameObject.transform.localScale;
    }
    public void close()
    {
        MENUGamobjects.SkillShopHelp2.SetActive(false);
        gameObject.transform.localScale = Bulist;
        StartCoroutine(CameraMove.SkillShopBe(0.3f, gameObject, 1, gameObject.transform.position));
        //gameObject.SetActive(false);//
    }
    public void clickBuy()
    {
        MENUGamobjects.SkillShopHelp2.SetActive(false);
        if (BuyMOney > database.GDC)
            return;

        database.GDC -= BuyMOney;
        MENUGamobjects.YellowDImondCounter.GetComponent<Text>().text = database.GDC.ToString();
        buy=MENUGamobjects.BuyUpdateValasztas(index,"buy");
        if (buy == 0)
        {
            MENUGamobjects.visszairas(index, 1,"buy");
        }
        else
            if (buy == 2)
        {
            MENUGamobjects.visszairas(index, 3, "buy");
        }

        gameobjectt.GetComponent<Image>().color = MENUGamobjects.BuyingLosColor2;
        gameObject.SetActive(false);
    }
}
