using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerArrow : MonoBehaviour
{
    public float moveSpeed = 50f;
    private Transform enemy=null;
    private float destroyDist = 0.7f;
    public static Vector3 moveDir;
    private float damage;
    public static EnemyMove em;
    private float time = 0.5f;
    private Transform targetEnemy;
    //public static Component em;


    public static float GetAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        //n -= 90;
        
        return n;
    }
    public static void Create(Vector3 spawnPosition, Transform enemy1,float demage2)
    {
       // enemy = enemy1;
        //em = enemy1.gameObject.GetComponent<EnemyMove>();
        SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "Íj1 cut");
        spawnPosition.z = 10;
        Transform arrowTransform = Instantiate(AllGameObject.TowerArrow.transform, spawnPosition, Quaternion.identity);
        //em.changeHP(15);
        TowerArrow arrow = arrowTransform.GetComponent<TowerArrow>();
        arrow.Setup(demage2, enemy1);
    }

    //private Vector3 targetPosition;

    private void Setup(float demage2,Transform enemy1)
    {
        damage = demage2;
        targetEnemy = enemy1;
        enemy = enemy1;
    }
    public void setup(float demage2, Transform enemy1)
    {
        damage = demage2;
        targetEnemy = enemy1;
        enemy = enemy1;
    }
    private void Update()
    {
       // if (enemy)
        {
            if(!targetEnemy)
            {
                Destroy(gameObject);
                return;
            }
            moveDir = (targetEnemy.position - transform.position).normalized;

            transform.position += moveSpeed * Time.deltaTime * moveDir;

            float angle = GetAngle(moveDir);
            transform.eulerAngles = new Vector3(0, 0, angle);
        }

        
        if (Vector3.Distance(transform.position, targetEnemy.position) < destroyDist)
        {
            if (enemy)
            {
                enemy.gameObject.GetComponent<EnemyMove>().changeHP(damage);
            }

            //em.changeHP(15);

            Destroy(gameObject);

        }
        else
        {
            time -= Time.deltaTime;
            if(time<0)
            {
                if (enemy)
                {
                    enemy.gameObject.GetComponent<EnemyMove>().changeHP(damage);
                }
                Destroy(gameObject);
            }
        }
    }
}