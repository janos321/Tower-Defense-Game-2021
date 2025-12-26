using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpenUpOptions : MonoBehaviour
{
    private bool present = false;
    public void click()
    {
        OnMouseDown();
    }
    private void OnMouseDown()
    {
        if (CameraMOverClick.mozoge)
            return;
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 1 && MENUGamobjects.TutorialMap != 4)
        {
            return;
        }
        else
                if (MENUGamobjects.TutorialMap != 0)
        {
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        AllGameObject.SetactiveFalse(4);
       present = !present;
        AllGameObject.Options.SetActive(present);
        if (!present)
        {
            AllGameObject.KonnyebbenLehessenLerakniATornyokat();
            AllGameObject.Spaces.SetActive(present);
        }

    }
}
