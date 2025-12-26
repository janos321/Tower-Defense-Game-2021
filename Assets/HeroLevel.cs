using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroLevel : MonoBehaviour
{
    public GameObject HeroLevelCounterText;
    public static int presentIndex = 1;
    public GameObject Level;
    private float Presentradio=0;
    public float atackPerPercentage2 = 0.2f;
    public static float atackPerPercentage;
    public float minusz = 0.85f;
    public GameObject Abality2Lock;
    public GameObject BodyIMage;
    private void Start()
    {
        BodyIMage.transform.GetComponent<SpriteRenderer>().sprite = MENUGamobjects.HeroBodyIMages[database.HS].Image;
        BodyIMage.transform.GetComponent<SpriteRenderer>().size = MENUGamobjects.HeroBodyIMages[database.HS].Size;
        BodyIMage.transform.position = new Vector3(BodyIMage.transform.position.x+ MENUGamobjects.HeroBodyIMages[database.HS].pos.x, BodyIMage.transform.position.y + MENUGamobjects.HeroBodyIMages[database.HS].pos.y, BodyIMage.transform.position.z);
        Presentradio = 0;
        presentIndex = 1;
        HeroLevelCounterText.GetComponent<Text>().text = "0";
        atackPerPercentage = atackPerPercentage2;
        Level.GetComponent<Transform>().localScale = new Vector3(0, 1, 1);
    }
    private void Awake()
    {
        Presentradio = 0;
        presentIndex = 1;
        HeroLevelCounterText.GetComponent<Text>().text = "0";
        atackPerPercentage = atackPerPercentage2;
        Level.GetComponent<Transform>().localScale = new Vector3(0,1,1);
    }

    public void HeroDemage()
    {
        if (presentIndex == 9)
            return;

        if (Presentradio + atackPerPercentage < 1)
        {
            Presentradio += atackPerPercentage;
            Level.GetComponent<Transform>().localScale = new Vector3(Presentradio, 1, 1);
        }
        else
        {
                // Hero Ugrade ---------------------------

            
            if(AllGameObject.HERO.GetComponentInParent<CLassicHEroScript>())
            {
                AllGameObject.HERO.GetComponent<CLassicHEroScript>().Damegex*=1.1f;
                AllGameObject.HERO.GetComponent<CLassicHEroScript>().Damegey*= 1.1f;
                AllGameObject.HERO.GetComponent<CLassicHEroScript>().maxHP *= 1.1f;
                AllGameObject.HERO.GetComponent<CLassicHEroScript>().IjaszDamegex *= 1.1f;
                AllGameObject.HERO.GetComponent<CLassicHEroScript>().IjaszDamegey *= 1.1f;
                AllGameObject.HERO.GetComponent<CLassicHEroScript>().changeHP(-AllGameObject.HERO.GetComponent<CLassicHEroScript>().maxHP);
            }
            else
            {
                // többi Hero Level Update
            }





              //  Hero Update Over ---------------------
            presentIndex += 1;
            HeroLevelCounterText.GetComponent<Text>().text = presentIndex.ToString();
            if (presentIndex == 9)
            {
                Level.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
            else
            {
                if(presentIndex==5)
                {
                    Abality2Lock.SetActive(false);
                }
                Presentradio = 0;
                atackPerPercentage *= minusz;
                Level.GetComponent<Transform>().localScale = new Vector3(0, 1, 1);
            }
        }
    }
}
