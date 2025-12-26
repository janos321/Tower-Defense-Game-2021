using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuistionMArkEnciklopediaPagesSetActive : MonoBehaviour
{
    public List<GameObject> QuistionMark = new List<GameObject>();
    public List<int> mapCountSetActiveTrue = new List<int>();
    public List<GameObject> Pages = new List<GameObject>();
    public static List<GameObject> Szabade = new List<GameObject>();
    private void Start()
    {
        int seged = 0;
        for (int i = 0; i < 10; i++)
        {
            if (database.MAP[i] != 0||seged==0)
            {
                if(database.MAP[i]==0)
                {
                    seged = 1;
                }
                for(int j=0;j<QuistionMark.Count;j++)
                {
                    if(mapCountSetActiveTrue[j]==i+1)
                    {
                        if (Pages[j] != null)
                            Pages[j].SetActive(true);
                        Pages[j] = null;
                        QuistionMark[j].SetActive(false);
                        
                    }
                    else
                    {
                        if (Pages[j] != null)
                        {
                            QuistionMark[j].SetActive(true);
                            Pages[j].SetActive(false);
                        }
                    }
                }
            }
        }
        Szabade.Clear();
        for(int i=0;i<Pages.Count;i++)
        {
            Szabade.Add(Pages[i]);
        }
    }
}
