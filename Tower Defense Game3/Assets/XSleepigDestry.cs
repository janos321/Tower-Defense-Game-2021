using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XSleepigDestry : MonoBehaviour
{
    public void Awake()
    {
        gameObject.transform.position += new Vector3(0,0,20);
        StartCoroutine(Sleeping());
    }
    IEnumerator Sleeping()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
