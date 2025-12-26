using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdatePipaButtons : MonoBehaviour
{
    public Sprite presentImage=null;
    public GameObject SkillText;
    public int SkillMoney;
    public int next;
    public GameObject UpgradeArrowTowerScriptCIrcle;
    public int index = 0;
    public GameObject MoneyBackground;
    private void Start()
    {
        MoneyBackground.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = SkillMoney.ToString();
    }
    private void OnMouseDown()
    {
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 6&& MENUGamobjects.TutorialMap != 7)
        {
            return;
        }
        else
         if (MENUGamobjects.TutorialMap != 0)
        {
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite != AllGameObject.Pipa&& gameObject.GetComponent<SpriteRenderer>().sprite != AllGameObject.x)
        {
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().PipaXOFF();
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite!= AllGameObject.Pipa && gameObject.GetComponent<SpriteRenderer>().sprite != AllGameObject.x)
        {
            if (SkillMoney <= BeginnerMoney.Beginnermoney)
            {
                SkillText.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().sprite = AllGameObject.Pipa;
            }
            else
            {
                SkillText.SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().sprite = AllGameObject.x;
            }
        }
        else
        if(gameObject.GetComponent<SpriteRenderer>().sprite == AllGameObject.Pipa)
        {
                BeginnerMoney.Beginnermoney -= SkillMoney;
                AllGameObject.MoneyText.GetComponent<Text>().text = BeginnerMoney.Beginnermoney.ToString();    
            AllGameObject.TowerUpgrade(UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().UpgradeLevel, UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().TowerType, UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().HomeTower,index);
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().UpgradeLevel += next;
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().money += SkillMoney;
        }
        else
            if(gameObject.GetComponent<SpriteRenderer>().sprite == AllGameObject.x)
        {
            SkillText.SetActive(false);
        }

    }
}
