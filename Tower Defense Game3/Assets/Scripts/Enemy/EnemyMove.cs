using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyMove : MonoBehaviour
{
    public float maxHP = 50;
    public float realodingTime = 1f;
    public float Damegex = 6f;
    public float Damegey = 12f;
    public float range = 3f;
    public int EnemyGiveMoney;
    public float EnemySpeed = 10f;
    public string vege = "------------------";
    public int KarakterIndex = 0;

    private Transform target;
    //public int foglalte = 0;
    public List<Transform> target2=new List<Transform>();
    public int index = 0;
    
    private float presentTime = 0;
    public float minuszposition=0;
    public float currentHP;
    public int start = 0;
    public GameObject segedStart = null;
    public int randomszam;
    public float TimeQuicksandTime = -10f;
    public float TimeBigQuicksandTime = -10f;
    private float szamlalo = 0;
    private GameObject BigQuicksand=null;
    private GameObject QuicSand = null;
    private float BackSpeed;
    private float BackDemage;
    public float ArrowTowerPoison = 0;
    public int direction = 0; // 1=up , 2= down , 3= right, 4= left, 5= hit
    private GameObject posioneffekt=null;
    public Sprite EnemySkin;
    public Vector2 KarakterSkillImageSize;
    public string necromaceData = "--NacromacerData:--";
    public float SkeletonSpawnTime;
    public string necromaceDataVege = "---NacromacerDataVege:---";
    public List<Sprite> HandUp = new List<Sprite>();
    public string hilerenemyData = "--Hiler enemyData--";
    public float hilerrange;
    public float pluszhil;
    public int hilTimex;
    public int hilTimey;
    public string hilerenemyDataVege = "---Hiler enemyData vege---";
    private float segedSkeletonSpawner = 0;
    public GameObject SkeletonEnemy;
    public string VegenecromaceData = "Vege NacromacerData:";
    private bool mehete = true;
    //public bool dog;

    [System.Obsolete]
    private void OnMouseDown()
    {
            StartCoroutine(MapOnMouseClick.varakoztatas(0.1f));
        if (MENUGamobjects.TutorialMap == 0)
        {
                AllGameObject.KarakterSkillAd(maxHP, currentHP, EnemySpeed, realodingTime, Damegex, Damegey, EnemySkin, gameObject, KarakterSkillImageSize);
            
        }

    }
    void Start()
    {
        target2.Clear();
        randomszam = Random.Range(0,segedStart.GetComponent<Spawner>().WayPoints.Count);
        currentHP = maxHP;
        target = segedStart.GetComponent<Spawner>().WayPoints[randomszam].GetComponent<WayPoint>().Points[index];
    }
    public void changeHP(float damage)
    {
        currentHP -= damage;
        if(currentHP>maxHP)
        {
            currentHP = maxHP;
        }
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = currentHP / maxHP;
    }

    void Update()
    {
        if (currentHP <= 0)
        {
            if(BigQuicksand!=null)
            {
                Destroy(BigQuicksand);
            }
            if (QuicSand != null)
            {
                Destroy(QuicSand);
            }
            if(posioneffekt!=null)
            {
                Destroy(posioneffekt);
            }
            AllGameObject.AllEnemys.Remove(gameObject.transform);
            BeginnerMoney.Beginnermoney += EnemyGiveMoney;
            AllGameObject.MoneyText.GetComponent<Text>().text = BeginnerMoney.Beginnermoney.ToString();
            direction = 0;
            SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "halal");
            Destroy(gameObject);
        }
        if(ArrowTowerPoison>0)
        {
            if(posioneffekt==null)
            {
                posioneffekt = Instantiate(AllGameObject.poisonEfekt, gameObject.transform.position, gameObject.transform.rotation);
            }
            posioneffekt.transform.position = gameObject.transform.position;
            float a = ArrowTowerPoison;
            ArrowTowerPoison -= Time.deltaTime;
            changeHP((a- ArrowTowerPoison)*2);
        }
        else
        if(posioneffekt!=null)
        {
            Destroy(posioneffekt);
            posioneffekt = null;
        }
        if (TimeQuicksandTime>0&&QuickSandGO.Setactive)
        {          
            if (QuicSand == null)
            {
                BackDemage = Damegey;
                BackSpeed = EnemySpeed;
                Damegey  = Damegex;
                EnemySpeed *= 0.2f;
                QuicSand = Instantiate(MENUGamobjects.QuicksandRange.transform.GetChild(0).GetComponent<QuickSandGO>().QuicksandIMage, gameObject.transform.position-new Vector3(0, 0.5f, 0), Quaternion.identity);
            }
            else
            {
                QuicSand.transform.position = gameObject.transform.position - new Vector3(0, 0.5f, 0);
            }
            TimeQuicksandTime -=Time.deltaTime;
        }
        else
        if(TimeQuicksandTime!=-10f)
        {
            Damegey= BackDemage;
            EnemySpeed= BackSpeed;
            Destroy(QuicSand);
            QuicSand = null;
            TimeQuicksandTime = -10f;
        }

        if (TimeBigQuicksandTime > 0)
        {
            direction = 0;
            if (BigQuicksand==null)
            {
                BigQuicksand = Instantiate(MENUGamobjects.BigQuicksand, gameObject.transform.position, Quaternion.identity);
            }
            if(szamlalo>=1)
            {
                szamlalo = 0;
                changeHP(MENUGamobjects.BigQuicksand.GetComponent<BigQuicksandScript>().demaga);
            }
            TimeBigQuicksandTime -= Time.deltaTime;
            szamlalo += Time.deltaTime;
            return;
        }
        else
      if (TimeBigQuicksandTime != -10f)
        {
            Destroy(BigQuicksand);
            BigQuicksand = null;
            TimeBigQuicksandTime = -10f;
        }
        if (PauseButtonImagePause.Bool||!mehete)
            return;
        if (target2.Count>0)
        {
            if(target2[0]!=null)
            if (Mathf.Abs(target2[0].position.x+ minuszposition - transform.position.x) <= 0.1f || Mathf.Abs(target2[0].position.y - transform.position.y) <= 0.1f)
            {
                Vector2 dir = target2[0].position - transform.position;
               gameObject.transform.GetComponent<ImagesChangesANimation>().hitprezent= MENUGamobjects.directiondefinition(dir);
                direction = 5;
                if (presentTime >= realodingTime)
                {
                    if (target2[0].GetComponentInParent<SoldiersMove>())
                    {
                        int r = Random.Range(1, 101);
                            if(target2[0]!=null)
                        if (r > target2[0].GetComponent<SoldiersMove>().Skill[1])
                        {
                            target2[0].GetComponent<SoldiersMove>().changeHP(Random.Range(Damegex, Damegey));
                        }
                    }
                    else
                        if(target2[0].GetComponentInParent<CLassicHEroScript>())
                    {    
                        target2[0].GetComponent<CLassicHEroScript>().changeHP(Random.Range(Damegex, Damegey));
                    }

                    presentTime = 0;
                }
                presentTime += Time.deltaTime;
                return;
            }
        }

        if (target2.Count == 0)
        {
            if (segedStart.GetComponent<Spawner>().WayPoints[randomszam].GetComponent<WayPoint>().Points.Length <= index)
            {
                AllGameObject.AllEnemys.Remove(gameObject.transform);
                Destroy(gameObject);

                HeartCounter.BeginnerHeart--;

                HeartCounter.HeartText.GetComponent<Text>().text = HeartCounter.BeginnerHeart.ToString();
                if (HeartCounter.BeginnerHeart == 0)
                {
                    GameOver();
                    return;
                }
            }
            if (Vector2.Distance(target.position, transform.position) <= 0.4f)
            {
                index++;
                if (segedStart.GetComponent<Spawner>().WayPoints[randomszam].GetComponent<WayPoint>().Points.Length > index)
                {
                    target = segedStart.GetComponent<Spawner>().WayPoints[randomszam].GetComponent<WayPoint>().Points[index];

                }
            }
        }
            
        
        if (target2.Count > 0)
        {
        
            Vector2 dir = target2[0].position - transform.position;
            dir = new Vector3(dir.x + minuszposition, dir.y);
            direction = MENUGamobjects.directiondefinition(dir);
            transform.Translate(dir.normalized * EnemySpeed * Time.deltaTime, Space.World);
        }
        else
        {
            Vector2 dir = target.position - transform.position;
          direction=MENUGamobjects.directiondefinition(dir);
            transform.Translate(dir.normalized * EnemySpeed * Time.deltaTime, Space.World);
            if (KarakterIndex == 5)
            {
                
                if (segedSkeletonSpawner >= SkeletonSpawnTime)
                {
                    segedSkeletonSpawner = 0;
                    mehete = false;
                    StartCoroutine(SKeletonSpawn(3));
                }
                segedSkeletonSpawner += Time.deltaTime;
            }
            if (KarakterIndex == 8)
            {
                if (segedSkeletonSpawner == 0)
                {
                    int random = Random.Range(hilTimex, hilTimey);
                    segedSkeletonSpawner = random;
                }
                segedSkeletonSpawner -= Time.deltaTime;
                if (segedSkeletonSpawner <= 0)
                {
                    segedSkeletonSpawner = 0;
                    mehete = false;
                    StartCoroutine(Hiler(3));
                }
            }
        }

    }
    // 1=up , 2= down , 3= right, 4= left, 5= hit

    public IEnumerator SKeletonSpawn(float a)
    {
        float Timer = 0;
        bool nez = true;
        while(Timer<a)
        {
            int index =(int)(Timer * HandUp.Count / a);
            if(HandUp.Count>index)
                gameObject.GetComponent<SpriteRenderer>().sprite = HandUp[index];
            if (nez&&Timer>=a/2)
            {
                Transform Enemy2 = Instantiate(SkeletonEnemy.transform, gameObject.transform.position, gameObject.transform.rotation);
                //Transform Enemy2 = Enemy.transform;
                AllGameObject.AllEnemys.Add(Enemy2);
                Enemy2.GetComponent<EnemyMove>().segedStart = gameObject.GetComponent<EnemyMove>().segedStart;
                Enemy2.GetComponent<EnemyMove>().index = gameObject.GetComponent<EnemyMove>().index;
                Enemy2.SetParent(GameObject.Find("Enemys").transform);
                nez = false;
            }
            yield return Timer += Time.deltaTime;
        }
        mehete = true;
    }

    public IEnumerator Hiler(float a)
    {
        float Timer = 0;
        while (Timer < a)
        {
            int index = (int)(Timer * HandUp.Count / a);
            if (HandUp.Count > index)
                gameObject.GetComponent<SpriteRenderer>().sprite = HandUp[index];
            yield return Timer += Time.deltaTime;
        }
        for(int i=0;i<AllGameObject.AllEnemys.Count;i++)
        {
            if(Vector3.Distance(transform.position,AllGameObject.AllEnemys[i].position)<=hilerrange)
            {
                AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().changeHP(-pluszhil);
            }
        }
        mehete = true;
    }

    void GameOver()
        {
        AllGameObject.SettingsButton = false;
            //GameObject.Find("ExternalDevicesCanvas").SetActive(false);
            //GameObject.Find("Start").SetActive(false);
            AllGameObject.GameOverCanvas.SetActive(true);
            AllGameObject.GameOverPanel.SetActive(true);
        AllGameObject.SetactiveFalse(-1);
        PauseButtonImagePause.Bool = !PauseButtonImagePause.Bool;
        //AllGameObject.PauseButtonImageLocation.SetActive(!PauseButtonImagePause.Bool);
        AllGameObject.Kulsok.SetActive(!PauseButtonImagePause.Bool);
        AllGameObject.attackfromheavenButton.SetActive(!PauseButtonImagePause.Bool);
        AllGameObject.attackfromheavenButton2.SetActive(false);
        AllGameObject.OwnUnitSoldiersButton1.SetActive(!PauseButtonImagePause.Bool);
        AllGameObject.OwnUnitSoldiersButton2.SetActive(false);
        AllGameObject.OwnUNitSoldiersClickBool = false;
        AllGameObject.BubbleAllSkillObjects.SetActive(!PauseButtonImagePause.Bool);
        gameObject.SetActive(false);
    }
    
}
