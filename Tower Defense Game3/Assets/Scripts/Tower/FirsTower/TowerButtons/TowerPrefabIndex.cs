using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPrefabIndex : MonoBehaviour
{
    public int index = 0;
    public int TowerMoney = 0;

    [System.Obsolete]
    void OnMouseDown()
    {
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 2)
        {
            return;
        }
        else
        if(index == 0 &&        MENUGamobjects.TutorialMap != 0)
        {
            
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        else
                if (MENUGamobjects.TutorialMap != 0)
        {
            return;
        }
        AllGameObject.SetactiveFalse(-1);
        lenullazo();
        AllGameObject.BubbleAllSkillObjects.SetActive(false);
        AllGameObject.attackfromheavenButton.SetActive(false);
        //AllGameObject.attackfromheavenClickBool = false;
        AllGameObject.OwnUnitSoldiersButton1.SetActive(false);
        AllGameObject.OwnUNitSoldiersClickBool = false;
        AllGameObject.Xess[index].SetActive(true);
        AllGameObject.Spaces.SetActive(true);
        for (int i=0;i< AllGameObject.Spaceses.Count;i++)
        {
            if (AllGameObject.SpacesTransform[i+1] == null)
            {
                AllGameObject.Spaceses[i].SetActive(true);
            }
            else
                AllGameObject.Spaceses[i].SetActive(false);

        }
        location.Towerindex = index;
        location.TowerMoney = TowerMoney;
        
    }

    [System.Obsolete]
    void lenullazo()
    {
        for (int i=0;i<AllGameObject.Xess.Count;i++)
        {
            //if(XessActiveOrNotactive.Xess[i]!=null)
            AllGameObject.Xess[i].SetActive(false);
        }
    }
}
