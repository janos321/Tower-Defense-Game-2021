using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnSolidersAnimation : MonoBehaviour
{
    // 1=up , 2= down , 3= right, 4= left , 5= hit
    public List<Skin> Skins = new List<Skin>();
    public int prezent = -1;
    public int hitprezent;
    private float ImageSkipTimeWalk, ImageSkipTimeAttack;
    private float LoadinTime = 0, PresentsegetTime = 0;
    private int SkinIndex, gladiatorIndexShoot = 0;
    //public bool Lefte = true;
    private Vector3 Save = new Vector3(0, 0, 0);
    public int AttackIndex = 0, WalkIndex = 0;


    [System.Serializable]
    public class Skin
    {
        public Vector2 AlapSize;
        //public Vector2 AlapPosition;
        public List<Sprite> Left = new List<Sprite>();
        public List<AttackData> AttackLeft = new List<AttackData>();
        public Sprite ClassicImagesLeft;
    }
    [System.Serializable]
    public class AttackData
    {
        public Sprite image;
        public Vector2 Size;
        public Vector2 Position;
    }
    private void Update()
    {
        if (PauseButtonImagePause.Bool) { return; }

            prezent = gameObject.GetComponent<SoldiersMove>().direction;
            ImageSkipTimeAttack = gameObject.GetComponent<SoldiersMove>().realodingTime;
            ImageSkipTimeWalk = gameObject.GetComponent<SoldiersMove>().SoldiersSpeed/2;
            SkinIndex = gameObject.GetComponent<SoldiersMove>().IndexSkin;
            StartCoroutine(directionChange());


    }

    public IEnumerator directionChange()
    {
        if (prezent == 0)
        {
            nullazo();
            yield return null;
        }
        else
        {
            if (prezent != 5)
            {
                Save = new Vector3(0, 0, 0);
                AttackIndex = 0;
                if (LoadinTime < (1.3 / (ImageSkipTimeWalk / 1.3)) / Skins[SkinIndex].Left.Count)
                {
                    yield return LoadinTime += Time.deltaTime;
                }
                else
                {
                    LoadinTime = 0;
                    if (prezent == 3)
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    else
                       if (prezent == 4)
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    WalkAnimation();
                }

            }
            else
            {
                if(Save == new Vector3(0, 0, 0))
                {
                    Save = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                WalkIndex = 0;
                if (LoadinTime < ImageSkipTimeAttack / Skins[SkinIndex].AttackLeft.Count)
                {
                    yield return LoadinTime += Time.deltaTime;
                }
                else
                {
                    LoadinTime = 0;

                    if (hitprezent == 3)
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    else
                    if (hitprezent == 4)
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    AttackAnimation();
                }

            }
        }
        yield return null;
    }

    public void WalkAnimation()
    {

        if (Skins[SkinIndex].Left.Count - 1 == WalkIndex)
        {
            WalkIndex = 0;
        }
        else
        {
            WalkIndex++;
        }
        gameObject.GetComponent<SpriteRenderer>().size = Skins[SkinIndex].AlapSize;
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x+ Skins[SkinIndex].AlapPosition.x, gameObject.transform.position.y+ Skins[SkinIndex].AlapPosition.y, gameObject.transform.position.z);
        gameObject.GetComponent<SpriteRenderer>().sprite = Skins[SkinIndex].Left[WalkIndex];
    }

    public void AttackAnimation()
    {
        if (Skins[SkinIndex].AttackLeft.Count - 1 == AttackIndex)
        {
            AttackIndex = 0;
        }
        else
        {
            AttackIndex++;
        }
        gameObject.GetComponent<SpriteRenderer>().size = Skins[SkinIndex].AttackLeft[AttackIndex].Size;
        if (gameObject.transform.eulerAngles == new Vector3(0, 0, 0))
        {
            gameObject.transform.position = new Vector3(Save.x + Skins[SkinIndex].AttackLeft[AttackIndex].Position.x, Save.y + Skins[SkinIndex].AttackLeft[AttackIndex].Position.y, Save.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(Save.x - Skins[SkinIndex].AttackLeft[AttackIndex].Position.x, Save.y - Skins[SkinIndex].AttackLeft[AttackIndex].Position.y, Save.z);
        }
            gameObject.GetComponent<SpriteRenderer>().sprite = Skins[SkinIndex].AttackLeft[AttackIndex].image;
    }

    public void nullazo()
    {
        if (gameObject.GetComponent<SoldiersMove>().Skill[2] > 0)
        {
            if (gameObject.GetComponent<SoldiersMove>().target3 == null)
            {
                PresentsegetTime = 0;
                gladiatorIndexShoot = 0;
                float distance = 9999999;
                for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
                {

                    if (AllGameObject.AllEnemys[i] != null)
                    {

                        if (AllGameObject.AllEnemys[i].transform.position.x <= gameObject.transform.position.x + gameObject.GetComponent<SoldiersMove>().GladiatorShootRange && AllGameObject.AllEnemys[i].transform.position.x >= gameObject.transform.position.x - gameObject.GetComponent<SoldiersMove>().GladiatorShootRange && AllGameObject.AllEnemys[i].transform.position.y <= gameObject.transform.position.y + gameObject.GetComponent<SoldiersMove>().GladiatorShootRange && AllGameObject.AllEnemys[i].transform.position.y >= gameObject.transform.position.y - gameObject.GetComponent<SoldiersMove>().GladiatorShootRange)
                        {
                            if (Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position) < distance)
                            {
                                distance = Vector3.Distance(gameObject.transform.position, AllGameObject.AllEnemys[i].position);
                                gameObject.GetComponent<SoldiersMove>().target3 = AllGameObject.AllEnemys[i];
                            }
                        }

                    }
                }
            }
            if (gameObject.GetComponent<SoldiersMove>().target3 != null)
            {
                if (gameObject.GetComponent<SoldiersMove>().target3.position.x>gameObject.transform.position.x)
                {
                    gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                }
                else
                {
                    gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                gladiatorIndexShoot = (int)(gameObject.GetComponent<SoldiersMove>().GladiatorShootSkinSize.Count * PresentsegetTime / gameObject.GetComponent<SoldiersMove>().gladiatorShootTime);
                if (gameObject.GetComponent<SpriteRenderer>().sprite != gameObject.GetComponent<SoldiersMove>().GladiatorShootSkinSize[gladiatorIndexShoot].GladiatorShootSkin)
                {
                    gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SoldiersMove>().GladiatorShootSkinSize[gladiatorIndexShoot].GladiatorShootSkin;
                    gameObject.GetComponent<SpriteRenderer>().size = gameObject.GetComponent<SoldiersMove>().GladiatorShootSkinSize[gladiatorIndexShoot].GladiatorShootSize;
                }
                if (gladiatorIndexShoot == ((int)gameObject.GetComponent<SoldiersMove>().GladiatorShootSkinSize.Count / 2))
                {
                    //BuzoganyMove.Create(gameObject.transform.position, gameObject.GetComponent<SoldiersMove>().target3, gameObject.GetComponent<SoldiersMove>().Skill[2]);
                   GameObject buzogany= Instantiate(AllGameObject.Buzogany, gameObject.transform.position, Quaternion.identity);
                    buzogany.GetComponent<BuzoganyMove>().damage = gameObject.GetComponent<SoldiersMove>().Skill[2];
                    buzogany.GetComponent<BuzoganyMove>().targetEnemy = gameObject.GetComponent<SoldiersMove>().target3;
                    PresentsegetTime += (gameObject.GetComponent<SoldiersMove>().gladiatorShootTime / gameObject.GetComponent<SoldiersMove>().GladiatorShootSkinSize.Count);
                }
                PresentsegetTime += Time.deltaTime;
                if (PresentsegetTime > gameObject.GetComponent<SoldiersMove>().gladiatorShootTime)
                {
                    PresentsegetTime = 0;
                }

            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().size = Skins[SkinIndex].AlapSize;
                gameObject.GetComponent<SpriteRenderer>().sprite = Skins[SkinIndex].ClassicImagesLeft;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().size = Skins[SkinIndex].AlapSize;
            gameObject.GetComponent<SpriteRenderer>().sprite = Skins[SkinIndex].ClassicImagesLeft;
        }
        Save = new Vector3(0, 0, 0);
        AttackIndex = 0;
        WalkIndex = 0;
    }
}
