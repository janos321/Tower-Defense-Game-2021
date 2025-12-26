using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroLoadingSeconButtonScript : MonoBehaviour
{
    public int LOadingTime=1;
    float Timer = 0;
    Vector3 a,b;
    float radiox, radioy;
    public string h = "0=died,1=ability1,2=abality2";
    public int index=0;
    void Update()
    {
        if (PauseButtonImagePause.Bool)
            return;
        if(index==1)
        {
            Timer = AllGameObject.Abality1Timer;
        }
        else
         if (index == 2)
        {
            Timer = AllGameObject.Abality2Timer;
        }
        if ((AllGameObject.heroLOadintActive&&index==0)|| (AllGameObject.Abality1LOadintActive && index == 1) || (AllGameObject.Abality2LOadintActive && index == 2) )
        {
            if (Timer == 0)
            {
                radiox = gameObject.GetComponent<Transform>().localScale.x; radioy = AllGameObject.SecondCircleLOading.GetComponent<Transform>().localScale.y;
                a = gameObject.GetComponent<Transform>().localScale; b = new Vector3(0, 0, 0);
            }
            {
                gameObject.GetComponent<Transform>().localScale = Vector3.Lerp(a, b, Timer / LOadingTime);
               Timer += Time.deltaTime;
                if (index == 1)
                {
                    AllGameObject.Abality1Timer=Timer;
                }
                else
                if (index == 2)
                {
                    AllGameObject.Abality2Timer=Timer;
                }
            }
            if (Timer >= LOadingTime)
            {
                Timer = 0;
                if (index == 1)
                {
                    AllGameObject.Abality1Timer=0;
                }
                else
                if (index == 2)
                {
                    AllGameObject.Abality2Timer=0;
                }
                gameObject.GetComponent<Transform>().localScale = new Vector3(radiox, radioy, 0);
                if(index==0)
                {
                    AllGameObject.heroLOadintActive = false;
                }
                else
                    if(index==1)
                {
                    AllGameObject.Abality1LOadintActive = false;
                }
                else
                    if(index==2)
                {
                    AllGameObject.Abality2LOadintActive = false;
                }
                gameObject.SetActive(false);
            }

        }
    }
}
