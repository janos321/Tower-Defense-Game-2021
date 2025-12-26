using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class BuyYellowDiamondMenu : MonoBehaviour
{
    public GameObject DiamondShopPanel;
    public float hourTimer;
    public GameObject FreeVideoText;
    public static GameObject FreeVideoText2;
    public GameObject TimerText;
    public static TimeSpan ido;
    public static Vector3 Yellowdiamondpanel;
    public void OnMouseDown()
    {
        if (CameraMOverClick.mozoge|| MENUGamobjects.ShopPanelMozoge)
            return;
        if (DiamondShopPanel.active )
        {
            MENUGamobjects.SettingsButton.SetActive(true);
            //DiamondShopPanel.SetActive(false);
             gameObject.transform.localScale= Yellowdiamondpanel;
            StartCoroutine(CameraMove.SkillShopBe(0.7f, DiamondShopPanel, 1, gameObject.transform.position));
            FajlDatabase.WriteIntoTxtFile();
        }
        else
        {
            if (MENUGamobjects.footloose == 0)
            {
                MENUGamobjects.SettingsButton.SetActive(false);
                MENUGamobjects.footloose = 1;
                MENUGamobjects.kameramozgatas = 1;
                gameObject.transform.localScale = Yellowdiamondpanel;
                StartCoroutine(CameraMove.SkillShopBe(0.7f, DiamondShopPanel, 0, gameObject.transform.position));
                //DiamondShopPanel.SetActive(true);
            }
        }
    }
    private void Start()
    {
        Yellowdiamondpanel = gameObject.transform.localScale;
        FreeVideoText2 = FreeVideoText;
            DateTime mai = DateTime.Now;
            ido = mai - database.FVT;
        
    }
    private void Update()
    {

        if (DiamondShopPanel.active)
        {
            if (MENUGamobjects.WifiEllenorzesido >= 3)
            {
                MENUGamobjects.WifiEllenorzesido = 0;
                StartCoroutine(database.CheckInternetConnection1(isConnected =>
                {
                    MENUGamobjects.WifiBool = isConnected;
                }, (int)MENUGamobjects.WifiEllenorzesido));
            }
            else
            {
                MENUGamobjects.WifiEllenorzesido += Time.deltaTime;
            }
            if (ido.TotalHours >= hourTimer)
            {
                TimerText.SetActive(false);
                FreeVideoText.SetActive(true);
            }
            else
            {
                TimerText.SetActive(true);
                FreeVideoText.SetActive(false);
                DateTime mai = DateTime.Now;
                ido = mai - database.FVT;
                float minutes =60- ido.Minutes;
                float Hours = hourTimer - ido.Hours-1;
                TimerText.GetComponent<Text>().text = Hours + ":" + minutes;
            }
        }
    }
    public void Buy(int buyCount)
    {
        if (!MENUGamobjects.WifiBool)
        {
            Instantiate(MENUGamobjects.WifiBlock);
            return;
        }
        MENUGamobjects.YellowDImondCounter.GetComponent<YellowDiamondCounter>().YellowDIamonCoundChange(-buyCount);
        FajlDatabase.WriteIntoTxtFile();
        Debug.Log(buyCount);
    }
    /*public void FreeVideo()
    {
        if (!MENUGamobjects.WifiBool || ido.TotalHours<= hourTimer)
        {
            if (!MENUGamobjects.WifiBool)
            {
                Instantiate(MENUGamobjects.WifiBlock);
            }
            return;
        }
    }*/
    public static void DiamondRewardAds()
    {
        if (FreeVideoText2.active)
        {
            MENUGamobjects.YellowDImondCounter.GetComponent<YellowDiamondCounter>().YellowDIamonCoundChange(-50);
            DateTime mai = DateTime.Now;
            database.FVT = mai;
            ido = mai - database.FVT;
            FajlDatabase.WriteIntoTxtFile();
        }
    }

}
