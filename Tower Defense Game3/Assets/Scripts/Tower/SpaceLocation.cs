using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceLocation : MonoBehaviour
{
    public static Transform[] Spaces;

    void Awake()
    {
        Spaces = new Transform[transform.childCount];
        for (int i = 0; i < Spaces.Length; i++)
        {
            Spaces[i] = transform.GetChild(i);
        }
    }
}
