using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecuendHeroSkill : MonoBehaviour
{
    public float DestroyTimes;
    private int indexek = 0;
    public List<GameObject> cracks;
    public GameObject Hero;
    void Start()
    {
        StartCoroutine(Destroy(DestroyTimes));
    }

    public IEnumerator Destroy(float DestroyTimes)
    {
        float Timer = 0;
        while (Timer < DestroyTimes)
        {
            if((DestroyTimes/ cracks.Count) * indexek <=Timer)
            {
                if (indexek < cracks.Count&&!cracks[indexek].active)
                {
                    cracks[indexek].SetActive(true);
                    for(int i=0;i<AllGameObject.AllEnemys.Count;i++)
                    {
                        if (AllGameObject.AllEnemys[i] != null && MENUGamobjects.Bennevane(cracks[indexek].transform, AllGameObject.AllEnemys[i].position))
                        {
                            float damage = 10;
                            if (Hero != null)
                            {
                                 damage = Hero.GetComponent<CLassicHEroScript>().DashDamage;
                            }
                            AllGameObject.AllEnemys[i].GetComponent<EnemyMove>().changeHP(damage);
                        }
                    }
                    indexek++;
                }
            }
            yield return Timer += Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
