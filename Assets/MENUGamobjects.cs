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
    public List<Flags> Flagments = new List<Flags>();
    public static bool WifiBool = false;
    public static float WifiEllenorzesido = 0;
    private int WifiEllenorzesMaxIdo = 20;
    public List<HeroImages> HeroBodyIMages2 = new List<HeroImages>();
    public static List<HeroImages> HeroBodyIMages = new List<HeroImages>();
    public GameObject HeroShopHelp;
    public GameObject SkillShopHelp;
    public static GameObject HeroShopHelp2;
    public static GameObject SkillShopHelp2;
    public GameObject UserNameSettingsText;
    public GameObject FeliratSettings;
    public static Vector3 SettingsStandartSize, HeroPanelSize, OpinionSize, SkillShopSize, DataSize, LanguagesSize, MakersSize, ChangeSize;
    public List<GameObject> SkillShopUpgrades;
    public static float Timer = 0;
    private bool kijelentkezes = true;
    public GameObject wifiGameobject;
    public static GameObject LOadingSceneGameobject2;
    public GameObject ChangePanel;
    public GameObject ChangeButton;
    public GameObject ChangeTextusername;
    public GameObject ChangeTextPass;
    public GameObject WrongChangeTextusernameNoName;
    public GameObject WrongChangeTextusernametaken;
    public GameObject WrongChangeTextusernamenowifi;
    public GameObject WrongChangeTextNoPass;
    public GameObject WrongChangeTextWrongnameOrPass;
    public GameObject WrongChangeTextNomoney;


    [System.Serializable]
    public class Flags
    {
        public Sprite FlagImage;
        public Vector2 size;
    }


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
        LOadingSceneGameobject2 = LOadingSceneGameobject;
        FajlDatabase.WriteIntoTxtFile();
        SkillShopHelp2=SkillShopHelp;
        if (LogInRegisztrelScript.username == "")
        {
            UserNameSettingsText.GetComponent<Text>().text = "Tester";
        }
        else
        {
            UserNameSettingsText.GetComponent<Text>().text = LogInRegisztrelScript.username;
        }
        HeroShopHelp2 = HeroShopHelp;
        HeroBodyIMages.Clear();
        for (int i = 0; i < HeroBodyIMages2.Count; i++)
        {
            HeroBodyIMages.Add(HeroBodyIMages2[i]);
        }
        int r =  Random.Range(0, database.PingTarget.Count);
        StartCoroutine(database.CheckInternetConnection1(isConnected =>
            {
                WifiBool = isConnected;
            },r));

        SpellShopUpdateMenu2 = SpellShopUpdateMenu;
        SpellShopBuyMenu2 = SpellShopBuyMenu;
        WifiBlock = WifiBlock2; ;
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
        else
              if (database.LNG == "DE")
        {
            LanguagesButtonColorChange(3);
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
            SkillShopUpgrades[0].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count += (database.LIGUPG - 1) * SkillShopUpgrades[0].GetComponent<UpgradeButtonMenu>().Upgrade[0];
            SkillShopUpgrades[0].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count += (database.LIGUPG - 1) * SkillShopUpgrades[0].GetComponent<UpgradeButtonMenu>().Upgrade[1];
            LighningAttackPrefab.GetComponent<LighningShadowAtacking>().lightningDamage = SkillShopUpgrades[0].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count;
            LighningAttackPrefab.transform.localScale = new Vector3(SkillShopUpgrades[0].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count , SkillShopUpgrades[0].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count, 5);
        }
        //3EgyiptionGod --------------------
        {
            SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count += (database.EGYUPG - 1) * SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().Upgrade[0];
            SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count += (database.EGYUPG - 1) * SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().Upgrade[1];
            SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().PresentUpgrade[2].Count += (database.EGYUPG - 1) * SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().Upgrade[2];
            EgyiptianGod2.transform.GetChild(0).GetComponent<SoldiersMove>().Damegex = SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count;
            EgyiptianGod2.transform.GetChild(0).GetComponent<SoldiersMove>().Damegex = SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count;
            EgyiptianGod2.transform.GetChild(0).GetComponent<SoldiersMove>().maxHP = SkillShopUpgrades[2].GetComponent<UpgradeButtonMenu>().PresentUpgrade[2].Count;

        }
        {
            SkillShopUpgrades[1].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count += (database.QUIUPG - 1) * SkillShopUpgrades[1].GetComponent<UpgradeButtonMenu>().Upgrade[0];
            SkillShopUpgrades[1].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count += (database.QUIUPG - 1) * SkillShopUpgrades[1].GetComponent<UpgradeButtonMenu>().Upgrade[1];
            QuicksandRange.transform.GetChild(0).localScale = new Vector3(SkillShopUpgrades[1].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count, SkillShopUpgrades[1].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count, 5);
            QuicksandRange.transform.GetChild(0).GetComponent<QuickSandGO>().time = SkillShopUpgrades[1].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count;
        }
        {
            SkillShopUpgrades[3].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count += (database.BQSUPG - 1) * SkillShopUpgrades[3].GetComponent<UpgradeButtonMenu>().Upgrade[0];
            SkillShopUpgrades[3].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count += (database.BQSUPG - 1) * SkillShopUpgrades[3].GetComponent<UpgradeButtonMenu>().Upgrade[1];
            BigQuicksand.GetComponent<BigQuicksandScript>().time = SkillShopUpgrades[3].GetComponent<UpgradeButtonMenu>().PresentUpgrade[0].Count;
            BigQuicksand.GetComponent<BigQuicksandScript>().demaga = SkillShopUpgrades[3].GetComponent<UpgradeButtonMenu>().PresentUpgrade[1].Count;
        }
        if (database.gamedata == "")
        {
            database.FillGameDataString();
        }
        HERO = HeroShopPages.GetComponent<HeroPagesMOver>().Pages[database.HS].GetComponent<HEroPagesReturn>().HERO;
        SettingsStandartSize = SettingsPanel2.transform.localScale;
        OpinionSize = OpinionPanel.transform.localScale;
        SkillShopSize = ShopPanel.transform.localScale;
        DataSize = DataGameobject.transform.localScale;
        HeroPanelSize = HeroShop.transform.localScale;
        LanguagesSize = LanguagesPanel.transform.localScale;
        MakersSize = MekersPanel.transform.localScale;
        ChangeSize = ChangePanel.transform.localScale;
        try
        {
            if (!WifiBool)
            {
                if (LogInRegisztrelScript.username != "")
                {
                    database.InsertPlayTime(LogInRegisztrelScript.username, Mathf.Ceil(Timer));
                }
            }
        }
        catch
        {
            Debug.Log("Hiba");
        }
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
            MENUGamobjects.SkillShopHelp2.SetActive(false);
            MENUGamobjects.SkillShopHelp2.SetActive(false);
            //ShopPanel.transform.localScale = SkillShopSize;
            StartCoroutine(CameraMove.SkillShopBe(0.5f, ShopPanel, 1, ShopIqon.transform.position));
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
                //ShopPanel.transform.localScale = SkillShopSize;
                StartCoroutine(CameraMove.SkillShopBe(0.5f, ShopPanel, 0, ShopIqon.transform.position));
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
            //HeroShop.transform.localScale = HeroPanelSize;
            StartCoroutine(CameraMove.SkillShopBe(0.5f, HeroShop, 1, HeroShopIqon.transform.position));
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
                //HeroShop.transform.localScale = HeroPanelSize;
                StartCoroutine(CameraMove.SkillShopBe(0.5f, HeroShop, 0, HeroShopIqon.transform.position));
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
        MENUGamobjects.Timer += Time.deltaTime / 60;
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
                try
                {
                    if (!WifiBool)
                    {
                        if (LogInRegisztrelScript.username != "")
                        {
                            database.UpdateDatabase(LogInRegisztrelScript.username, LogInRegisztrelScript.pasword);
                            database.InsertPlayTime(LogInRegisztrelScript.username, Mathf.Ceil(Timer));
                        }
                    }
                }
                catch
                {
                    Debug.Log("Hiba");
                }
                if (kijelentkezes)
                {
                    FajlDatabase.WriteIntoTxtFile();
                }
                wifiGameobject.SetActive(!WifiBool);
            }
            else
            {
                WifiEllenorzesido += Time.deltaTime;
            }
        }
    }
    public void Settingsbutton(GameObject SettingBUtton)
    {
        if (CameraMOverClick.mozoge || ShopPanelMozoge)
            return;
        if (SettingsPanel.active)
        {
            WifiEllenorzesMaxIdo = 20;
            OpinionPanel.SetActive(false);
            LanguagesPanel.SetActive(false);
            MekersPanel.SetActive(false);
            ChangePanel.SetActive(false);
            OpinionText.GetComponent<InputField>().text = "";
            SettingLanguageButton.SetActive(true);
            SettingOpinionButton.SetActive(true);
            QuitButton.SetActive(true);
            ExitButton.SetActive(true);
            Valume.SetActive(true);
            MekersButton.SetActive(true);
            FeliratSettings.SetActive(true);
            ChangeButton.SetActive(true);
            //SettingsPanel.transform.localScale = SettingsStandartSize;
            StartCoroutine(CameraMove.SkillShopBe(0.4f, SettingsPanel, 1, SettingBUtton.transform.position));          
            FajlDatabase.WriteIntoTxtFile();
        }
        else
        {
            if (MENUGamobjects.footloose == 0)
            {
                WifiEllenorzesMaxIdo = 1;
                footloose = 1;
                kameramozgatas = 1;
                //SettingsPanel.transform.localScale = SettingsStandartSize;
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
        kijelentkezes = false;
        if (LogInRegisztrelScript.username != "")
        {
            database.UpdateDatabase(LogInRegisztrelScript.username, LogInRegisztrelScript.pasword);
            database.InsertPlayTime(LogInRegisztrelScript.username, Mathf.Ceil(Timer));
        }
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
            FeliratSettings.SetActive(false);
            ChangeButton.SetActive(false);
            OpinionPanel.transform.localScale = OpinionSize;
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
        FeliratSettings.SetActive(true);
        ChangeButton.SetActive(true);
        OpinionPanel.transform.localScale = OpinionSize;
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
            FeliratSettings.SetActive(true);
            ChangeButton.SetActive(true);
            LanguagesPanel.transform.localScale = LanguagesSize;
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
            FeliratSettings.SetActive(false);
            ChangeButton.SetActive(false);
            //LanguagesPanel.SetActive(true);
            LanguagesPanel.transform.localScale = LanguagesSize;
            StartCoroutine(CameraMove.SkillShopBe(0.4f, LanguagesPanel, 0, LanguasgesButton.transform.position));
        }
    }

    public void UsernameChangeButton(GameObject ChangeButton)
    {
        if (ChangePanel.active)
        {
            //LanguagesPanel.SetActive(false);
            FajlDatabase.WriteIntoTxtFile();
            SettingLanguageButton.SetActive(true);
            SettingOpinionButton.SetActive(true);
            QuitButton.SetActive(true);
            ExitButton.SetActive(true);
            Valume.SetActive(true);
            MekersButton.SetActive(true);
            FeliratSettings.SetActive(true);
            ChangeButton.SetActive(true);
            ChangePanel.transform.localScale = ChangeSize;
            StartCoroutine(CameraMove.SkillShopBe(0.4f, ChangePanel, 1, ChangeButton.transform.position));
        }
        else
        {
            if (!WifiBool)
            {
                Instantiate(WifiBlock);
                return;
            }
            SoundsScript.MusicStart(gameObject, "opentab");
            ChangeTextPass.GetComponent<InputField>().text = "";
            ChangeTextusername.GetComponent<InputField>().text = "";
            WrongChangeTextusernameNoName.SetActive(false); 
            WrongChangeTextusernametaken.SetActive(false); 
            WrongChangeTextusernamenowifi.SetActive(false);
            WrongChangeTextNoPass.SetActive(false);
            WrongChangeTextWrongnameOrPass.SetActive(false);
            WrongChangeTextNomoney.SetActive(false);
            SettingLanguageButton.SetActive(false);
            SettingOpinionButton.SetActive(false);
            QuitButton.SetActive(false);
            ExitButton.SetActive(false);
            Valume.SetActive(false);
            MekersButton.SetActive(false);
            FeliratSettings.SetActive(false);
            ChangeButton.SetActive(false);
            //LanguagesPanel.SetActive(true);
            ChangePanel.transform.localScale = ChangeSize;
            StartCoroutine(CameraMove.SkillShopBe(0.4f, ChangePanel, 0, ChangeButton.transform.position));
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
            FeliratSettings.SetActive(true);
            ChangeButton.SetActive(true);
            //MekersPanel.SetActive(false);
            FajlDatabase.WriteIntoTxtFile();
            MekersPanel.transform.localScale = MakersSize;
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
            FeliratSettings.SetActive(false);
            ChangeButton.SetActive(false);
            MekersPanel.transform.localScale = MakersSize;
            StartCoroutine(CameraMove.SkillShopBe(0.4f, MekersPanel, 0, MekersButton.transform.position));
        }
    }
    public void DataBack()
    {
        SkillShopHelp2.SetActive(false);
        DataGameobject.transform.localScale = DataSize;
        StartCoroutine(CameraMove.SkillShopBe(0.3f, DataGameobject, 1, DataGameobject.transform.position));
        //DataGameobject.SetActive(false);
    }
    
    public static IEnumerator LoadYourAsyncScene(string Scene,GameObject LOadingSceneGameobject)
    { 
        if (LOadingSceneGameobject.active)
        {
            LOadingSceneGameobject.GetComponent<Animator>().Play("LOadingLostScene");
            float presentTimer = 0;
            while (presentTimer < 1f)
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
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Oštećenja:\nUdaljenost:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Munja";
            }
            else
                if (database.LNG == "DE")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Schaden:\nReichweite:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Blitz";
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
            else
                if (database.LNG == "DE")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Zeit:\nBereich:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Treibsand";
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
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Oštećenjax:\nOštećenjay:\nZdravlje:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Egipatski Bog";
            }
            else
                if (database.LNG == "DE")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Schadenx:\nSchadeny:\nGP:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Ägyptischer Gott";
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
            else
                if (database.LNG == "DE")
            {
                ShopUpgradeTextSkillName.GetComponent<Text>().text = "Schaden:\nZeit:";
                ShopUpgradeSkillName.GetComponent<Text>().text = "Großer Treibsand";
            }


        }
        ShopBuyTextSkillName.GetComponent<Text>().text = ShopUpgradeTextSkillName.GetComponent<Text>().text;
        ShopBuySkillName.GetComponent<Text>().text = ShopUpgradeSkillName.GetComponent<Text>().text;

    }

    public void flagmentImageAds(int index)
    {
        try
        {
            SettingsFlagMent.GetComponent<SpriteRenderer>().sprite = Flagments[index].FlagImage;
            SettingsFlagMent.GetComponent<SpriteRenderer>().size = Flagments[index].size;
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

    public void SkillhopHelped()
    {
        SkillShopHelp.SetActive(true);
    }

    public void ChangeUsername()
    {
        if (WifiBool)
        {
            if (ChangeTextusername.GetComponent<InputField>().text == "")
            {
                WrongChangeTextusernametaken.SetActive(false);
                WrongChangeTextusernamenowifi.SetActive(false);
                WrongChangeTextusernameNoName.SetActive(true);
                WrongChangeTextNoPass.SetActive(false);
                WrongChangeTextWrongnameOrPass.SetActive(false);
                WrongChangeTextNomoney.SetActive(false);
            }
            else
            if (database.CheckIfThisExists(ChangeTextusername.GetComponent<InputField>().text, "") == 1)
            {
                WrongChangeTextusernameNoName.SetActive(false);
                WrongChangeTextusernamenowifi.SetActive(false);
                WrongChangeTextusernametaken.SetActive(true);
                WrongChangeTextNoPass.SetActive(false);
                WrongChangeTextWrongnameOrPass.SetActive(false);
                WrongChangeTextNomoney.SetActive(false);
            }
            else
            if (ChangeTextPass.GetComponent<InputField>().text == "")
            {
                WrongChangeTextusernametaken.SetActive(false);
                WrongChangeTextusernamenowifi.SetActive(false);
                WrongChangeTextusernameNoName.SetActive(false);
                WrongChangeTextNoPass.SetActive(true);
                WrongChangeTextWrongnameOrPass.SetActive(false);
                WrongChangeTextNomoney.SetActive(false);
            }
            else
            {
                if (database.GDC >= 100)
                {
                    //Debug.Log(database.ChangeUsernameThroughOldUsernameAndPassword(LogInRegisztrelScript.username, ChangeTextPass.GetComponent<InputField>().text, ChangeTextusername.GetComponent<InputField>().text));
                    if(database.ChangeUsernameThroughOldUsernameAndPassword(LogInRegisztrelScript.username, ChangeTextPass.GetComponent<InputField>().text,ChangeTextusername.GetComponent<InputField>().text)== "Wrong username or password!")
                    {
                        WrongChangeTextusernametaken.SetActive(false);
                        WrongChangeTextusernamenowifi.SetActive(false);
                        WrongChangeTextusernameNoName.SetActive(false);
                        WrongChangeTextNoPass.SetActive(false);
                        WrongChangeTextWrongnameOrPass.SetActive(true);
                        WrongChangeTextNomoney.SetActive(false);
                        return;
                    }
                    if (LogInRegisztrelScript.username == "")
                    {
                        UserNameSettingsText.GetComponent<Text>().text = "Tester";
                    }
                    else
                    {
                        LogInRegisztrelScript.username = ChangeTextusername.GetComponent<InputField>().text;
                        UserNameSettingsText.GetComponent<Text>().text = LogInRegisztrelScript.username;
                    }
                    YellowDImondCounter.GetComponent<YellowDiamondCounter>().YellowDIamonCoundChange(100);
                    UsernameChangeButton(ChangeButton);
                }
                else
                {
                    WrongChangeTextusernametaken.SetActive(false);
                    WrongChangeTextusernamenowifi.SetActive(false);
                    WrongChangeTextusernameNoName.SetActive(false);
                    WrongChangeTextNoPass.SetActive(false);
                    WrongChangeTextWrongnameOrPass.SetActive(false);
                    WrongChangeTextNomoney.SetActive(true);
                }
            }
        }
        else
        {
            WrongChangeTextusernameNoName.SetActive(false);
            WrongChangeTextusernametaken.SetActive(false);
            WrongChangeTextusernamenowifi.SetActive(true);
            WrongChangeTextNoPass.SetActive(false);
            WrongChangeTextWrongnameOrPass.SetActive(false);
            WrongChangeTextNomoney.SetActive(false);
        }
    }

}
