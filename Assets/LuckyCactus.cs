using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCactus : MonoBehaviour
{
    public int index = 0;
    private float TimerMax = 2f,PresentTimer=0;
    public GameObject Cube;
    private float forogXRotian = 0;
    public static bool forog = true;

    private void Update()
    {
        if(index==MiniGameAllScript.LuckyCactusIndex&& PresentTimer!=-1)
        {
            if(MiniGameAllScript.HERO!=null)
            if(Vector3.Distance(MiniGameAllScript.HERO.transform.position,gameObject.transform.position)<=0.5f)
            {
                if (PresentTimer< TimerMax)
                {
                    PresentTimer += Time.deltaTime;
                }
                else
                {
                    PresentTimer = -1;                    
                    MiniGameAllScript.PauseButtonImageLocation.GetComponent<MiniPousIMageGAme>().OnMouseDown();
                    MiniGameAllScript.PauseButtonImageLocation.SetActive(false);
                    MiniGameAllScript.LuckyPanel2.SetActive(true);
                }
            }
        }
        if(forog&& index == MiniGameAllScript.LuckyCactusIndex&&Cube.active)
        {
            forogXRotian += Time.deltaTime;
            Cube.transform.eulerAngles = new Vector3(0, forogXRotian*1000, 0);
        }
    }

}
