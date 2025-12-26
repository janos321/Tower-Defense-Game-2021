using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPanelScript : MonoBehaviour
{
    public List<GameObject> TowerPages2 = new List<GameObject>();
    public static List<GameObject> TowerPages = new List<GameObject>();

    /*public List<Sprite> TowerImages2 = new List<Sprite>();
    public static List<Sprite> TowerImages = new List<Sprite>();*/
    public static List<GameObject> TowerInPlaceDaks = new List<GameObject>();
    public static List<GameObject> TowerInPanelDaks = new List<GameObject>();

    public static List<GameObject> SpawnerInPlaceDaks = new List<GameObject>();
    public static List<GameObject> SpawnerInPanelDaks = new List<GameObject>();

    public List<GameObject> TowerPagesPositions2 = new List<GameObject>();
    public static List<GameObject> TowerPagesPositions = new List<GameObject>();

    public List<GameObject> SPawnerPages2 = new List<GameObject>();
    public static List<GameObject> SPawnerPages = new List<GameObject>();

    /*public List<Sprite> SPawnerImages2 = new List<Sprite>();
    public static List<Sprite> SPawnerImages = new List<Sprite>();*/

    public List<GameObject> SPawnerPagesPositions2 = new List<GameObject>();
    public static List<GameObject> SPawnerPagesPositions = new List<GameObject>();

    public List<GameObject> TowerPLaces2 = new List<GameObject>();
    public static List<GameObject> TowerPLaces = new List<GameObject>();

    public List<GameObject> SpawnerPLaces2 = new List<GameObject>();
    public static List<GameObject> SpawnerPLaces = new List<GameObject>();

    public Sprite X2;
    public static Sprite X;
    public Sprite PLusz2;
    public static Sprite PLusz;
    public static GameObject BigPages = null;
    public static GameObject DeckPanelGameobject;
    public Color OkColor2;
    public Color NoColor2;
    public static Color OkColor;
    public static Color NoColor;

    public GameObject AllDeckPlace;

    public GameObject map;
    public static float mapMinX, mapMaxX, mapMinY, mapMaxY;

    public static bool TowerPlaces = true;

    public GameObject BackGroundPLaces;

    public GameObject AllTowerPlaces;
    public GameObject AllSpawnerPLaces;

    public GameObject Egyeb2;
    public static GameObject Egyeb;

        public static bool mozoge;

    public GameObject TowerDeksPickButton;
    public GameObject EnemyDeksPickButton;
    public void Starts()
    {
        TowerDekspIckButtonFalseOrTrue(false);
        Egyeb = Egyeb2;
        OkColor = OkColor2;
        NoColor = NoColor2;
        DeckPanelGameobject = gameObject;
        PLusz = PLusz2;
        X = X2;
        SpawnerPLaces.Clear();
        for (int i = 0; i < SpawnerPLaces2.Count; i++)
        {
            SpawnerPLaces.Add(SpawnerPLaces2[i]);
        }
        TowerPLaces.Clear();
        for (int i = 0; i < TowerPLaces2.Count; i++)
        {
            TowerPLaces.Add(TowerPLaces2[i]);
        }
        TowerPages.Clear();
        for (int i = 0; i < TowerPages2.Count; i++)
        {
            TowerPages.Add(TowerPages2[i]);
        }
        SPawnerPages.Clear();
        for (int i = 0; i < SPawnerPages2.Count; i++)
        {
            SPawnerPages.Add(SPawnerPages2[i]);
        }
        TowerPagesPositions.Clear();
        for (int i = 0; i < TowerPagesPositions2.Count; i++)
        {
            TowerPagesPositions.Add(TowerPagesPositions2[i]);
        }
        SPawnerPagesPositions.Clear();
        for (int i = 0; i < SPawnerPagesPositions2.Count; i++)
        {
            SPawnerPagesPositions.Add(SPawnerPagesPositions2[i]);
        }




        TowerInPlaceDaks.Clear();
        for (int i = 0; i < database.DEC.Count; i++)
        {
            if (i < 3)
            {
                if (database.DEC[i] != 0)
                {
                    TowerInPlaceDaks.Add(TowerPages[database.DEC[i] - 1]);
                }
                else
                {
                    TowerInPlaceDaks.Add(null);
                }
            }
        }
        

        SpawnerInPlaceDaks.Clear();
        for (int i = 0; i < database.DEC.Count; i++)
        {
                if (i >= 3)
                {
                    if (database.DEC[i] != 0)
                    {
                        SpawnerInPlaceDaks.Add(SPawnerPages[database.DEC[i] - 1]);
                    }
                    else
                    {
                    SpawnerInPlaceDaks.Add(null);
                    }
                }            
        }
        TowerInPanelDaks.Clear();
        for (int i = 0; i < TowerPages.Count; i++)
        {
            int j = 0;
            while (j < TowerInPlaceDaks.Count)
            {
                if (TowerPages[i] == TowerInPlaceDaks[j])
                {
                    break;
                }
                j++;
            }
            if (j == TowerInPlaceDaks.Count)
            {
                TowerInPanelDaks.Add(TowerPages[i]);
            }
        }
        for (int i = TowerInPanelDaks.Count; i < TowerPages.Count; i++)
        {
            TowerInPanelDaks.Add(null);
        }
        SpawnerInPanelDaks.Clear();
        for (int i = 0; i < SPawnerPages.Count; i++)
        {
            int j = 0;
            while (j < SpawnerInPlaceDaks.Count)
            {
                if (SPawnerPages[i] == SpawnerInPlaceDaks[j])
                {
                    break;
                }
                j++;
            }
            if (j == SpawnerInPlaceDaks.Count)
            {
                SpawnerInPanelDaks.Add(SPawnerPages[i]);
            }
        }
        for (int i = SpawnerInPanelDaks.Count; i < SPawnerPages.Count; i++)
        {
            SpawnerInPanelDaks.Add(null);
        }

        for (int i = 0; i < TowerInPanelDaks.Count; i++)
        {
            if (TowerInPanelDaks[i] != null)
                TowerInPanelDaks[i].transform.position = TowerPagesPositions[i].transform.position;
        }
        for (int i = 0; i < SpawnerInPanelDaks.Count; i++)
        {
            if (SpawnerInPanelDaks[i] != null)
                SpawnerInPanelDaks[i].transform.position = SPawnerPagesPositions[i].transform.position;
        }

        for (int i = 0; i < TowerPLaces.Count; i++)
        {
            if (database.DEC[i] != 0)
            {
                TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = DeckPanelScript.TowerPages[database.DEC[i] - 1].GetComponent<DeckPages>().PlaceImage;
                TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = DeckPanelScript.TowerPages[database.DEC[i] - 1].GetComponent<DeckPages>().PlaceIllesztesSize;
            }
            else
            {
                TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = DeckPanelScript.PLusz;
                TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
            }
        }
        for (int i = 0; i < TowerInPlaceDaks.Count; i++)
        {
            if (TowerInPlaceDaks[i] != null)
            {
                TowerInPlaceDaks[i].SetActive(false);
                Vector3 VegeScala = new Vector3(0.2f, 0.2f, 0.2f);
                StartCoroutine(DeckMove2(0.5f, TowerInPlaceDaks[i], TowerInPlaceDaks[i].transform.position, TowerPLaces[i].transform.position, VegeScala));
            }
        }
        try
        {
            for (int i = 0; i < SpawnerPLaces.Count; i++)
            {
                if (database.DEC[i + 3] != 0)
                {
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = SPawnerPages[database.DEC[i + 3] - 1].GetComponent<DeckPages>().PlaceImage;
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = SPawnerPages[database.DEC[i + 3] - 1].GetComponent<DeckPages>().PlaceIllesztesSize;
                }
                else
                {
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = DeckPanelScript.PLusz;
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
                }
            }
        }
        catch
        {
            AdatbazisHelyreallitasa();
            for (int i = 0; i < SpawnerPLaces.Count; i++)
            {
                if (database.DEC[i + 3] != 0)
                {
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = SPawnerPages[database.DEC[i + 3] - 1].GetComponent<DeckPages>().PlaceImage;
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = SPawnerPages[database.DEC[i + 3] - 1].GetComponent<DeckPages>().PlaceIllesztesSize;
                }
                else
                {
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = DeckPanelScript.PLusz;
                    SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = new Vector2(1, 1);
                }
            }
        }

        for (int i = 0; i < SpawnerInPlaceDaks.Count; i++)
        {
            if (SpawnerInPlaceDaks[i] != null)
            {
                SpawnerInPlaceDaks[i].SetActive(false);
                Vector3 VegeScala = new Vector3(0.2f, 0.2f, 0.2f);
                StartCoroutine(DeckMove2(0.5f, SpawnerInPlaceDaks[i], SpawnerInPlaceDaks[i].transform.position, SpawnerPLaces[i].transform.position, VegeScala));
            }
        }
        if (!TowerPlaces)
        {
            SkipButton(true);
            StartCoroutine(helyreallit());
        }

        ElrendezInPLace(true);
        ElrendezInPLace(false);
    }

    public void SkipButton(bool Towere)
    {
        if (Towere == TowerPlaces)
        {
            SetactiveFalse(1);
            return;
        }
        if (Towere)
        {
            TowerDekspIckButtonFalseOrTrue(false);
            Vector3 indulasPositionTowerPLaces = new Vector3(BackGroundPLaces.transform.position.x - 1.5f, BackGroundPLaces.transform.position.y, BackGroundPLaces.transform.position.z);
            Vector3 VegePOsitionSpawnerPLaces = new Vector3(BackGroundPLaces.transform.position.x + 1.5f, BackGroundPLaces.transform.position.y, BackGroundPLaces.transform.position.z);
            StartCoroutine(DeckMove2(0.5f, AllTowerPlaces, indulasPositionTowerPLaces, BackGroundPLaces.transform.position, AllTowerPlaces.transform.localScale));
            StartCoroutine(DeckMove2(0.5f, AllSpawnerPLaces, BackGroundPLaces.transform.position, VegePOsitionSpawnerPLaces, AllSpawnerPLaces.transform.localScale));
            for(int i=0;i<TowerPLaces.Count;i++)
            {
                StartCoroutine(HalvanyitasSotitites(false,0.4f,TowerPLaces[i]));
                StartCoroutine(HalvanyitasSotitites(false,0.4f,TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage));
            }

            for (int i = 0; i < SpawnerPLaces.Count; i++)
            {
                StartCoroutine(HalvanyitasSotitites(true, 0.4f, SpawnerPLaces[i]));
                StartCoroutine(HalvanyitasSotitites(true, 0.4f, SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage));
            }


            AllTowerPlaces.SetActive(true);

            TowerPlaces = true;
        }
        else
        {
            TowerDekspIckButtonFalseOrTrue(true);
            Vector3 indulasPositionSpawnerPLaces = new Vector3(BackGroundPLaces.transform.position.x + 1.5f, BackGroundPLaces.transform.position.y, BackGroundPLaces.transform.position.z);
            Vector3 VegePOsitionTowerPLaces = new Vector3(BackGroundPLaces.transform.position.x - 1.5f, BackGroundPLaces.transform.position.y, BackGroundPLaces.transform.position.z);
            StartCoroutine(DeckMove2(0.5f, AllTowerPlaces, BackGroundPLaces.transform.position, VegePOsitionTowerPLaces, AllTowerPlaces.transform.localScale));
            StartCoroutine(DeckMove2(0.5f, AllSpawnerPLaces, indulasPositionSpawnerPLaces, BackGroundPLaces.transform.position, AllSpawnerPLaces.transform.localScale));

            for (int i = 0; i < TowerPLaces.Count; i++)
            {
                StartCoroutine(HalvanyitasSotitites(true, 0.4f, TowerPLaces[i]));
                StartCoroutine(HalvanyitasSotitites(true, 0.4f, TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage));
            }

            for (int i = 0; i < SpawnerPLaces.Count; i++)
            {
                StartCoroutine(HalvanyitasSotitites(false, 0.4f, SpawnerPLaces[i]));
                StartCoroutine(HalvanyitasSotitites(false, 0.4f, SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage));
            }


            AllSpawnerPLaces.SetActive(true);

            TowerPlaces = false;
        }
        SetactiveFalse(2);
    }


    IEnumerator HalvanyitasSotitites(bool halvanyitas,float MaxTime,GameObject Targy)
    {
        float PresentTime =0;
        if (halvanyitas)
        {
            PresentTime = MaxTime;
            while (PresentTime>0)
            {
                Targy.GetComponent<SpriteRenderer>().color = new Color(Targy.GetComponent<SpriteRenderer>().color.r, Targy.GetComponent<SpriteRenderer>().color.g, Targy.GetComponent<SpriteRenderer>().color.b, PresentTime / MaxTime);
                yield return PresentTime -= Time.deltaTime;
            }
            Targy.GetComponent<SpriteRenderer>().color = new Color(Targy.GetComponent<SpriteRenderer>().color.r, Targy.GetComponent<SpriteRenderer>().color.g, Targy.GetComponent<SpriteRenderer>().color.b, 1);
        }
        else
        {
            while (PresentTime < MaxTime)
            {
                Targy.GetComponent<SpriteRenderer>().color = new Color(Targy.GetComponent<SpriteRenderer>().color.r, Targy.GetComponent<SpriteRenderer>().color.g, Targy.GetComponent<SpriteRenderer>().color.b, PresentTime / MaxTime);
                yield return PresentTime += Time.deltaTime;
            }
            if(TowerPlaces)
            {
                AllSpawnerPLaces.SetActive(false);
            }
            else
            {
                AllTowerPlaces.SetActive(false);
            }
        }
            
        
    }
    public static void SetactiveFalse(int x)
    {

        for (int i = 0; i < TowerPLaces.Count; i++)
        {
            if (TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite == X)
            {
                TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = TowerPages[database.DEC[TowerPLaces[i].GetComponent<DeckPLacesClick>().index] - 1].GetComponent<DeckPages>().PlaceImage;
                TowerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = TowerPages[database.DEC[TowerPLaces[i].GetComponent<DeckPLacesClick>().index] - 1].GetComponent<DeckPages>().PlaceIllesztesSize;
            }
        }
        for (int i = 0; i < SpawnerPLaces.Count; i++)
        {
            if (SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite == X)
            {
                SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = SPawnerPages[database.DEC[SpawnerPLaces[i].GetComponent<DeckPLacesClick>().index+3] - 1].GetComponent<DeckPages>().PlaceImage;
                SpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = SPawnerPages[database.DEC[SpawnerPLaces[i].GetComponent<DeckPLacesClick>().index+3] - 1].GetComponent<DeckPages>().PlaceIllesztesSize;
            }
        }

        if (x != 1&&x!=2)
        {
            if (BigPages != null && BigPages.active)
            {
                BigPages.GetComponent<DeckPages>().BigX();
            }
        }
        if(x==2)
        {
            if (BigPages != null && BigPages.active)
            {
                BigPages.GetComponent<DeckPages>().TextSzinezes();
            }
        }

    }

    public void Active()
    {
        if (BigPages.GetComponent<DeckPages>().ActiveButton.GetComponent<SpriteRenderer>().color == NoColor)
            return;
        for (int i = 0; i < BigPages.GetComponent<DeckPages>().BigImages.Count; i++)
        {
            BigPages.GetComponent<DeckPages>().BigImages[i].SetActive(false);
        }
        for (int i = 0; i < BigPages.GetComponent<DeckPages>().SmallIMages.Count; i++)
        {
            BigPages.GetComponent<DeckPages>().SmallIMages[i].SetActive(true);
        }
        GameObject SzabadPLace = null;
        int index = 0;

        List<GameObject> TowerSpawnerPLaces;
        List<GameObject> TowerSpawnerPages;
        if (BigPages.GetComponent<DeckPages>().Towere)
        {
            TowerSpawnerPLaces = TowerPLaces;
            TowerSpawnerPages = TowerPages;
        }
        else
        {
            TowerSpawnerPLaces = SpawnerPLaces;
            TowerSpawnerPages = SPawnerPages;
        }
        for (int i = 0; i < TowerSpawnerPLaces.Count; i++)
        {
            if (TowerSpawnerPLaces[i].GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite == PLusz)
            {
                SzabadPLace = TowerSpawnerPLaces[i];
                for (int j = 0; j < TowerSpawnerPages.Count; j++)
                {
                    if (TowerSpawnerPages[j] == BigPages)
                    {
                        if (TowerPlaces) {
                            database.DEC[i] = j + 1;
                        }
                        else
                        {
                            database.DEC[i+3] = j + 1;
                        }    
                        FajlDatabase.WriteIntoTxtFile();
                        index = i;
                    }
                }
                break;
            }
        }
        Vector3 VegeScala = new Vector3(0.2f, 0.2f, 0.2f);
        Egyeb.SetActive(true);
        StartCoroutine(DeckMove2(0.5f, BigPages, BigPages.transform.position, SzabadPLace.transform.position, VegeScala));
        StartCoroutine(PlaceBeillesztes(0.5f, SzabadPLace, BigPages, index));
        for (int i = 0; i < TowerInPanelDaks.Count; i++)
        {
            if (TowerInPanelDaks[i] != null)
                TowerInPanelDaks[i].SetActive(true);
        }
        for (int i = 0; i < SpawnerInPanelDaks.Count; i++)
        {
            if (SpawnerInPanelDaks[i] != null)
                SpawnerInPanelDaks[i].SetActive(true);
        }
        if (BigPages.GetComponent<DeckPages>().Towere)
        {
            ElrendezInPLace(true);
        }
        else
        {
            ElrendezInPLace(false);
        }
        BigPages = null;
    }


    public IEnumerator PlaceBeillesztes(float Time, GameObject SzabadPLace, GameObject BigPages, int index)
    {
        List<GameObject> TowerSPawnerInPlaceDaks;
        List<GameObject> TowerSPawnerInPanelDaks;
        if (BigPages.GetComponent<DeckPages>().Towere)
        {
            TowerSPawnerInPlaceDaks = TowerInPlaceDaks;
            TowerSPawnerInPanelDaks = TowerInPanelDaks;
        }
        else
        {
            TowerSPawnerInPlaceDaks = SpawnerInPlaceDaks;
            TowerSPawnerInPanelDaks = SpawnerInPanelDaks;
        }
        TowerSPawnerInPanelDaks[TowerSPawnerInPanelDaks.IndexOf(BigPages)] = null;
        yield return new WaitForSeconds(Time);
        SzabadPLace.GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().sprite = BigPages.GetComponent<DeckPages>().PlaceImage;
        SzabadPLace.GetComponent<DeckPLacesClick>().SpacesImage.GetComponent<SpriteRenderer>().size = BigPages.GetComponent<DeckPages>().PlaceIllesztesSize;
        if (TowerSPawnerInPlaceDaks.Count <= index)
        {
            TowerSPawnerInPlaceDaks.Add(BigPages);
        }
        else
        {
            TowerSPawnerInPlaceDaks[index] = BigPages;
        }
        BigPages.SetActive(false);
    }

    public void ElrendezInPLace(bool Towere)
    {
        List<GameObject> TowerSPawnerInPanelDaks;
        List<GameObject> TowerSpawnerPages;
        if (Towere)
        {
            TowerSPawnerInPanelDaks = TowerInPanelDaks;
            TowerSpawnerPages = TowerPages;
        }
        else
        {
            TowerSPawnerInPanelDaks = SpawnerInPanelDaks;
            TowerSpawnerPages = SPawnerPages;
        }
        for (int i = 0, j = 0; i < TowerSpawnerPages.Count; i++)
        {
            if (TowerSpawnerPages[i].active)
            {
                if (TowerSPawnerInPanelDaks[j] == null)
                {
                    if (TowerSPawnerInPanelDaks.IndexOf(TowerSpawnerPages[i]) != -1)
                    {
                        int PagesINdex = TowerSPawnerInPanelDaks.IndexOf(TowerSpawnerPages[i]);
                        Vector3 VegeScala = new Vector3(TowerSPawnerInPanelDaks[PagesINdex].transform.localScale.x, TowerSPawnerInPanelDaks[PagesINdex].transform.localScale.y, TowerSPawnerInPanelDaks[PagesINdex].transform.localScale.z);
                        StartCoroutine(DeckMove(0.7f, TowerSPawnerInPanelDaks[PagesINdex], TowerSPawnerInPanelDaks[PagesINdex].transform.position, j, VegeScala));
                        TowerSPawnerInPanelDaks[j] = TowerSpawnerPages[i];
                        TowerSPawnerInPanelDaks[PagesINdex] = null;
                        j++;

                    }
                }
                else
                {
                    j++;
                }
            }


        }
    }

    public void ElrendezInPLaceBackPanel(GameObject BackPages,int PLacesIndex)
    {
        List<GameObject> TowerSPawnerInPanelDaks;
        List<GameObject> TowerSpawnerPages;
        List<GameObject> TowerSpawnerPLaces;
        if (BackPages.GetComponent<DeckPages>().Towere)
        {
            TowerSPawnerInPanelDaks = TowerInPanelDaks;
            TowerSpawnerPages = TowerPages;
            TowerSpawnerPLaces = TowerPLaces;
        }
        else
        {
            TowerSPawnerInPanelDaks = SpawnerInPanelDaks;
            TowerSpawnerPages = SPawnerPages;
            TowerSpawnerPLaces = SpawnerPLaces;
        }
        int k = -1, j = 1;
        while (k == -1 && TowerSpawnerPages.Count > TowerSpawnerPages.IndexOf(BackPages) + j)
        {
            k = TowerSPawnerInPanelDaks.IndexOf(TowerSpawnerPages[TowerSpawnerPages.IndexOf(BackPages) + j]);
            j++;
        }
        if (k == -1)
        {
            for (int i = 0; i < TowerSPawnerInPanelDaks.Count; i++)
            {
                if (TowerSPawnerInPanelDaks[i] == null)
                {
                    TowerSPawnerInPanelDaks[i] = BackPages;
                    Vector3 VegeScala = new Vector3(1, 1, 1);
                    StartCoroutine(DeckMove(0.7f, TowerSPawnerInPanelDaks[i], TowerSpawnerPLaces[PLacesIndex].transform.position, i, VegeScala));
                    break;
                }
            }
        }
        else
        {
            GameObject Elozo = BackPages;
            GameObject Mostani = null;
            int szamlalo = 0;
            while (k < TowerSpawnerPages.Count)
            {
                if (TowerSPawnerInPanelDaks[k] == null)
                {
                    szamlalo++;
                    if (szamlalo == 2)
                    {
                        break;
                    }
                }
                Mostani = TowerSPawnerInPanelDaks[k];
                TowerSPawnerInPanelDaks[k] = Elozo;
                Elozo = Mostani;
                Vector3 VegeScala = new Vector3(1, 1, 1);
                if (BackPages == TowerSPawnerInPanelDaks[k])
                {
                    StartCoroutine(DeckMove(0.7f, TowerSPawnerInPanelDaks[k], TowerSpawnerPLaces[PLacesIndex].transform.position, k, VegeScala));
                }
                else
                {
                    StartCoroutine(DeckMove(0.7f, TowerSPawnerInPanelDaks[k], TowerSPawnerInPanelDaks[k].transform.position, k, VegeScala));
                }



                k++;

            }
        }
    }

    public static void BackPanelElrendezes(GameObject Pages,int PLacesIndex)
    {
        Pages.SetActive(true);
        DeckPanelGameobject.GetComponent<DeckPanelScript>().ElrendezInPLaceBackPanel(Pages, PLacesIndex);
    }

    public static IEnumerator DeckMove(float Maxtime, GameObject Targy, Vector3 indulas, int vegeindex, Vector3 VegeScala)
    {
        List<GameObject> TowerSpawnerPagesPosition;
        if (Targy.GetComponent<DeckPages>().Towere)
        {
            TowerSpawnerPagesPosition = TowerPagesPositions;
        }
        else
        {
            TowerSpawnerPagesPosition = SPawnerPagesPositions;
        }
        float PresentTime = 0;
        Vector3 KezdetiScala = new Vector3(Targy.transform.localScale.x, Targy.transform.localScale.y, Targy.transform.localScale.z);
        while (PresentTime < Maxtime)
        {
            Targy.transform.position = Vector3.Lerp(indulas, TowerSpawnerPagesPosition[vegeindex].transform.position, PresentTime / Maxtime);
            Targy.transform.localScale = Vector3.Lerp(KezdetiScala, VegeScala, PresentTime / Maxtime);
            yield return PresentTime += Time.deltaTime;
        }
        yield return null;
    }

    public static IEnumerator DeckMove2(float Maxtime, GameObject Targy, Vector3 indulas, Vector3 vege, Vector3 VegeScala)
    {

        float PresentTime = 0;
        Vector3 KezdetiScala = new Vector3(Targy.transform.localScale.x, Targy.transform.localScale.y, Targy.transform.localScale.z);
        while (PresentTime < Maxtime)
        {
            Targy.transform.position = Vector3.Lerp(indulas, vege, PresentTime / Maxtime);
            Targy.transform.localScale = Vector3.Lerp(KezdetiScala, VegeScala, PresentTime / Maxtime);
            yield return PresentTime += Time.deltaTime;
        }

        yield return null;
    }



    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    private float timer = 0;

    void Update()
    {
        mozoge = false;
        if (Input.GetMouseButtonDown(0))
        {
            hit_position = Input.mousePosition;
            camera_position = transform.position;
        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            LeftMouseDrag();
        }
    }

    void LeftMouseDrag()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            return;
        }

        if (Input.touchCount > 0)
        {
            if (Input.touchCount != 1)
            {
                timer = 0.2f;
                return;
            }
        }
        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.
        direction = direction;

        Vector3 position = camera_position + direction;

        if (Mathf.Abs(position.x - camera_position.x) < 0.1f && Mathf.Abs(position.y - camera_position.y) < 0.1f)
        {
            mozoge = false;
        }
        else
        {
            SetactiveFalse(0);
            mozoge = true;
        }
        if (!mozoge)
            return;
        Vector3 positions = position - gameObject.transform.position;
        positions.z = 5;
        if (positions.x == 0 && positions.y != 0)
        {
            if (positions.y > 0)
            {
                if (CameraMove.camMinY > mapMinY)
                {
                    transform.position = position;
                    CoordChange();
                }
            }
            else
            {
                if (CameraMove.camMaxY < mapMaxY)
                {
                    transform.position = position;
                    CoordChange();
                }
            }
        }
        else
