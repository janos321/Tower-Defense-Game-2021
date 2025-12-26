using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagesChangesANimation : MonoBehaviour
{
    // 1=up , 2= down , 3= right, 4= left , 5= hit
    public List<Sprite> Left = new List<Sprite>();
    public List<Sprite> AttackLeft = new List<Sprite>();
    public Sprite ClassicImagesLeft;
    public int prezent = -1;
    public int hitprezent;
    private float ImageSkipTimeWalk, ImageSkipTimeAttack;
    private float LoadinTime = 0;
    private int AttackIndex = 0, WalkIndex = 0;
    //public bool Lefte = true;
    private void Update()
    {
        if (PauseButtonImagePause.Bool) { return; }

        if (gameObject.GetComponentInParent<EnemyMove>())
        {
            /*if (gameObject.GetComponent<EnemyMove>().direction == 5)
            {
                hitprezent = prezent;
            }*/
            prezent = gameObject.GetComponent<EnemyMove>().direction;
            ImageSkipTimeAttack = gameObject.GetComponent<EnemyMove>().realodingTime;
            ImageSkipTimeWalk = (3.5f-gameObject.GetComponent<EnemyMove>().EnemySpeed)/3;
            StartCoroutine(directionChange());

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
                AttackIndex = 0;
                if (LoadinTime <(ImageSkipTimeWalk) / Left.Count)
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
                WalkIndex = 0;
                if (LoadinTime < ImageSkipTimeAttack / AttackLeft.Count)
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

        if (Left.Count - 1 == WalkIndex)
        {
            WalkIndex = 0;
        }
        else
        {
            WalkIndex++;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = Left[WalkIndex];
    }

    public void AttackAnimation()
    {
        if (AttackLeft.Count - 1 == AttackIndex)
        {
            AttackIndex = 0;
        }
        else
        {
            AttackIndex++;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = AttackLeft[AttackIndex];
    }

    public void nullazo()
    {
        AttackIndex = 0;
        WalkIndex = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = ClassicImagesLeft;
    }
}
