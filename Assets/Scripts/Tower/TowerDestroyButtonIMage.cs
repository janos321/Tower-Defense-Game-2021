using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerDestroyButtonIMage : MonoBehaviour
{
    public GameObject Text;
    public GameObject MOney;
    public Sprite PrezentSprite;
    public void OnMouseDown()
    {
        if(MENUGamobjects.TutorialMap!=0)
        {
            return;
        }
        if (gameObject.GetComponent<SpriteRenderer>().sprite == AllGameObject.Pipa)
        {
           
            if (AllGameObject.SegedUpgradeButton != null)
                AllGameObject.SegedUpgradeButton.SetActive(false);
            Destroy(AllGameObject.SegedTowerRangeEllipszis);
            BeginnerMoney.Beginnermoney += Mathf.FloorToInt( MOney.GetComponent<UpgradeArrowTower>().money/3);
            AllGameObject.MoneyText.GetComponent<Text>().text = BeginnerMoney.Beginnermoney.ToString();
            for (int i = 0; i < AllGameObject.SpacesTransform.Length; i++)
            {
                if (AllGameObject.SpacesTransform[i] == AllGameObject.SegedUpgradeTower.transform)
                {
                    AllGameObject.SpacesTransform[i] = null;
                    break;
                }
            }

            Destroy(AllGameObject.SegedUpgradeTower);
        }
        else
        {
            MOney.GetComponent<UpgradeArrowTower>().PipaXOFF();
            gameObject.GetComponent<SpriteRenderer>().sprite = AllGameObject.Pipa;
            Text.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Mathf.FloorToInt(MOney.GetComponent<UpgradeArrowTower>().money / 3).ToString();
            Text.SetActive(true);
        }
    }


}
