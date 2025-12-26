using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CLassicHEroScript : MonoBehaviour
{
    public float maxHP = 50;
    public float Damegex = 6f;
    public float Damegey = 12f;
    public float range = 0;
    public float SoldiersSpeed = 0;
    public float Selfhealing = 1f;
    public float TimeSelfhealingLoop = 1f;
    public float realodingTime = 1f;
    public string vege = "------------------------";
    public string Abalitis = "Abalitiys Data -----------------";
    public string Abalitiisis1 = "Abality1:";
    public float DashDamage = 20;
    public float DashDistanse = 1;
    public string Abalitiisis2 = "Abality2:";
    public float CircleDamage = 30;
    public int DamageCount = 3;
    public float Circleistanse = 5;
    public string AbalitisOver = "Abalitiys Over -----------------";
    public float currentHP;
    public Transform Target = null;
    public float minuszposition;
    private float presentTime = 0;
    public Vector3 target2 = new Vector3(0.000001f, 0.000001f, -50000f);
    private float TimeSelfHealingPerSecundum = 0,ShootTime=0;
    public Sprite SkinImage;
    //public List<GameObject> BodyPart = new List<GameObject>();
    public int Direction = 0;
    public int HeroTypeINdex;
    public GameObject KleopatraHusbandSequendSkill;
    public GameObject KleopatraHusbandFirstSkill;
    private int DirectionSeged = 0;
    public float KepessegAnimationTime = 2f;
    public List<guggolas> KepessegImages = new List<guggolas>();
    public string Ijaaasz = "Ijjasz adatok:";
    public float IjaszRange = 2f;
    public float IjaszDamegex = 6f;
    public float IjaszDamegey = 12f;
    public string IjaaaszVege = "Vegeee Ijjasz adatok:";
    private Transform EnemyIJasz=null;
    public Vector2 SizeData = new Vector2(15, 30);
   
    [System.Serializable]
    public class guggolas
    {
        public Sprite guggolaskep;
        public Vector3 Pos;
        public Vector2 Size;
    }
    public void Abality1Button()
    {

        if (gameObject.transform.eulerAngles == new Vector3(0, 180, 0))
        {
            if (HeroTypeINdex==0)
            {
                if (Target != null)
                {
                    Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
                    Target.GetComponent<EnemyMove>().changeHP(DashDamage);
                }
                Target = null;
                SoundsScript.MusicStart(gameObject, "hero dash cut");
                StartCoroutine(Dash(DashDistanse, 0.2f, gameObject.transform.position, false));
                for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
                {
                    if (AllGameObject.AllEnemys[i] != Target)
                    {
                        if (AllGameObject.AllEnemys[i].position.x - gameObject.transform.position.x <= DashDistanse && AllGameObject.AllEnemys[i].position.x - gameObject.transform.position.x > -0.2f && Mathf.Abs(AllGameObject.AllEnemys[i].position.y - gameObject.transform.position.y) <= 1.5f)
                        {
                            AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().changeHP(DashDamage);
                        }
                    }
                }
            }
            else
            if(HeroTypeINdex == 1)
            {
                if (Target != null)
                {
                    Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
                    Target.GetComponent<EnemyMove>().changeHP(DashDamage);
                }
                Target = null;
                SoundsScript.MusicStart(gameObject, "hero dash cut");
                DirectionSeged = Direction;
                Direction = -1;
                GameObject skill = Instantiate(KleopatraHusbandFirstSkill, gameObject.transform.position, gameObject.transform.rotation);
                skill.transform.rotation= Quaternion.Euler(0, 180, 0);
                StartCoroutine(Kepesseg());
            }

        }
        else
        {
            if (HeroTypeINdex==0)
            {
                if (Target != null)
                {
                    Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
                    Target.GetComponent<EnemyMove>().changeHP(DashDamage);
                }
                Target = null;
                StartCoroutine(Dash(DashDistanse, 0.2f, gameObject.transform.position, true));
                for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
                {
                    if (AllGameObject.AllEnemys[i] != Target)
                    {
                        if (gameObject.transform.position.x - AllGameObject.AllEnemys[i].position.x <= DashDistanse && gameObject.transform.position.x - AllGameObject.AllEnemys[i].position.x > -0.2f && Mathf.Abs(AllGameObject.AllEnemys[i].position.y - gameObject.transform.position.y) <= 1.5f)
                        {
                            AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().changeHP(DashDamage);
                        }
                    }
                }
            }
            else
            if (HeroTypeINdex == 1)
            {
                if (Target != null)
                {
                    Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
                    Target.GetComponent<EnemyMove>().changeHP(DashDamage);
                }
                Target = null;
                DirectionSeged = Direction;
                Direction = -1;
                GameObject Cracrk=Instantiate(KleopatraHusbandFirstSkill, gameObject.transform.position, gameObject.transform.rotation);
                Cracrk.GetComponent<SecuendHeroSkill>().Hero = gameObject;
                StartCoroutine(Kepesseg());
            }

        }
        if (HeroTypeINdex == 2)
        {
            DirectionSeged = Direction;
            Direction = -1;
            if (Target != null)
            {
                Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
            }
            Target = null;
            StartCoroutine(Ijaszloves(5));
        }
    }

    public void Abality2Button()
    {


        if (HeroTypeINdex==0)
        {
            SoundsScript.MusicStart(gameObject, "herospin");
            StartCoroutine(Porges(1.2f));
        }
        else
        if(HeroTypeINdex==1)
        {
            SoundsScript.MusicStart(gameObject, "herospin");
            DirectionSeged = Direction;
            Direction = -1;
            GameObject skill = Instantiate(KleopatraHusbandSequendSkill, gameObject.transform.position, gameObject.transform.rotation);
            skill.transform.localScale = new Vector3(Circleistanse * 2, Circleistanse * 2, 1);
            StartCoroutine(Kepesseg());

            StartCoroutine(Porges(1.3f));
        }
        else
        if (HeroTypeINdex == 2)
        {
            DirectionSeged = Direction;
            Direction = -1;
            if (Target != null)
            {
                Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
            }
            Target = null;
            StartCoroutine(Ijaszloves(50));
        }


    }

    public IEnumerator Porges(float a)
    {
        float Timer = 0;
        int DamaegIndex = 0;
        while(Timer<a)
        {
            if ((a / DamageCount) * DamaegIndex <= Timer)
            {
                DamaegIndex++;
                for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
                {
                    if (Mathf.Abs(Vector3.Distance(AllGameObject.AllEnemys[i].position, gameObject.transform.position)) <= Circleistanse)
                    {
                        if (AllGameObject.AllEnemys[i] != null)
                        {
                            AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().changeHP(CircleDamage);
                        }
                    }
                }
            }

            if(HeroTypeINdex == 0)
            gameObject.transform.rotation= Quaternion.Euler(0,Mathf.Lerp(0, 3000, Timer / a),0);
            yield return Timer += Time.deltaTime;
        }
        gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }

    public IEnumerator Dash(float a, float ido,Vector3 kezdopos, bool left)
    {
        float Timer = 0;
        while (Timer < ido)
        {
            if (left)
            {
                gameObject.transform.position = Vector3.Lerp(kezdopos, new Vector3(kezdopos.x - a, kezdopos.y, kezdopos.y), Timer / ido);
            }
            else
            {
                gameObject.transform.position = Vector3.Lerp(kezdopos, new Vector3(kezdopos.x+ a, kezdopos.y , kezdopos.y), Timer / ido);
            }
            yield return Timer += Time.deltaTime;
        }
    }

    public IEnumerator Kepesseg()
    {
        float timer = 0;
        Vector3 Save = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        while (timer< KepessegAnimationTime)
        {
            int index = Mathf.FloorToInt(timer / (KepessegAnimationTime / KepessegImages.Count));
            gameObject.GetComponent<SpriteRenderer>().sprite= KepessegImages[index].guggolaskep;
            gameObject.GetComponent<SpriteRenderer>().size= KepessegImages[index].Size;
            if (gameObject.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                gameObject.transform.position = new Vector3(Save.x + KepessegImages[index].Pos.x, Save.y + KepessegImages[index].Pos.y, Save.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(Save.x - KepessegImages[index].Pos.x, Save.y - KepessegImages[index].Pos.y, Save.z);
            }
           yield return timer += Time.deltaTime;
        }
        gameObject.transform.position = Save;
        Direction =DirectionSeged;
    }
    public IEnumerator Ijaszloves (int darab)
    {
        float timer = 0;
        Vector3 Save = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        while (timer < KepessegAnimationTime)
        {
            int index = Mathf.FloorToInt(timer / (KepessegAnimationTime / KepessegImages.Count));
            gameObject.GetComponent<SpriteRenderer>().sprite = KepessegImages[index].guggolaskep;
            gameObject.GetComponent<SpriteRenderer>().size = KepessegImages[index].Size;
            if (gameObject.transform.eulerAngles == new Vector3(0, 0, 0))
            {
                gameObject.transform.position = new Vector3(Save.x + KepessegImages[index].Pos.x, Save.y + KepessegImages[index].Pos.y, Save.z);
            }
            else
            {
                gameObject.transform.position = new Vector3(Save.x - KepessegImages[index].Pos.x, Save.y - KepessegImages[index].Pos.y, Save.z);
            }
            yield return timer += Time.deltaTime;
        }
        gameObject.transform.position = Save;
        int szamlalo = 0;
        for (int i = 0; i < AllGameObject.AllEnemys.Count&&szamlalo< darab; i++)
        {

            if (AllGameObject.AllEnemys[i] != null)
            {
                if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + IjaszRange && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - IjaszRange && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + IjaszRange && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - IjaszRange)
                {
                    szamlalo++;
                    Transform arrowTransform = Instantiate(AllGameObject.TowerArrow.transform, gameObject.transform.position, Quaternion.identity);
                    //em.changeHP(15);
                    TowerArrow arrow = arrowTransform.GetComponent<TowerArrow>();
                    arrow.setup(Random.Range(IjaszDamegex, IjaszDamegey), AllGameObject.AllEnemys[i]);
                    //TowerArrow.Create(gameObject.transform.position, AllGameObject.AllEnemys[i], Random.Range(IjaszDamegex, IjaszDamegey));
                }

            }
        }
        Direction = DirectionSeged;
    }


    [System.Obsolete]
    private void OnMouseDown()
    {
        StartCoroutine(MapOnMouseClick.varakoztatas(0.1f));
        if (MENUGamobjects.TutorialMap == 0)
        {
            AllGameObject.heroactive = true;
            AllGameObject.KarakterSkillAd(maxHP, currentHP, SoldiersSpeed, realodingTime, Damegex, Damegey, SkinImage, gameObject, SizeData);
        }

    }
    void Start()
    {
        AllGameObject.AllSoldier.Add(gameObject.transform);
        currentHP = maxHP;

    }
    public void changeHP(float damage)
    {
        if ((damage < 0 && maxHP > currentHP-damage) || damage > 0)
        {
            currentHP -= damage;
        }
        else
        {
            currentHP = maxHP;
        }
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = currentHP / maxHP;
    }
    private void Update()
    {
        if (currentHP <= 0)
        {
            DestroySoldiers();
        }


        if (PauseButtonImagePause.Bool||Direction==-1)
            return;
        if (target2 != new Vector3(0.000001f, 0.000001f, -50000f))
        {
            if (Mathf.Abs(target2.x - transform.position.x) <= 0.02f || Mathf.Abs(target2.y - transform.position.y) <= 0.02f)
            {
                target2 = new Vector3(0.000001f, 0.000001f, -50000f);
                return;
            }
            Vector2 dir = target2 - transform.position;
            Direction = MENUGamobjects.directiondefinition(dir);
            transform.Translate(dir.normalized * SoldiersSpeed * Time.deltaTime, Space.World);
            return;
        }

        if (Target != null)
        {
            if (Target.GetComponent<EnemyMove>().target2.Count > 1)
            {
                float distance = float.MaxValue;
                Transform tarol = null;
                for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
                {

                    if (AllGameObject.AllEnemys[i] != null && target2 == new Vector3(0.000001f, 0.000001f, -50000f))
                    {
                        if (AllGameObject.AllEnemys[i] != tarol)
                        {
                            if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + range && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - range && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + range && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - range && AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().target2.Count == 0)
                            {
                                if (Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position) < distance)
                                {
                                    distance = Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position);
                                    tarol = AllGameObject.AllEnemys[i];
                                }
                            }
                        }
                    }
                }

                if (tarol != null)
                {

                    //Target.GetComponent<EnemyMove>().foglalte--;
                    Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
                    tarol.GetComponent<EnemyMove>().target2.Add(gameObject.transform);
                    Target = tarol;
                    if (Vector3.Distance(tarol.position + new Vector3(0.2f, 0, 0), gameObject.transform.position) <= Vector3.Distance(tarol.position + new Vector3(-0.2f, 0, 0), gameObject.transform.position))
                    {
                        minuszposition = 0.8f;
                        tarol.GetComponent<EnemyMove>().minuszposition = -0.8f;

                    }
                    else
                    {
                        minuszposition = -0.8f;
                        tarol.GetComponent<EnemyMove>().minuszposition = +0.8f;
                    }
                    //tarol.GetComponent<EnemyMove>().foglalte++;
                }
            }
        }

        if (Target != null)
        {
            if (Mathf.Abs(Target.position.x+ minuszposition - transform.position.x) <= 0.05f || Mathf.Abs(Target.position.y - transform.position.y) <= 0.05f)
            {
                Direction = 5;
                if (presentTime >= realodingTime)
                {
                    SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "Kardcsapasok");
                    
                    AllGameObject.HeroLevelBacgroundIMage.GetComponent<HeroLevel>().HeroDemage();
                    Target.GetComponent<EnemyMove>().changeHP(Random.Range(Damegex, Damegey));
                    presentTime = 0;
                }
                presentTime += Time.deltaTime;
                return;
            }
        }
        if (Target == null)
        {
            //foglalte = false;
            float distance = float.MaxValue;
            float distance2 = float.MaxValue;
            Transform tarol = null;
            for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
            {

                if (AllGameObject.AllEnemys[i] != null&& target2== new Vector3(0.000001f, 0.000001f, -50000f))
                {
                    if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + range && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - range && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + range && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - range && AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().target2.Count == 0)
                    {
                        if (Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position) < distance)
                        {
                            distance = Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position);
                            tarol = AllGameObject.AllEnemys[i];
                        }
                    }
                    else
                    if (distance == float.MaxValue)
                    {
                        if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + range && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - range && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + range && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - range)
                        {
                            if (Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position) < distance2)
                            {
                                distance2 = Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position);
                                tarol = AllGameObject.AllEnemys[i];
                            }

                        }
                    }
                }
            }
            if (tarol != null)
            {
                tarol.GetComponent<EnemyMove>().target2.Add(gameObject.transform);
                Target = tarol;
                if (Vector3.Distance(tarol.position + new Vector3(0.2f, 0, 0), gameObject.transform.position) <= Vector3.Distance(tarol.position + new Vector3(-0.2f, 0, 0), gameObject.transform.position))
                {
                    minuszposition = 0.8f;
                    tarol.GetComponent<EnemyMove>().minuszposition = -0.8f;

                }
                else
                {
                    minuszposition = -0.8f;
                    tarol.GetComponent<EnemyMove>().minuszposition = +0.8f;
                }
                //tarol.GetComponent<EnemyMove>().foglalte++;
            }
        }
        if (Target != null)
        {
            Vector2 dir = Target.position - transform.position;
            dir = new Vector3(dir.x + minuszposition, dir.y);
            Direction = MENUGamobjects.directiondefinition(dir);
            transform.Translate(dir.normalized * SoldiersSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            if (HeroTypeINdex == 2)
            {
                if (EnemyIJasz == null)
                {
                    float distance = float.MaxValue;
                    Transform tarol = null;
                    for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
                    {

                        if (AllGameObject.AllEnemys[i] != null)
                        {
                            if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + IjaszRange && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - IjaszRange && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + IjaszRange && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - IjaszRange)
                            {
                                if (Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position) < distance)
                                {
                                    distance = Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position);
                                    tarol = AllGameObject.AllEnemys[i];
                                }
                            }
                           
                        }
                    }
                    if (tarol != null)
                    {
                        EnemyIJasz = tarol;
                    }
                    else
                    {
                        Direction = 0;
                        if (TimeSelfHealingPerSecundum >= TimeSelfhealingLoop)
                        {
                            changeHP(-Selfhealing);
                            TimeSelfHealingPerSecundum = 0;
                        }
                        TimeSelfHealingPerSecundum += Time.deltaTime;
                    }
                }          
                else
                {
                    Direction = -2;
                    if (ShootTime >= KepessegAnimationTime)
                    {
                        ShootTime = 0;
                        AllGameObject.HeroLevelBacgroundIMage.GetComponent<HeroLevel>().HeroDemage();
                        TowerArrow.Create(gameObject.transform.position,EnemyIJasz, Random.Range(IjaszDamegex, IjaszDamegey));
                    }
                    int index = Mathf.FloorToInt(ShootTime / (KepessegAnimationTime / KepessegImages.Count));
                    if (EnemyIJasz.position.x - gameObject.transform.position.x > 0)
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                        //gameObject.transform.position = new Vector3(gameObject.transform.position.x - KepessegImages[index].Pos.x, gameObject.transform.position.y - KepessegImages[index].Pos.y, gameObject.transform.position.z);
                    }
                    else
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                        //gameObject.transform.position = new Vector3(gameObject.transform.position.x + KepessegImages[index].Pos.x, gameObject.transform.position.y + KepessegImages[index].Pos.y, gameObject.transform.position.z);
                    }
                    gameObject.GetComponent<SpriteRenderer>().sprite = KepessegImages[index].guggolaskep;

                    gameObject.GetComponent<SpriteRenderer>().size = KepessegImages[index].Size;
                    ShootTime += Time.deltaTime;
                }
            }
            else
            {
                Direction = 0;
                if (TimeSelfHealingPerSecundum >= TimeSelfhealingLoop)
                {
                    changeHP(-Selfhealing);
                    TimeSelfHealingPerSecundum = 0;
                }
                TimeSelfHealingPerSecundum += Time.deltaTime;
            }
        }


    }
   public void DestroySoldiers()
    {
        if (Target != null)
        {
            Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
        }
        AllGameObject.AllSoldier.Remove(gameObject.transform);
        for (int i = 0; i < AllGameObject.SpacesTransform.Length; i++)
        {
            if (AllGameObject.SpacesTransform[i] != null)
                if (AllGameObject.SpacesTransform[i].GetComponentInParent<TowerOwnSolderBuilding>())
                    AllGameObject.SpacesTransform[i].GetComponent<TowerOwnSolderBuilding>().AllSoldier.Remove(gameObject);
        }
        AllGameObject.SecondCircleLOading.SetActive(true);
        AllGameObject.heroLOadintActive = true;
        AllGameObject.heroactive = false;
        AllGameObject.HeroButton.GetComponent<Image>().color = Color.white;

        HeroLevel.atackPerPercentage = AllGameObject.HeroLevelBacgroundIMage.GetComponent<HeroLevel>().atackPerPercentage2;
        HeroLevel.presentIndex = 1;
        AllGameObject.HeroLevelBacgroundIMage.GetComponent<HeroLevel>().Level.GetComponent<Transform>().localScale = new Vector3(0, 1, 1);
        AllGameObject.HeroLevelBacgroundIMage.GetComponent<HeroLevel>().Abality2Lock.SetActive(true);
        AllGameObject.HeroLevelBacgroundIMage.GetComponent<HeroLevel>().HeroLevelCounterText.GetComponent<Text>().text = "0";
        SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "halal");
        Direction = 0;
        Destroy(gameObject);
    }
}
