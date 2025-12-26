using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapOnMosueClickGame : MonoBehaviour
{
    public static bool voltmar = false;
    public static Vector3 Target = new Vector3(-0.000000000000051515f, 0.254511f, 0), click;
    public static int xd = 0;
    public static IEnumerator varakoztatas(float a)
    {
        if (MiniPousIMageGAme.Bool)
           yield return null;
        if (Input.touchCount >= 2)
        {
            click = MiniGameAllScript.MainCamera.ScreenToWorldPoint(Input.GetTouch(Input.touchCount - 1).position);
           /* if (MENUGamobjects.Bennevane(MiniGameAllScript.Jozstic.transform, click))
            {
                Debug.Log("bENNE VAN");
            }*/
     //click = Input.GetTouch(Input.touchCount - 1).position;
     //Debug.Log(Input.touchCount - 1);
    /* for(int i=0;i<Input.touchCount;i++)
     {
         if (MENUGamobjects.Bennevane(MiniGameAllScript.Joystick2.transform, Input.GetTouch(i).position))
         {
            //Debug.Log("Benne van " + i);
         }
         else
         {
             //Debug.Log("Ninincs benne "+i);
         }
     }*/
        }
        else
        {
             click = MiniGameAllScript.MainCamera.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            /*if (MENUGamobjects.Bennevane(MiniGameAllScript.Jozstic.transform, click))
            {
                Debug.Log("bENNE VAN");
            }*/
        }
       /* if (MENUGamobjects.Bennevane(MiniGameAllScript.Joystick2.transform, click)) ;
            yield return null;*/
        MiniGameAllScript.SetactiveFalse(-1);
        click = new Vector3(click.x, click.y, 0);
        //Vector3 click = new Vector3(Random.Range(MiniGameAllScript.HERO.transform.position.x * 1000, (MiniGameAllScript.HERO.transform.position.x + 2f) * 1000)/1000, MiniGameAllScript.HERO.transform.position.y, 5);
        if (MiniGameAllScript.attackfromheavenClickBool)
        {
            MiniGameAllScript.ShadowArrow.SetActive(true);
            MiniGameAllScript.BPositionAttack.transform.position = click;
            MiniGameAllScript.APositionAttack.transform.position = new Vector3(MiniGameAllScript.BPositionAttack.transform.position.x, MiniGameAllScript.APositionAttack.transform.position.y, 1f);
            SoundsScript.MusicStart(MiniGameAllScript.MiniGame, "Nyilaskepessegvágott");
            Instantiate(MiniGameAllScript.attackfromheavenArrows.transform, MiniGameAllScript.APositionAttack.position, MiniGameAllScript.attackfromheavenArrows.transform.rotation);
            Instantiate(MiniGameAllScript.attackfromheavenArrows.transform, MiniGameAllScript.APositionAttack.position, MiniGameAllScript.attackfromheavenArrows.transform.rotation);
            MiniGameAllScript.BPositionAttack.transform.position = click;
            MiniGameAllScript.APositionAttack.transform.position = new Vector3(MiniGameAllScript.BPositionAttack.transform.position.x, MiniGameAllScript.APositionAttack.transform.position.y, 1f);
            /*if (!MiniGameAllScript.WinnerCheckpoint2.active)
            {
                MiniGameAllScript.BPositionAttack.transform.position = new Vector3(MiniGameAllScript.HERO.transform.position.x+1.5f, MiniGameAllScript.HERO.transform.position.y, 5);
                MiniGameAllScript.APositionAttack.transform.position = new Vector3(MiniGameAllScript.BPositionAttack.transform.position.x, MiniGameAllScript.APositionAttack.transform.position.y, 1f);
            }
            else
            {
                MiniGameAllScript.BPositionAttack.transform.position = new Vector3(MiniGameAllScript.HERO.transform.position.x- 1.5f, MiniGameAllScript.HERO.transform.position.y, 5);
                MiniGameAllScript.APositionAttack.transform.position = new Vector3(MiniGameAllScript.BPositionAttack.transform.position.x, MiniGameAllScript.APositionAttack.transform.position.y, 1f);

            }

            Instantiate(MiniGameAllScript.attackfromheavenArrows.transform, MiniGameAllScript.APositionAttack.position, MiniGameAllScript.attackfromheavenArrows.transform.rotation);
            Instantiate(MiniGameAllScript.attackfromheavenArrows.transform, MiniGameAllScript.APositionAttack.position, MiniGameAllScript.attackfromheavenArrows.transform.rotation);
            Instantiate(MiniGameAllScript.attackfromheavenArrows.transform, MiniGameAllScript.APositionAttack.position, MiniGameAllScript.attackfromheavenArrows.transform.rotation);
            Instantiate(MiniGameAllScript.attackfromheavenArrows.transform, MiniGameAllScript.APositionAttack.position, MiniGameAllScript.attackfromheavenArrows.transform.rotation);
            Instantiate(MiniGameAllScript.attackfromheavenArrows.transform, MiniGameAllScript.APositionAttack.position, MiniGameAllScript.attackfromheavenArrows.transform.rotation);
            if (!MiniGameAllScript.WinnerCheckpoint2.active)
            {
                MiniGameAllScript.BPositionAttack.transform.position = new Vector3(MiniGameAllScript.HERO.transform.position.x+ 1.5f, MiniGameAllScript.HERO.transform.position.y, 5);
                MiniGameAllScript.APositionAttack.transform.position = new Vector3(MiniGameAllScript.BPositionAttack.transform.position.x, MiniGameAllScript.APositionAttack.transform.position.y, 1f);
            }
            else
            {
                MiniGameAllScript.BPositionAttack.transform.position = new Vector3(MiniGameAllScript.HERO.transform.position.x- 1.5f, MiniGameAllScript.HERO.transform.position.y, 5);
                MiniGameAllScript.APositionAttack.transform.position = new Vector3(MiniGameAllScript.BPositionAttack.transform.position.x, MiniGameAllScript.APositionAttack.transform.position.y, 1f);

            }
            */
            MiniGameAllScript.attackfromheavenClickBool = false;
            voltmar = true;


        }
            yield return null;
    }

    /*public void OnMouseDrag()
    {
        if(Input.touchCount==1)
        Debug.Log(Input.GetTouch(0).position);
    }*/
    public void OnMouseDown()
        {
            StartCoroutine(varakoztatas(0.1f));
        }
    
}
