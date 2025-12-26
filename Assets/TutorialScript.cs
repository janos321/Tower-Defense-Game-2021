using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public List<GameObject> TutorialPages2 = new List<GameObject>();
    public static List<GameObject> TutorialPages = new List<GameObject>();
    public static void ChangePages()
    {
        for(int i=0;i<TutorialPages.Count;i++)
        {
            if(MENUGamobjects.TutorialMap==i+1)
            {
                TutorialPages[i].SetActive(true);
            }
            else
            {
                TutorialPages[i].SetActive(false);
            }
        }
    }

    void Start()
    {
        TutorialPages.Clear();
        for(int i=0;i<TutorialPages2.Count;i++)
        {
            TutorialPages.Add(TutorialPages2[i]);
        }
        ChangePages();
        TutorialPages2[TutorialPages2.Count - 1].SetActive(true);
        TutorialPages2[TutorialPages2.Count - 2].SetActive(true);
    }

}
