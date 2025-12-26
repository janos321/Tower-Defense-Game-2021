using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterSpawner : MonoBehaviour
{
    public GameObject Humster;
    public List<GameObject> Celok = new List<GameObject>();

    public void click()
    {
        GameObject Hum = Instantiate(Humster, gameObject.transform);
        Hum.GetComponent<HamsterRun>().indulas = gameObject;
        Hum.GetComponent<HamsterRun>().cel = Celok[Random.Range(0,Celok.Count)];
    }
}
