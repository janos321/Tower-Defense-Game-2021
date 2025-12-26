using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TowerSkillUpdateScript : MonoBehaviour
{
    public Sprite presentImage = null;
    public List<GameObject> SkillText= new List<GameObject>();
    public List<int> SkillMoney=new List<int>();
    public GameObject UpgradeArrowTowerScriptCIrcle;
    public List<GameObject> SmallGreenCircle = new List<GameObject>();
    public GameObject MoneyBackground;
    private int skill = 0;
    public int SkillIndex;
    private void Start()
    {
        MoneyBackground.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = SkillMoney[skill].ToString();
    }
    private void OnMouseDown()
    {
        if ((gameObject.GetComponent<SpriteRenderer>().sprite != AllGameObject.Pipa && gameObject.GetComponent<SpriteRenderer>().sprite != AllGameObject.x)|| skill == SmallGreenCircle.Count)
        {
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().PipaXOFF();
        }
        if (skill == SmallGreenCircle.Count)
            return;
        if (gameObject.GetComponent<SpriteRenderer>().sprite != AllGameObject.Pipa && gameObject.GetComponent<SpriteRenderer>().sprite != AllGameObject.x)
        {
            if (SkillMoney[skill] <= BeginnerMoney.Beginnermoney)
            {
                SkillText[skill].SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().sprite = AllGameObject.Pipa;
            }
            else
            {
                SkillText[skill].SetActive(true);
                gameObject.GetComponent<SpriteRenderer>().sprite = AllGameObject.x;
            }
        }
        else
        if (gameObject.GetComponent<SpriteRenderer>().sprite == AllGameObject.Pipa)
        {
            BeginnerMoney.Beginnermoney -= SkillMoney[skill];
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().money += SkillMoney[skill];
            AllGameObject.MoneyText.GetComponent<Text>().text = BeginnerMoney.Beginnermoney.ToString();
            SmallGreenCircle[skill].GetComponent<SpriteRenderer>().sprite = AllGameObject.greenCircle;
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().PipaXOFF();
            skill++;
            //Debug.Log("LEVEL: " + UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().UpgradeLevel);
            //Debug.Log("SkillIndex: " + SkillIndex);
            AllGameObject.TowerUpgrade(UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().UpgradeLevel, UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().TowerType, UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().HomeTower, SkillIndex);
            if(skill==SkillMoney.Count)
            {
                MoneyBackground.SetActive(false);
            }
            else
            MoneyBackground.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = SkillMoney[skill].ToString();

        }
        else
            if (gameObject.GetComponent<SpriteRenderer>().sprite == AllGameObject.x)
        {
            SkillText[skill].SetActive(false);
        }

    }
}
