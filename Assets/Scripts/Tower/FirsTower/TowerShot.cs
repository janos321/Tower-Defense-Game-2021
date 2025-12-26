using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TowerShot : MonoBehaviour
{
    public float range=0;
 //innen lovodik ki a golyo
    //public float fireRate = 2;
    public float timerMax=0.5f;
    //public int maxLevel=4;
    //public int levelupMoney = 0;
    public float damage1;
    public string vege = "------------------------";
    //public int level=1;
    public float validrange = 0;
    private float timer = 0;
    //public Transform shootPosBazic;
    //public Transform shootPos1;
    //public Transform shootPos2;
    public int kepsseg1 = 0, kepsseg2 = 0, kepsseg3 =5;
    //public static float damage;
    public GameObject TowerUpgradeCanvas;
    public GameObject UpgradeArrowTowerScriptCIrcle;
    public GameObject SegedDestroyButtons;
    public GameObject TowerUpgrade1;
    public GameObject TowerUpgrade2;
    public GameObject TowerUpgrade3;
    public GameObject TowerUpgrade4;

    //private GameObject TowerUpgradeButtonPosition = null;
    private GameObject TowerDestroyButtonPosition = null;
    private GameObject TowerRangeEllipszisPosition = null;
    private Transform enemy=null;
    public Read LANG;
    [System.Serializable]
    public class Translate
    {
        public List<GameObject> Text = new List<GameObject>();
        public List<string> Languasges = new List<string>();
    }
    [System.Serializable]
    public class Read
    {
        public List<string> Langs = new List<string>();
        public List<Translate> TextCount = new List<Translate>();
    }
    private void Awake()
    {
       float TowerRangeSize = Mathf.Sqrt(Mathf.Sqrt(Mathf.Sqrt((CameraMove.mapMaxX - CameraMove.mapMinX) * (CameraMove.mapMaxY - CameraMove.mapMinY) / 1500)));
        LanguagesChange(database.LNG, LANG);
        kepsseg3 = 5;
        AllGameObject.TowerRangeEllipszis.transform.localScale = new Vector3(range*4/5, range*4/5, 0);
        validrange = range*3;
        //TowerUpgradeButtonPosition = gameObject.transform.GetChild(1).gameObject;
        TowerDestroyButtonPosition = gameObject.transform.GetChild(0).gameObject;
        TowerRangeEllipszisPosition = gameObject.transform.GetChild(1).gameObject;


    }
    public static void LanguagesChange(string Lang, Read LANg)
    {
        database.LNG = Lang;
        int index = 0;
        for (int i = 0; i < LANg.Langs.Count; i++)
        {
            if (Lang == LANg.Langs[i])
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < LANg.TextCount.Count; i++)
        {
            for (int j = 0; j < LANg.TextCount[i].Text.Count; j++)
            {
                if (LANg.TextCount[i].Languasges[index].IndexOf('|') == -1)
                {
                    LANg.TextCount[i].Text[j].GetComponent<Text>().text = LANg.TextCount[i].Languasges[index];
                }
                else
                {
                    string[] split = LANg.TextCount[i].Languasges[index].Split('|');
                    LANg.TextCount[i].Text[j].GetComponent<Text>().text = split[0];
                    for (int k = 1; k < split.Length; k++)
                    {
                        LANg.TextCount[i].Text[j].GetComponent<Text>().text += "\n" + split[k];
                    }
                }
            }
        }
    }
    private bool nez = false;
    //private float animation = 0;
    private int direction = 1;
    private void Update()
    {
        if (PauseButtonImagePause.Bool)
                    return;
        timer += Time.deltaTime;
        //animation -= Time.deltaTime;
      /* if(/*timer<0.4f&&timer>0.3&&*/ /*animation<=0)
        {
            animation = 100;
            ClassicPosition();
            
        }*/
        float animationTime = 0.35f;
        if (timerMax-timer< animationTime && enemy==null)
        {
           //animation = animationTime;
            enemy = getClosestEnemy(AllGameObject.AllEnemys, TowerRangeEllipszisPosition.transform.position, validrange);
            if (enemy != null)
            {
                Vector3 local = enemy.position - gameObject.transform.position;
                AttackAnimation(local);
            }
        }
        if (timer >=timerMax)
        {
            timer = 0;
            //Transform enemy = getClosestEnemy(AllGameObject.AllEnemys, TowerRangeEllipszisPosition.transform.position, validrange);
            if (enemy != null )
            {
                if(TowerUpgrade1.active)
                {
                    TowerArrow.Create(TowerUpgrade1.transform.GetChild(0).transform.GetChild(0).position, enemy, damage1);
                }
                else
                {
                    GameObject a=null;
                    if (TowerUpgrade2.active)
                    {
                        a = TowerUpgrade2;
                         }
                    else
                    if (TowerUpgrade3.active)
                    {
                        a = TowerUpgrade3;
                         }
                    else
                    if (TowerUpgrade4.active)
                    {
                        a = TowerUpgrade4;
                         }

                    int r = Random.Range(0, 100);
                    if (nez)
                    {
                        if (r <= kepsseg1 &&kepsseg1!=0)
                        {
                            TowerArrow.Create(a.transform.GetChild(0).transform.GetChild(0).position, enemy, 300);
                        }
                        else
                        if (r <= kepsseg2 && kepsseg2 != 0)
                        {
                            TowerArrow.Create(a.transform.GetChild(0).transform.GetChild(0).position, enemy, 100);
                            Transform Shadow = Instantiate(AllGameObject.OwnSoldier.transform, enemy.position, AllGameObject.Starts[0].transform.rotation);
                            Shadow.SetParent(GameObject.Find("Soldiers").transform);
                        }
                        else
                        if (r <= kepsseg3&&r>5 && kepsseg3 != 5)
                        {
                            TowerArrow.Create(a.transform.GetChild(0).transform.GetChild(0).position, enemy, damage1);
                            if (enemy.GetComponentInParent<EnemyMove>())
                            {
                                enemy.GetComponent<EnemyMove>().ArrowTowerPoison += 2 * kepsseg3;
                            }
                        }
                        else
                        {
                            TowerArrow.Create(a.transform.GetChild(0).transform.GetChild(0).position, enemy, damage1);
                        }
                    }
                    else
                    {

                        if (r <= kepsseg1 && kepsseg1 != 0)
                        {
                            TowerArrow.Create(a.transform.GetChild(1).transform.GetChild(0).position, enemy, 300);
                        }
                        else
                           if (r <= kepsseg2 && kepsseg2 != 0)
                        {
                            TowerArrow.Create(a.transform.GetChild(1).transform.GetChild(0).position, enemy, 100);
                            Transform Shadow = Instantiate(AllGameObject.OwnSoldier.transform, enemy.position, AllGameObject.Starts[0].transform.rotation);
                            Shadow.SetParent(GameObject.Find("Soldiers").transform);
                        }
                        else
                            if (r <= kepsseg3 && r > 5 && kepsseg3 != 5)
                        {
                            TowerArrow.Create(a.transform.GetChild(1).transform.GetChild(0).position, enemy, damage1);
                            if(enemy.GetComponentInParent<EnemyMove>())
                            {
                                enemy.GetComponent<EnemyMove>().ArrowTowerPoison += 2 * kepsseg3;
                            }
                        }
                        else
                        {
                            TowerArrow.Create(a.transform.GetChild(1).transform.GetChild(0).position, enemy, damage1);
                        }
                    }
                }
            }
            //animation = 100;
            ClassicPosition();
            enemy = null;
            nez = !nez;
        }


    }
    public static int x = 0;
    public void OnMouseDown()
    {
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 5)
        {
            return;
        }
        else
        if(MENUGamobjects.TutorialMap!=0)
        {
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        AllGameObject.SetactiveFalse(1);

        if (MENUGamobjects.TutorialMap == 0)
        {
            AllGameObject.KarakterSkillAd(-1, -1, timerMax, -1, damage1, damage1, gameObject.GetComponent<SpriteRenderer>().sprite, gameObject, new Vector2(90, 60));
        }



        if (x == 0 && AllGameObject.SegedUpgradeTower != gameObject)
        {
            if(AllGameObject.SegedUpgradeButton!=null)
            AllGameObject.SegedUpgradeButton.SetActive(false);
            Destroy(AllGameObject.SegedTowerRangeEllipszis);
            //Destroy(AllGameObject.SegedDestroyButton);
            TowerUpgradeCanvas.SetActive(true);
            //SegedDestroyButtons = AllGameObject.SegedDestroyButton = Instantiate(AllGameObject.DestroyButton, TowerDestroyButtonPosition.transform.position, gameObject.transform.rotation);
            SegedDestroyButtons.GetComponent<TowerDestroyButtonIMage>().MOney = UpgradeArrowTowerScriptCIrcle;
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().PipaXOFF();
            AllGameObject.SegedUpgradeButton = TowerUpgradeCanvas;
            //AllGameObject.SegedUpgradeButton = Instantiate(AllGameObject.UpgradeButton, TowerUpgradeButtonPosition.transform.position, gameObject.transform.rotation);
            AllGameObject.SegedTowerRangeEllipszis = Instantiate(AllGameObject.TowerRangeEllipszis, TowerRangeEllipszisPosition.transform.position, gameObject.transform.rotation);
            AllGameObject.SegedTowerRangeEllipszis.transform.localScale = new Vector3(range * 4 / 5, range * 4 / 5, 0);
            AllGameObject.SegedUpgradeTower = gameObject;
        }
        else
        {
            TowerUpgradeCanvas.SetActive(false);
           // Destroy(AllGameObject.SegedDestroyButton);
            Destroy(AllGameObject.SegedTowerRangeEllipszis);
            AllGameObject.SegedUpgradeTower = null;
            if (AllGameObject.SegedUpgradeButton != null)
                AllGameObject.SegedUpgradeButton.SetActive(false);
        }
    }


    public static Transform getClosestEnemy(List<Transform> allEnemy, Vector3 currentPos, float range)
    {
        Transform closestE = null; //egközelebbi enemy, ha nincs a rangeben enemy null marad
        float closeR = float.MaxValue;
        float distance; //segedvltozo, tarolja a ciklusban az aktulalis enemy tavolsagot
        float distance2;
        int a=-1;
        int i = 0;
        foreach (var enemy in allEnemy)
        {
            i++;
           distance = Vector3.Distance(enemy.position, currentPos)-10;
            if (enemy.GetComponent<EnemyMove>().index >= a && distance <= range)
            {
                if (enemy.GetComponent<EnemyMove>().index > a)
                {
                    closeR= Vector3.Distance(enemy.position, enemy.GetComponent<EnemyMove>().segedStart.GetComponent<Spawner>().WayPoints[enemy.GetComponent<EnemyMove>().randomszam].GetComponent<WayPoint>().Points[enemy.GetComponent<EnemyMove>().index].position);
                    closestE = enemy;
                    a = enemy.GetComponent<EnemyMove>().index;
                }
                else
                {
                    distance2 = Vector3.Distance(enemy.position, enemy.GetComponent<EnemyMove>().segedStart.GetComponent<Spawner>().WayPoints[enemy.GetComponent<EnemyMove>().randomszam].GetComponent<WayPoint>().Points[enemy.GetComponent<EnemyMove>().index].position);
                    if (closeR > distance2)
                    {
                        closestE = enemy;
                        closeR = distance2;
                    }
                }
                
                
            }
        }
        return closestE;
    }

    public void ClassicPosition()
        {
        if (direction == 1)
        {
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace1");
            }
            else
                   if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace1");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace1");
                }
            }
            else
                  if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace1");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace1");
                }
            }
            else
                                    if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace1");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace1");
                }
            }
        }
        else
                if (direction == 2)
        {
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace2");
            }
            else
                   if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace2");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace2");
                }
            }
            else
                  if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace2");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace2");
                }
            }
            else
                                    if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace2");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace2");
                }
            }
        }
        else
                if (direction == 3)
        {
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace3");
            }
            else
                   if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace3");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace3");
                }
            }
            else
                  if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace3");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace3");
                }
            }
            else
                                    if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace3");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace3");
                }
            }
        }
        else
                if (direction == 4)
        {
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace4");
            }
            else
                   if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace4");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace4");
                }
            }
            else
                  if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace4");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace4");
                }
            }
            else
                                    if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicPlace4");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicPlace4");
                }
            }
        }
    }
    public void AttackAnimation(Vector3 local)
    {
        if (local.x <= 0 && local.y <= 0)
        {
            direction = 1;
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft1");
            }
            else
               if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft1");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnLeft1");
                }
            }
            else
              if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft1");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnLeft1");
                }
            }
            else
                                if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft1");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnLeft1");
                }
            }

        }
        else
                    if (local.x >= 0 && local.y >= 0)
        {
            direction = 4;
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight2");
            }
            else
               if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight2");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnRight2");
                }
            }
            else
              if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight2");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnRight2");
                }
            }
            else
                                if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight2");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnRight2");
                }
            }

        }
        else
                    if (local.x >= 0 && local.y <= 0)
        {
            direction = 2;
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight1");
            }
            else
               if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight1");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnRight1");
                }
            }
            else
              if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight1");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnRight1");
                }
            }
            else
                                if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnRight1");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnRight1");
                }
            }
        }
        else
                    if (local.x <= 0 && local.y >= 0)
        {
            direction = 3;
            if (TowerUpgrade1.active)
            {
                TowerUpgrade1.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft2");
            }
            else
               if (TowerUpgrade2.active)
            {
                if (nez)
                {
                    TowerUpgrade2.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft2");
                }
                else
                {
                    TowerUpgrade2.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnLeft2");
                }
            }
            else
              if (TowerUpgrade3.active)
            {
                if (nez)
                {
                    TowerUpgrade3.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft2");
                }
                else
                {
                    TowerUpgrade3.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnLeft2");
                }
            }
            else
                                if (TowerUpgrade4.active)
            {
                if (nez)
                {
                    TowerUpgrade4.transform.GetChild(0).GetComponent<Animator>().Play("ClassicArrowsMAnLeft2");
                }
                else
                {
                    TowerUpgrade4.transform.GetChild(1).GetComponent<Animator>().Play("ClassicArrowsMAnLeft2");
                }
            }

        }
    }
}
