using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class location : MonoBehaviour
{
    public int Spaceindex=0;
    private GameObject Mother;
    public static int Towerindex=0;
    public static int TowerMoney = 0;

    void OnMouseDown()
    {
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 3)
        {
            return;
        }
        else
        if(Spaceindex == 2 &&MENUGamobjects.TutorialMap != 0)
        {
           
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        else
                if (MENUGamobjects.TutorialMap != 0)
        {
            return;
        }
        AllGameObject.KonnyebbenLehessenLerakniATornyokat();
        AllGameObject.SetactiveFalse(-1);
        if (AllGameObject.SpacesTransform[Spaceindex] != null||BeginnerMoney.Beginnermoney<TowerMoney)
            return;

        Mother =((GameObject)Instantiate(AllGameObject.Towers[Towerindex],  gameObject.transform.position+new Vector3(0.2f,1f,0),Quaternion.identity));
        Mother.transform.parent = GameObject.Find("Tower").transform;
        if (MENUGamobjects.TutorialMap == 0)
        {
            if (Mother.GetComponentInParent<TowerShot>())
            {
                SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "IjTowerEpites");
                Mother.GetComponent<TowerShot>().UpgradeArrowTowerScriptCIrcle.transform.localScale = new Vector3(Mother.GetComponent<TowerShot>().UpgradeArrowTowerScriptCIrcle.transform.localScale.x * AllGameObject.MainCamera.GetComponent<Zoomer>().ScalePersentage / 100, Mother.GetComponent<TowerShot>().UpgradeArrowTowerScriptCIrcle.transform.localScale.y * AllGameObject.MainCamera.GetComponent<Zoomer>().ScalePersentage / 100, 5);
                AllGameObject.MainCamera.GetComponent<Zoomer>().ChangeScaleObject.Add(Mother.GetComponent<TowerShot>().UpgradeArrowTowerScriptCIrcle);
            }
            else
                  if (Mother.GetComponentInParent<TowerOwnSolderBuilding>())
            {
                SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "katonatoronyupgrade+epites1");
                Mother.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.localScale = new Vector3(Mother.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.localScale.x * AllGameObject.MainCamera.GetComponent<Zoomer>().ScalePersentage / 100, Mother.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.localScale.y * AllGameObject.MainCamera.GetComponent<Zoomer>().ScalePersentage / 100, 5);
                AllGameObject.MainCamera.GetComponent<Zoomer>().ChangeScaleObject.Add(Mother.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle);
            }
        }
        else
        {
                SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "IjTowerEpites");
        }
        AllGameObject.SpacesTransform[Spaceindex] = Mother.transform;
        if (AllGameObject.SpacesTransform[Spaceindex].GetComponentInParent<TowerOwnSolderBuilding>())
        {
            if(gameObject.transform.GetChild(0).gameObject.transform.position.y-gameObject.transform.position.y>0)
            {
                Mother.GetComponent<SpriteRenderer>().sprite = IMAGE.OwnsolderTowerSecuendLVL1;
                Mother.GetComponent<TowerOwnSolderBuilding>().Gate.SetActive(false);
            }
            AllGameObject.SpacesTransform[Spaceindex].GetComponent<TowerOwnSolderBuilding>().Aim = gameObject.transform.GetChild(0).gameObject.transform.position;
            AllGameObject.SpacesTransform[Spaceindex].GetComponent<TowerOwnSolderBuilding>().FirstPosition = gameObject.transform.GetChild(0).gameObject.transform.position;
        }
        BeginnerMoney.Beginnermoney -= TowerMoney;
        AllGameObject.MoneyText.GetComponent<Text>().text = BeginnerMoney.Beginnermoney.ToString();
    }
}
