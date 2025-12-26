using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameHeroAnimation : MonoBehaviour
{
    public GameObject Right;
    public GameObject Left;
    public GameObject HeroAnimator;
    public int Direction = 0;
    void Start()
    {
        Direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(MiniPousIMageGAme.Bool)
        {
            HeroAnimator.GetComponent<Animator>().enabled = false;
            return;
        }
        if(Direction==0)
        {
            HeroAnimator.GetComponent<Animator>().enabled = false;
            return;
        }
        HeroAnimator.GetComponent<Animator>().enabled = true;
        Right.SetActive(false);
        Left.SetActive(false);
        if (Direction == 1)
        {
            Right.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("Right");
        }
        else
            if (Direction == 2)
        {
            Left.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("Left");
        }
        else
          if (Direction == 3)
        {
            Right.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("KleopatraRight");
        }
        else
          if (Direction == 4)
        {
            Left.SetActive(true);
            HeroAnimator.GetComponent<Animator>().Play("KleopatraLeft");
        }
    }
}
