using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePositionOwnSoldiers : MonoBehaviour
{
    public GameObject Tower;
    private void OnMouseDown()
    {
        Tower.GetComponent<TowerOwnSolderBuilding>().rangeSetactive();
    }
}
