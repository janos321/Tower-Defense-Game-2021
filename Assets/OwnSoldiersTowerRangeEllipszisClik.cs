using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnSoldiersTowerRangeEllipszisClik : MonoBehaviour
{
    private void OnMouseDown()
    {
        Vector3 click = AllGameObject.MainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (AllGameObject.IsItInMapRoads(click))
        {
            AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().Aim = click;
            AllGameObject.SegedUpgradeTower.GetComponent<TowerOwnSolderBuilding>().ChangeAim();
            AllGameObject.SegedUpgradeTower = null;
            Destroy(AllGameObject.SegedTowerRangeEllipszis);
        }
    }
}
