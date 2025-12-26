using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzoganyMove : MonoBehaviour
{
    public float moveSpeed = 50f;

    public float damage;
    public Transform targetEnemy;

    //public static Transform enemy = null;
    private float destroyDist = 0.5f;
    private Vector3 moveDir;
    //public static EnemyMove em;
    private float time = 0.5f;
    //public static Component em;
    private float ForgasN=0;


    private float GetAngle(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        n += ForgasN;
        ForgasN+=65f;

        return n;
    }

    /*public static void Create(Vector3 spawnPosition, Transform enemy1, float demage2)
    {
        enemy = enemy1;
         em = enemy1.gameObject.GetComponent<EnemyMove>();
        spawnPosition.z = 10;
        Transform arrowTransform = Instantiate(AllGameObject.Buzogany.transform, spawnPosition, Quaternion.identity);
        BuzoganyMove arrow = arrowTransform.GetComponent<BuzoganyMove>();
        arrow.Setup(demage2, enemy1);
    }

    //private Vector3 targetPosition;

    private void Setup(float demage2, Transform enemy1)
    {
        damage = demage2;
        targetEnemy = enemy1;
    }*/

    private void Update()
    {
        // if (enemy)
        {
            if (!targetEnemy)
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
            if (targetEnemy)
            {
                targetEnemy.GetComponent<EnemyMove>().changeHP(damage);
            }
            //em.changeHP(15);

            Destroy(gameObject);

        }
        else
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                if (targetEnemy)
                {
                    targetEnemy.GetComponent<EnemyMove>().changeHP(damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
