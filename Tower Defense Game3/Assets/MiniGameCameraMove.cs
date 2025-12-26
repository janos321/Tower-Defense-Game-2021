using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameCameraMove : MonoBehaviour
{
    //private float panSpeed = 7f;
    private GameObject map;
    public static float mapMinX, mapMaxX, mapMinY, mapMaxY, camMinX, camMaxX, camMinY, camMaxY;

    public void Start()
    {
        map = GameObject.Find("Image");
        /*for(int i=0;i<MoveObjects.Count;i++)
        {
            xPostitionMoveObjects.Add((2f * Camera.main.orthographicSize)-MoveObjects[i].transform.position.x);
            yPostitionMoveObjects.Add((2f * Camera.main.orthographicSize * Camera.main.aspect)-MoveObjects[i].transform.position.y);
        }*/
        mapMaxX = map.GetComponent<BoxCollider2D>().bounds.center.x + map.GetComponent<BoxCollider2D>().bounds.extents.x;
        mapMinX = map.GetComponent<BoxCollider2D>().bounds.center.x - map.GetComponent<BoxCollider2D>().bounds.extents.x;
        mapMaxY = map.GetComponent<BoxCollider2D>().bounds.center.y + map.GetComponent<BoxCollider2D>().bounds.extents.y;
        mapMinY = map.GetComponent<BoxCollider2D>().bounds.center.y - map.GetComponent<BoxCollider2D>().bounds.extents.y;
        CoordChange();
    }
    void Update()
    {
        //Checkpointok
        if (MiniGameAllScript.PrincesCheckpoint2.active)
        {
            if (MiniGameAllScript.HERO == null)
                return;
            if (MiniGameAllScript.HERO.transform.position.x + 5f > gameObject.transform.position.x&&mapMaxX>camMaxX) {
                Vector2 direction = new Vector2(1f, 0f);
                transform.Translate(direction.normalized *MiniGameAllScript.speed * Time.deltaTime, Space.World);
                CoordChange();
            }
            else
            if(MiniGameAllScript.HERO.transform.position.x -4f< camMinX && mapMinX<camMinX)
            {
                Vector2 direction = new Vector2(-1f, 0f);
                transform.Translate(direction.normalized * MiniGameAllScript.speed * Time.deltaTime, Space.World);
                CoordChange();
            }
        }
        else
        {
            if (MiniGameAllScript.HERO == null)
                return;
            if (MiniGameAllScript.HERO.transform.position.x - 5f < gameObject.transform.position.x&&mapMinX<camMinX)
            {
                Vector2 direction = new Vector2(-1f, 0f);
                transform.Translate(direction.normalized * MiniGameAllScript.speed * Time.deltaTime, Space.World);
                CoordChange();
            }
            else
            if (MiniGameAllScript.HERO.transform.position.x +4f > camMaxX && mapMaxX>camMaxX)
            {
                Vector2 direction = new Vector2(+1f, 0f);
                transform.Translate(direction.normalized * MiniGameAllScript.speed * Time.deltaTime, Space.World);
                CoordChange();
            }
        }

        /*if (MENUGamobjects.kameramozgatas != 0)
            return;
        if (camMaxX != gameObject.transform.position.x + (2f * Camera.main.orthographicSize * Camera.main.aspect) / 2 || camMaxY != gameObject.transform.position.y + (2f * Camera.main.orthographicSize) / 2)
        {
            CoordChange();
        }
        if (Input.GetKey("w") && camMaxY < mapMaxY)
        {
            Vector2 direction = new Vector2(0f, 1f);
            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }
        else
            if (Input.GetKey("d") && camMaxX < mapMaxX)
        {
            Vector2 direction = new Vector2(1f, 0f);
            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }
        else
        if (Input.GetKey("a") && camMinX > mapMinX)
        {

            Vector2 direction = new Vector2(-1f, 0f);

            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }
        else
        if (Input.GetKey("s") && camMinY > mapMinY)
        {

            Vector2 direction = new Vector2(0f, -1f);


            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }

        */


    }
    public void CoordChange()
    {
        camMaxX = gameObject.transform.position.x + (2f * Camera.main.orthographicSize * Camera.main.aspect) / 2;
        camMinX = gameObject.transform.position.x - (2f * Camera.main.orthographicSize * Camera.main.aspect) / 2;
        camMaxY = gameObject.transform.position.y + (2f * Camera.main.orthographicSize) / 2;
        camMinY = gameObject.transform.position.y - (2f * Camera.main.orthographicSize) / 2;
        /*camMaxX = gameObject.GetComponent<BoxCollider2D>().transform.position.x + gameObject.GetComponent<BoxCollider2D>().size.x / 2;
            camMinX = gameObject.GetComponent<BoxCollider2D>().transform.position.x - gameObject.GetComponent<BoxCollider2D>().size.x / 2;
            camMaxY = gameObject.GetComponent<BoxCollider2D>().transform.position.y + gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            camMinY = gameObject.GetComponent<BoxCollider2D>().transform.position.y - gameObject.GetComponent<BoxCollider2D>().size.y / 2;*/
        /*for(int i=0;i<MoveObjects.Count;i++)
        {
            MoveObjects[i].transform.position = new Vector3(camMaxX - xPostitionMoveObjects[i], camMaxY - yPostitionMoveObjects[i], 5);
        }*/
            try
            {
                MiniGameAllScript.attackfromheavenButton.transform.position = new Vector2(camMaxX - 5.5f, camMinY + 1.65f);
                MiniGameAllScript.PauseButtonImageLocation.transform.position = new Vector2(camMinX + 1.5f, camMaxY - 1f);
                MiniGameAllScript.GameOverPanel.transform.position = new Vector2((camMaxX - camMinX) / 2, (camMaxY - camMinY) / 2 + camMinY);
           //MiniGameAllScript.PauseMenuPanel.transform.position = new Vector2((camMaxX - camMinX) / 2, (camMaxY - camMinY) / 2 + camMinY);
            MiniGameAllScript.HealthBarGamobject3.transform.position = new Vector2((camMaxX - camMinX) / 2 + camMinX, camMaxY - 1f);
                //MiniGameAllScript.BigFingerMoveCircle2.transform.position = new Vector2(camMinX+2.5f, camMinY+2.5f);
            }
            catch
            {

            }


    }
}
