using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WifiBlockPrefabSript : MonoBehaviour
{
    public float DIeTime = 1;
    void Start()
    {
        gameObject.transform.position = new Vector3((CameraMove.camMaxX - CameraMove.camMinX) / 2 + CameraMove.camMinX, (CameraMove.camMaxY - CameraMove.camMinY) / 2 + CameraMove.camMinY, 5);
        if (Camera.main.GetComponentInParent<CameraMove>()) 
        { 
         gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x * Camera.main.GetComponent<CameraMove>().ScalaPersentage * LogInRegisztrelScript.CameraPersentAge, gameObject.transform.localScale.y * Camera.main.GetComponent<CameraMove>().ScalaPersentage * LogInRegisztrelScript.CameraPersentAge, gameObject.transform.localScale.z);
            }
        StartCoroutine(megszuntetes());
    }

    public IEnumerator megszuntetes()
    {
        yield return new WaitForSeconds(DIeTime);
        Destroy(gameObject);
    }
}
