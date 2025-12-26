using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiPlayerMenuAllGameobject : MonoBehaviour
{
    public string Külsõkelhelyezése = "------------------------";
    public GameObject YellowDiamondImage2;
    public static GameObject YellowDiamondImage;
    public GameObject BackMainMenu;
    public static GameObject BackMainMenu2,MultiPlayerMenu=null;
    public GameObject DeckButton2;
    public static GameObject DeckButton;
    public GameObject HeroBodyImagesBackground2;
    public static GameObject HeroBodyImagesBackground;
    public GameObject PLayButton2;
    public static GameObject PLayButton;
    public string Vege = "------------------------";
    public GameObject DeckPanel;
    public static GameObject Deckpanel2;
    public GameObject LOadingSceneGameobject;
    public GameObject YellowDIamondCOunter;
    public static float PresentXP = 1,MinXP,MaxXP;
    public GameObject XpLine;
    private int footloose = 0;
    public float XPLineLoadingTime = 3f;
    public static GameObject bigpages = null;
    public GameObject IgayitoYCoordianataPont;
    public GameObject HeroBodyImages;
    public Read LANG;
    //public static Vector3 eredetiPosition;
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

    private void Update()
    {
        MENUGamobjects.Timer += Time.deltaTime / 60;
    }
    void Start()
    {
        PLayButton = PLayButton2;
        LanguagesChange(database.LNG, LANG);
        HeroBodyImagesBackground = HeroBodyImagesBackground2;
        //HeroBodyImages.transform.GetComponent<Image>().sprite = MENUGamobjects.HeroBodyIMages[database.HS];
        HeroBodyImages.transform.GetComponent<SpriteRenderer>().sprite = MENUGamobjects.HeroBodyIMages[database.HS].Image;
        HeroBodyImages.transform.GetComponent<SpriteRenderer>().size = MENUGamobjects.HeroBodyIMages[database.HS].Size;
        HeroBodyImages.transform.position = new Vector3(HeroBodyImages.transform.position.x + MENUGamobjects.HeroBodyIMages[database.HS].pos.x, HeroBodyImages.transform.position.y + MENUGamobjects.HeroBodyIMages[database.HS].pos.y, HeroBodyImages.transform.position.z);

        Deckpanel2 = DeckPanel;
        DeckButton = DeckButton2;
        MaxXP = CameraMove.mapMaxX - CameraMove.mapMinX;
        MultiPlayerMenu = gameObject;
        BackMainMenu2 = BackMainMenu;
        YellowDiamondImage = YellowDiamondImage2;
        DeckPanel.transform.position = new Vector3((CameraMove.camMaxX - CameraMove.camMinX) / 2 + CameraMove.camMinX, CameraMove.camMaxY - (IgayitoYCoordianataPont.transform.position.y - DeckPanel.transform.position.y), DeckPanel.transform.position.z);
    }

    public void DeckSetactive()
    {
        if (DeckPanel.active)
        {
            bigpages = DeckPanelScript.BigPages;
            HeroBodyImagesBackground.SetActive(true);
            BackMainMenu.SetActive(true);
            PLayButton.SetActive(true);
            YellowDiamondImage.SetActive(true);
            DeckButton.SetActive(true);
            DeckPanelScript.SetactiveFalse(0);
            DeckPanel.SetActive(false);
            DeckPanel.transform.position = new Vector3((CameraMove.camMaxX - CameraMove.camMinX) / 2 + CameraMove.camMinX, CameraMove.camMaxY - (IgayitoYCoordianataPont.transform.position.y-DeckPanel.transform.position.y), DeckPanel.transform.position.z);
            footloose = 0;
            MENUGamobjects.kameramozgatas = 0;
            //StartCoroutine(CameraMove.SkillShopBe(0.7f, DeckPanel, 1, ShopIqon.transform.position));
            FajlDatabase.WriteIntoTxtFile();
        }
        else
        {
            if (footloose == 0)
            {

                DeckPanel.SetActive(true);
                DeckPanelScript.BigPages = bigpages;
                DeckPanel.GetComponent<DeckPanelScript>().Starts();
                DeckPanel.GetComponent<DeckPanelScript>().CoordChange();
                HeroBodyImagesBackground.SetActive(false);
                PLayButton.SetActive(false);
                BackMainMenu.SetActive(false);
                YellowDiamondImage.SetActive(false);
                DeckButton.SetActive(false);
                footloose = 1;
               MENUGamobjects.kameramozgatas = 1;
                //StartCoroutine(CameraMove.SkillShopBe(0.7f, DeckPanel, 0, ShopIqon.transform.position));
            }
        }
    }
    public void MainMenuBack()
    {
        if (CameraMOverClick.mozoge)
            return;
        StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
    }

    public IEnumerator ChangeXPLine(float PLuszXP)
    {
        float presentTime = 0;
        while (presentTime < XPLineLoadingTime)
        {
            float persentage = presentTime / XPLineLoadingTime;
            XpLine.transform.localScale = new Vector3(PresentXP+PLuszXP* persentage, XpLine.transform.localScale.y, XpLine.transform.localScale.z);
            yield return presentTime += Time.deltaTime;
        }
        PresentXP += PLuszXP;
        XpLine.transform.localScale = new Vector3(PresentXP, XpLine.transform.localScale.y, XpLine.transform.localScale.z);
        yield return null;
    }

    public void DestroyAudio2(float timer, AudioSource Sound, GameObject Targy)
    {
        StartCoroutine(DestroyAudio(timer, Sound, Targy));
    }
    public IEnumerator DestroyAudio(float timer, AudioSource Sound, GameObject Targy)
    {
        yield return new WaitForSeconds(timer);
        Component[] Sounds = Targy.GetComponents<AudioSource>();
        for (int i = 0; i < Sounds.Length; i++)
        {
            if (Sounds[i].GetComponent<AudioSource>() == Sound)
            {
                Sounds[i].GetComponent<AudioSource>().mute = true;
                Destroy(Sounds[i].GetComponent<AudioSource>());
            }
        }

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
