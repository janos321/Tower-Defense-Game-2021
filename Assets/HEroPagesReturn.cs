using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEroPagesReturn : MonoBehaviour
{
    public GameObject firstSide;
    public GameObject SecondSide;
    public GameObject SkillImage;
    public GameObject SkillText;
    public int Money;
    public string MoneyType;
    public GameObject HERO;
    public GameObject Pipa;
    public GameObject buyButton;
    public static int poroge = 0;
    public bool QuistioMark;
    public void click()
    {
        MENUGamobjects.HeroShopHelp2.SetActive(false);
        if (QuistioMark)
            return;
        if (HeroPagesMOver.ChoicePage == gameObject)
        {
            if(buyButton!=null)
            buyButton.SetActive(false);
            poroge = 1;
        StartCoroutine(porgetes(1));
        }

    }
    IEnumerator porgetes(float timer)
    {
        if (QuistioMark)
           yield return null;
        float time = 0;
        float a = gameObject.transform.rotation.x;
        float b = gameObject.transform.rotation.x + 180;
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 0;
        rotationVector.z = 0;
        while (time < timer/2)
        {
            if (HeroPagesMOver.ChoicePage != gameObject)
            {
                break;
            }
                rotationVector.y = Mathf.Lerp(a, b, time / timer);
                gameObject.transform.rotation = Quaternion.Euler(rotationVector);
                yield return time += Time.deltaTime;
            }
            if (firstSide.active)
            {
                SecondSide.SetActive(true);
                firstSide.SetActive(false);
            SecondSide.transform.rotation = Quaternion.Euler(0,180,0);
        }
            else
            {
                firstSide.SetActive(true);
                SecondSide.SetActive(false);
            firstSide.transform.rotation = Quaternion.Euler(0, 180, 0);

        }        
        while (time < timer)
        {
            if (HeroPagesMOver.ChoicePage != gameObject)
            {
                break;
            }
            rotationVector.y = Mathf.Lerp(a, b, time / timer);
            gameObject.transform.rotation = Quaternion.Euler(rotationVector);
            if (firstSide.active)
            {
                firstSide.transform.rotation = Quaternion.Euler(0, rotationVector.y+180, 0);
            }
            else
            {
                SecondSide.transform.rotation = Quaternion.Euler(0, rotationVector.y + 180, 0);

            }
            yield return time += Time.deltaTime;
        }
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (firstSide.active)
        {
            firstSide.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            SecondSide.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
        poroge = 0;
        if (database.ALN[HeroPagesMOver.PagesIndex] != 0 && HeroPagesMOver.PagesIndex != 5&&buyButton!=null)
        {
            buyButton.SetActive(true);
        }
    }

    
}
