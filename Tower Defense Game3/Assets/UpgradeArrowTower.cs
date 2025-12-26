using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradeArrowTower : MonoBehaviour
{
    public List<GameObject> upgrade = new List<GameObject>();   
    public int UpgradeLevel = 0;
    public GameObject HomeTower;
    public int TowerType = 1;     // 1=Tower1 ; 2=Tower2
    public int money = 150;
    public void PipaXOFF()
    {
        if(HomeTower.GetComponentInParent<TowerShot>())
        {
            HomeTower.GetComponent<TowerShot>().SegedDestroyButtons.GetComponent<SpriteRenderer>().sprite = HomeTower.GetComponent<TowerShot>().SegedDestroyButtons.GetComponent<TowerDestroyButtonIMage>().PrezentSprite;
           HomeTower.GetComponent<TowerShot>().SegedDestroyButtons.GetComponent<TowerDestroyButtonIMage>().Text.SetActive(false);
        }
        else
            if(HomeTower.GetComponentInParent<TowerOwnSolderBuilding>())
        {
            HomeTower.GetComponent<TowerOwnSolderBuilding>().SegedDestroyButtons.GetComponent<SpriteRenderer>().sprite = HomeTower.GetComponent<TowerOwnSolderBuilding>().SegedDestroyButtons.GetComponent<TowerDestroyButtonIMage>().PrezentSprite;
            HomeTower.GetComponent<TowerOwnSolderBuilding>().SegedDestroyButtons.GetComponent<TowerDestroyButtonIMage>().Text.SetActive(false);
        }
        for (int j = 0; j < upgrade.Count; j++)
        {
            //Debug.Log(upgrade[j].active);
            for (int i = 0; i < upgrade[j].transform.childCount; i++)
            {

                if (upgrade[j].transform.GetChild(i).GetComponentInParent<UpdatePipaButtons>())
                {
                    upgrade[j].transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = upgrade[j].transform.GetChild(i).GetComponent<UpdatePipaButtons>().presentImage;
                    upgrade[j].transform.GetChild(i).GetComponent<UpdatePipaButtons>().SkillText.SetActive(false);
                }
                else
                    if (upgrade[j].transform.GetChild(i).GetComponentInParent<TowerSkillUpdateScript>())
                {
                    upgrade[j].transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = upgrade[j].transform.GetChild(i).GetComponent<TowerSkillUpdateScript>().presentImage;
                    for (int e = 0; e < upgrade[j].transform.GetChild(i).GetComponent<TowerSkillUpdateScript>().SkillText.Count; e++)
                    {
                        if (upgrade[j].transform.GetChild(i).GetComponentInParent<TowerSkillUpdateScript>())
                        {
                            upgrade[j].transform.GetChild(i).GetComponent<TowerSkillUpdateScript>().SkillText[e].SetActive(false);
                        }
                    }
                }
            }
        }
    }
    private int upgradeseged = -1;
    private void Update()
    {
        if (upgradeseged == UpgradeLevel)
            return;
        for(int i=1;i<=upgrade.Count;i++)
        {
            if(i==UpgradeLevel)
            {
                if(!upgrade[i-1].active)
                {
                    upgradeseged = UpgradeLevel;
                    upgrade[i-1].SetActive(true);
                }
            }
            else
            {
                upgrade[i-1].SetActive(false);
            }

        }

    }
}
