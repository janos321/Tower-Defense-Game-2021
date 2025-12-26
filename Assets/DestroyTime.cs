using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTime : MonoBehaviour
{
    public float DestroyTimes;
    void Start()
    {
        StartCoroutine(Destroy(DestroyTimes));
    }

   public IEnumerator Destroy(float DestroyTimes)
    {
        float Timer = 0;
        while(Timer< DestroyTimes)
        {
            yield return Timer += Time.deltaTime;
        }
        Destroy(gameObject);
    }
}
