using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xes : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (MENUGamobjects.TutorialMap != 0)
            return;

        AllGameObject.KonnyebbenLehessenLerakniATornyokat();
        AllGameObject.SetactiveFalse(-1);
    }
}
