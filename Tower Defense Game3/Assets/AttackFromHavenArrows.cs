using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFromHavenArrows : MonoBehaviour
{
    public static List<Transform> Arrows = new List<Transform>();
    public static List<Vector3> down = new List<Vector3>();
    public static List<int> nez = new List<int>(8);
    private int most = 0;
    void Start()
    {
        Arrows.Clear();
        down.Clear();
        for (int i=0;i<8;i++)
        {
            //Debug.Log(i);
            Arrows.Add(gameObject.transform.GetChild(i));
        }
        float a = AllGameObject.APositionAttack.position.y - AllGameObject.BPositionAttack.position.y;
        down.Add( new Vector3(Arrows[0].position.x, Arrows[0].position.y-a, 1) + new Vector3(0, 2f, 0));
        down.Add(new Vector3(Arrows[1].position.x, Arrows[1].position.y - a, 1) + new Vector3(0, 2f, 0));
        down.Add(new Vector3(Arrows[2].position.x, Arrows[2].position.y - a, 1) + new Vector3(0, 2f, 0));
        down.Add(new Vector3(Arrows[3].position.x, Arrows[3].position.y - a, 1) + new Vector3(0, 2f, 0));
        down.Add(new Vector3(Arrows[4].position.x, Arrows[4].position.y - a, 1) + new Vector3(0, 2f, 0));
        down.Add(new Vector3(Arrows[5].position.x, Arrows[5].position.y - a, 1) + new Vector3(0, 2f, 0));
        down.Add(new Vector3(Arrows[6].position.x, Arrows[6].position.y - a, 1) + new Vector3(0, 2f, 0));
        down.Add(new Vector3(Arrows[7].position.x, Arrows[7].position.y - a, 1) + new Vector3(0, 2f, 0));
        int szamlalo = 0,index=0;
        int[] asd = new int[10];
        asd[0] = 1;
        while (szamlalo<8)
        {
            while(asd[index]!=0)
            {
                index = Random.Range(1, 9);
            }
            asd[index] = 1;
            StartCoroutine(ArrowsDown(0.3f * szamlalo, 0.5f, index-1, 0));
            index = 0;
            szamlalo++;
        }
        

    }

    IEnumerator ArrowsDown(float nextTime,float downTime,int index,float present)
    {
        yield return new WaitForSeconds(nextTime);

        Transform Shadow = Instantiate(AllGameObject.ShadowArrow.transform, down[index] - new Vector3(0, 2f, 0), AllGameObject.attackfromheavenArrows.transform.rotation);
        Shadow.SetParent(GameObject.Find("Enemys").transform);
        while (present <= downTime)
        {
            present += Time.deltaTime;
            Arrows[index].position = Vector3.Lerp(AllGameObject.APositionAttack.position, down[index], (present) / downTime);//AllGameObject.Arrowsoblique.Evaluate(present / time));
            yield return null;
        }
        most++;
        GameObject efekt = Instantiate(AllGameObject.ArrowsDOwnParticleEffect, down[index] - new Vector3(0, 2f, 0), AllGameObject.attackfromheavenArrows.transform.rotation);
        Arrows[index].position = new Vector3(10000000, 100000000, 1);
        yield return new WaitForSeconds(0.3f);
        Destroy(efekt);
        if (most==8)
        {
            Destroy(gameObject);
        }

    }
}
