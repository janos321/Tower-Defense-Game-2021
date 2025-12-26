using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateListScript : MonoBehaviour
{
    public static int index = 0;
    public static int UpgradeMOney = 10;
    public static GameObject LevelCount;
    public static int maxlevel = 3;
    public static GameObject gameobjectt;
    public static GameObject LevelText;
    private int upgrade;

    public void close()
    {
        StartCoroutine(CameraMove.SkillShopBe(0.3f, gameObject, 1, gameObject.transform.position));
        //gameObject.SetActive(false);//
    }
    public void clickUpgrade()
    {
        upgrade = MENUGamobjects.BuyUpdateValasztas(index, "upgrade");
        if (upgrade >= maxlevel || UpgradeMOney > database.GDC)
            return;
        database.GDC -= UpgradeMOney;
        MENUGamobjects.YellowDImondCounter.GetComponent<Text>().text = database.GDC.ToString();
        upgrade++;
        MENUGamobjects.visszairas(index, upgrade, "upgrade");
        if(upgrade >= maxlevel)
        {
            LevelText.GetComponent<Text>().color = MENUGamobjects.ChangeMaxLevelColor;
            LevelCount.GetComponent<Image>().color = MENUGamobjects.ChangeMaxLevelColor;
        }
        for (int i = 0; i < gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade.Count; i++)
        {
            gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[i].Count += gameobjectt.GetComponent<UpgradeButtonMenu>().Upgrade[i];
        }
        // Fejlesztés helye ----------------------------
        {
            if (index == 1)
            {

                // Lightning update ---------------------------
                MENUGamobjects.LighningAttackPrefab.GetComponent<LighningShadowAtacking>().lightningDamage = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count;
                LighningShadowAtacking.range = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count;
            }
            else
                if (index == 2)
            {
                MENUGamobjects.QuicksandRange.transform.GetChild(0).GetComponent<QuickSandGO>().time = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count;
                MENUGamobjects.QuicksandRange.transform.GetChild(0).localScale = new Vector3(gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count, gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count, 5);
            }
            else
                if (index == 3)
            {
               
                MENUGamobjects.EgyiptianGod.transform.GetChild(0).GetComponent<SoldiersMove>().Damegex = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count;
                MENUGamobjects.EgyiptianGod.transform.GetChild(0).GetComponent<SoldiersMove>().Damegey = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count;
                MENUGamobjects.EgyiptianGod.transform.GetChild(0).GetComponent<SoldiersMove>().maxHP = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[2].Count;
                // Egyiptian God update ----------------------
            }
            else
                if (index == 4)
            {

                // Big quickSand update ----------------------------------
                MENUGamobjects.BigQuicksand.GetComponent<BigQuicksandScript>().demaga = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count;
                MENUGamobjects.BigQuicksand.GetComponent<BigQuicksandScript>().time = gameobjectt.GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count;

            }


        }

        //-----------------------------------------------
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
            LevelCount.GetComponent<Image>().sprite = MENUGamobjects.Level3Count;
        }
        gameObject.SetActive(false);
    }
}
