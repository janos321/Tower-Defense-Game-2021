using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerUpgradeButton : MonoBehaviour
{
   /* public string Tower1 = "Tower1 Update data------";
    public float rangeTower1levelup = 1.2f;
    public float timerMaxlevelup = 1.2f;
    public float damage1levelup = 1.2f;
    public string Tower2 = "Tower2 Update data------";
    public float rangeTower2levelup = 1.2f;
    public float OwnSoldiersRelodinglevelup = 1.2f;
    public float OwnSoldersdamage1levelup = 1.2f;
    public float OwnSoldiersrangelevelup = 1.2f;
    public void OnMouseDown()
    {
        if (AllGameObject.SegedUpgradeTower.GetComponentInParent<TowerShot>())
        {
            if (AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().level < AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().maxLevel && BeginnerMoney.Beginnermoney >= AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().levelupMoney)
            {
                BeginnerMoney.Beginnermoney -= AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().levelupMoney;
                AllGameObject.MoneyText.GetComponent<Text>().text = BeginnerMoney.Beginnermoney.ToString();
                TowerShot.x = 1;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().level++;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().validrange *= rangeTower1levelup;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().range *= rangeTower1levelup;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().damage1 *= damage1levelup;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().timerMax *= timerMaxlevelup;
                AllGameObject.SegedTowerRangeEllipszis.transform.localScale = new Vector3(AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().range, AllGameObject.SegedUpgradeTower.GetComponent<TowerShot>().range, 1);
                TowerShot.x = 0;
            }
        }
        else
            if(AllGameObject.SegedUpgradeTower.GetComponentInParent<TowerOwnSolderBuilding>())
        {
            if (AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().level < AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().maxLevel && BeginnerMoney.Beginnermoney >= AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().levelupMoney)
            {
                AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().level++;
                BeginnerMoney.Beginnermoney -= AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().levelupMoney;
                AllGameObject.MoneyText.GetComponent<Text>().text = BeginnerMoney.Beginnermoney.ToString();
                TowerOwnSolderBuilding.x = 1;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().validrange *= rangeTower2levelup;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().range *= rangeTower2levelup;
                AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().timerMax *= OwnSoldiersRelodinglevelup;
                AllGameObject.SegedTowerRangeEllipszis.transform.localScale = new Vector3(AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().range, AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().range, 1);
               for(int i=0;i< AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count;i++)
                {
                    AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegex *= OwnSoldersdamage1levelup;
                    AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegey *= OwnSoldersdamage1levelup;
                    AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().range *= OwnSoldiersrangelevelup;
                }

                TowerOwnSolderBuilding.x = 0;
            }
        }
    }*/
}
