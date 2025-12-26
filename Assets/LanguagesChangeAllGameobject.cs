using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguagesChangeAllGameobject : MonoBehaviour
{
    public Read LANG;
    [System.Serializable]
    public class Translate
    {
        public List<GameObject> Text = new List<GameObject>();
        public List<string> Languasges = new List<string>();
    }
    [System.Serializable]
    public class Read
    {
        public List<string> Langs = new List<string>();
        public List<Translate> TextCount = new List<Translate>();
    }
    void Start()
    {
        LanguagesChange(database.LNG, LANG);
    }

    public static void LanguagesChange(string Lang, Read LANg)
    {
        database.LNG = Lang;
        int index = 0;
        for (int i = 0; i < LANg.Langs.Count; i++)
        {
            if (Lang == LANg.Langs[i])
            {
                index = i;
                break;
            }
        }
        for (int i = 0; i < LANg.TextCount.Count; i++)
        {
            for (int j = 0; j < LANg.TextCount[i].Text.Count; j++)
            {
                if (LANg.TextCount[i].Languasges[index].IndexOf('|') == -1)
                {
                    LANg.TextCount[i].Text[j].GetComponent<Text>().text = LANg.TextCount[i].Languasges[index];
                }
                else
                {
                    string[] split = LANg.TextCount[i].Languasges[index].Split('|');
                    LANg.TextCount[i].Text[j].GetComponent<Text>().text = split[0];
                    for (int k = 1; k < split.Length; k++)
                    {
                        LANg.TextCount[i].Text[j].GetComponent<Text>().text += "\n" + split[k];
                    }
                }
            }
        }
    }
}
