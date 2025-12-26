using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckPages : MonoBehaviour
{
    public Sprite PlaceImage;
    public List<GameObject> SmallIMages = new List<GameObject>();
    public List<GameObject> BigImages = new List<GameObject>();
    private bool a = false;
    public GameObject ActiveButton;
    public GameObject ActiveText;
    public GameObject QuestionMark;
    public bool QuistionMark=false;
    public bool Towere=true;
    public Vector2 PlaceIllesztesSize;

    private void Start()
    {
        if (QuistionMark)
        {
            for (int i = 0; i < SmallIMages.Count; i++)
            {
                SmallIMages[i].SetActive(false);
            }
            QuestionMark.SetActive(true);
        }
        else
        {
            for (int i = 0; i < SmallIMages.Count; i++)
            {
                SmallIMages[i].SetActive(true);
            }
            QuestionMark.SetActive(false);
        }

    }
    public void ClickKicsi()
    {
        if (BigImages[0].active|| a|| QuistionMark|| DeckPanelScript.mozoge)
            return;

        DeckPanelScript.BigPages = gameObject;
        a = true;
        StartCoroutine(asd(0.7f));
        DeckPanelScript.SetactiveFalse(1);
        TextSzinezes();
        for (int i = 0; i < DeckPanelScript.TowerInPanelDaks.Count; i++)
        {
            if (DeckPanelScript.TowerInPanelDaks[i] != gameObject&& DeckPanelScript.TowerInPanelDaks[i]!=null)
            {
                DeckPanelScript.TowerInPanelDaks[i].SetActive(false);
            }
        }
        for (int i = 0; i < DeckPanelScript.SpawnerInPanelDaks.Count; i++)
        {
            if (DeckPanelScript.SpawnerInPanelDaks[i] != gameObject && DeckPanelScript.SpawnerInPanelDaks[i] != null)
            {
                DeckPanelScript.SpawnerInPanelDaks[i].SetActive(false);
            }
        }
        DeckPanelScript.Egyeb.SetActive(false);
        Vector3 VegePosition = new Vector3((CameraMove.camMaxX - CameraMove.camMinX) / 2 + CameraMove.camMinX, (CameraMove.camMaxY - CameraMove.camMinY) / 2 + CameraMove.camMinY, 5);
        Vector3 VegeScala = new Vector3(2f, 2f, 2f);
        StartCoroutine(Megjelenites(0, true));
        StartCoroutine(DeckPanelScript.DeckMove2(0.35f,gameObject,gameObject.transform.position, VegePosition, VegeScala));
    }


    public void BigX()
    {
        if (QuistionMark)
            return;
        List<GameObject> TowerSPawnerInPanelDaks;
        if (Towere)
        {
            TowerSPawnerInPanelDaks = DeckPanelScript.TowerInPanelDaks;
        }
        else
        {
            TowerSPawnerInPanelDaks = DeckPanelScript.SpawnerInPanelDaks;
        }
        int VegePosition=0;
        for (int i=0;i< TowerSPawnerInPanelDaks.Count;i++)
        {
            if(TowerSPawnerInPanelDaks[i]==gameObject)
            {
                VegePosition = i;
                break;
            }
        }
        DeckPanelScript.BigPages = null;
        Vector3 VegeScala = new Vector3(1f, 1f, 1f);
        DeckPanelScript.Egyeb.SetActive(true);
        StartCoroutine(Megjelenites(0, false));
        StartCoroutine(DeckPanelScript.DeckMove(0.35f, gameObject, gameObject.transform.position, VegePosition, VegeScala));
        StartCoroutine(MegjelenitesPages(0.35f));
    }

    public void TextSzinezes()
    {
        List<GameObject> TowerSPawnerInPlaceDaks;
        if (Towere)
        {
            TowerSPawnerInPlaceDaks = DeckPanelScript.TowerInPlaceDaks;
        }
        else
        {
            TowerSPawnerInPlaceDaks = DeckPanelScript.SpawnerInPlaceDaks;
        }
        if (Towere && !DeckPanelScript.TowerPlaces)
        {
            ActiveButton.GetComponent<SpriteRenderer>().color = DeckPanelScript.NoColor;
            ActiveText.GetComponent<Text>().text = "No Spawner";
        }
        else
if (!Towere && DeckPanelScript.TowerPlaces)
        {
            ActiveButton.GetComponent<SpriteRenderer>().color = DeckPanelScript.NoColor;
            ActiveText.GetComponent<Text>().text = "No Tower";
        }
        else
if ((Towere && TowerSPawnerInPlaceDaks.Count < 3) || (!Towere && TowerSPawnerInPlaceDaks.Count < 4))
        {
            ActiveButton.GetComponent<SpriteRenderer>().color = DeckPanelScript.OkColor;
            ActiveText.GetComponent<Text>().text = "Ok";
        }
        else
        {
            for (int i = 0; i < TowerSPawnerInPlaceDaks.Count; i++)
            {
                if (TowerSPawnerInPlaceDaks[i] == null)
                {
                    ActiveButton.GetComponent<SpriteRenderer>().color = DeckPanelScript.OkColor;
                    ActiveText.GetComponent<Text>().text = "Ok";
                    break;
                }
                if (i == TowerSPawnerInPlaceDaks.Count - 1)
                {
                    ActiveButton.GetComponent<SpriteRenderer>().color = DeckPanelScript.NoColor;
                    ActiveText.GetComponent<Text>().text = "No";
                }
            }
        }
    }

    public IEnumerator Megjelenites(float time,bool a)
    {
        yield return new WaitForSeconds(time);
        for(int i=0;i< BigImages.Count;i++)
        {
            BigImages[i].SetActive(a);
        }
        for (int i = 0; i < SmallIMages.Count; i++)
        {
            SmallIMages[i].SetActive(!a);
        }
    }

    public IEnumerator MegjelenitesPages(float time)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < DeckPanelScript.TowerInPanelDaks.Count; i++)
        {
            if (DeckPanelScript.TowerInPanelDaks[i] != gameObject && DeckPanelScript.TowerInPanelDaks[i] != null)
            {
                DeckPanelScript.TowerInPanelDaks[i].SetActive(true);
            }
        }
        for (int i = 0; i < DeckPanelScript.SpawnerInPanelDaks.Count; i++)
        {
            if (DeckPanelScript.SpawnerInPanelDaks[i] != gameObject && DeckPanelScript.SpawnerInPanelDaks[i] != null)
            {
                DeckPanelScript.SpawnerInPanelDaks[i].SetActive(true);
            }
        }
    }

    public IEnumerator asd(float time)
    {
        yield return new WaitForSeconds(time);
        a = false;
    }
}
