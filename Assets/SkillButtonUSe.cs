using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillButtonUSe : MonoBehaviour
{
    public GameObject BubbleObjects;
    private bool neyclick=false;
    public GameObject scillObjects = null;
    public void click(bool a)//
    {
        if (CameraMOverClick.mozoge)
            return;
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 18 && MENUGamobjects.TutorialMap != 19)
        {
            return;
        }
        else
        if(MENUGamobjects.TutorialMap != 0)
        {

            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
            if(MENUGamobjects.TutorialMap==20)
            {
                PauseButtonImagePause.Bool = true;
                AllGameObject.PauseMenuPanel.SetActive(PauseButtonImagePause.Bool);
                AllGameObject.Kulsok.SetActive(!PauseButtonImagePause.Bool);
                AllGameObject.attackfromheavenButton.SetActive(!PauseButtonImagePause.Bool);
                AllGameObject.OwnUnitSoldiersButton1.SetActive(!PauseButtonImagePause.Bool);
                AllGameObject.BubbleAllSkillObjects.SetActive(!PauseButtonImagePause.Bool);
                AllGameObject.HeroButton.SetActive(!PauseButtonImagePause.Bool);
            }
        }
        if (a)
        AllGameObject.SetactiveFalse(11);
        if(!a)
        {
            neyclick = true;
        }
        int buy= MENUGamobjects.BuyUpdateValasztas(1, "buy");
        if (buy == 0 || buy == 2)
        {
            AllGameObject.LightningButton.GetComponent<Image>().color =AllGameObject.Darkening;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(2, "buy");
        if (buy == 0 || buy == 2)
        {
            AllGameObject.quicksandButton.GetComponent<Image>().color = AllGameObject.Darkening;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(3, "buy");
        if (buy == 0 || buy == 2)
        {
            AllGameObject.EgyptianGodButton.GetComponent<Image>().color = AllGameObject.Darkening;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(4, "buy");
        if (buy == 0 || buy == 2)
        {
            AllGameObject.BigquicksandButton.GetComponent<Image>().color = AllGameObject.Darkening;
        }
        scillObjects.SetActive(!neyclick);
            BubbleObjects.SetActive(neyclick);
            neyclick = !neyclick;

    }
}
