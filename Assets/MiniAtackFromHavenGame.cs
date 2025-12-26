using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniAtackFromHavenGame : MonoBehaviour
{
    public GameObject SecoundButton = null;
    public float LoadTime;
    //public float RADIO;
    private bool a = true;
    private void Start()
    {
        MiniMapOnMosueClickGame.voltmar = true;
    }
    public void Arrows()
    {

       // MiniGameAllScript.SetactiveFalse(0);
        if (a)
        {
            /*MiniGameAllScript.attackfromheavenClickBool = true;
            StartCoroutine(MiniMapOnMosueClickGame.varakoztatas(0.1f));*/
            MiniGameAllScript.attackfromheavenClickBool = !MiniGameAllScript.attackfromheavenClickBool;
            if (MiniGameAllScript.attackfromheavenClickBool)
            {
                gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            }
        }
    }
    //private float PresentTime = 0.1f;
    [System.Obsolete]

    private void Update()
    {
        if (MiniPousIMageGAme.Bool || !MiniMapOnMosueClickGame.voltmar)
            return;
        if (!SecoundButton.active)
            SecoundButton.SetActive(true);
        if (MiniGameAllScript.AttackfromHavenTimer <= 0)
        {
            MiniMapOnMosueClickGame.voltmar = false;
            SecoundButton.SetActive(false);
            MiniGameAllScript.AttackfromHavenTimer = 0.1f;
            a = true;
            return;
        }
        if (MiniGameAllScript.AttackfromHavenTimer == 0.1f)
        {
            a = false;
            MiniGameAllScript.AttackfromHavenTimer = LoadTime;
            SecoundButton.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            SecoundButton.GetComponent<Image>().fillAmount = 1;
        }
        MiniGameAllScript.AttackfromHavenTimer -= Time.deltaTime;
        SecoundButton.GetComponent<Image>().fillAmount = MiniGameAllScript.AttackfromHavenTimer / LoadTime;


    }
}
