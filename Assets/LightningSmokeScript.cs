using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSmokeScript : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(varakoztatas());
    }
   
        IEnumerator varakoztatas()
    {

        yield return new WaitForSeconds(0.55f);
        Destroy(gameObject);
    }
}
