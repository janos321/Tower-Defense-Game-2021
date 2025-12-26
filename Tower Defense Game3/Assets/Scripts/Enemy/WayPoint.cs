using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public Transform[] Points;

    void Awake()
    {
        Points = new Transform[transform.childCount];
        for(int i=0;i<Points.Length;i++)
        {
            Points[i] = transform.GetChild(i);
        }
    }
}
