using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTowerButtonClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        AllGameObject.ShopButtonActivOrNotactive = !AllGameObject.ShopButtonActivOrNotactive;
        AllGameObject.Spaces.SetActive(AllGameObject.ShopButtonActivOrNotactive);       
    }
}
