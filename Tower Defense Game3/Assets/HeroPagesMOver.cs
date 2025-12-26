using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeroPagesMOver : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Pages = new List<GameObject>();
    public GameObject GameobjectPages;
    private float GameobjectPagesleft = 0, GameobjectPagesright = 0, PanelRight = 0, Panelleft = 0;
    public static GameObject ChoicePage = null;
    public static int PagesIndex = 0;
    public GameObject ActiveButton;
    public Color white;
    public Color halvany;
    public static bool Active = false;
    public static List<int> AllPagesMOney = new List<int>();
    private int  nez3 = 0;
    private List<int> ab = new List<int>();
    private bool kozepenvane;

    public void ActiveBUtton()
    {
        if (Active)
        {
            Pages[database.HS].GetComponent<HEroPagesReturn>().Pipa.SetActive(false);
            database.HS = PagesIndex;
            MENUGamobjects.HERO = Pages[PagesIndex].GetComponent<HEroPagesReturn>().HERO;
            Pages[database.HS].GetComponent<HEroPagesReturn>().Pipa.SetActive(true);
            //MENUGamobjects.HeroIndexChange();
        }


    }

    public void BUYButton()
    {
        if (Pages[PagesIndex].GetComponent<HEroPagesReturn>().MoneyType == "cs")
        {
            if (database.STC >= AllPagesMOney[PagesIndex])
            {
                database.ALN[PagesIndex] = 0;
                Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.SetActive(false);
                database.STC -= AllPagesMOney[PagesIndex];
            }
        }
        else
        if (Pages[PagesIndex].GetComponent<HEroPagesReturn>().MoneyType == "dia")
        {
            if (database.GDC >= AllPagesMOney[PagesIndex])
            {
                database.ALN[PagesIndex] = 0;
                Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.SetActive(false);
                database.GDC -= AllPagesMOney[PagesIndex];
                MENUGamobjects.YellowDImondCounter.GetComponent<Text>().text = database.GDC.ToString();
            }
        }
        else
        {
            //igazi pénzt levonni, szóval itt kel hogy betobja azt az utalást
            Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.SetActive(false);
            database.ALN[PagesIndex] = 0;
        }

    }






    void Starts()
    {
        GameobjectPages.SetActive(true);
        //GameobjectPages.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y-0.5f, 0);
        GameobjectPages.transform.position = gameObject.transform.position;
        if (MENUGamobjects.HERO!= Pages[4].GetComponent<HEroPagesReturn>().HERO)
        {
            Active = true;
            ActiveButton.transform.GetComponent<Image>().color = white;
        }
        ChoicePage = Pages[4];
        if (AllPagesMOney.Count == 0)
        {
            for (int i = 0; i < Pages.Count; i++)
            {
                AllPagesMOney.Add(Pages[i].GetComponent<HEroPagesReturn>().Money);
            }
        }
        for (int i = 0; i < Pages.Count; i++)
        {
            if (Pages[i].GetComponent<HEroPagesReturn>().Pipa.active)
            {
                break;
            }
            if (Pages.Count - 1 == i)
            {
                Pages[database.HS].GetComponent<HEroPagesReturn>().Pipa.SetActive(true);
            }
        }
        PanelRight = gameObject.transform.position.x + gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
        Panelleft = gameObject.transform.position.x - gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
        SetactiveChanges();
    }
    Vector3 hit_position = Vector3.zero;
    Vector3 current_position = Vector3.zero;
    Vector3 camera_position = Vector3.zero;
    // Update is called once per frame
    private int nez = 0;
    private void SetactiveChanges()
    {
        GameobjectPagesright = GameobjectPages.transform.position.x + GameobjectPages.GetComponent<BoxCollider2D>().bounds.extents.x;
        GameobjectPagesleft = GameobjectPages.transform.position.x - GameobjectPages.GetComponent<BoxCollider2D>().bounds.extents.x;
        for (int i = 0; i < Pages.Count; i++)
        {
            if (Pages[i] != null)
                if (PanelRight > Pages[i].transform.position.x && Panelleft < Pages[i].transform.position.x)
                {
                    Pages[i].SetActive(true);
                    if (!Pages[i].GetComponent<HEroPagesReturn>().firstSide.active && ChoicePage != Pages[i])
                    {
                        if (!Pages[i].GetComponent<HEroPagesReturn>().QuistioMark)
                        {
                            Pages[i].GetComponent<HEroPagesReturn>().firstSide.SetActive(true);
                            Pages[i].GetComponent<HEroPagesReturn>().SecondSide.SetActive(false);
                        }
                    }
                }
                else
                {
                    Pages[i].SetActive(false);
                }
        }
    }
    //Ez itt nem mukodik
    public void Right1Left0Button(int a)
    {
        MENUGamobjects.HeroShopHelp2.SetActive(false);
        if ((PagesIndex != 0 && a == 0) || (PagesIndex + 1 < Pages.Count && a != 0))
        {
            SoundsScript.MusicStart(SoundsScript.Menugameobject, "closetab");
        }
        else
            return;
        for (int i = 0; i < Pages.Count; i++)
        {
            if (Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton != null)
                Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.SetActive(false);
        }

        if (a == 0)
        {

            if (PagesIndex != 0)
            {
                Pages[PagesIndex].transform.rotation = Quaternion.Euler(0, 0, 0);
                // GameobjectPages.transform.position += new Vector3(8, 0, 0);
                PagesIndex--;
                ChoicePage = null;
                for(int i=0;i<ab.Count;i++)
                {
                    ab[i] = 0;
                }
                ab.Add(1);
                StartCoroutine(Mover2(-Pages[PagesIndex].transform.position.x + gameObject.transform.position.x, 1f, PagesIndex,ab.Count-1));
            }
        }
        else
        {
            if (PagesIndex + 1 < Pages.Count)
            {
                if (Pages[PagesIndex + 1] != null)
                {
                    Pages[PagesIndex].transform.rotation = Quaternion.Euler(0, 0, 0);
                    //GameobjectPages.transform.position -= new Vector3(8, 0, 0);                     
                    PagesIndex++;
                    ChoicePage = null;
                    for (int i = 0; i < ab.Count; i++)
                    {
                        ab[i] = 0;
                    }
                    ab.Add(1);
                    StartCoroutine(Mover2(-Pages[PagesIndex].transform.position.x + gameObject.transform.position.x, 1f, PagesIndex, ab.Count - 1));
                }
            }

            //SetactiveChanges();
        }
    }
    IEnumerator Mover2(float POsition, float Timee, int PagesIndeX,int abindex)
    {
        if (!kozepenvane)
          yield return null;
        nez3 = 1;
        float Timer = 0;
        Vector3 a = new Vector3(GameobjectPages.transform.position.x + POsition, GameobjectPages.transform.position.y, GameobjectPages.transform.position.z);
        Vector3 xd = GameobjectPages.transform.position;
        while (Timer < Timee)
        {
            if (nez != 0 || ab[abindex] == 0)
            {
                Timer = -1;
                break;
            }

            GameobjectPages.transform.position = Vector3.Lerp(xd, a, Timer / Timee);

            SetactiveChanges();
            yield return Timer += Time.deltaTime;
        }
        if (ab[abindex] == 1&&Timer!=-1)
        {
            nez3 = 0;
            ChoicePage = Pages[PagesIndeX];
            KozepreIgazit();
        }
        //ab.Remove(ab[abindex]);
    }
    private void KozepreIgazit()
    {
        if (nez3 == 1||!kozepenvane)
            return;
        float Moveposition = 999999;
        for (int i = 0; i < Pages.Count; i++)
        {
            if(Pages[i]!=null)
            if (PanelRight > Pages[i].transform.position.x && Panelleft < Pages[i].transform.position.x)
            {
                if(Mathf.Abs( gameObject.transform.position.x - Pages[i].transform.position.x)< Mathf.Abs(Moveposition))
                {
                    Moveposition = gameObject.transform.position.x - Pages[i].transform.position.x;
                        PagesIndex = i;
                }
            }
        }
        if (Moveposition!= 999999)
        StartCoroutine(Mover(Moveposition, 0.5f));
    }
    IEnumerator Mover(float POsition,float Timee)
    {
        if (!kozepenvane)
            yield return null;
        float Timer = 0;
        Vector3 a = new Vector3(GameobjectPages.transform.position.x+POsition, GameobjectPages.transform.position.y, GameobjectPages.transform.position.z);
        Vector3 xd = GameobjectPages.transform.position; 
        while (Timer<Timee)
        {

            if (nez != 0||nez3!=0)
                break;
            GameobjectPages.transform.position = Vector3.Lerp(xd, a, Timer/Timee);

            SetactiveChanges();
            yield return  Timer += Time.deltaTime;
        }
        if (nez3 == 0)
        {
            ChoicePage = Pages[PagesIndex];
            SetactiveChanges();
        }
    }
    void Update()
    { 
        if(MENUGamobjects.ShopPanelMozoge)
        {
            kozepenvane = false;
            GameobjectPages.SetActive(false);
        }
        else
        if(!kozepenvane)
        {
            Starts();
            kozepenvane = true;
        }
        //ActiveButton
        if (ChoicePage == null || PagesIndex == database.HS)
        {
            ActiveButton.GetComponent<Image>().color = halvany;
            Active = false;
            for (int i = 0; i < Pages.Count; i++)
            {
                if (Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton != null)
                    Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.SetActive(false);
            }
        }
        else
        if(database.ALN[PagesIndex] != 0/*&& !Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.active*/)
        {
            if (HEroPagesReturn.poroge==0) {
                if (ChoicePage == Pages[4] && MENUGamobjects.HERO != Pages[4].GetComponent<HEroPagesReturn>().HERO)
                {
                    Active = true;
                    ActiveButton.transform.GetComponent<Image>().color = white;
                }
                else
                {
                    ActiveButton.GetComponent<Image>().color = halvany;

                    Active = false;
                }
                for (int i = 0; i < Pages.Count; i++)
                {
                    if(Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton!=null)
                    Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.SetActive(false);
                }
                if (nez3 == 0)
                {
                    if (!Pages[PagesIndex].GetComponent<HEroPagesReturn>().QuistioMark)
                    {
                        if (Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton != null)
                            Pages[PagesIndex].GetComponent<HEroPagesReturn>().buyButton.SetActive(true);
                    }
                }
            }
        }
        else
        if(database.ALN[PagesIndex] != 0)
        {
            ActiveButton.GetComponent<Image>().color = halvany;
            Active = false;
        }
        else
        {
            if (!Pages[PagesIndex].GetComponent<HEroPagesReturn>().QuistioMark)
            {
                ActiveButton.GetComponent<Image>().color = white;
                Active = true;
            }
            else
            {
                ActiveButton.GetComponent<Image>().color = halvany;
                Active = false;
            }
        }



        // MOuseMOver
        if (Input.GetMouseButtonUp(0))
        {
            nez = 0;
            if (nez3 == 0)
            {
                KozepreIgazit();
            }
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            nez = 1;
           // nez3 = 0;
            hit_position = Input.mousePosition;
            camera_position = GameobjectPages.transform.position;

        }
        if (Input.GetMouseButton(0))
        {
            current_position = Input.mousePosition;
            Transform kulso = gameObject.transform;
            Vector3 belso = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10);
            if (belso.x >= (kulso.transform.position.x - kulso.GetComponent<BoxCollider2D>().size.x / 2) && belso.x <= (kulso.GetComponent<BoxCollider2D>().size.x / 2 + kulso.position.x) && belso.y >= (kulso.position.y - kulso.GetComponent<BoxCollider2D>().size.y / 2) && belso.y <= (kulso.GetComponent<BoxCollider2D>().size.y / 2 + kulso.position.y))
            {
                LeftMouseDrag();
            }
            else
            {
                nez = 0;
                if (nez3==0)
                {
                    KozepreIgazit();
                }
            }
        }
    }
    void LeftMouseDrag()
    {
        if(ChoicePage!=null)
        if (Mathf.Abs( ChoicePage.transform.position.x)- Mathf.Abs(gameObject.transform.position.x) >0.5f)
        ChoicePage = null;
        SetactiveChanges();
        nez3 = 0;
        // From the Unity3D docs: "The z position is in world units from the camera."  In my case I'm using the y-axis as height
        // with my camera facing back down the y-axis.  You can ignore this when the camera is orthograhic.
        current_position.z = hit_position.z = camera_position.y;

        // Get direction of movement.  (Note: Don't normalize, the magnitude of change is going to be Vector3.Distance(current_position-hit_position)
        // anyways.  
        Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);

        // Invert direction to that terrain appears to move with the mouse.

        Vector3 position = camera_position + direction;
      if (Mathf.Abs(position.x - camera_position.x) < 0.1f )
        {
            return;
        }
        if (position.x < 0)
        {
        position = new Vector3(position.x - 1.8f, position.y, position.z);
        }
        else
        {
            position = new Vector3(position.x + 1.8f, position.y, position.z);
        }

        Vector3 positions = position - GameobjectPages.transform.position;

        if (positions.x != 0 && positions.y == 0)
        {
            if (positions.x > 0)
            {
                if (GameobjectPagesleft < Panelleft)
                {
                    GameobjectPages.transform.position = position;
                }
            }
            else
            {
                if (GameobjectPagesright > PanelRight)
                {
                    GameobjectPages.transform.position = position;
                }
            }
        }
        else
if (positions.x > 0)
        {
            if (GameobjectPagesleft < Panelleft)
            {
                GameobjectPages.transform.position = new Vector2(position.x, GameobjectPages.transform.position.y);
            }

        }
        else
        {
            if (GameobjectPagesright > PanelRight)
            {

                GameobjectPages.transform.position = new Vector2(position.x, GameobjectPages.transform.position.y);
                
            }

        }
    }
    }
