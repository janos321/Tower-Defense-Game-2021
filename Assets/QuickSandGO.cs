using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSandGO : MonoBehaviour
{
    public int time;
    private float presentTime = 0;
    public GameObject QuicksandIMage;
    public static bool Setactive = false;
    private void Awake()
    {
         if(!Setactive)
        {
            Setactive = true;
        }
    }
    void Update()
    {
       
        if (presentTime > time)
        {
            Setactive = false;
            presentTime = 0;
            Destroy(gameObject);
        }

        for (int i = 0; i < AllGameObject.AllEnemys.Count; i++)
        {
            if(AllGameObject.AllEnemys[i]!=null)
            if (MENUGamobjects.Bennevane(gameObject.transform,AllGameObject.AllEnemys[i].position))
               { 
                if (AllGameObject.AllEnemys[i].GetComponentInParent<EnemyMove>()&& AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().TimeQuicksandTime==-10f)
                {
                  AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().TimeQuicksandTime = time-presentTime;
                }

            }
            else
                    if(AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().TimeQuicksandTime != -10f)
                {
                    AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().TimeQuicksandTime = 0;
                }

        }
        presentTime += Time.deltaTime;
    }

}
