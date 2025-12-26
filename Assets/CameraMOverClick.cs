using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMOverClick : MonoBehaviour
{
    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    public static bool mozoge;
    private float timer = 0;

    void Update()
    {
        if (MENUGamobjects.kameramozgatas != 0)
            return;
        mozoge = false;
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
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        if (MENUGamobjects.kameramozgatas != 0)
            return;
        if (Input.touchCount>0)
        {
            if (Input.touchCount !=1)
            {
                timer = 0.2f;
                return;
            }
        }
        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.
        direction = direction * -1;

        Vector3 position = camera_position + direction;

        if(Mathf.Abs(position.x- camera_position.x)<0.1f&&Mathf.Abs( position.y - camera_position.y)<0.1f)
        {
            mozoge = false;
        }
        else
        {
            if(AllGameObject.PauseButtonImageLocation!=null&&MENUGamobjects.TutorialMap==0)
            {
                if (AllGameObject.heroactive&&AllGameObject.designateCaracter==AllGameObject.HERO)
                {
                    AllGameObject.SetactiveFalse(14);
                    AllGameObject.heroactive = true;
                }
                else
                {
                    AllGameObject.SetactiveFalse(14);
                }
            }
            mozoge = true;
        }
        if (!mozoge)
            return;
        Vector3 positions = position - gameObject.transform.position;

        if(MENUGamobjects.TutorialMap==8)
        {
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        if (positions.x == 0 && positions.y != 0)
        {
            if (positions.y > 0)
            {
                if (CameraMove.camMaxY < CameraMove.mapMaxY)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }
            else
            {
                if (CameraMove.camMinY > CameraMove.mapMinY)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }
        }
        else
if (positions.x != 0 && positions.y == 0)
        {
            if (positions.x > 0)
            {
                if (CameraMove.camMaxX < CameraMove.mapMaxX)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }
            else
            {
                if (CameraMove.camMinX > CameraMove.mapMinX)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }
        }
        else
if (positions.x > 0)
        {
            if (positions.y > 0)
            {
                if (CameraMove.camMaxY < CameraMove.mapMaxY && CameraMove.camMaxX < CameraMove.mapMaxX)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                    if(CameraMove.camMaxY >= CameraMove.mapMaxY && CameraMove.camMaxX < CameraMove.mapMaxX)
                {
                    transform.position = new Vector3(position.x, transform.position.y,-20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                if(CameraMove.camMaxY < CameraMove.mapMaxY && CameraMove.camMaxX >= CameraMove.mapMaxX)
                {
                    transform.position = new Vector3(transform.position.x,position.y , -20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }
            else
            {
                if (CameraMove.camMinY > CameraMove.mapMinY && CameraMove.camMaxX < CameraMove.mapMaxX)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                    if (CameraMove.camMinY <= CameraMove.mapMinY && CameraMove.camMaxX < CameraMove.mapMaxX)
                {
                    transform.position = new Vector3(position.x, transform.position.y, -20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                if (CameraMove.camMinY > CameraMove.mapMinY && CameraMove.camMaxX >= CameraMove.mapMaxX)
                {
                    transform.position = new Vector3(transform.position.x, position.y, -20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }

        }
        else
        {
            if (positions.y > 0)
            {
                if (CameraMove.camMaxY < CameraMove.mapMaxY && CameraMove.camMinX > CameraMove.mapMinX)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                    if (CameraMove.camMaxY >= CameraMove.mapMaxY && CameraMove.camMinX > CameraMove.mapMinX)
                {
                    transform.position = new Vector3(position.x, transform.position.y, -20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                if (CameraMove.camMaxY < CameraMove.mapMaxY && CameraMove.camMinX <= CameraMove.mapMinX)
                {
                    transform.position = new Vector3(transform.position.x, position.y, -20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }
            else
            {
                if (CameraMove.camMinY > CameraMove.mapMinY && CameraMove.camMinX > CameraMove.mapMinX)
                {
                    transform.position = position;
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                    if (CameraMove.camMinY <= CameraMove.mapMinY && CameraMove.camMinX > CameraMove.mapMinX)
                {
                    transform.position = new Vector3(position.x, transform.position.y, -20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
                else
                if (CameraMove.camMinY > CameraMove.mapMinY && CameraMove.camMinX <= CameraMove.mapMinX)
                {
                    transform.position = new Vector3(transform.position.x, position.y, -20);
                    Camera.main.GetComponent<CameraMove>().CoordChange();
                }
            }

        }
    }
}
