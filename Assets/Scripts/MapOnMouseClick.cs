using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class MapOnMouseClick : MonoBehaviour
{

    public static bool voltmar = false;
    public static bool voltmarOwnSoldiers = false;
    public static int masrakatintottam = 0;
    private int buy;
    
    private void Start()
    {

        for (int j=1,k=0; k < MENUGamobjects.BuyObjectsMOney.Count; k++,j++)
        {
            buy = MENUGamobjects.BuyUpdateValasztas(j, "buy");
            if (buy == 2 && MENUGamobjects.BuyObjectsMOney[k] <= database.GDC)
            {
                database.GDC -= MENUGamobjects.BuyObjectsMOney[k];
                MENUGamobjects.visszairas(j, 3, "buy");
            }
        }
        AllGameObject.INBubbleskillObjectsDarking();
    }[System.Obsolete]
    public static IEnumerator varakoztatas(float a)
    {
        Vector3 click = AllGameObject.MainCamera.ScreenToWorldPoint(Input.mousePosition)+new Vector3(0,0,10);
        click.z = 10;
        yield return new WaitForSeconds(a);
        if (masrakatintottam == 0)
        {
            if (MENUGamobjects.TutorialMap == 0) { 
            if (AllGameObject.Spaces.active)
            {
                AllGameObject.KonnyebbenLehessenLerakniATornyokat();
                GameObject X = Instantiate(AllGameObject.X, click, Quaternion.identity);
                X.transform.parent = GameObject.Find("Tower").transform;
            }
            AllGameObject.SetactiveFalse(-5);
                }
            {
                if(AllGameObject.heroactive)
                {
                    click.z = 0;
                    AllGameObject.HeroButton.GetComponent<UnityEngine.UI.Image>().color = Color.white;
                    if (AllGameObject.designateCaracter != AllGameObject.HERO)
                    {
                        AllGameObject.heroactive = false;
                    }
                    if (AllGameObject.IsItInMapRoads(click))
                    {
                        if (MENUGamobjects.TutorialMap != 0)
                        {
                            MENUGamobjects.TutorialMap++;
                            TutorialScript.ChangePages();
                        }
                        if (AllGameObject.HERO == null)
                        {
                            AllGameObject.HeroLevelBacgroundIMage.GetComponent<HeroLevel>().HeroLevelCounterText.GetComponent<Text>().text = "1";
                            AllGameObject.HERO = Instantiate(MENUGamobjects.HERO, click, Quaternion.identity);
                            AllGameObject.heroactive = false;
                        }
                        else
                        {
                            if (AllGameObject.HERO.GetComponentInParent<CLassicHEroScript>())
                            {
                                if (AllGameObject.HERO.GetComponent<CLassicHEroScript>().Target != null)
                                {
                                    if (AllGameObject.HERO.GetComponent<CLassicHEroScript>().Target.GetComponentInParent<EnemyMove>())
                                    {
                                        AllGameObject.HERO.GetComponent<CLassicHEroScript>().Target.GetComponent<EnemyMove>().target2.Remove(AllGameObject.HERO.transform);
                                    }
                                }
                                else
                                {
                                    //többi ennemy
                                }
                                AllGameObject.HERO.GetComponent<CLassicHEroScript>().Target = null;
                                AllGameObject.HERO.GetComponent<CLassicHEroScript>().target2 = click;
                            }
                            else
                            {
                                //többi HERO
                            }
                        }
                    }
                    else
                    {
                        if(MENUGamobjects.TutorialMap!=0)
                        {
                            AllGameObject.heroactive = true;
                        }
                        GameObject X = Instantiate(AllGameObject.X, click, Quaternion.identity);
                        X.transform.parent = GameObject.Find("Tower").transform;
                    }    
                }
                if (AllGameObject.Lightning)
                {
                    if (AllGameObject.IsItInMapRoads(click))
                    {
                        AllGameObject.Lightning = false;
                        int buy = MENUGamobjects.BuyUpdateValasztas(1, "buy");
                        if (buy == 1)
                        {
                            MENUGamobjects.visszairas(1, 0, "buy");
                        }
                        else
                        {  MENUGamobjects.visszairas(1, 2, "buy"); }
                        AllGameObject.INBubbleskillObjectsDarking();
                        AllGameObject.LightningButton.GetComponent<UnityEngine.UI.Image>().color = AllGameObject.Darkening;
                        FajlDatabase.WriteIntoTxtFile();
                        SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial,"villám halkul cut");
                        //elvegez-----
                        {
                            GameObject X = Instantiate(MENUGamobjects.LighningAttackPrefab, click, Quaternion.identity);
                        }
                    }
                }
                if (AllGameObject.quicksand)
                {
                    if (AllGameObject.IsItInMapRoads(click))
                    {
                        AllGameObject.quicksand = false;
                        int buy = MENUGamobjects.BuyUpdateValasztas(2, "buy");
                        if (buy == 1)
                        {
                            MENUGamobjects.visszairas(2, 0, "buy");
                        }
                        else
                        { MENUGamobjects.visszairas(2, 2, "buy"); }
                        AllGameObject.INBubbleskillObjectsDarking();
                        AllGameObject.quicksandButton.GetComponent<UnityEngine.UI.Image>().color = AllGameObject.Darkening;
                        FajlDatabase.WriteIntoTxtFile();
                        SoundsScript.MusicStart( AllGameObject.SinglePlayerMApsAndTutorial,"futóhomok cut");

                        //elvegez-----
                        {
                            GameObject X = Instantiate(MENUGamobjects.QuicksandRange, click, Quaternion.identity);
                        }
                    }
                }
                if (AllGameObject.EgyptianGod)
                {
                    if (AllGameObject.IsItInMapRoads(click))
                    {
                        AllGameObject.EgyptianGod = false;
                        int buy = MENUGamobjects.BuyUpdateValasztas(3, "buy");
                        if (buy == 1)
                        {
                            MENUGamobjects.visszairas(3, 0, "buy");
                        }
                        else
                        { MENUGamobjects.visszairas(3, 2, "buy");  }
                        AllGameObject.INBubbleskillObjectsDarking();
                        AllGameObject.EgyptianGodButton.GetComponent<UnityEngine.UI.Image>().color = AllGameObject.Darkening;

                        //elvegez-----
                       GameObject EgyiptianGod= Instantiate(MENUGamobjects.EgyiptianGod, click, Quaternion.identity);
                        EgyiptianGod.transform.GetChild(0).GetComponent<SoldiersMove>().Skill.Add(0); EgyiptianGod.transform.GetChild(0).GetComponent<SoldiersMove>().Skill.Add(0); EgyiptianGod.transform.GetChild(0).GetComponent<SoldiersMove>().Skill.Add(0);
                        FajlDatabase.WriteIntoTxtFile();
                    }
                }
                if (AllGameObject.Bigquicksand)
                {
                    if (AllGameObject.IsItInMapRoads(click))
                    {

                        AllGameObject.Bigquicksand = false;
                        int buy = MENUGamobjects.BuyUpdateValasztas(4, "buy");
                        if (buy == 1)
                        {
                            MENUGamobjects.visszairas(4, 0, "buy");
                        }
                        else
                        { MENUGamobjects.visszairas(4, 2, "buy"); }
                        AllGameObject.INBubbleskillObjectsDarking();
                        AllGameObject.BigquicksandButton.GetComponent<UnityEngine.UI.Image>().color = AllGameObject.Darkening;
                        //elvegez-----
                        {
                            for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
                            {
                                AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().TimeBigQuicksandTime = MENUGamobjects.BigQuicksand.GetComponent<BigQuicksandScript>().time;
                            }
                            FajlDatabase.WriteIntoTxtFile();
                        }
                    }
                }
                if (AllGameObject.OwnUNitSoldiersClickBool)
                {
                    if (AllGameObject.IsItInMapRoads(click))
                    {
                        if (MENUGamobjects.TutorialMap != 0)
                        {
                            MENUGamobjects.TutorialMap++;
                            TutorialScript.ChangePages();
                        }
                        Transform Shadow = Instantiate(AllGameObject.OwnSoldier.transform, click, AllGameObject.Starts[0].transform.rotation);
                        Shadow.SetParent(GameObject.Find("Soldiers").transform);
                        Shadow.GetComponent<SoldiersMove>().Skill.Add(0); Shadow.GetComponent<SoldiersMove>().Skill.Add(0); Shadow.GetComponent<SoldiersMove>().Skill.Add(0);
                        voltmarOwnSoldiers = true;
                        AllGameObject.OwnUNitSoldiersClickBool = false;
                    }
                }
                if (AllGameObject.attackfromheavenClickBool)
                {

                    if (AllGameObject.IsItInMapRoads(click))
                    {
                        if (MENUGamobjects.TutorialMap != 0)
                        {
                            MENUGamobjects.TutorialMap++;
                            TutorialScript.ChangePages();
                        }
                        AllGameObject.ShadowArrow.SetActive(true);
                        AllGameObject.BPositionAttack.transform.position = click;
                        AllGameObject.APositionAttack.transform.position = new Vector3(AllGameObject.BPositionAttack.transform.position.x, AllGameObject.APositionAttack.transform.position.y, 1f);

                        SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "Nyilaskepessegvágott");
                        Instantiate(AllGameObject.attackfromheavenArrows.transform, AllGameObject.APositionAttack.position, AllGameObject.attackfromheavenArrows.transform.rotation);
                        AllGameObject.BPositionAttack.transform.position = click;
                        AllGameObject.APositionAttack.transform.position = new Vector3(AllGameObject.BPositionAttack.transform.position.x, AllGameObject.APositionAttack.transform.position.y, 1f);

                        AllGameObject.attackfromheavenClickBool = false;
                        voltmar = true;
                    }

                }
            }
        }
        else
        {
            masrakatintottam = 0;
        }
    }
    [System.Obsolete]
    public void OnMouseDown()
    {
        StartCoroutine(varakoztatas(0.1f));      
    }

}
