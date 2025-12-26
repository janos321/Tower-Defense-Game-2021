using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowArrowScaleUpgrowth : MonoBehaviour
{
    private float present = 0;
    private Transform seged;
    public float Demage;
    void Start()
    {
        present = 0;
        seged = gameObject.transform;
        seged.transform.position = new Vector3(seged.transform.position.x, seged.transform.position.y, 0);
        seged.localScale = new Vector3(0.1f, 0.05f, 0);       
        StartCoroutine(ShadowScele(0.5f));
        
    }
    IEnumerator ShadowScele(float time)
    {
        while (present <= time)
        {            
            present += Time.deltaTime;
            gameObject.transform.localScale= Vector3.Lerp(seged.localScale, new Vector3(0.35f, 0.2f, 0), (present* Time.deltaTime / time));//AllGameObject.Arrowsoblique.Evaluate(present / time));
            yield return null;
        }
        float shadowleft = gameObject.transform.position.x - 1.5f, shadowright = gameObject.transform.position.x + 1.5f, shadowup = gameObject.transform.position.y + 1f, shadowdown = gameObject.transform.position.y - 1f;
        for(int i=0;i<AllGameObject.AllEnemys.Count;i++)
        {
           if(AllGameObject.AllEnemys[i].position.x>=shadowleft&& AllGameObject.AllEnemys[i].position.x <= shadowright&& AllGameObject.AllEnemys[i].position.y >= shadowdown&& AllGameObject.AllEnemys[i].position.y <= shadowup)
            {
                AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().changeHP(Demage);
            }
        }
        Destroy(gameObject);
    }
}
