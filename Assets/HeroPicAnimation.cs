using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPicAnimation : MonoBehaviour
{
    // 1=up , 2= down , 3= right, 4= left , 5= hit
    public Skin Skins;
    public int prezent = -2;
    public int hitprezent;
    private float ImageSkipTimeWalk, ImageSkipTimeAttack;
    private float LoadinTime = 0;
    //public bool Lefte = true;
    private Vector3 Save = new Vector3(0, 0, 0);
    public int AttackIndex = 0, WalkIndex = 0;
    private Transform Target = null;


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
        if (gameObject.GetComponentInParent<CLassicHEroScript>())
        {
            prezent = gameObject.GetComponent<CLassicHEroScript>().Direction;
        }
            if (PauseButtonImagePause.Bool|| prezent<0) { return; }

        if(gameObject.GetComponentInParent<CLassicHEroScript>())
        {
            prezent = gameObject.GetComponent<CLassicHEroScript>().Direction;
            ImageSkipTimeAttack = gameObject.GetComponent<CLassicHEroScript>().realodingTime;
            ImageSkipTimeWalk = gameObject.GetComponent<CLassicHEroScript>().SoldiersSpeed/2;
            Target = gameObject.GetComponent<CLassicHEroScript>().Target;
            try
            {
                StartCoroutine(directionChange());
            }
            catch
            {

            }
        }


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
                if (LoadinTime < (1.3 / (ImageSkipTimeWalk / 1.3)) / Skins.Left.Count)
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
                if (Save == new Vector3(0, 0, 0))
                {
                    Save = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
                }
                WalkIndex = 0;
                if (LoadinTime < ImageSkipTimeAttack / Skins.AttackLeft.Count)
                {
                    yield return LoadinTime += Time.deltaTime;
                }
                else
                {
                    LoadinTime = 0;
                    if(Target.position.x<gameObject.transform.position.x)
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                    }
                    AttackAnimation();
                }

            }
        }
        yield return null;
    }

    public void WalkAnimation()
    {

        if (Skins.Left.Count - 1 == WalkIndex)
        {
            WalkIndex = 0;
        }
        else
        {
            WalkIndex++;
        }
        gameObject.GetComponent<SpriteRenderer>().size = Skins.AlapSize;
        //gameObject.transform.position = new Vector3(gameObject.transform.position.x+ Skins[SkinIndex].AlapPosition.x, gameObject.transform.position.y+ Skins[SkinIndex].AlapPosition.y, gameObject.transform.position.z);
        gameObject.GetComponent<SpriteRenderer>().sprite = Skins.Left[WalkIndex];
    }

    public void AttackAnimation()
    {
        if (Skins.AttackLeft.Count - 1 == AttackIndex)
        {
            AttackIndex = 0;
        }
        else
        {
            AttackIndex++;
        }
        gameObject.GetComponent<SpriteRenderer>().size = Skins.AttackLeft[AttackIndex].Size;
        if (gameObject.transform.eulerAngles == new Vector3(0, 0, 0))
        {
            gameObject.transform.position = new Vector3(Save.x + Skins.AttackLeft[AttackIndex].Position.x, Save.y + Skins.AttackLeft[AttackIndex].Position.y, Save.z);
        }
        else
        {
            gameObject.transform.position = new Vector3(Save.x - Skins.AttackLeft[AttackIndex].Position.x, Save.y - Skins.AttackLeft[AttackIndex].Position.y, Save.z);
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Skins.AttackLeft[AttackIndex].image;
    }

    public void nullazo()
    {
        Save = new Vector3(0, 0, 0);
        AttackIndex = 0;
        WalkIndex = 0;
    }
}
