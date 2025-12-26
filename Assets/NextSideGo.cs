using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSideGo : MonoBehaviour
{
    public bool side = true;
    public GameObject FirstSide;
    public GameObject AutomaticPipa;
    public GameObject SecandSide;
    public void Click()
    {
        FirstSide.SetActive(!side); AutomaticPipa.SetActive(!side);
        SecandSide.SetActive(side);//
    }
}
