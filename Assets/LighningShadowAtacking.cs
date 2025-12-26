using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighningShadowAtacking : MonoBehaviour
{
    public int lightningDamage = 100;
    public static float range=2f;
    private void Awake()
    {
        StartCoroutine(varakoztatas2(0.27f));
        gameObject.transform.localScale = new Vector3(range, range, 1);
        for(int i=0;i<AllGameObject.AllEnemys.Count;i++)
        {
            if(AllGameObject.AllEnemys[i].transform.position.x>=(gameObject.transform.position.x-gameObject.transform.localScale.x/2)&& AllGameObject.AllEnemys[i].transform.position.x <= (gameObject.transform.localScale.x / 2 + gameObject.transform.position.x)&&AllGameObject.AllEnemys[i].transform.position.y >= (gameObject.transform.position.y - gameObject.transform.localScale.y / 2) && AllGameObject.AllEnemys[i].transform.position.y <= (gameObject.transform.localScale.y / 2 + gameObject.transform.position.y))
                    {
                if (AllGameObject.AllEnemys[i].GetComponentInParent<EnemyMove>())
                {
                    AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().changeHP(lightningDamage);
                    Instantiate(MENUGamobjects.SmokeLightningPrefab, AllGameObject.AllEnemys[i].transform.position, AllGameObject.AllEnemys[i].rotation);
                }

        }
        }
    }
    IEnumerator varakoztatas2(float a)
    {
        yield return new WaitForSeconds(a);
        Destroy(gameObject);
    }
}
