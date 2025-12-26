using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AllGameObject : MonoBehaviour
{
    public GameObject PauseMenuPanel2 = null;
    public GameObject Kulsok2 = null;
    public GameObject Options2 = null;
    public GameObject Spaces2 = null;
    public List<GameObject> Spaceses2 = new List<GameObject>();
    public GameObject MoneyLocation2 = null;
    public GameObject PauseButtonImageLocation2 = null;
    public GameObject GameOverPanel2 = null;
    public GameObject ShopArrowButton2 = null;
    public GameObject MoneyText2 = null;
    public List<GameObject> Towers2 = new List<GameObject>();
    public GameObject X2 = null;
    //public Transform Enemy2 = null;
    //public int Spacecount2 = 1;
    public GameObject GameOverCanvas2 = null;
    public GameObject TowerArrow2 = null;
    public float radioNextWaveCircle2;
    public GameObject WinnerCanvas2 = null;
    public Image Star12 = null;
    public Image Star22 = null;
    public Image Star32 = null;
    public Sprite EmptyStarImage2;
    public Sprite StarImage2;
    public GameObject attackfromheavenButton21 = null;
    public GameObject attackfromheavenArrows2 = null;
    public GameObject attackfromheavenButton22 = null;
    public GameObject ShadowArrow2 = null;
    public string NextScene2 = "SinglePlayerMenu";
    public Camera MainCamera2 = null;
    public Transform BPositionAttack2 = null;
    public Transform APositionAttack2 = null;
    public GameObject UpgradeButton2 = null;
    public GameObject DestroyButton2 = null;
    public GameObject TowerRangeEllipszis2 = null;
    public GameObject OwnUnitSoldiersButton12 = null;
    public GameObject OwnUnitSoldiersButton22 = null;
    public GameObject OwnSoldier2 = null;
    public GameObject SoldersTowerRangeEllipszis2 = null;
    public GameObject ArrowsDOwnParticleEffect2 = null;
    public int LevelCount2 = 0;
    public List<GameObject> Starts2 = new List<GameObject>();
    public GameObject YellowDiamondText2;
    public GameObject LightningButton2;
    public GameObject quicksandButton2;
    public GameObject BigquicksandButton2;
    public GameObject EgyptianGodButton2;
    public GameObject LightningSkillBubbleObjects2;
    public GameObject BigquicksandSkillBubbleObjectsn2;
    public GameObject EgyptianGodSkillBubbleObjects2;
    public Color clickSkillButton;
    public Color WhiteColor2;
    public GameObject BubbleAllSkillObjects2;
    public GameObject MapRodas2;
    public GameObject MiniGamesOrVideoSurface2;
    public GameObject SecondCircleLOading2;
    public Sprite Pipa2;
    public Sprite x2;
    public Sprite greenCircle2;
    public GameObject BubbleUseButon2;
    public GameObject Abality12;
    public GameObject Abality22;
    public GameObject Abalitys2;
    public GameObject Abality12LOadingCircle;
    public GameObject Abality22LOadingCircle;
    public GameObject Abality1TextSkill;
    public GameObject Abality2TextSkill;
    public GameObject HeroLevelBacgroundIMage2;
    public GameObject KarakterSkillGameObject2;
    public GameObject HealtyText2;
    public GameObject ReolodinfText2;
    public GameObject SpeedText2;
    public GameObject DamageText2;
    public GameObject SkinCaracterImage2;
    public Color ChooseCaracter2;
    public GameObject LOadingSceneGameobject2;


    public static GameObject LOadingSceneGameobject;
    public static Color ChooseCaracter;
    public static GameObject SkinCaracterImage;
    public static GameObject HealtyText;
    public static GameObject ReolodinfText;
    public static GameObject SpeedText;
    public static GameObject DamageText;
    public static GameObject KarakterSkillGameObject;
    public static GameObject PauseMenuPanel;
    public static GameObject Kulsok;
    public static GameObject Options;
    public static GameObject Spaces;
    public static GameObject MoneyLocation;
    public static GameObject PauseButtonImageLocation;
    public static GameObject GameOverPanel;
    public static GameObject ShopArrowButton;
    public static GameObject MoneyText;
    public static List<GameObject> Towers = new List<GameObject>();
    public static List<GameObject> Starts = new List<GameObject>();
    public static GameObject X;
    public static Transform Enemy;
    public static GameObject TowerArrow = null;
    public static float radioNextWaveCircle;
    public static GameObject WinnerCanvas = null;
    public static Image Star1 = null;
    public static Image Star2 = null;
    public static Image Star3 = null;
    public static Sprite EmptyStarImage;
    public static Sprite StarImage;
    public static GameObject attackfromheavenButton;
    public static bool attackfromheavenClickBool = false;
    public static bool OwnUNitSoldiersClickBool = false;
    public static GameObject attackfromheavenArrows = null;
    public static GameObject attackfromheavenButton2;
    public static GameObject ShadowArrow = null;
    public static string NextScene = "SinglePlayerMenu";
    public static Camera MainCamera = null;
    public static Transform BPositionAttack = null;
    public static Transform APositionAttack = null;
    public static GameObject UpgradeButton = null;
    public static GameObject SegedUpgradeButton = null;
    public static GameObject SegedUpgradeTower = null;
    //public static GameObject SegedDestroyButton = null;
    public static GameObject DestroyButton = null;
    public static GameObject TowerRangeEllipszis = null;
    public static GameObject SegedTowerRangeEllipszis = null;
    public static GameObject OwnUnitSoldiersButton1 = null;
    public static GameObject OwnUnitSoldiersButton2 = null;
    public static GameObject OwnSoldier = null;
    public static GameObject SoldersTowerRangeEllipszis = null;
    public static GameObject ArrowsDOwnParticleEffect = null;
    public static int LevelCount = 0;
    public static GameObject YellowDiamondText;
    public static bool Lightning = false;
    public static bool quicksand = false;
    public static bool Bigquicksand = false;
    public static bool EgyptianGod = false;
    public static GameObject LightningButton;
    public static GameObject quicksandButton;
    public static GameObject BigquicksandButton;
    public static GameObject EgyptianGodButton;
    public static GameObject LightningSkillBubbleObjects;
    public static GameObject BigquicksandSkillBubbleObjectsn;
    public static GameObject EgyptianGodSkillBubbleObjects;
    public static GameObject BubbleAllSkillObjects;
    public static GameObject MapRodas;
    public static GameObject MiniGamesOrVideoSurface;
    public static GameObject SecondCircleLOading;
    public static Sprite Pipa;
    public static Sprite x;
    public static Sprite greenCircle;
    public static GameObject BubbleUseButon;
    public static GameObject Abality1;
    public static GameObject Abality2;
    public static GameObject Abalitys;
    public static float Abality1Timer = 0;
    public static float Abality2Timer = 0;
    public static float AttackfromHavenTimer = 0;
    public static GameObject HeroLevelBacgroundIMage, SinglePlayerMApsAndTutorial = null;
    public static float OwnSOlderTimer = 0;
    public static List<GameObject> Spaceses = new List<GameObject>();
    public static bool SettingsButton = true;


    public static int Spacecount = 6;
    public static bool ShopButtonActivOrNotactive;
    public static Transform[] SpacesTransform = new Transform[100];
    public static GameObject GameOverCanvas = null;
    public static List<Transform> AllEnemys = new List<Transform>();
    public static List<Transform> AllSoldier = new List<Transform>();
    public static Color WhiteColor;
    public Color Darkening2;
    public static Color Darkening;
    public static bool heroLOadintActive = false;
    public static bool Abality1LOadintActive = false;
    public static bool Abality2LOadintActive = false;
    public static bool Abality1Active = false;
    public static bool Abality2Active = false;
    public static GameObject HERO = null;
    public static bool heroactive = false;
    public static GameObject designateCaracter = null;
    //public static int PresentUpgradeTowerLevelCounter=0;




    public static List<GameObject> Xess = new List<GameObject>();
    public List<GameObject> Xes = new List<GameObject>();
    public GameObject HeroButton2;
    public static GameObject HeroButton;
    public GameObject poisonEfekt2;
    public static GameObject poisonEfekt;
    public GameObject Buzogany2;
    public static GameObject Buzogany;
    private List<Transform> Spriterenderer = new List<Transform>();
    private float OneSecend = 0;


    private void Start()
    {
        PauseButtonImagePause.Bool = false;
        MENUGamobjects.kameramozgatas = 0;
        Abality1Timer = 0;
        Abality1LOadintActive = false;
        Abality2LOadintActive = false;
        Abality2Timer = 0;
        AttackfromHavenTimer = 0;
        OwnSOlderTimer = 0;
        heroLOadintActive = false;
        Xess.Clear();
        Towers.Clear();
        //AllGameObject.AllEnemys.Clear();
        AllSoldier.Clear();
        Starts.Clear();
        Spaceses.Clear();
        for (int i = 0; i < SpacesTransform.Length; i++)
        {
            SpacesTransform[i] = null;
        }
        Buzogany = Buzogany2;
        AllGameObject.SettingsButton = true;
        LOadingSceneGameobject = LOadingSceneGameobject2;
        SinglePlayerMApsAndTutorial = gameObject;
        ChooseCaracter = ChooseCaracter2;
        SkinCaracterImage = SkinCaracterImage2;
        HealtyText = HealtyText2;
        ReolodinfText = ReolodinfText2;
        SpeedText = SpeedText2;
        DamageText = DamageText2;
        KarakterSkillGameObject = KarakterSkillGameObject2;
        OwnSOlderTimer = 0;
        AttackfromHavenTimer = 0;
        AllEnemys.Clear();
        MENUGamobjects.kameramozgatas = 0;
        poisonEfekt = poisonEfekt2;
        HeroLevelBacgroundIMage = HeroLevelBacgroundIMage2;
        Abalitys = Abalitys2;
        Abality1 = Abality12;
        Abality2 = Abality22;
        BubbleUseButon = BubbleUseButon2;
        greenCircle = greenCircle2;
        x = x2;
        Pipa = Pipa2;
        SecondCircleLOading = SecondCircleLOading2;
        HeroButton = HeroButton2; ;
        MiniGamesOrVideoSurface = MiniGamesOrVideoSurface2;
        MapRodas = MapRodas2;
        BubbleAllSkillObjects = BubbleAllSkillObjects2;
        LightningSkillBubbleObjects = LightningSkillBubbleObjects2;
        BigquicksandSkillBubbleObjectsn = BigquicksandSkillBubbleObjectsn2;
        EgyptianGodSkillBubbleObjects = EgyptianGodSkillBubbleObjects2;
        Darkening = Darkening2;
        WhiteColor = WhiteColor2;
        LightningButton = LightningButton2;
        quicksandButton = quicksandButton2;
        BigquicksandButton = BigquicksandButton2;
        EgyptianGodButton = EgyptianGodButton2;
        for (int i = 0; i <= Spacecount + 1; i++)
        {
            SpacesTransform[i] = null;
        }
        LevelCount = LevelCount2;
        PauseMenuPanel = PauseMenuPanel2;
        Kulsok = Kulsok2;
        Options = Options2;
        Spaces = Spaces2;
        MoneyLocation = MoneyLocation2;
        PauseButtonImageLocation = PauseButtonImageLocation2;
        GameOverPanel = GameOverPanel2;
        ShopArrowButton = ShopArrowButton2;
        MoneyText = MoneyText2;
        X = X2;
        //Enemy = Enemy2;
        Spacecount = Spaceses2.Count;
        for (int i = 0; i < Spaceses2.Count; i++)
        {
            Spaceses.Add(Spaceses2[i]);
        }
        GameOverCanvas = GameOverCanvas2;
        TowerArrow = TowerArrow2;
        radioNextWaveCircle = radioNextWaveCircle2;
        WinnerCanvas = WinnerCanvas2;
        Star1 = Star12;
        Star2 = Star22;
        Star3 = Star32;
        EmptyStarImage = EmptyStarImage2;
        StarImage = StarImage2;
        attackfromheavenButton = attackfromheavenButton21;
        attackfromheavenArrows = attackfromheavenArrows2;
        attackfromheavenButton2 = attackfromheavenButton22;
        ShadowArrow = ShadowArrow2;
        NextScene = NextScene2;
        MainCamera = MainCamera2;
        BPositionAttack = BPositionAttack2;
        APositionAttack = APositionAttack2;
        UpgradeButton = UpgradeButton2;
        DestroyButton = DestroyButton2;
        TowerRangeEllipszis = TowerRangeEllipszis2;
        OwnUnitSoldiersButton1 = OwnUnitSoldiersButton12;
        OwnUnitSoldiersButton2 = OwnUnitSoldiersButton22;
        OwnSoldier = OwnSoldier2;
        SoldersTowerRangeEllipszis = SoldersTowerRangeEllipszis2;
        ArrowsDOwnParticleEffect = ArrowsDOwnParticleEffect2;
        YellowDiamondText = YellowDiamondText2;
        for (int i = 0; i < Towers2.Count; i++)
        {
            Towers.Add(Towers2[i]);
        }
        for (int i = 0; i < Xes.Count; i++)
        {
            Xess.Add(Xes[i]);
        }
        for (int i = 0; i < Starts2.Count; i++)
        {
            Starts.Add(Starts2[i]);
        }
    }

    // 1=Tower1(ArrowTower) ; 2=Tower2(OwnSoldiersTower)
    public static void TowerUpgrade(int Level, int OwnArrowTowerStb, GameObject Tower, int Index)
    {
        /*Destroy(SegedDestroyButton);
       SegedUpgradeTower=null;*/
        if (OwnArrowTowerStb == 1)
        {
            //Tower.GetComponent<TowerShot>().TowerUpgradeCanvas.SetActive(false);
            if (Level == 1)
            {
                if (MENUGamobjects.TutorialMap != 0)
                {
                    Destroy(Tower.GetComponent<TowerShot>().UpgradeArrowTowerScriptCIrcle);
                    if (SegedTowerRangeEllipszis != null)
                        Destroy(SegedTowerRangeEllipszis);
                    SegedUpgradeTower = null;


                }

                SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "IjtowerFejlesztes");
                Tower.GetComponent<TowerShot>().TowerUpgrade1.SetActive(false);
                Tower.GetComponent<TowerShot>().TowerUpgrade2.SetActive(true);

                // TowerArrow Elsõ fejlesztése
                Tower.GetComponent<TowerShot>().timerMax /= 2.2f;
                Tower.GetComponent<TowerShot>().range += 0.3f;
                Tower.GetComponent<TowerShot>().damage1 += 3;

            }
            else
                if (Level == 2)
            {
                // TowerArrow második fejlesztése
                if (Index == 1)
                {
                    SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "IjtowerFejlesztes");
                    Tower.GetComponent<TowerShot>().TowerUpgrade2.SetActive(false);
                    Tower.GetComponent<TowerShot>().TowerUpgrade3.SetActive(true);
                    Tower.GetComponent<SpriteRenderer>().sprite = IMAGE.ArrowTowerCrosbowLVL2Tower;

                    // TowerArrow Crosbowá változása
                    Tower.GetComponent<TowerShot>().timerMax /= 1.2f;
                    Tower.GetComponent<TowerShot>().range += 0.3f;
                    Tower.GetComponent<TowerShot>().damage1 += 25;

                }
                else
                if (Index == 2)
                {
                    SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "IjtowerFejlesztes");
                    Tower.GetComponent<TowerShot>().TowerUpgrade2.SetActive(false);
                    Tower.GetComponent<TowerShot>().TowerUpgrade4.SetActive(true);
                    Tower.GetComponent<SpriteRenderer>().sprite = IMAGE.ArrowTowerClassicArrowLVL2Tower;

                    // TowerArrow Erösebb Arrowok
                    Tower.GetComponent<TowerShot>().timerMax /= 1.8f;
                    Tower.GetComponent<TowerShot>().range += 0.3f;
                    Tower.GetComponent<TowerShot>().damage1 += 15;
                }
            }
            else
            if (Level == 3)
            {
                // TowerArrow Crossbow skiljei
                SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "ijspecializacio2");
                if (Index == 1)
                {
                    // TowerArrow Crosbow elsõ skilje Force
                    Tower.GetComponent<TowerShot>().damage1 += 10;
                }
                else
                 if (Index == 2)
                {
                    // TowerArrow Crosbow második skilje kritikus sebzés
                    Tower.GetComponent<TowerShot>().kepsseg1 += 2;

                }
            }
            else
            if (Level == 4)
            {
                SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial, "ijspecializacio2");
                // TowerArrow Erösebb Arrowok
                if (Index == 1)
                {
                    // TowerArrow Erösebb Arrowok elsõ skilje Force
                    Tower.GetComponent<TowerShot>().damage1 += 10;
                }
                else
                if (Index == 2)
                {
                    // TowerArrow bowman második skilje transformation
                    Tower.GetComponent<TowerShot>().kepsseg2++;
                }
                else
                if (Index == 3)
                {
                    // TowerArrow Erösebb Arrowok harmadik skilje Poison
                    Tower.GetComponent<TowerShot>().kepsseg3 += 2;
                }
            }
        }
        else
            if (OwnArrowTowerStb == 2)
        {
            //Tower.GetComponent<TowerOwnSolderBuilding>().TowerUpgradeCanvas.SetActive(false);
            if (Level == 1)
            {
                // OwnSoldiersTower elsõ fejlesztése
                if (Index == 1)
                {
                    // OwnSoldiersTower Erösebb Romai katonák
                    int pluszDamage = 20, pluszHP = 50;


                    int index = 1;

                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszDamage += pluszDamage;
                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszmaxHp += pluszHP;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegex += pluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegey += pluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().maxHP += pluszHP;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].gameObject.GetComponent<OwnSolidersAnimation>().WalkIndex = 0;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].gameObject.GetComponent<OwnSolidersAnimation>().AttackIndex = 0;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].gameObject.GetComponent<SoldiersMove>().IndexSkin = index;
                        /*for (int g = 0; g < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().SoldiersSkin.Count; g++)
                        {
                            Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().SoldiersSkin[g].SetActive(false);
                        }
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().SoldiersSkin[index].SetActive(true);*/
                    }
                    Tower.GetComponent<TowerOwnSolderBuilding>().indexskin = index;
                    Tower.transform.position = new Vector3(Tower.transform.position.x + 0.6f, Tower.transform.position.y - 0.1f, Tower.transform.position.z);
                    Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position = new Vector3(Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position.x - 0.6f, Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position.y, Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position.z);
                    if (Tower.GetComponent<TowerOwnSolderBuilding>().Gate.active)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().Gate.GetComponent<SpriteRenderer>().sprite = IMAGE.OwnsolderGatelvl2;
                        Tower.GetComponent<SpriteRenderer>().sprite = IMAGE.OwnsolderTowerFirstLVL2;
                    }
                    else
                    {
                        Tower.GetComponent<SpriteRenderer>().sprite = IMAGE.OwnsolderTowerSecuendLVL2;
                    }
                }
                else
                 if (Index == 2)
                {
                    // OwnSoldiersTower gladiatorokká változás
                    int pluszDamage = 30, pluszHP = 35;


                    int index = 2;
                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszDamage += pluszDamage;
                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszmaxHp += pluszHP;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegex += pluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegey += pluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().maxHP += pluszHP;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].gameObject.GetComponent<OwnSolidersAnimation>().WalkIndex = 0;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].gameObject.GetComponent<OwnSolidersAnimation>().AttackIndex = 0;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].gameObject.GetComponent<SoldiersMove>().IndexSkin = index;
                        /*for (int g = 0; g < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().SoldiersSkin.Count; g++)
                        {
                            Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().SoldiersSkin[g].SetActive(false);
                        }
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().SoldiersSkin[index].SetActive(true);*/
                    }
                    Tower.GetComponent<TowerOwnSolderBuilding>().indexskin = index;
                    Tower.transform.position = new Vector3(Tower.transform.position.x, Tower.transform.position.y - 0.05f, Tower.transform.position.z);
                    Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position = new Vector3(Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position.x - 0.1f, Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position.y, Tower.GetComponent<TowerOwnSolderBuilding>().UpgradeArrowTowerScriptCIrcle.transform.position.z);
                    if (Tower.GetComponent<TowerOwnSolderBuilding>().Gate.active)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().Gate.GetComponent<SpriteRenderer>().sprite = IMAGE.OwnsolderGatelvl3;
                        Tower.GetComponent<SpriteRenderer>().sprite = IMAGE.OwnsolderTowerFirstLVL3;
                    }
                    else
                    {
                        Tower.GetComponent<SpriteRenderer>().sprite = IMAGE.OwnsolderTowerSecuendLVL3;
                    }
                }
            }
            else
            if (Level == 2)
            {
                // OwnSoldiersTower erõsebb Romai soldiers skiljei
                if (Index == 1)
                {
                    // OwnSoldiersTower Romai soldiers elsõ skilje AtackHiler
                    Tower.GetComponent<TowerOwnSolderBuilding>().Skill[0]++;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Skill[0]++;
                    }
                }
                else
                if (Index == 2)
                {
                    // OwnSoldiersTower Romai soldiers második skilje defense

                    int Pluszpercentage = 5;

                    Tower.GetComponent<TowerOwnSolderBuilding>().Skill[1] += Pluszpercentage;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Skill[1] += Pluszpercentage;
                    }
                }
                else
                if (Index == 3)
                {
                    // OwnSoldiersTower Romai soldiers harmadik skilje Force
                    int pluszHp = 20, PluszDamage = 10;

                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszDamage += PluszDamage;
                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszmaxHp += pluszHp;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegex += PluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegey += PluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().maxHP += pluszHp;
                    }
                }
            }
            else
            if (Level == 3)
            {
                // OwnSoldiersTower Gladiators soldiers skiljei
                if (Index == 1)
                {
                    // OwnSoldiersTower Gladiators elsõ skilje buzoganyDobás
                    int PluszDamage = 15;



                    Tower.GetComponent<TowerOwnSolderBuilding>().Skill[2] += PluszDamage;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Skill[2] += PluszDamage;
                    }
                }
                else
                if (Index == 2)
                {
                    // OwnSoldiersTower Gladiators második skilje ChillHiler
                    int ChilHiler = 15;

                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszChilHiler += ChilHiler;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Selfhealing += ChilHiler;
                    }
                }
                else
                if (Index == 3)
                {
                    // OwnSoldiersTower Gladiators harmadik skilje Force
                    int pluszHp = 10, PluszDamage = 15;

                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszDamage += PluszDamage;
                    Tower.GetComponent<TowerOwnSolderBuilding>().pluszmaxHp += pluszHp;
                    for (int i = 0; i < Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                    {
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegex += PluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().Damegey += PluszDamage;
                        Tower.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().maxHP += pluszHp;
                    }
                }
            }
        }
    }

    public static void INBubbleskillObjectsDarking()
    {
        int buy = MENUGamobjects.BuyUpdateValasztas(1, "buy");
        if (buy == 0 || buy == 2)
        {
            LightningSkillBubbleObjects.GetComponent<Image>().color = Darkening;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(3, "buy");
        if (buy == 0 || buy == 2)
        {
            EgyptianGodSkillBubbleObjects.GetComponent<Image>().color = Darkening;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(2, "buy");
        int buy2 = MENUGamobjects.BuyUpdateValasztas(4, "buy");
        if ((buy2 == 0 || buy2 == 2) && (buy == 0 || buy == 2))
        {
            BigquicksandSkillBubbleObjectsn.GetComponent<Image>().color = Darkening;
        }
    }
    public static bool IsItInMapRoads(Vector3 watch)
    {
        for (int i = 0; i < MapRodas.transform.childCount; i++)
        {
            if (watch.x >= (MapRodas.transform.GetChild(i).transform.position.x - MapRodas.transform.GetChild(i).transform.localScale.x / 2) && watch.x <= (MapRodas.transform.GetChild(i).transform.localScale.x / 2 + MapRodas.transform.GetChild(i).transform.position.x) && watch.y >= (MapRodas.transform.GetChild(i).transform.position.y - MapRodas.transform.GetChild(i).transform.localScale.y / 2) && watch.y <= (MapRodas.transform.GetChild(i).transform.localScale.y / 2 + MapRodas.transform.GetChild(i).transform.position.y))
            {
                return true;

            }
        }
        GameObject X = Instantiate(AllGameObject.X, watch, Quaternion.identity);
        X.transform.parent = GameObject.Find("Tower").transform;
        if (MENUGamobjects.TutorialMap == 0)
        {
            SetactiveFalse(150000);
        }
        return false;
    }
    private void Update()
    {
        if (PauseButtonImagePause.Bool)
            return;

        if(OneSecend>=1)
        {
            OneSecend = 0;
            Spriterenderer.Clear();
            Spriterenderer.AddRange(AllEnemys);
            Spriterenderer.AddRange(AllSoldier);
            if(HERO!=null)
            Spriterenderer.Add(HERO.transform);
            for(int i=0;i< Spriterenderer.Count;i++)
            {
                for(int j=i+1;j< Spriterenderer.Count;j++)
                {
                    if(Spriterenderer[i]!=null&& Spriterenderer[j]!=null)
                    if(Spriterenderer[i].position.y< Spriterenderer[j].position.y)
                    {
                        Transform seged = Spriterenderer[i];
                        Spriterenderer[i] = Spriterenderer[j];
                        Spriterenderer[j] = seged;
                    }
                }
                if (Spriterenderer[i] != null)
                    Spriterenderer[i].GetComponent<SpriteRenderer>().sortingOrder = i+3;
            }


        }
        OneSecend += Time.deltaTime;

        if (!Abality12LOadingCircle.active && Abality1LOadintActive)
        {
            Abality1Timer += Time.deltaTime;
        }
        if (!Abality22LOadingCircle.active && Abality2LOadintActive)
        {
            Abality2Timer += Time.deltaTime;
        }
        if (!attackfromheavenButton.active && AttackfromHavenTimer != 0.1f)
        {
            AttackfromHavenTimer -= Time.deltaTime;
        }
        if (!OwnUnitSoldiersButton1.active && OwnSOlderTimer != -5f)
        {
            OwnSOlderTimer -= Time.deltaTime;
        }
        if (designateCaracter != null)
        {
            if (designateCaracter.GetComponentInParent<EnemyMove>())
            {
                HealtyText.GetComponent<Text>().text = MENUGamobjects.Kerekito(designateCaracter.GetComponent<EnemyMove>().maxHP) + "/" + MENUGamobjects.Kerekito(designateCaracter.GetComponent<EnemyMove>().currentHP);
            }
            else
              if (designateCaracter.GetComponentInParent<SoldiersMove>())
            {
                HealtyText.GetComponent<Text>().text = MENUGamobjects.Kerekito(designateCaracter.GetComponent<SoldiersMove>().maxHP) + "/" + MENUGamobjects.Kerekito(designateCaracter.GetComponent<SoldiersMove>().currentHP);
            }
            else
              if (designateCaracter.GetComponentInParent<CLassicHEroScript>())
            {
                HealtyText.GetComponent<Text>().text = MENUGamobjects.Kerekito(designateCaracter.GetComponent<CLassicHEroScript>().maxHP) + "/" + MENUGamobjects.Kerekito(designateCaracter.GetComponent<CLassicHEroScript>().currentHP);
            }
            else
              if (designateCaracter.GetComponentInParent<TowerOwnSolderBuilding>())
            {
                float maxhp = 0, currenthp = 0;
                for (int i = 0; i < designateCaracter.GetComponent<TowerOwnSolderBuilding>().AllSoldier.Count; i++)
                {
                    maxhp += designateCaracter.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().maxHP;
                    currenthp += designateCaracter.GetComponent<TowerOwnSolderBuilding>().AllSoldier[i].GetComponent<SoldiersMove>().currentHP;
                }
                HealtyText.GetComponent<Text>().text = MENUGamobjects.Kerekito(maxhp) + "/" + MENUGamobjects.Kerekito(currenthp);
            }
        }
        else
        {
            if (KarakterSkillGameObject != null)
            {
                KarakterSkillGameObject.SetActive(false);
            }
        }
    }
    public static void KonnyebbenLehessenLerakniATornyokat()
    {
        AllGameObject.BubbleAllSkillObjects.SetActive(true);
        AllGameObject.attackfromheavenButton.SetActive(true);
        // AllGameObject.attackfromheavenButton2.SetActive(true);
        AllGameObject.OwnUnitSoldiersButton1.SetActive(true);
        //AllGameObject.OwnUnitSoldiersButton2.SetActive(true);
    }
    public static void SetactiveFalse(int x)
    {
        if (x != -5 && MENUGamobjects.TutorialMap == 0 && x != 14)
        {
            KarakterSkillGameObject.SetActive(false);
            if (designateCaracter != null)
            {
                //changeColorCHooseDataSkill(Color.white);
                designateCaracter.GetComponent<SpriteRenderer>().color = Color.white;
                designateCaracter = null;
            }
        }
        if (x != 1)
        {
            //Destroy(SegedDestroyButton);
            if (AllGameObject.SegedUpgradeButton != null)
                AllGameObject.SegedUpgradeButton.SetActive(false);
            Destroy(SegedTowerRangeEllipszis);
            SegedUpgradeTower = null;
        }

        if (x != 2 && attackfromheavenClickBool && x != -5)
        {
            attackfromheavenClickBool = false;
            attackfromheavenButton.GetComponent<Image>().color = new Color(1, 1, 1);

        }

        if (x != 3)
        {
            for (int i = 0; i < Xess.Count; i++)
            {
                if (Xess[i] != null)
                {
                    if (Xess[i].active)
                    {
                        KonnyebbenLehessenLerakniATornyokat();
                    }
                    Xess[i].SetActive(false);
                }
            }
        }

        if (x != 4)
        {
            Spaces.SetActive(false);

        }

        if (x != 5 && OwnUNitSoldiersClickBool && x != -5)
        {
            OwnUNitSoldiersClickBool = !OwnUNitSoldiersClickBool;

            OwnUnitSoldiersButton1.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        int buy = MENUGamobjects.BuyUpdateValasztas(1, "buy");
        if (x != 6 && x != -5 && (buy == 1 || buy == 3))
        {
            Lightning = false;
            LightningButton.GetComponent<Image>().color = WhiteColor;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(2, "buy");
        if (x != 7 && x != -5 && (buy == 1 || buy == 3))
        {
            quicksand = false;
            quicksandButton.GetComponent<Image>().color = WhiteColor;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(4, "buy");
        if (x != 8 && x != -5 && (buy == 1 || buy == 3))
        {
            Bigquicksand = false;
            BigquicksandButton.GetComponent<Image>().color = WhiteColor;
        }
        buy = MENUGamobjects.BuyUpdateValasztas(3, "buy");
        if (x != 9 && x != -5 && (buy == 1 || buy == 3))
        {
            EgyptianGod = false;
            EgyptianGodButton.GetComponent<Image>().color = WhiteColor;
        }
        if (x != 10 && x != -5 && x != 12 && x != 13)
        {
            heroactive = false;
            HeroButton.GetComponent<Image>().color = Color.white;
            Abalitys.SetActive(false);
        }
        if (x == -5 && !EgyptianGod && !Bigquicksand && !quicksand && !Lightning)
        {
            BubbleUseButon.GetComponent<SkillButtonUSe>().click(false);
        }
        if (x != 11 && x != 9 && x != 8 && x != 7 && x != 6 && x != -5)
        {
            BubbleUseButon.GetComponent<SkillButtonUSe>().click(false);
        }

        if (x != 12)
        {
            Abality1Active = false;
            if (HERO != null)
            {
                Abality1.GetComponent<Image>().sprite = HERO.GetComponent<BAbalityInformation>().Abality1Image;
            }
        }
        if (x != 13)
        {
            Abality2Active = false;
            if (HERO != null)
            {
                Abality2.GetComponent<Image>().sprite = HERO.GetComponent<BAbalityInformation>().Abality2Image;
            }
        }
        if (x != 13 && x != 12)
        {
            Abalitys.SetActive(false);
        }

    }

    public void lihning(int index)
    {
        if (MENUGamobjects.TutorialMap != 0)
            return;
        SetactiveFalse(6);
        int buy = MENUGamobjects.BuyUpdateValasztas(index, "buy");
        if (buy == 1 || buy == 3)
        {
            LightningButton.GetComponent<Image>().color = clickSkillButton;
            Lightning = !Lightning;
        }
    }
    public void Quicksand(int index)
    {
        if (MENUGamobjects.TutorialMap != 0)
            return;
        SetactiveFalse(7);
        int buy = MENUGamobjects.BuyUpdateValasztas(index, "buy");
        if (buy == 1 || buy == 3)
        {
            quicksandButton.GetComponent<Image>().color = clickSkillButton;
            quicksand = !quicksand;
        }
    }
    public void bigquicksand(int index)
    {
        if (MENUGamobjects.TutorialMap != 0)
            return;
        SetactiveFalse(8);
        int buy = MENUGamobjects.BuyUpdateValasztas(index, "buy");
        if (buy == 1 || buy == 3)
        {
            BigquicksandButton.GetComponent<Image>().color = clickSkillButton;
            Bigquicksand = !Bigquicksand;
        }
    }
    public void egyptianGod(int index)
    {
        if (MENUGamobjects.TutorialMap != 0)
            return;
        SetactiveFalse(9);
        int buy = MENUGamobjects.BuyUpdateValasztas(index, "buy");
        if (buy == 1 || buy == 3)
        {
            EgyptianGodButton.GetComponent<Image>().color = clickSkillButton;
            EgyptianGod = !EgyptianGod;
        }
    }


    public void HeroButtonClik()
    {
        if (CameraMOverClick.mozoge)
            return;
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 14 && MENUGamobjects.TutorialMap != 16)
        {
            return;
        }
        else
         if (MENUGamobjects.TutorialMap != 0)
        {

            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        if (!heroLOadintActive)
        {
            SetactiveFalse(10);
            if (!heroactive)
            {
                if (HERO != null)
                {
                    //Abality1TextSkill.GetComponent<Text>().text = HERO.GetComponent<BAbalityInformation>().Abality1TextSkill;
                    //Abality2TextSkill.GetComponent<Text>().text = HERO.GetComponent<BAbalityInformation>().Abality2TextSkill;
                    /*Abality1TextSkill.SetActive(false);
                    Abality2TextSkill.SetActive(false);*/
                    Abalitys.SetActive(true);
                }
                HeroButton.GetComponent<Image>().color = clickSkillButton;
            }
            else
            {
                HeroButton.GetComponent<Image>().color = Color.white;
            }
            heroactive = !heroactive;
        }
    }

    public void Abality1Click()
    {
        if (MENUGamobjects.TutorialMap != 0)
            return;
        if (CameraMOverClick.mozoge)
            return;
        if (!Abality1LOadintActive)
        {
            SetactiveFalse(12);
            if (!Abality1Active)
            {
                Abality1.GetComponent<Image>().sprite = Pipa;
                Abality1Active = true;
                /*Abality1TextSkill.SetActive(true);
                Abality2TextSkill.SetActive(false);*/
            }
            else
            {
                Abality1.GetComponent<Image>().sprite = HERO.GetComponent<BAbalityInformation>().Abality1Image;
                if (HERO.GetComponentInParent<CLassicHEroScript>())
                {
                    HERO.GetComponent<CLassicHEroScript>().Abality1Button();
                }
                //Abality1TextSkill.SetActive(false);
                Abality12LOadingCircle.SetActive(true);
                Abality1LOadintActive = true;
                Abality1Active = false;
            }
        }
    }

    public void Abality2Click()
    {
        if (MENUGamobjects.TutorialMap != 0)
            return;
        if (CameraMOverClick.mozoge)
            return;
        if (HeroLevel.presentIndex >= 5)
        {
            if (!Abality2LOadintActive)
            {
                SetactiveFalse(13);
                if (!Abality2Active)
                {
                    /*Abality2TextSkill.SetActive(true);
                    Abality1TextSkill.SetActive(false);*/
                    Abality2.GetComponent<Image>().sprite = Pipa;
                    Abality2Active = true;
                }
                else
                {
                    Abality2.GetComponent<Image>().sprite = HERO.GetComponent<BAbalityInformation>().Abality2Image;
                    if (HERO.GetComponentInParent<CLassicHEroScript>())
                    {
                        HERO.GetComponent<CLassicHEroScript>().Abality2Button();
                    }
                    /*Abality2TextSkill.SetActive(false);*/
                    Abality22LOadingCircle.SetActive(true);
                    Abality2LOadintActive = true;
                    Abality2Active = false;
                }
            }
        }
    }

    public static void KarakterSkillAd(float MaxHP, float CurrentHP, float Speed, float Reloading, float Damagex, float Damagey, Sprite CaracterImage, GameObject caracter,Vector2 Size)
    {
        //SetactiveFalse(-5);
        //MapOnMouseClick.masrakatintottam = 1;
        if (designateCaracter != null)
        {
            designateCaracter.GetComponent<SpriteRenderer>().color = Color.white;
            //changeColorCHooseDataSkill(Color.white);
            designateCaracter = null;
        }
        if (!OwnUNitSoldiersClickBool && !attackfromheavenClickBool)
        {
            designateCaracter = caracter;
            if (designateCaracter != HERO)
            {
                heroactive = false;
            }
            caracter.GetComponent<SpriteRenderer>().color = ChooseCaracter;
            //changeColorCHooseDataSkill(ChooseCaracter);
            KarakterSkillGameObject.SetActive(true);
            SkinCaracterImage.GetComponent<SpriteRenderer>().size = Size;
            SkinCaracterImage.GetComponent<SpriteRenderer>().sprite = CaracterImage;
            if (MaxHP == -1)
            {
                HealtyText.GetComponent<Text>().text = "-" + "/" + "-";
            }
            else
            {
                HealtyText.GetComponent<Text>().text = MENUGamobjects.Kerekito(MaxHP) + "/" + MENUGamobjects.Kerekito(CurrentHP);
            }
            if (Speed == -1)
            {
                SpeedText.GetComponent<Text>().text = "-";
            }
            else
            {
                SpeedText.GetComponent<Text>().text = Speed.ToString();
            }
            if (Reloading == -1)
            {
                ReolodinfText.GetComponent<Text>().text = "-";
            }
            else
            {
                ReolodinfText.GetComponent<Text>().text = Reloading.ToString();
            }
            if (Damagex == -1 && Damagey == -1)
            {
                DamageText.GetComponent<Text>().text = "- " + "-" + " -";
            }
            else
            {
                DamageText.GetComponent<Text>().text = Damagex + "-" + Damagey;
            }
        }
    }


    public void DestroyAudio2(float timer, AudioSource Sound, GameObject Targy)
    {
        StartCoroutine(DestroyAudio(timer, Sound, Targy));
    }
    public IEnumerator DestroyAudio(float timer, AudioSource Sound, GameObject Targy)
    {
        float PresentTime = 0;
        while (PresentTime < timer)
        {
            if (PauseButtonImagePause.Bool)
                break;
            yield return PresentTime += Time.deltaTime;
        }

        if (Targy != null)
        {
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
        yield return null;

    }
}
