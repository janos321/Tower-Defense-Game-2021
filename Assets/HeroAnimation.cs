using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAnimation : MonoBehaviour
{
    public GameObject Down;
    public GameObject Up;
    public GameObject Right;
    public GameObject Left;
    public GameObject HeroAnimator;
    public int Direction = 0;
    private int elozo = 1;
    public float Timer = 0;
    void Start()
    {
        Direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer>0)
        {
            Timer -= Time.deltaTime;
            return;
        }
        if(Direction==elozo)
        {
            return;
        }
        if (PauseButtonImagePause.Bool)
        {
            HeroAnimator.GetComponent<Animator>().enabled = false;
            return;
        }
        if (Direction == 0)
        {
            HeroAnimator.GetComponent<Animator>().enabled = false;
            return;
        }
        HeroAnimator.GetComponent<Animator>().enabled = true;
        Right.SetActive(false);
        Left.SetActive(false);
        Down.SetActive(false);
        Up.SetActive(false);
        if (Direction == 1)
        {
            elozo = 1;
            Up.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("Up");
        }
        else
            if (Direction == 2)
        {
            elozo = 2;
            Down.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("Down");
        }
        else
          if (Direction == 3)
        {
            elozo = 3;
            Right.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("Right");
        }
        else
          if (Direction == 4)
        {
            elozo = 4;
            Left.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("Left");
        }
        else
                if (Direction == 5)
        {
            if (elozo == 1)
            {
                Up.SetActive(true);
                HeroAnimator.GetComponent<Animator>().Play("UpHit");
            }
            else
            if (elozo == 2)
            {
                Down.SetActive(true);
                HeroAnimator.GetComponent<Animator>().Play("DownHit");
            }
            else
            if (elozo == 3)
            {
                Right.SetActive(true);
                HeroAnimator.GetComponent<Animator>().Play("RightHit");
            }
            else
            if (elozo == 4)
            {
                Left.SetActive(true);
                HeroAnimator.GetComponent<Animator>().Play("LeftHit");
            }

        }
    }
}
