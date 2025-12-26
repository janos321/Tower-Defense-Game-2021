using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticPipaButtonMenu : MonoBehaviour
{
    public int index=0;
    private int buy;
    private void Awake()
    {
        buy = MENUGamobjects.BuyUpdateValasztas(index, "buy");
        if (buy > 1)
            {
                gameObject.GetComponent<Image>().sprite = MENUGamobjects.PIPA2;
                gameObject.GetComponent<SpriteRenderer>().sprite = MENUGamobjects.PIPA2;
            }
        
    }
    public void click()
    {
        MENUGamobjects.SkillShopHelp2.SetActive(false);
                if (gameObject.GetComponent<Image>().sprite == MENUGamobjects.PIPA2) {
            buy = MENUGamobjects.BuyUpdateValasztas(index, "buy");
            if (buy == 2)
            {
                 MENUGamobjects.visszairas(index, 0, "buy");
            }
            else
            if (buy == 3)
            {
                MENUGamobjects.visszairas(index, 1, "buy");
            }
            gameObject.GetComponent<Image>().sprite = MENUGamobjects.NONPIPA2;
            gameObject.GetComponent<SpriteRenderer>().sprite = MENUGamobjects.NONPIPA2;
        }
        else
        {
            if(buy == 1)
            {
                MENUGamobjects.visszairas(index, 3, "buy");
            }
            else
            if (buy == 0)
            {
                MENUGamobjects.visszairas(index, 2, "buy");
            }
            gameObject.GetComponent<Image>().sprite = MENUGamobjects.PIPA2;
            gameObject.GetComponent<SpriteRenderer>().sprite = MENUGamobjects.PIPA2;
        }
    }
}
