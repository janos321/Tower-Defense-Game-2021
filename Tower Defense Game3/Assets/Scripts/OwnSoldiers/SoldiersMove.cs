using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoldiersMove : MonoBehaviour
{
    public float maxHP = 50;
    public float Damegex = 6f;
    public float Damegey = 12f;
    public float range = 0;
    public float SoldiersSpeed = 0;
    public float Selfhealing = 1f;
    public float TimeSelfhealingLoop = 1f;
    public float realodingTime = 1f;
    public float AttackTimeSelfhealingLoop = 1f;
    public float AttackSelfhealing = 100f;
    public float Despawn = 15;
    public float gladiatorShootTime=2f;
    public float GladiatorShootRange = 5f;
    public string valtoztatasokvege = "---------------------";
    public List<int> Skill = new List<int>();
    public float currentHP;
    public Transform Target = null;
    private float presentTime = 0;
    public float minuszposition = 0;
    public Vector3 target2 = new Vector3(0.000001f, 0.000001f, -50000f);
    public Transform target3 = null;
    private float TimeSelfHealingPerSecundum=0, AttackTimeSelfHealingPerSecundum=0;
    //public List<GameObject> SoldiersSkin = new List<GameObject>();
    public int direction=1;
    //public List<GameObject> SoldiersSkin = new List<GameObject>();
    public int IndexSkin = 0;
    private float DespawnTimer = 0;
    public List<Sprite> SkinImage = new List<Sprite>();
    public List<Vector2> SkinSize = new List<Vector2>();
    //public List<GameObject> BodyPart = new List<GameObject>();
    public bool TowerSoldiers = false;
    public List<GladiatorData> GladiatorShootSkinSize = new List<GladiatorData>();

    [System.Serializable]
    public class GladiatorData
    {
        public Sprite GladiatorShootSkin;
        public Vector2 GladiatorShootSize;
    }
    //private int gladiatorIndexShoot=0;
    //private float PresentsegetTime = 0;
    /*public List<Wave> SoldersSkinOptions = new List<Wave>();

    [System.Serializable]
    public class Wave
    {
        public GameObject SoldiersSkin;
        public Animator SoldiersAnimator;
        public List<GameObject> SkinTypes = new List<GameObject>();
    }*/
    [System.Obsolete]
    private void OnMouseDown()
    {
        StartCoroutine(MapOnMouseClick.varakoztatas(0.1f));
        if (MENUGamobjects.TutorialMap == 0)
        {
            AllGameObject.KarakterSkillAd(maxHP, currentHP, SoldiersSpeed, realodingTime, Damegex, Damegey, SkinImage[IndexSkin], gameObject, SkinSize[IndexSkin]);
        }

    }
    void Start()
    {
        AllGameObject.AllSoldier.Add(gameObject.transform);
        currentHP = maxHP;
        /*for (int i=0;i< SoldiersSkin.Count;i++)
        {
            SoldiersSkin[i].SetActive(false);
        }
        SoldiersSkin[IndexSkin].SetActive(true);/*
        gameObject.GetComponent<EnemyAnimationMOve>().Up = SoldersSkinOptions[0].SkinTypes[0];
        gameObject.GetComponent<EnemyAnimationMOve>().right = SoldersSkinOptions[0].SkinTypes[1];
        gameObject.GetComponent<EnemyAnimationMOve>().Down = SoldersSkinOptions[0].SkinTypes[2];
        gameObject.GetComponent<EnemyAnimationMOve>().Left = SoldersSkinOptions[0].SkinTypes[3];*/

    }
    public void changeHP(float damage)
    {
        if ((damage < 0 && maxHP > currentHP - damage) || damage > 0)
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

        if (PauseButtonImagePause.Bool)
            return;
        if(target2!= new Vector3(0.000001f, 0.000001f, -50000f))
        {
            DespawnTimer = 0;
            if (Target != null)
            {
                Target.GetComponent<EnemyMove>().target2.Remove(gameObject.transform);
                Target = null;
            }
            if (Mathf.Abs(target2.x - transform.position.x) <= 0.02f || Mathf.Abs(target2.y - transform.position.y) <= 0.02f)
            {
                target2 = new Vector3(0.000001f, 0.000001f, -50000f);
                return;
            }
                Vector2 dir = target2 - transform.position;
           direction=directiondefinition(dir);
            transform.Translate(dir.normalized * SoldiersSpeed * Time.deltaTime, Space.World);
            return;
        }
        if(Target!=null)
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
                Vector2 dir = Target.transform.position - transform.position;
               gameObject.transform.GetComponent<OwnSolidersAnimation>().hitprezent=directiondefinition(dir);
                direction = 5;
                if (Skill[0] >0)
                {
                    if (AttackTimeSelfHealingPerSecundum >= AttackTimeSelfhealingLoop)
                    {
                        changeHP(-AttackSelfhealing* Skill[0]);
                        AttackTimeSelfHealingPerSecundum = 0;
                    }
                    AttackTimeSelfHealingPerSecundum += Time.deltaTime;
                }


                if (presentTime >= realodingTime)
                {
                    SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "Kardcsapasok");
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
            direction = 0;
            float distance = float.MaxValue;
            float distance2 = float.MaxValue;
            Transform tarol = null;
            for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
            {
                
                if (AllGameObject.AllEnemys[i] != null && target2 == new Vector3(0.000001f, 0.000001f, -50000f))
                {
                    if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + range && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - range && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + range && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - range && AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().target2.Count==0)
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
                        if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + range && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - range && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + range && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - range )
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
                tarol.GetComponent<EnemyMove>().target2.Add( gameObject.transform);
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
            target3 = null;
            DespawnTimer = 0;
            Vector2 dir = Target.position - transform.position;
            dir = new Vector3(dir.x + minuszposition, dir.y);
            direction = directiondefinition(dir);
            transform.Translate(dir.normalized * SoldiersSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            direction = 0;
            if (TimeSelfHealingPerSecundum >= TimeSelfhealingLoop)
            {
                changeHP(-Selfhealing);
                TimeSelfHealingPerSecundum = 0;
            }
            DespawnTimer += Time.deltaTime;
            TimeSelfHealingPerSecundum += Time.deltaTime;
            if (!TowerSoldiers)
            {
                if (DespawnTimer >= Despawn)
                {
                    DestroySoldiers();
                }
            }
           
            }

    }
    public int directiondefinition(Vector2 pos)
    {
        if (pos.x >= 0)
        {
                return 3;
            
        }
        else
        {
            return 4;
        }


    }


    public void DestroySoldiers()
    {
        if(Target != null)
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
        direction = 0;
        SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "halal");
        Destroy(gameObject);
    }
}
