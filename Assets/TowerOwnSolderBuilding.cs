using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerOwnSolderBuilding : MonoBehaviour
{
    public float range = 0;
    public float timerMax = 0.5f;
    //public int maxLevel = 4;
    //public float damage1;
    public float maxSoldiers = 2;
    //public int levelupMoney = 0;
    public string asd = "-------------------------";
    public List<int> Skill = new List<int>();
    public float pluszmaxHp=0;
    public float pluszDamage=0;
    public float pluszChilHiler = 0;
    public float pluszspeed = 1;
    //public Transform shootPos; //innen lovodik ki a golyo
    private float timer = 0;
    //public int level = 1;
    public float validrange = 0;
    //public static float damage;
    public Vector3 Aim = new Vector3(0.000001f,0.000001f,-50000f);
    public List<GameObject> AllSoldier = new List<GameObject>();
    public GameObject TowerUpgradeCanvas;
    public GameObject UpgradeArrowTowerScriptCIrcle;
    public GameObject SegedDestroyButtons;
    public GameObject Gate;
    public Vector3 FirstPosition;
    public int indexskin = 0;
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
    public void rangeSetactive()
    {
        TowerUpgradeCanvas.SetActive(false);
        //Destroy(AllGameObject.SegedDestroyButton);
        if (AllGameObject.SegedUpgradeButton != null)
            AllGameObject.SegedUpgradeButton.SetActive(false);
        Destroy(AllGameObject.SegedTowerRangeEllipszis);
        AllGameObject.SegedTowerRangeEllipszis = Instantiate(AllGameObject.SoldersTowerRangeEllipszis, TowerRangeEllipszisPosition.transform.position, AllGameObject.SoldersTowerRangeEllipszis.transform.rotation);
        AllGameObject.SegedTowerRangeEllipszis.transform.localScale = new Vector3(range, range, 0);

    }
    public void ChangeAim()
    {
        for (int i = 0; i < AllSoldier.Count; i++)
        {
            if (AllSoldier[i] != null/*&&AllSoldier[i].GetComponent<SoldiersMove>().Target == null*/)
            {
                AllSoldier[i].GetComponent<SoldiersMove>().target2 = Aim + new Vector3(i, 0, 0);
            }
        }
    }
    public GameObject TowerDestroyButtonPosition = null;
    public GameObject TowerRangeEllipszisPosition = null;
    
    private void Awake()
    {
        Skill.Clear();
        Skill.Add(0); Skill.Add(0); Skill.Add(0);
        LanguagesChange(database.LNG, LANG);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 0.2f, gameObject.transform.position.y - 0.05f, gameObject.transform.position.z);
        timer = timerMax;
        Aim = new Vector3(0.000001f, 0.000001f, -50000f);
        AllGameObject.SoldersTowerRangeEllipszis.transform.localScale = new Vector3(range, range, 0);
        validrange = range * 10;
    }
    private void Update()
    {
        if (PauseButtonImagePause.Bool||AllSoldier.Count> maxSoldiers||Aim==new Vector3(0.000001f,0.000001f,-50000f))
            return;
        timer += Time.deltaTime;
        if (timer >= timerMax)
        {
            if(AllSoldier.Count< maxSoldiers)
            StartCoroutine(GateAnimation());
            for (int i = AllSoldier.Count; i < maxSoldiers; i++)
            {
                TowerRangeEllipszisPosition.transform.position=new Vector3(TowerRangeEllipszisPosition.transform.position.x, TowerRangeEllipszisPosition.transform.position.y,5);
                AllSoldier.Add(Instantiate(AllGameObject.OwnSoldier, TowerRangeEllipszisPosition.transform.position, AllGameObject.OwnSoldier.transform.rotation));
                AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().IndexSkin = indexskin;
                AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().TowerSoldiers = true;
                AllSoldier[AllSoldier.Count-1].transform.parent = GameObject.Find("Soldiers").transform;
                AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().target2 = Aim + new Vector3(i, 0, 0);
                AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().Skill.Add(Skill[0]);AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().Skill.Add(Skill[1]);AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().Skill.Add(Skill[2]);

                    AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().Damegex +=pluszDamage ;
                    AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().Damegey += pluszDamage;
                AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().maxHP += pluszmaxHp;
                AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().Selfhealing += pluszChilHiler;
                AllSoldier[AllSoldier.Count - 1].GetComponent<SoldiersMove>().realodingTime /= pluszspeed;
                
            }
            timer = 0;
                
        }


    }
    IEnumerator GateAnimation()
    {
        Gate.GetComponent<Animator>().Play("GateAnimation1");
        yield return new WaitForSeconds(1f);
        Gate.GetComponent<Animator>().Play("GateAnimation2");

    }
    public static int x = 0;
    public void OnMouseDown()
    {
        AllGameObject.SetactiveFalse(1);
        float maxhp=0, currenthp=0;
        for(int i=0;i<AllSoldier.Count;i++)
        {
            maxhp += AllSoldier[i].GetComponent<SoldiersMove>().maxHP;
            currenthp += AllSoldier[i].GetComponent<SoldiersMove>().currentHP;
        }
        AllGameObject.KarakterSkillAd(maxhp, currenthp, -1, timerMax, -1, -1, gameObject.GetComponent<SpriteRenderer>().sprite, gameObject, new Vector2(100, 50));

        if (x == 0 && AllGameObject.SegedUpgradeTower != gameObject)
        {
            if (AllGameObject.SegedUpgradeButton != null)
                AllGameObject.SegedUpgradeButton.SetActive(false);
           Destroy(AllGameObject.SegedTowerRangeEllipszis);
            AllGameObject.SegedUpgradeButton = TowerUpgradeCanvas;
            SegedDestroyButtons.GetComponent<TowerDestroyButtonIMage>().MOney = UpgradeArrowTowerScriptCIrcle;
            TowerUpgradeCanvas.SetActive(true);
            UpgradeArrowTowerScriptCIrcle.GetComponent<UpgradeArrowTower>().PipaXOFF();
            AllGameObject.SegedUpgradeTower = gameObject;
        }
        else
        {
            TowerUpgradeCanvas.SetActive(false);
           Destroy(AllGameObject.SegedTowerRangeEllipszis);
            AllGameObject.SegedUpgradeTower = null;
            if (AllGameObject.SegedUpgradeButton != null)
                AllGameObject.SegedUpgradeButton.SetActive(false);
        }
    }

}
