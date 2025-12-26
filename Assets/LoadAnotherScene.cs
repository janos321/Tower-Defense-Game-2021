using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class LoadAnotherScene : MonoBehaviour
{
    public string Külsõkelhelyezése = "------------------------";
    //public GameObject PrincesLefDown2;
    //public static GameObject PrincesLefDown;
    public GameObject RightDownSettings2;
    public static GameObject RightDownSettings;
    public GameObject RightUpDiamondCounterAndStarCounter2;
    public static GameObject RightUpDiamondCounterAndStarCounter;
    public List<GameObject> LevelStarPanel2 = new List<GameObject>();
    public static List<GameObject> LevelStarPanel = new List<GameObject>();
    public GameObject EncikplopediaButton2;
    public static GameObject EncikplopediaButton;
    public GameObject CenterEnciklopedia2;
    public static GameObject CenterEnciklopedia;
    public static GameObject EnciklopediaHelp;
    public static GameObject EnciklopediaHelp3;
    public GameObject EnciklopediaHelp2;
    public GameObject EnciklopediaHelp4;
    public string Vege = "------------------------";
    public GameObject EncikplopediaPanel2;
    public static GameObject EncikplopediaPanel;
    public GameObject EnciklopediaMEnu;
    public GameObject TowerCollectionGAmeobject;
    public GameObject EnemyCollectionGameobject;
    public List<GameObject> levelStart = new List<GameObject>();
    public GameObject Star;
    public GameObject YellowDiamondText;
    //public static List<int> level = new List<int>();
    //public static bool PrincessEnemy=true;
    public GameObject MiniGamesOrVideoSurFace;
    public GameObject KleoptarasThrone;
    public static GameObject KleoptarasThrone2;
    public GameObject ClassicThrone;
    public static GameObject ClassicThrone2;
    //public GameObject KleopatraButton;
    //public static GameObject KleopatraButton2;
    public static string map;
    private int buy;
    public static int footloose = 0;
    public List<GameObject> EnciklopediaPages = new List<GameObject>();
    public GameObject StartTutorialPanel;
    public static GameObject StartTutorialPanel2,SinglePlayerMenu=null;
    public static int ForceSojdan = 0;
    public Color EasymhPicColor2;
    public Color NoChooseEasyButton2;
    public Color White2;
    public static Color EasymhPicColor;
    public static Color NoChooseEasyButton;
    public static Color White;
    public  GameObject StarButteons2;
    public static GameObject StarButteons;
    public GameObject LOadingSceneGameobject;
    public static GameObject LOadingSceneGameobject2;
    public GameObject Helping;
    public GameObject Helping2;
    public Read LANG;
    private float WifiEllenorzesido, WifiEllenorzesMaxIdo = 2;

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
            if (WifiEllenorzesido >= WifiEllenorzesMaxIdo)
            {
                WifiEllenorzesido = 0;
                int r = Random.Range(0, database.PingTarget.Count);
                StartCoroutine(database.CheckInternetConnection1(isConnected =>
                {
                    if (!isConnected)
                    {
                        if (LogInRegisztrelScript.username != "")
                        {
                            database.UpdateDatabase(LogInRegisztrelScript.username, LogInRegisztrelScript.pasword);
                        }
                    }
                    FajlDatabase.WriteIntoTxtFile();
                }, r));

            }
            else
            {
                WifiEllenorzesido += Time.deltaTime;
            }
        
    }
    private void Start()
    {
        EnciklopediaHelp3 = EnciklopediaHelp4;
        EnciklopediaHelp = EnciklopediaHelp2;
        PauseButtonImagePause.Bool = false;
        MiniPousIMageGAme.Bool = false;
        MiniMapOnMosueClickGame.Target = new Vector3(-0.000000000000051515f, 0.254511f, 0);
        MiniGameAllScript.AttackfromHavenTimer = 0;
        MiniGameAllScript.AllEnemys.Clear();
        MENUGamobjects.kameramozgatas = 0;
        AllGameObject.Abality1Timer = 0;
        AllGameObject.Abality1LOadintActive = false;
        AllGameObject.Abality2LOadintActive = false;
        AllGameObject.Abality2Timer = 0;
        AllGameObject.AttackfromHavenTimer = 0;
        AllGameObject.OwnSOlderTimer = 0;
        AllGameObject.heroLOadintActive = false;
        AllGameObject.Xess.Clear();
        AllGameObject.Towers.Clear();
        //AllGameObject.AllEnemys.Clear();
        AllGameObject.AllSoldier.Clear();
        AllGameObject.Starts.Clear();
        AllGameObject.Spaceses.Clear();
        for (int c = 0; c < AllGameObject.SpacesTransform.Length; c++)
        {
            AllGameObject.SpacesTransform[c] = null;
        }
        LOadingSceneGameobject2 = LOadingSceneGameobject;
        SinglePlayerMenu = gameObject;
        White = White2;
        NoChooseEasyButton = NoChooseEasyButton2;
        StarButteons = StarButteons2;
        EasymhPicColor = EasymhPicColor2;
        ForceSojdan = 1;
        StartTutorialPanel2 = StartTutorialPanel;
        ClassicThrone2 = ClassicThrone;
        MENUGamobjects.kameramozgatas = 0;
        if (database.Q==0)
        {
            ClassicThrone.SetActive(true);
            KleoptarasThrone.SetActive(false);
            //KleopatraButton.transform.GetComponent<Image>().sprite = ClassicThrone;
        }
        else
        {
            KleoptarasThrone.SetActive(true);
            ClassicThrone.SetActive(false);
            //KleopatraButton.transform.GetComponent<Image>().sprite = KleoptarasThrone;
        }
        CenterEnciklopedia = CenterEnciklopedia2;
        EncikplopediaButton = EncikplopediaButton2;
        EncikplopediaPanel = EncikplopediaPanel2;
        LanguagesChange(database.LNG, LANG);
       // PrincesLefDown = PrincesLefDown2;
        RightDownSettings = RightDownSettings2;
        RightUpDiamondCounterAndStarCounter = RightUpDiamondCounterAndStarCounter2;
        MENUGamobjects.TutorialMap = 0;
        //KleopatraButton2 = KleopatraButton;
        KleoptarasThrone2 = KleoptarasThrone;
        footloose = 0;
        LevelStarPanel.Clear();
        for (int o = 0; o < LevelStarPanel2.Count; o++)
        {
            LevelStarPanel.Add(LevelStarPanel2[o]);
        }
        for (int j = 1, k = 0; k < MENUGamobjects.BuyObjectsMOney.Count; j++, k++)
        {
            buy = MENUGamobjects.BuyUpdateValasztas(j, "buy");
            if (buy == 2 && MENUGamobjects.BuyObjectsMOney[k] <= database.GDC)
            {
                database.GDC -= MENUGamobjects.BuyObjectsMOney[k];
                MENUGamobjects.visszairas(j, 3, "buy");
            }
        }
        FajlDatabase.WriteIntoTxtFile();
        YellowDiamondText.GetComponent<Text>().text = database.GDC.ToString();
        int i = 0;
       /* if (database.MAP[0] == 9)
            return;*/
        for (i = 0; i < 10; i++)
        {
            if (database.MAP[i] == 0)
            {
                break;
            }
            csillagosztasesPalyamegjelenites(database.MAP[i]/3, levelStart[i]);
            levelStart[i].SetActive(true);
        }
        if (levelStart.Count > i)
            levelStart[i].SetActive(true);
        FajlDatabase.WriteIntoTxtFile();
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
    public void Level1()
    {
        if (CameraMOverClick.mozoge)
            return;
        map = "OneMap";
        if (Megnez())
        {
            footloose = 0;
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene("OneMap", LOadingSceneGameobject));
            //SceneManager.LoadScene("OneMap");
        }
    }
    public void TutorialPanelSetactive()
    {
        if (CameraMOverClick.mozoge)
            return;
        if(StartTutorialPanel.active)
        {
            footloose = 0;
            StartTutorialPanel.SetActive(false);
        }
        else
        {
            if (footloose == 0)
            {
                footloose = 1;
                StartTutorialPanel.SetActive(true);
            }
        }
       // MENUGamobjects.TutorialMap = 1;
        //StartCoroutine(MENUGamobjects.LoadYourAsyncScene("Tutorial"));
        //SceneManager.LoadScene("Tutorial");
    }
    public void Tutorial()
    {
        if (CameraMOverClick.mozoge)
            return;
        footloose = 0;
        MENUGamobjects.TutorialMap = 1;
        ForceSojdan = 1;
        StartCoroutine(MENUGamobjects.LoadYourAsyncScene("Tutorial", LOadingSceneGameobject));
        //SceneManager.LoadScene("Tutorial");
    }
    public void Level2()
    {
        if (CameraMOverClick.mozoge)
            return;
        map = "TwoMap";
        if (Megnez())
        {
            footloose = 0;
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene("TwoMap", LOadingSceneGameobject));
        }
    }
    public void Level3()
    {
        if (CameraMOverClick.mozoge)
            return;
        map = "ThreeMap";
        if (Megnez())
        {
            footloose = 0;
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene("ThreeMap", LOadingSceneGameobject));
        }
    }
    public void ActivedMiniGameOrVideo()
    {
        if (CameraMOverClick.mozoge||footloose!=0)
            return;
        if (database.Q == 0)
        {
            footloose = 1;
            map = "";
            MiniGamesOrVideoSurFace.SetActive(true);
        }
    }
    public bool Megnez()
    {
        if (database.Q == 1)
        {
            KleoptarasThrone.SetActive(true);
            ClassicThrone.SetActive(false);
            //KleopatraButton.transform.GetComponent<Image>().sprite = KleoptarasThrone;
            database.Q = 0;
            return true;
        }
        else
        {
            footloose = 1;
            MiniGamesOrVideoSurFace.SetActive(true);
            return false;
        }
    }
    public void csillagosztasesPalyamegjelenites(float level, GameObject levelStart)
    {
            if (level >=3)
        {
            Instantiate(Star, new Vector3(levelStart.transform.position.x, levelStart.transform.position.y + levelStart.GetComponent<RectTransform>().rect.height / 2, 1), levelStart.transform.rotation);
            Instantiate(Star, new Vector3(levelStart.transform.position.x - 0.8f, levelStart.transform.position.y + levelStart.GetComponent<RectTransform>().rect.height / 3, 1), levelStart.transform.rotation);
            Instantiate(Star, new Vector3(levelStart.transform.position.x + 0.8f, levelStart.transform.position.y + levelStart.GetComponent<RectTransform>().rect.height / 3, 1), levelStart.transform.rotation);

        }        else
        if (level >= 2)
        {
            Instantiate(Star, new Vector3(levelStart.transform.position.x - 0.6f, levelStart.transform.position.y + levelStart.GetComponent<RectTransform>().rect.height / 2, 1), levelStart.transform.rotation);
            Instantiate(Star, new Vector3(levelStart.transform.position.x + 0.6f, levelStart.transform.position.y + levelStart.GetComponent<RectTransform>().rect.height / 2, 1), levelStart.transform.rotation);

        }
            else
        if (level >= 1)
        {
            Instantiate(Star, new Vector3(levelStart.transform.position.x, levelStart.transform.position.y + levelStart.GetComponent<RectTransform>().rect.height / 2 + 0.15f, 1), levelStart.transform.rotation);

        }

    }
    public static void csillagosztasesSzintAlatti(int level, GameObject Buttons,int szorzo)
    {
        if (level >=3+3* szorzo)
        {
           PicEasyMediumHArd.stars.Add( Instantiate(StarButteons, new Vector3(Buttons.transform.position.x, Buttons.transform.position.y -0.85f, 1), Buttons.transform.rotation));
            PicEasyMediumHArd.stars.Add(Instantiate(StarButteons, new Vector3(Buttons.transform.position.x - 0.7f, Buttons.transform.position.y - 0.6f, 1), Buttons.transform.rotation));
            PicEasyMediumHArd.stars.Add(Instantiate(StarButteons, new Vector3(Buttons.transform.position.x + 0.7f, Buttons.transform.position.y - 0.6f, 1), Buttons.transform.rotation));

        }
        else
    if (level >= 2+3* szorzo)
        {
            PicEasyMediumHArd.stars.Add(Instantiate(StarButteons, new Vector3(Buttons.transform.position.x - 0.35f, Buttons.transform.position.y -0.6f, 1), Buttons.transform.rotation));
            PicEasyMediumHArd.stars.Add(Instantiate(StarButteons, new Vector3(Buttons.transform.position.x + 0.35f, Buttons.transform.position.y -0.6f, 1), Buttons.transform.rotation));

        }
        else
    if (level >= 1+3*szorzo)
        {
            PicEasyMediumHArd.stars.Add(Instantiate(StarButteons, new Vector3(Buttons.transform.position.x, Buttons.transform.position.y -0.8f, 1), Buttons.transform.rotation));

        }
    }


    //Settings-------------------------------------------------------


    public void GOMenuButton()
    {
        if (CameraMOverClick.mozoge||footloose!=0)
            return;
        StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
    }

  public void LevelStarPanelSetactive(int index)
      {
        if (CameraMOverClick.mozoge)
            return;
        ForceSojdan = 0;
        if (index == 0)
        {
            footloose = 0;
            for (int i = 0; i < LevelStarPanel.Count; i++)
            {
                MENUGamobjects.kameramozgatas = 0;
                LevelStarPanel[i].SetActive(false);
                for(int l=0;l<PicEasyMediumHArd.stars.Count;l++)
                {
                    Destroy(PicEasyMediumHArd.stars[l]);
                }
                PicEasyMediumHArd.stars.Clear();
            }
        }
        else
        {
            if (footloose == 0)
            {
                footloose = 1;
                for (int i = 0; i < LevelStarPanel.Count; i++)
                {
                    LevelStarPanel[i].SetActive(false);
                }
                MENUGamobjects.kameramozgatas = 1;
                LevelStarPanel[index - 1].SetActive(true);
                //csillagosztasesSzintAlatti(database.MAP[index], LevelStarPanel[index - 1]);
            }
        }
    }

    public void EnciklopediaTrue()
    {
        if (CameraMOverClick.mozoge)
            return;
            if (footloose == 0)
            {
                footloose = 1;
                MENUGamobjects.kameramozgatas = 1;
                EncikplopediaPanel.SetActive(true);
            }
    }
    public void EnciklopediaFalse()
    {
        if (CameraMOverClick.mozoge)
            return;
            footloose = 0;
            MENUGamobjects.kameramozgatas = 0;
            EncikplopediaPanel.SetActive(false);
        
    }

    public void TowerCollectionSetActive()
    {
        if (CameraMOverClick.mozoge)
            return;
        if (TowerCollectionGAmeobject.active)
        {
            Enciklopediatarolo = null;
            for (int i = 0; i < EnciklopediaPages.Count; i++)
            {
                EnciklopediaPages[i].GetComponent<Animator>().Play("Standart");
            }
            EnciklopediaMEnu.SetActive(true);
            TowerCollectionGAmeobject.SetActive(false);
        }
        else
        {
            EnciklopediaMEnu.SetActive(false);
            TowerCollectionGAmeobject.SetActive(true);
        }
    }
    public void EnemyCoolectionSetActive()
    {
        ChangeSetActive(false);
        ChangeSetActiveTower(false);
        if (CameraMOverClick.mozoge)
            return;
        if (EnemyCollectionGameobject.active)
        {
            Enciklopediatarolo = null;
            for (int i = 0; i < EnciklopediaPages.Count; i++)
            {
                EnciklopediaPages[i].GetComponent<Animator>().Play("Standart");
            }
            EnciklopediaMEnu.SetActive(true);
            EnemyCollectionGameobject.SetActive(false);
        }
        else
        {
            EnciklopediaMEnu.SetActive(false);
            EnemyCollectionGameobject.SetActive(true);
        }
    }
    private GameObject Enciklopediatarolo=null;
    public void EnciklopediaPagesClick(GameObject Pages)
    {
        if (Input.touchCount >= 2)
            return;
        ChangeSetActive(false);
        ChangeSetActiveTower(false);
        for (int i=0;i<QuistionMArkEnciklopediaPagesSetActive.Szabade.Count;i++)
        {
            if(QuistionMArkEnciklopediaPagesSetActive.Szabade[i]==Pages)
            {
                return;
            }
        }
        if(Enciklopediatarolo!=null)
        {
            Enciklopediatarolo.GetComponent<Animator>().Play("Secuend");
        }
        if(Pages==Enciklopediatarolo)
        {
            Enciklopediatarolo = null;
            return;
        }
        Enciklopediatarolo = Pages;
        Enciklopediatarolo.GetComponent<Animator>().Play("First");
    }

    public void ChangeSetActive(bool a)
    {
        Helping.SetActive(a);
    }
    public void ChangeSetActiveTower(bool a)
    {
        Helping2.SetActive(a);
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


}
