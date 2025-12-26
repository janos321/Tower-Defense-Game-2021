using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeFelmozgatas : MonoBehaviour
{
    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    public static float mapMinY, mapMaxY;
    public GameObject map;
    private void Start()
    {
        CoordChange();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
    }

    void LeftMouseDrag()
    {

        if (Input.touchCount > 0)
        {
            if (Input.touchCount != 1)
            {
                return;
            }
        }

        current_position.z = hit_position.z = camera_position.y;

        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);


        direction = direction;

        Vector3 position = camera_position + direction;

        if (Mathf.Abs(position.x - camera_position.x) < 0.1f && Mathf.Abs(position.y - camera_position.y) < 0.1f)
        {
            return;
        }

        Vector3 positions = position - map.transform.position;
        positions.z = 5;
        if(positions.y>0)
        {
            if (CameraMove.camMinY > mapMinY)
            {
               map.transform.position = new Vector3(map.transform.position.x,position.y, 5);
                CoordChange();
            }
        }
        else
        {
            if (CameraMove.camMaxY < mapMaxY)
            {
                map.transform.position = new Vector3(map.transform.position.x,position.y, 5);
                CoordChange();
            }
        }
    }


    public void CoordChange()
    {
        mapMaxY = map.GetComponent<BoxCollider2D>().bounds.center.y + 7;
        mapMinY = map.GetComponent<BoxCollider2D>().bounds.center.y - 7;
        if(CameraMove.camMinY < mapMinY)
        {
            map.transform.position = new Vector3(map.transform.position.x, map.transform.position.y-(mapMinY- CameraMove.camMinY), 5);
            mapMinY = CameraMove.camMinY;
        }
        else
            if(CameraMove.camMaxY > mapMaxY)
        {
            map.transform.position = new Vector3(map.transform.position.x, map.transform.position.y + (CameraMove.camMaxY-mapMaxY), 5);
            mapMaxY = CameraMove.camMaxY;
        }
    }
}
