using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniSkeletonMoverAndAttackGAme : MonoBehaviour
{
    public float speed = 4;
    public float Demage = 20;
    public float range = 10;
    public float DeamgeRange = 3;
    public float ReloadingTime = 2;
    //public float MAxHp=10;
    public string eddig = "-----------------------------------";
    private List<Transform> checkponts = new List<Transform>();
    //public float CurentHp;
    public Transform Checkpoint;
    private Transform Target =null;
    private int index = 0;
    private float reloadingTime = 0;
    private void Start()
    {
        reloadingTime = ReloadingTime/2;
        //CurentHp = MAxHp;
        MiniGameAllScript.AllEnemys.Add(gameObject);
        for(int i=0;i< Checkpoint.transform.childCount;i++)
        {
            checkponts.Add(Checkpoint.transform.GetChild(i));
        }
    }
    private void Update()
    {
        if (MiniPousIMageGAme.Bool|| MiniGameAllScript.HERO==null)
            return;
        if(Vector3.Distance( MiniGameAllScript.HERO.transform.position,gameObject.transform.position) <=range)
        {
            Target = MiniGameAllScript.HERO.transform;
            if(Vector3.Distance(MiniGameAllScript.HERO.transform.position, gameObject.transform.position) <= DeamgeRange)
            {
                if(reloadingTime>=ReloadingTime)
                {
                    MiniGameAllScript.Demage(Demage);
                    reloadingTime = 0;
                }
                reloadingTime += Time.deltaTime;
            }
        }
        else
        { 
            if(Vector3.Distance(gameObject.transform.position, checkponts[index].position)<0.1f)
            {

                if (index < checkponts.Count-1)
                {
                    index++;
                    
                }
                else
                    if(index == checkponts.Count - 1)
                {
                    index = 0;
                }
                
            }
            Target = checkponts[index];
        }
            Vector2 dir = Target.position - transform.position;
        if (Mathf.Abs( Vector3.Distance(MiniGameAllScript.HERO.transform.position, gameObject.transform.position)) < 0.2f)
        {
            gameObject.GetComponent<RightLeftAttackAnimationScript>().Direction = 0;
        }
        else
        {
            gameObject.GetComponent<RightLeftAttackAnimationScript>().Direction = MENUGamobjects.directiondefinition(dir);
        }
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
    }
}
