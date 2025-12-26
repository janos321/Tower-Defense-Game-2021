using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public int i = 1;
    private void OnMouseDown()
    {
        if (i == 1)
        {
            MiniGameAllScript.PauseButtonImageLocation.GetComponent<MiniPousIMageGAme>().Retry();
        }
        else if (i == 2)
        {
            MiniGameAllScript.PauseButtonImageLocation.GetComponent<MiniPousIMageGAme>().Menu();
        }
        else if (i == 3)
        {
            MiniGameAllScript.PauseButtonImageLocation.GetComponent<MiniPousIMageGAme>().OnMouseDown();
        }
        
    }
}
