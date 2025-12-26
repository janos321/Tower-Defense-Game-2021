using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class MENUGamobjects : MonoBehaviour
{
    public string Külsőkelhelyezése = "------------------------";
    public GameObject YellowDiamondImage2;
    public static GameObject YellowDiamondImage;
    public GameObject SettingsButton2;
    public static GameObject SettingsButton;
    public GameObject SettingsPanel2;
    public static GameObject SettingsPanel;
    public GameObject YellowDiamondImageShopPanel2;
    public static GameObject YellowDiamondImageShopPanel;
    public GameObject HeroShop2;
    public static GameObject HeroShop;
    public string Vege = "------------------------";
    public Color ChangeMaxLevelColor2;
    public Sprite PIPA = null;
    public Sprite NONPIPA = null;
    public GameObject ShopPanel = null;
    public static List<GameObject> AutomaticList = new List<GameObject>();
    //public static List<int> Buying = new List<int>(8);
    public Color BuyingLosColor;
    public static Color BuyingLosColor2;
    public static Sprite PIPA2 = null;
    public static Sprite NONPIPA2 = null;
    //public static List<int> Upgrades = new List<int>(8);
    public Sprite Level1Count2;
    public Sprite Level2Count2;
    public Sprite Level3Count2;
    public static Sprite Level1Count;
    public static Sprite Level2Count;
    public static Sprite Level3Count;
    public GameObject YellowDImondCounter2;
    public static GameObject YellowDImondCounter;
    public static List<int> BuyObjectsMOney = new List<int>();
    public List<int> BuyObjectsMOney2 = new List<int>();
    public static GameObject ShopPanel2;
    public GameObject LighningAttackPrefab2;
    public static GameObject LighningAttackPrefab;
    public GameObject SmokeLightningPrefab2;
    public static GameObject SmokeLightningPrefab;
    public GameObject EgyiptianGod2;
    public static GameObject EgyiptianGod;
    //public GameObject NameText2;
    public GameObject PriceText2;
    public GameObject UpgradeInformationText2;
    public GameObject PresentInformationText2;
    //public static GameObject NameText;
    public static GameObject PriceText;
    public static GameObject UpgradeInformationText;
    public static GameObject PresentInformationText;
    public GameObject BuyList2;
    public static GameObject BuyList;
    //public GameObject BUYNameText2;
    public GameObject BuyPriceText2;
    public GameObject PresentInformationBUyText2;
    //public static GameObject BUYNameText;
    public static GameObject BuyPriceText;
    public static GameObject PresentInformationBUyText;
    public GameObject QuicksandRange2;
    public static GameObject QuicksandRange;
    public GameObject BigQuicksand2;
    public static GameObject BigQuicksand;
    public static Color ChangeMaxLevelColor;
    public GameObject HerosShopPanel2;
    public static GameObject HerosShopPanel;
    public static int kameramozgatas = 0;
    //public static int PRESENTHEROindex=4;
    //public static int BeginnerStar = 0;
    //public GameObject PagesGameobject2;
    //public GameObject classicHero;
    public static GameObject HERO;
    public GameObject MiniGameHero2;
    public static GameObject MiniGameHero;
    public GameObject HeroShopPages;
    public GameObject Valume;
    public Sprite MusicImage;
    public Sprite Music2Image;
    public GameObject OpinionPanel;
    public GameObject OpinionText;
    public GameObject QuitButton;
    public GameObject ExitButton;
    public GameObject LanguagesPanel;
    public GameObject ShopUpgradeTextSkillName2;
    public static GameObject ShopUpgradeTextSkillName;
    public GameObject ShopUpgradeSkillName2;
    public static GameObject ShopUpgradeSkillName;
    public GameObject ShopBuyTextSkillName2;
    public static GameObject ShopBuyTextSkillName;
    public GameObject ShopBuySkillName2;
    public static GameObject ShopBuySkillName;
    public List<GameObject> LaunguageButtons = new List<GameObject>();
    public Color ClassicLaunguagesButtonColor;
    public Color ChooseLaunguagesButtonColor;
    public static int footloose = 0;
    public GameObject MekersPanel;
    public GameObject MekersButton;
    public GameObject ShopDataSkillNameText2;
    public GameObject ShopDataInformation2;
    public GameObject ShopDataInformationCount2;
    public static GameObject ShopDataSkillNameText;
    public static GameObject ShopDataInformation;
    public static GameObject ShopDataInformationCount;
    public GameObject DataGameobject2;
    public static GameObject DataGameobject;
    public Read LANG;
    public static int TutorialMap = 0;
    public static bool irtEMarVelemenyt = false, ShopPanelMozoge = false;
    public GameObject SettingLanguageButton;
    public GameObject SettingOpinionButton;
    public GameObject SpellShopUpdateMenu;
    public GameObject SpellShopBuyMenu;
    public static GameObject SpellShopUpdateMenu2;
    public static GameObject SpellShopBuyMenu2;
    public GameObject LOadingSceneGameobject;
    public GameObject WifiBlock2;
    public static GameObject WifiBlock;
    public GameObject SettingsFlagMent;
    public List<Sprite> FlagmentImage = new List<Sprite>();
    public static bool WifiBool = false;
    public static float WifiEllenorzesido = 0;
    private int WifiEllenorzesMaxIdo = 20;
    public List<HeroImages> HeroBodyIMages2 = new List<HeroImages>();
    public static List<HeroImages> HeroBodyIMages = new List<HeroImages>();
    public GameObject HeroShopHelp;
    public static GameObject HeroShopHelp2;

    [System.Serializable]
    public class HeroImages
    {
        public Sprite Image;
        public Vector2 Size;
        public Vector3 pos;
    }

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

    public void ChooseLanguages(string a)
    {
        LanguagesChange(a, LANG);
    }
    public void LanguagesButtonColorChange(int index)
    {
        flagmentImageAds(index);
        for (int i = 0; i < LaunguageButtons.Count; i++)
        {
            LaunguageButtons[i].GetComponent<Image>().color = ClassicLaunguagesButtonColor;
        }
        LaunguageButtons[index].GetComponent<Image>().color = ChooseLaunguagesButtonColor;
    }
    private void Start()
    {
        HeroShopHelp2 = HeroShopHelp;
        HeroBodyIMages.Clear();
        for (int i = 0; i < HeroBodyIMages2.Count; i++)
        {
            HeroBodyIMages.Add(HeroBodyIMages2[i]);
        }
        int r = Random.Range(0, database.PingTarget.Count);
        StartCoroutine(database.CheckInternetConnection1(isConnected =>
            {
                WifiBool = isConnected;
            },r));

        SpellShopUpdateMenu2 = SpellShopUpdateMenu;
        SpellShopBuyMenu2 = SpellShopBuyMenu;
        WifiBlock = WifiBlock2; ;
        //Debug.Log(CameraMove.camMaxX - CameraMove.camMinX);
        //Debug.Log(CameraMove.camMaxY - CameraMove.camMinY);
        /*for(int i=0;i<database.DEC.Count;i++)
        {
            Debug.Log(database.DEC[i]);
            database.DEC[i] = 0;
        }
        database.DEC.Clear();
        while (database.DEC.Count<7)
        {
            database.DEC.Add(0);
        }*/
        HeroShop = HeroShop2;
        DataGameobject = DataGameobject2;
        ShopDataSkillNameText = ShopDataSkillNameText2;
        ShopDataInformation = ShopDataInformation2;
        ShopDataInformationCount = ShopDataInformationCount2;
        if (database.AUD == 0)
        {
            database.AUD = 0;
            Valume.GetComponent<Image>().sprite = MusicImage;
        }
        else
        {
            Valume.GetComponent<Image>().sprite = Music2Image;
        }
        // database.STC = 0;
        footloose = 0;
        if (database.LNG == "EN")
        {
            LanguagesButtonColorChange(0);
        }
        else
            if (database.LNG == "HU")
        {
            LanguagesButtonColorChange(1);
        }
        else
            if (database.LNG == "SR")
        {
            LanguagesButtonColorChange(2);
        }
        MENUGamobjects.kameramozgatas = 0;
        YellowDiamondImageShopPanel = YellowDiamondImageShopPanel2;
        ShopUpgradeTextSkillName = ShopUpgradeTextSkillName2;
        ShopBuySkillName = ShopBuySkillName2;
        LanguagesChange(database.LNG, LANG);
        ShopBuyTextSkillName = ShopBuyTextSkillName2;
        SettingsPanel = SettingsPanel2;
        SettingsButton = SettingsButton2;
        YellowDiamondImage = YellowDiamondImage2;
        MiniGameHero = MiniGameHero2;
        // PagesGameobject = PagesGameobject2;
        HerosShopPanel = HerosShopPanel2;
        ChangeMaxLevelColor = ChangeMaxLevelColor2;

        BigQuicksand = BigQuicksand2;
        QuicksandRange = QuicksandRange2;
        //BUYNameText = BUYNameText2;
        BuyPriceText = BuyPriceText2;
        PresentInformationBUyText = PresentInformationBUyText2;
        BuyList = BuyList2;
       // NameText = NameText2;
        PriceText = PriceText2;
        UpgradeInformationText = UpgradeInformationText2;
        PresentInformationText = PresentInformationText2;
        SmokeLightningPrefab = SmokeLightningPrefab2;
        EgyiptianGod = EgyiptianGod2;
        LighningAttackPrefab = LighningAttackPrefab2;
        ShopPanel2 = ShopPanel;
        YellowDImondCounter = YellowDImondCounter2;
        Level1Count = Level1Count2;
        Level2Count = Level2Count2;
        Level3Count = Level3Count2;
        PIPA2 = PIPA;
        ShopUpgradeSkillName = ShopUpgradeSkillName2;
        NONPIPA2 = NONPIPA;
        BuyObjectsMOney.Clear();
        for (int i = 0; i < BuyObjectsMOney2.Count; i++)
        {
            BuyObjectsMOney.Add(BuyObjectsMOney2[i]);
        }
        BuyingLosColor2 = BuyingLosColor;
        // HEROS Állitása ---------------------
        {
            //HEROPIPA[PRESENTHEROindex].SetActive(true);


        }
        //Lightning -----------------------
        {

        }
        //3EgyiptionGod --------------------
        {
            EgyiptianGod2.transform.GetChild(0).GetComponent<SoldiersMove>().Damegex = 30;
            EgyiptianGod2.transform.GetChild(0).GetComponent<SoldiersMove>().Damegex = 30;
            EgyiptianGod2.transform.GetChild(0).GetComponent<SoldiersMove>().maxHP = 50;

        }
        {
            QuicksandRange.transform.GetChild(0).localScale = new Vector3(3f, 3f, 5);
            QuicksandRange.transform.GetChild(0).GetComponent<QuickSandGO>().time = 10;
        }
        {
            BigQuicksand.GetComponent<BigQuicksandScript>().time = 10;
            BigQuicksand.GetComponent<BigQuicksandScript>().demaga = 5;
        }
        if (database.gamedata == "")
        {
            database.FillGameDataString();
        }
        HERO = HeroShopPages.GetComponent<HeroPagesMOver>().Pages[database.HS].GetComponent<HEroPagesReturn>().HERO;
    }

    public void ShopSetActive(GameObject ShopIqon)
    {
        if (CameraMOverClick.mozoge || ShopPanelMozoge)
            return;
        if (ShopPanel.active)
        {
            SettingsButton.SetActive(true);
            DataGameobject.SetActive(false);
            SpellShopUpdateMenu.SetActive(false);
            SpellShopBuyMenu.SetActive(false);
            StartCoroutine(CameraMove.SkillShopBe(0.7f, ShopPanel, 1, ShopIqon.transform.position));
            SoundsScript.MusicStart(gameObject, "Spellbolt2 vagy herobolt csuszkavágott");
            FajlDatabase.WriteIntoTxtFile();
        }
        else
        {
            if (footloose == 0)
            {
                SettingsButton.SetActive(false);
                footloose = 1;
                kameramozgatas = 1;
                SoundsScript.MusicStart(gameObject, "Spellbolt1");
                StartCoroutine(CameraMove.SkillShopBe(0.7f, ShopPanel, 0, ShopIqon.transform.position));
            }
        }
    }
    public void HEROShopSetActive(GameObject HeroShopIqon)
    {
        if (CameraMOverClick.mozoge || ShopPanelMozoge)
            return;
        if (HerosShopPanel.active)
        {
            MENUGamobjects.HeroShopHelp2.SetActive(false);
            Destroy(HeroShopPages.GetComponent<AudioSource>());
            SettingsButton.SetActive(true);
            StartCoroutine(CameraMove.SkillShopBe(0.7f, HeroShop, 1, HeroShopIqon.transform.position));
            SoundsScript.MusicStart(gameObject, "Spellbolt2 vagy herobolt csuszkavágott");
            FajlDatabase.WriteIntoTxtFile();
        }
        else
        {
            if (MENUGamobjects.footloose == 0)
            {
                Destroy(HeroShopPages.GetComponent<AudioSource>());
                SettingsButton.SetActive(false);
                footloose = 1;
                kameramozgatas = 1;
                SoundsScript.MusicStart(gameObject, "Spellbolt1");
                StartCoroutine(CameraMove.SkillShopBe(0.7f, HeroShop, 0, HeroShopIqon.transform.position));
            }
        }
    }
    public void GOSinglePlayerMenu()
    {
        if (CameraMOverClick.mozoge || footloose != 0)
            return;
        StartCoroutine(LoadYourAsyncScene("SinglePlayerMenu", LOadingSceneGameobject));
        //SceneManager.LoadScene("SinglePlayerMenu");
    }
    public void GOMultiPlayerMenu()
    {
        if (CameraMOverClick.mozoge || footloose != 0)
            return;
        StartCoroutine(LoadYourAsyncScene("MultiPlayerMenu", LOadingSceneGameobject));
        //SceneManager.LoadScene("SinglePlayerMenu");
    }
    private void Update()
    {
        if (!YellowDiamondImageShopPanel.active)
        {
            if (WifiEllenorzesido >= WifiEllenorzesMaxIdo)
            {
                WifiEllenorzesido = 0;
                int r = Random.Range(0, database.PingTarget.Count);
                StartCoroutine(database.CheckInternetConnection1(isConnected =>
                {
                    WifiBool = isConnected;
                }, r));
            }
            else
            {
                WifiEllenorzesido += Time.deltaTime;
            }
        }
    }
    public void Settingsbutton(GameObject SettingBUtton)
    {
        if (CameraMOverClick.mozoge)
            return;
        if (SettingsPanel.active)
        {
            WifiEllenorzesMaxIdo = 20;
            OpinionPanel.SetActive(false);
            LanguagesPanel.SetActive(false);
            MekersPanel.SetActive(false);
            OpinionText.GetComponent<InputField>().text = "";
            SettingLanguageButton.SetActive(true);
            SettingOpinionButton.SetActive(true);
            QuitButton.SetActive(true);
            ExitButton.SetActive(true);
            Valume.SetActive(true);
            MekersButton.SetActive(true);
            StartCoroutine(CameraMove.SkillShopBe(0.5f, SettingsPanel, 1, SettingBUtton.transform.position));
            FajlDatabase.WriteIntoTxtFile();
        }
        else
        {
            if (MENUGamobjects.footloose == 0)
            {
                WifiEllenorzesMaxIdo = 3;
                footloose = 1;
                kameramozgatas = 1;
                StartCoroutine(CameraMove.SkillShopBe(0.5f, SettingsPanel, 0, SettingBUtton.transform.position));
                //SettingsPanel.SetActive(true);
            }
        }
    }
    public void Music2SilenceButton()
    {
        if (CameraMOverClick.mozoge)
            return;
        if (Valume.GetComponent<Image>().sprite == Music2Image)
        {
            database.AUD = 0;
            Valume.GetComponent<Image>().sprite = MusicImage;
        }
        else
        {
            database.AUD = 1;
            Valume.GetComponent<Image>().sprite = Music2Image;
        }
    }
    public void LogOutButton()
    {
        if (!WifiBool)
        {
            Instantiate(WifiBlock);
           return;
        }
        database.ILO = 0;
        //database.FillUpConnectionString();
        database.UpdateDatabase(LogInRegisztrelScript.username, LogInRegisztrelScript.pasword);
        FajlDatabase.DeleteFile();
        StartCoroutine(LoadYourAsyncScene("LogIn", LOadingSceneGameobject));
        //SceneManager.LoadScene("LogIn");
    }

    public void Exit()
    {
        FajlDatabase.WriteIntoTxtFile();
        //#if UNITY_STANDALONE
        Application.Quit();
       // UnityEditor.EditorApplication.isPlaying = false;
        /*#endif
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif*/
    }

    public void Opinion(GameObject OpinionButton)
    {
        if (!WifiBool)
        {
            Instantiate(WifiBlock);
            return;
        }
        if (irtEMarVelemenyt)
            return;
        if (!OpinionPanel.active)
        {
            SoundsScript.MusicStart(gameObject, "opentab");
            //OpinionPanel.SetActive(true);
            SettingLanguageButton.SetActive(false);
            SettingOpinionButton.SetActive(false);
            QuitButton.SetActive(false);
            ExitButton.SetActive(false);
            Valume.SetActive(false);
            MekersButton.SetActive(false);
            StartCoroutine(CameraMove.SkillShopBe(0.4f, OpinionPanel, 0, OpinionButton.transform.position));
        }
    }
    public void OpinionSend(GameObject OpinionButton)
    {
        if (!WifiBool)
        {
            Instantiate(WifiBlock);
            return;
        }
        database.SendComplaint(OpinionText.GetComponent<InputField>().text);
        OpinionText.GetComponent<InputField>().text = "";
        irtEMarVelemenyt = true;
        OpinionClose(OpinionButton);
    }
    public void OpinionClose(GameObject OpinionButton)
    {
        OpinionText.GetComponent<InputField>().text = "";
        //OpinionPanel.SetActive(false);
        SettingLanguageButton.SetActive(true);
        SettingOpinionButton.SetActive(true);
        QuitButton.SetActive(true);
        ExitButton.SetActive(true);
        Valume.SetActive(true);
        MekersButton.SetActive(true);
        StartCoroutine(CameraMove.SkillShopBe(0.4f, OpinionPanel, 1, OpinionButton.transform.position));
    }

    public void LanguasgesPanel(GameObject LanguasgesButton)
    {
        if (LanguagesPanel.active)
        {
            //LanguagesPanel.SetActive(false);
            FajlDatabase.WriteIntoTxtFile();
            SettingLanguageButton.SetActive(true);
            SettingOpinionButton.SetActive(true);
            QuitButton.SetActive(true);
            ExitButton.SetActive(true);
            Valume.SetActive(true);
            MekersButton.SetActive(true);
            StartCoroutine(CameraMove.SkillShopBe(0.4f, LanguagesPanel, 1, LanguasgesButton.transform.position));
        }
        else
        {
            SoundsScript.MusicStart(gameObject, "opentab");
            SettingLanguageButton.SetActive(false);
            SettingOpinionButton.SetActive(false);
            QuitButton.SetActive(false);
            ExitButton.SetActive(false);
            Valume.SetActive(false);
            MekersButton.SetActive(false);
            //LanguagesPanel.SetActive(true);
            StartCoroutine(CameraMove.SkillShopBe(0.4f, LanguagesPanel, 0, LanguasgesButton.transform.position));
        }
    }

    public void MakersSetActive()
    {
        if (MekersPanel.active)
        {
            SettingLanguageButton.SetActive(true);
            SettingOpinionButton.SetActive(true);
            QuitButton.SetActive(true);
            ExitButton.SetActive(true);
            Valume.SetActive(true);
            MekersButton.SetActive(true);
            //MekersPanel.SetActive(false);
            FajlDatabase.WriteIntoTxtFile();
            StartCoroutine(CameraMove.SkillShopBe(0.4f, MekersPanel, 1, MekersButton.transform.position));
        }
        else
        {
            SoundsScript.MusicStart(gameObject, "opentab");
            SettingLanguageButton.SetActive(false);
            SettingOpinionButton.SetActive(false);
            //MekersPanel.SetActive(true);
            QuitButton.SetActive(false);
            ExitButton.SetActive(false);
            Valume.SetActive(false);
            MekersButton.SetActive(false);
            StartCoroutine(CameraMove.SkillShopBe(0.4f, MekersPanel, 0, MekersButton.transform.position));
        }
    }
    public void DataBack()
    {
        StartCoroutine(CameraMove.SkillShopBe(0.3f, DataGameobject, 1, DataGameobject.transform.position));
        //DataGameobject.SetActive(false);
    }
    
    public static IEnumerator LoadYourAsyncScene(string Scene,GameObject LOadingSceneGameobject)
    {
        if (LOadingSceneGameobject.active)
        {
            LOadingSceneGameobject.GetComponent<Animator>().Play("LOadingLostScene");
            float presentTimer = 0;
            while (presentTimer < 1.5f)
            {
                yield return presentTimer += Time.deltaTime;

            }
        }
        //yield return new WaitForSeconds(1.5f);
        // The Application loads the Scene in the background at the same time as the current Scene.
        //This is particularly good for creating loading screens. You could also load the Scene by build //number.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(Scene);
        //Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public static int directiondefinition(Vector2 pos)
    {
        if(pos.x>0)
        {
            return 3;
        }
        else
        {
            return 4;
        }

    }

    public static float Kerekito(float szam)
    {
        float vissza = Mathf.Round(szam);
        return vissza;
    }
    public static bool Bennevane(Transform kulso, Vector3 belso)
    {
        if (belso.x >= (kulso.transform.position.x - kulso.transform.localScale.x / 2) && belso.x <= (kulso.localScale.x / 2 + kulso.position.x) && belso.y >= (kulso.position.y - kulso.localScale.y / 2) && belso.y <= (kulso.localScale.y / 2 + kulso.position.y))
        {
            return true;
        }
        return false;
    }

    public static int BuyUpdateValasztas(int index, string a)
    {
        if (a == "buy")
        {
            if (index == 1)
            {
                return database.LIGB;
            }
            else
                        if (index == 2)
            {
                return database.QUIB;
            }
            else
                        if (index == 3)
            {
                return database.EGYB;
            }
            else
                        if (index == 4)
            {
                return database.BQSB;

            }
        }
        else
            if (a == "upgrade")
        {
            if (index == 1)
            {
                return database.LIGUPG;
            }
            else
                       if (index == 2)
            {
                return database.QUIUPG;
            }
            else
                       if (index == 3)
            {
                return database.EGYUPG;
            }
            else
                       if (index == 4)
            {
                return database.BQSUPG;

            }
        }
        return 0;

    }
    public static void visszairas(int index, int value, string a)
    {
        if (a == "buy")
        {
            if (index == 1)
            {
                database.LIGB = value;
            }
            else
                        if (index == 2)
            {
                database.QUIB = value;
            }
            else
                        if (index == 3)
            {
                database.EGYB = value;
            }
            else
                        if (index == 4)
            {
                database.BQSB = value;

            }
        }
        else
            if (a == "upgrade")
        {
            if (index == 1)
            {
                database.LIGUPG = value;
            }
            else
                        if (index == 2)
            {
                database.QUIUPG = value;
            }
            else
                        if (index == 3)
            {
                database.EGYUPG = value;
            }
            else
                        if (index == 4)
            {
                database.BQSUPG = value;

            }
        }
    }
    public static void ShopLaunguageChange(int index)
    {
        if (index == 1)
        {
            if (database.LNG == "EN")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Damage:\nRange:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Lightning";
            }
            else
                if (database.LNG == "HU")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Sebzés:\nTávolság:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Villám";
            }
            else
                if (database.LNG == "SR")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Oštećenje:\nUdaljenost:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Munja";
            }


        }
        else
                    if (index == 2)
        {
            if (database.LNG == "EN")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Time:\nRange:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Quicksand";
            }
            else
                if (database.LNG == "HU")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Idő:\nTávolság:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Futó homok";
            }
            else
                if (database.LNG == "SR")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Vreme:\nUdaljenost:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Živi pesak";
            }


        }
        else
                    if (index == 3)
        {
            if (database.LNG == "EN")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Damagex:\nDamagey:\nHP:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Egyiptian God";
            }
            else
                if (database.LNG == "HU")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Sebzésx:\nSebzésy:\nÉleterő:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Egyiptomi Isten";
            }
            else
                if (database.LNG == "SR")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Štetax:\nŠtetay:\nZdravlje:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Egipatski Bog";
            }


        }
        else
                    if (index == 4)
        {
            if (database.LNG == "EN")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Damage:\nTime:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Big Quicksand";
            }
            else
                if (database.LNG == "HU")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Sebzés:\nIdő:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Nagy futó homok";
            }
            else
                if (database.LNG == "SR")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Šteta:\nVreme:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Veliki živi pesak";
            }


        }
        ShopBuyTextSkillName.GetComponent<Text>().text = ShopUpgradeTextSkillName.GetComponent<Text>().text;
        ShopBuySkillName.GetComponent<Text>().text = ShopUpgradeSkillName.GetComponent<Text>().text;

    }

    public void flagmentImageAds(int index)
    {
        try
        {
            SettingsFlagMent.GetComponent<SpriteRenderer>().sprite = FlagmentImage[index];
        }
        catch
        {
            Debug.Log("Kell adni neki zászló image-et a menugameobjectben, kifut a flagmentImageListából");
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
                    if (LANg.TextCount[i].Text[j] != null)
                    {
                        LANg.TextCount[i].Text[j].GetComponent<Text>().text = LANg.TextCount[i].Languasges[index];
                    }
                    else
                    {
                        Debug.Log("Hiányzik ez a txt:");
                        Debug.Log("sor:"+i);
                        Debug.Log("Oszlop:"+j);
                    }
                }
                else
                {
                    string[] split = LANg.TextCount[i].Languasges[index].Split('|');
                    if (LANg.TextCount[i].Text[j] != null)
                    {
                        LANg.TextCount[i].Text[j].GetComponent<Text>().text = split[0];
                    }
                    else
                    {
                        Debug.Log("Hiányzik ez a txt:");
                        Debug.Log("sor:" + i);
                        Debug.Log("Oszlop:" + j);
                    }
                    for (int k = 1; k < split.Length; k++)
                    {
                        LANg.TextCount[i].Text[j].GetComponent<Text>().text += "\n" + split[k];
                    }
                }
            }
        }
    }

    public void HeroshopHelped()
    {
        HeroShopHelp.SetActive(true);
    }

}
