using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationMOve : MonoBehaviour
{
    // 1=up , 2= down , 3= right, 4= left , 5= hit
    public GameObject Up;
    public GameObject right;
    public GameObject Down;
    public GameObject Left;
    public GameObject Mother;
    public int prezent = -1;
    //public bool dogOrNo;
    private int hitprezent;
    private void Update()
    {
        if (PauseButtonImagePause.Bool) {  return; }
        if (prezent != 0)
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }

        if (gameObject.GetComponentInParent<EnemyMove>())
        {
            if(prezent!=gameObject.GetComponent<EnemyMove>().direction)
            {
                if(gameObject.GetComponent<EnemyMove>().direction==5)
                {
                    hitprezent = prezent;
                }
                prezent = gameObject.GetComponent<EnemyMove>().direction;
                directionChange();
            }
            if (gameObject.GetComponent<EnemyMove>().direction == 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
            }
        }
        else
             if (Mother.GetComponentInParent<SoldiersMove>())
        {
            if (prezent != Mother.GetComponent<SoldiersMove>().direction)
            {
                if (Mother.GetComponent<SoldiersMove>().direction == 5)
                {
                    hitprezent = prezent;
                }
                prezent = Mother.GetComponent<SoldiersMove>().direction;
                //Debug.Log(prezent);
                directionChange();
            }
            if (Mother.GetComponent<SoldiersMove>().direction == 0)
            {
                gameObject.GetComponent<Animator>().enabled = false;
            }
        }

    }

    public void directionChange()
    {
        if (prezent == 0)
        {
            gameObject.GetComponent<Animator>().enabled = false;
            if(!Up.active&& !Down.active && !right.active && !Left.active)
            {
                Left.SetActive(true);
            }
        }
        else
        {
            Up.SetActive(false);
            right.SetActive(false);
            Down.SetActive(false);
            Left.SetActive(false);

            if (prezent == 1)
            {
                Up.SetActive(true);
                gameObject.GetComponent<Animator>().Play("Up");
            }
            else
                if (prezent == 2)
            {
                Down.SetActive(true);
                gameObject.GetComponent<Animator>().Play("Down");
            }
            else
              if (prezent == 3)
            {
                right.SetActive(true);
                gameObject.GetComponent<Animator>().Play("Right");
            }
            else
              if (prezent == 4)
            {
                Left.SetActive(true);
                gameObject.GetComponent<Animator>().Play("Left");
            }
            else
                if (prezent == 5)
            {
                    if (hitprezent == 1)
                    {
                        Up.SetActive(true);
                        gameObject.GetComponent<Animator>().Play("UpHit");
                    }
                    else
                    if (hitprezent == 2)
                    {
                        Down.SetActive(true);
                        gameObject.GetComponent<Animator>().Play("DownHit");
                    }
                    else
                    if (hitprezent == 3)
                    {
                        right.SetActive(true);
                        gameObject.GetComponent<Animator>().Play("RightHit");
                    }
                    else
                    if (hitprezent == 4)
                    {
                        Left.SetActive(true);
                        gameObject.GetComponent<Animator>().Play("LeftHit");
                    }
                
            }
        }
    }

}
