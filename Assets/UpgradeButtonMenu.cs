using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpgradeButtonMenu : MonoBehaviour
{
    public int UpgradeMOney = 10;
    public int index = 0;
    public GameObject LevelCount;
    public int maxlevel = 3;
    public GameObject UpgradeLIst;
    //public string Name;
    public List<Present> PresentUpgrade = new List<Present>();//
    public List<int> Upgrade = new List<int>();//
    public GameObject LevelText;
    public int SellMOney = 50;
    public GameObject BuyButton;
    private int buy, upgrade;
    public static Vector3 BuyPanel;
    public static Vector3 DataPanel;
    public static Vector3 UpgradePanel;

    private void Start()
    {
        BuyPanel = MENUGamobjects.BuyList.transform.localScale;
        DataPanel = MENUGamobjects.DataGameobject.transform.localScale;
        UpgradePanel = UpgradeLIst.transform.localScale;
        //MENUGamobjects.BuyObjectsMOney[index] = SellMOney;
    }
    [System.Serializable]
    public class Present
    {
        //public string name;
        public int Count;
    }
    private void Awake()
    {
        //BUY ----------------------
       buy= MENUGamobjects.BuyUpdateValasztas(index,"buy");
        upgrade = MENUGamobjects.BuyUpdateValasztas(index, "upgrade");
        if (buy == 1 || buy == 3)
        {
            BuyButton.GetComponent<Image>().color = MENUGamobjects.BuyingLosColor2;
        }
        else
if (buy == 2 && SellMOney <= database.GDC)
        {
            database.GDC -= SellMOney;
            BuyButton.GetComponent<Image>().color = MENUGamobjects.BuyingLosColor2;
            buy = 3;
            MENUGamobjects.visszairas(index, buy, "buy");
            // Upgrade ---------------
}
            if (upgrade == 1)
            {
                LevelCount.GetComponent<Image>().sprite = MENUGamobjects.Level1Count;
            }
            else
            if (upgrade == 2)
            {
                LevelCount.GetComponent<Image>().sprite = MENUGamobjects.Level2Count;
            }
            else
            if (upgrade == 3)
            {
            LevelText.GetComponent<Text>().color = MENUGamobjects.ChangeMaxLevelColor;
            LevelCount.GetComponent<Image>().color = MENUGamobjects.ChangeMaxLevelColor;
        }
        
    }

    public void BUYclick()
    {
        MENUGamobjects.SkillShopHelp2.SetActive(false);
        MENUGamobjects.DataGameobject.SetActive(false);
        UpgradeLIst.SetActive(false);
        MENUGamobjects.BuyList.SetActive(false);
        MENUGamobjects.ShopLaunguageChange(index);
        buy = MENUGamobjects.BuyUpdateValasztas(index, "buy");
        if (buy == 1 || buy == 3)
            return;
        //MENUGamobjects.BUYNameText.GetComponent<Text>().text = Name;
        MENUGamobjects.BuyPriceText.GetComponent<Text>().text = "-" + SellMOney.ToString();
        MENUGamobjects.PresentInformationBUyText.GetComponent<Text>().text = "";
        for (int i = 0; i < PresentUpgrade.Count; i++)
            MENUGamobjects.PresentInformationBUyText.GetComponent<Text>().text += /*PresentUpgrade[i].name + ": " +*/ PresentUpgrade[i].Count + "\n";
        BuyListScript.index = index;
        BuyListScript.BuyMOney = SellMOney;
        BuyListScript.gameobjectt = BuyButton;
        MENUGamobjects.BuyList.transform.localScale = BuyPanel;
        StartCoroutine(CameraMove.SkillShopBe(0.4f, MENUGamobjects.BuyList, 0, gameObject.transform.position));
        //MENUGamobjects.BuyList.SetActive(true);
    }

    public void DataButton(int index)
    {
        MENUGamobjects.SkillShopHelp2.SetActive(false);
        MENUGamobjects.DataGameobject.SetActive(false);
        UpgradeLIst.SetActive(false);
        MENUGamobjects.BuyList.SetActive(false);
        MENUGamobjects.ShopLaunguageChange(index);
        MENUGamobjects.ShopDataSkillNameText.GetComponent<Text>().text = MENUGamobjects.ShopUpgradeSkillName.GetComponent<Text>().text;
        MENUGamobjects.ShopDataInformation.GetComponent<Text>().text = MENUGamobjects.ShopUpgradeTextSkillName.GetComponent<Text>().text;
        MENUGamobjects.ShopDataInformationCount.GetComponent<Text>().text ="";
        for (int i = 0; i < PresentUpgrade.Count; i++)
            MENUGamobjects.ShopDataInformationCount.GetComponent<Text>().text +=  PresentUpgrade[i].Count + "\n";
        MENUGamobjects.DataGameobject.transform.localScale = DataPanel;
        StartCoroutine(CameraMove.SkillShopBe(0.4f, MENUGamobjects.DataGameobject, 0, gameObject.transform.position));
        //MENUGamobjects.DataGameobject.SetActive(true);
    }
    public void click()
    {
        MENUGamobjects.SkillShopHelp2.SetActive(false);
        MENUGamobjects.DataGameobject.SetActive(false);
        UpgradeLIst.SetActive(false);
        MENUGamobjects.BuyList.SetActive(false);
        MENUGamobjects.ShopLaunguageChange(index);
        upgrade = MENUGamobjects.BuyUpdateValasztas(index, "upgrade");
        if (upgrade >= maxlevel)
            return;
        //MENUGamobjects.NameText.GetComponent<Text>().text = Name;
        MENUGamobjects.PriceText.GetComponent<Text>().text = "-"+UpgradeMOney.ToString();
        MENUGamobjects.PresentInformationText.GetComponent<Text>().text = "";
        MENUGamobjects.UpgradeInformationText.GetComponent<Text>().text = "";
        for (int i=0;i<PresentUpgrade.Count;i++)
        MENUGamobjects.PresentInformationText.GetComponent<Text>().text += /*PresentUpgrade[i].name+": "+*/PresentUpgrade[i].Count+"\n";
        for (int i = 0; i < Upgrade.Count; i++)
            MENUGamobjects.UpgradeInformationText.GetComponent<Text>().text += "+ " + Upgrade[i] + "\n";
        UpdateListScript.index = index;
        UpdateListScript.UpgradeMOney = UpgradeMOney;
        UpdateListScript.LevelCount= LevelCount;
        UpdateListScript.maxlevel = maxlevel;
        UpdateListScript.gameobjectt = gameObject;
        UpdateListScript.LevelText = LevelText;
        UpgradeLIst.transform.localScale = UpgradePanel;
        StartCoroutine(CameraMove.SkillShopBe(0.4f, UpgradeLIst, 0, gameObject.transform.position));
        //UpgradeLIst.SetActive(true);
    }
       
}