if (positions.x > 0)
        {
            if (positions.y > 0)
            {
                if (CameraMove.camMinY > mapMinY)
                {
                    transform.position = new Vector3(transform.position.x, position.y, 5);
                    CoordChange();
                }
            }
            else
            {
                if (CameraMove.camMaxY < mapMaxY)
                {
                    transform.position = new Vector3(transform.position.x, position.y, 5);
                    CoordChange();
                }
            }

        }
        else
        {
            if (positions.y > 0)
            {
                if (CameraMove.camMinY > mapMinY)
                {
                    transform.position = new Vector3(transform.position.x, position.y, 5);
                    CoordChange();
                }
            }
            else
            {
               
                if (CameraMove.camMaxY < mapMaxY)
                {
                    transform.position = new Vector3(transform.position.x, position.y, 5);
                    CoordChange();
                }
            }

        }
    }


   public void CoordChange()
        {


        mapMaxX = map.GetComponent<BoxCollider2D>().bounds.center.x + map.GetComponent<BoxCollider2D>().bounds.extents.x;
        mapMinX = map.GetComponent<BoxCollider2D>().bounds.center.x - map.GetComponent<BoxCollider2D>().bounds.extents.x;
        mapMaxY = map.GetComponent<BoxCollider2D>().bounds.center.y + map.GetComponent<BoxCollider2D>().bounds.extents.y;
        mapMinY = map.GetComponent<BoxCollider2D>().bounds.center.y - map.GetComponent<BoxCollider2D>().bounds.extents.y;
        AllDeckPlace.transform.position = new Vector3(AllDeckPlace.transform.position.x, CameraMove.camMinY + (CameraMove.camMaxY - CameraMove.camMinY) / 2+3.5f, 10);
}

    IEnumerator helyreallit()
    {
        yield return new WaitForSeconds(0.5f);
        AllTowerPlaces.transform.position = BackGroundPLaces.transform.position;
    }

    public void AdatbazisHelyreallitasa()
    {
        for(int i=0;i<database.DEC.Count;i++)
        {
            Debug.Log(database.DEC[i]);
            database.DEC[i] = 0;
        }
        while(database.DEC.Count<7)
        {
            database.DEC.Add(0);
        }
    }

    public void TowerDekspIckButtonFalseOrTrue(bool a)
    {
        TowerDeksPickButton.SetActive(a);
        EnemyDeksPickButton.SetActive(!a);
    }


}
