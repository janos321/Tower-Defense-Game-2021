using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameAllScript : MonoBehaviour
{
    public static GameObject ShadowArrow;
    public static Transform BPositionAttack;
    public static Transform APositionAttack;
    public static GameObject attackfromheavenArrows;
    public static bool attackfromheavenClickBool;
    public static Camera MainCamera;
    public static float AttackfromHavenTimer = 0;
    public static GameObject attackfromheavenButton;
    public static GameObject attackfromheavenButton2;
    public static GameObject PauseMenuPanel;
    public GameObject PauseMenuPanel2;
    public GameObject attackfromheavenButton1;
    public GameObject attackfromheavenButton22;
    public GameObject ShadowArrow2;
    public Transform BPositionAttack2;
    public Transform APositionAttack2;
    public GameObject attackfromheavenArrows2;
    public Camera MainCamera2;
    public static string NextScene = "SinglePlayerMenu";
    public static List<GameObject> AllEnemys = new List<GameObject>();
    public static GameObject HERO;
    public GameObject HeroSPawn;
    public GameObject ArrowsDOwnParticleEffect2;
    public GameObject PauseButtonImageLocation2;
    public static GameObject PauseButtonImageLocation;
    public static GameObject ArrowsDOwnParticleEffect;
    public GameObject GameOverPanel2;
    public static GameObject GameOverPanel;
    public GameObject HealthBarGamobject2;
    public float MiniGameHeroSpeed = 4;
    public float HeroMAxHP2 = 150;
    public float LoadingSkeletonTime = 2;
    private float PresentLoadingSkeletonTime = 0;
    public static GameObject HealthBarGamobject;
    public static float HeroMAxHP = 150;
    public static float floatMaxHP;
    public GameObject Spawnerek;
    List<Transform> Spawners = new List<Transform>();
    public GameObject Skeleton;
    public static GameObject HealthBarGamobject3;
    public GameObject HealthBarGamobject32;
    //public GameObject GameOverCanvas2;
    //public static GameObject GameOverCanvas;
    //public static bool PauseBool = true;
    //public static bool kameraMove=false;
    public GameObject HealtiBarCanvas2;
    public static GameObject HealtiBarCanvas;
    public GameObject WinnerCheckpoint;
    public static GameObject WinnerCheckpoint2;
    public GameObject PrincesCheckpoint;
    public static GameObject PrincesCheckpoint2;
    //public GameObject BigFingerMoveCircle;
    public GameObject smallFingerMoveCircle;
    public GameObject BigFingerMoveCircle;/*
    public GameObject smallFingerMoveCircle;*/
    public Joystick Joystick;
    public static Joystick Joystick2;
    public static float speed = 6f;
    public Read LANG;
    private float LOck, StartLock = 4.5f;
    public GameObject LockCage;
    public GameObject BackgroundLoadingCircle;
    //public GameObject LoadingCircle;
    public GameObject Kleopatra;
    public GameObject Jozstic2;
    public static GameObject Jozstic,MiniGame=null, MiniGame2 = null;
    private int plusz = 0, LoadingCount = 0,winner=0;
    public List<Sprite> LoadingImage = new List<Sprite>();
    // private int Direction=0;
    public static List<Vector3> Touches = new List<Vector3>();
    public GameObject IMage;
    private int LOckAudio=0;
    public GameObject LOadingSceneGameobject2;
    public static GameObject LOadingSceneGameobject;
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
    public static void SetactiveFalse(int a)
    {

        if (attackfromheavenClickBool && a != -1)
        {
            attackfromheavenClickBool = false;
            attackfromheavenButton.GetComponent<Image>().color = new Color(0.2f, 0.7f, 0.9f);
        }
    }

    private void Update()
    {
        if (HERO == null)
        {
            
            return;
        }
        if(MiniPousIMageGAme.Bool)
        {
            HERO.GetComponent<MiniGameHeroAnimation>().Direction =0;
            return;
        }
        

        //Animáció (Right-3 Left-4)


        //Spawnerek
        {
            if (PresentLoadingSkeletonTime >= LoadingSkeletonTime)
            {
                PresentLoadingSkeletonTime = 0;
                int r = Random.Range(0, Spawnerek.transform.childCount);
                for (int i = r; i < Spawnerek.transform.childCount; i++)
                {
                    StartCoroutine(spawner(i * 0.2f, i));
                }
            }
            PresentLoadingSkeletonTime += Time.deltaTime;
        }

        //Checkpointok
        {
            if (PrincesCheckpoint.active)
            {
                if (MENUGamobjects.Bennevane(PrincesCheckpoint.transform, HERO.transform.position))
                {
                    if (LOck >=StartLock)
                    {
                        LockCage.SetActive(false);
                        BackgroundLoadingCircle.SetActive(false);
                        LOckAudio = 0;
                    }
                    else
                    {
                        BackgroundLoadingCircle.SetActive(true);
                            if(LOckAudio==0)
                        {
                            LOckAudio = 1;
                            SoundsScript.MusicStart(BackgroundLoadingCircle,"minigameszabaditas2");
                        }
                        if (LoadingCount<LoadingImage.Count)
                        {
                            float x = StartLock / LoadingImage.Count;
                            int index = (int)Mathf.Floor( LOck / x);
                            BackgroundLoadingCircle.GetComponent<SpriteRenderer>().sprite = LoadingImage[index];
                        }
                        LOck += Time.deltaTime;
                    }
                }
                else
                {
                    BackgroundLoadingCircle.SetActive(false);
                    LOckAudio = 0;
                }
            }
            else
            if(!WinnerCheckpoint.active)
            {
                LoadingCount = 0;
                if (MENUGamobjects.Bennevane(Kleopatra.transform, HERO.transform.position))
                {
                    plusz = 2;
                    Kleopatra.SetActive(false);
                    WinnerCheckpoint.SetActive(true);
                }
            }
            else
            {
                if (MENUGamobjects.Bennevane(WinnerCheckpoint.transform, HERO.transform.position))
                {
                    if (winner == 0)
                    {
                        Winner();
                    }
                }
            }
        }
        //iranyitas
        {
            speed = 6f;
            float HeroMaxX = HERO.transform.position.x + 1f, HeroMinX = HERO.transform.position.x - 1f, HeroMaxY = HERO.transform.position.y + 1f, HeroMinY = HERO.transform.position.y - 1f;
            if(Input.GetKey("w")|| Input.GetKey("s")|| Input.GetKey("a") || Input.GetKey("d"))
            {
                BigFingerMoveCircle.SetActive(false);
                smallFingerMoveCircle.transform.position = BigFingerMoveCircle.transform.position;
            }
            else
            {
                BigFingerMoveCircle.SetActive(true);
            }
            if (Input.GetKey("w") && MiniGameCameraMove.mapMaxY > HeroMaxY && Input.GetKey("d") && MiniGameCameraMove.mapMaxX > HeroMaxX)
            {
               HERO.GetComponent<MiniGameHeroAnimation>().Direction = 1+plusz;
                Vector3 direction = new Vector3(10f, 10f, 0);
                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            if (Input.GetKey("d") && MiniGameCameraMove.mapMaxX > HeroMaxX && Input.GetKey("s") && MiniGameCameraMove.mapMinY < HeroMinY)
            {
                HERO.GetComponent<MiniGameHeroAnimation>().Direction = 1 + plusz;
                Vector3 direction = new Vector3(10f, -10f, 0);
                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
        if (Input.GetKey("a") && MiniGameCameraMove.mapMinX < HeroMinX && Input.GetKey("w") && MiniGameCameraMove.mapMaxY > HeroMaxY)
            {
                HERO.GetComponent<MiniGameHeroAnimation>().Direction = 2 + plusz;
                Vector3 direction = new Vector3(-10f, 10f, 0);

                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
        if (Input.GetKey("s") && MiniGameCameraMove.mapMinY < HeroMinY && Input.GetKey("a") && MiniGameCameraMove.mapMinX < HeroMinX)
            {
                HERO.GetComponent<MiniGameHeroAnimation>().Direction = 2 + plusz;
                Vector3 direction = new Vector3(-10f, -10f, 0);


                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            if (Input.GetKey("w") && MiniGameCameraMove.mapMaxY > HeroMaxY)
            {
                Vector3 direction = new Vector3(0f, 10f,0);
                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            if (Input.GetKey("d") && MiniGameCameraMove.mapMaxX > HeroMaxX)
            {
                HERO.GetComponent<MiniGameHeroAnimation>().Direction = 1 + plusz;
                Vector3 direction = new Vector3(10f, 0f,0);
                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
        if (Input.GetKey("a") && MiniGameCameraMove.mapMinX < HeroMinX)
            {
                HERO.GetComponent<MiniGameHeroAnimation>().Direction = 2 + plusz;
                Vector3 direction = new Vector3(-10f, 0f,0);

                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
        if (Input.GetKey("s") && MiniGameCameraMove.mapMinY < HeroMinY)
            {

                Vector3 direction = new Vector3(0f, -10f,0);


                HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            }
            else
            {
                Vector3 direction = smallFingerMoveCircle.transform.position - BigFingerMoveCircle.transform.position;
                direction.z = 0;
                bool a = false;
                if (direction.x >= 0)
                {
                    if (direction.y >= 0)
                    {
                        if (MiniGameCameraMove.mapMaxY > HeroMaxY && MiniGameCameraMove.mapMaxX > HeroMaxX)
                        {
                            a = true;
                        }
                    }
                    else
                        if (MiniGameCameraMove.mapMaxX > HeroMaxX && MiniGameCameraMove.mapMinY < HeroMinY)
                    {
                        a = true;
                    }
                }
                else
                {
                    if (direction.y >= 0)
                    {
                        if (MiniGameCameraMove.mapMaxY > HeroMaxY && MiniGameCameraMove.mapMinX < HeroMinX)
                        {
                            a = true;
                        }
                    }
                    else
                    if (MiniGameCameraMove.mapMinX < HeroMinX && MiniGameCameraMove.mapMinY < HeroMinY)
                    {
                        a = true;
                    }
                }
                if (a)
                {
                    speed = Vector2.Distance(smallFingerMoveCircle.transform.position, BigFingerMoveCircle.transform.position) * 2f;
                    if(direction.x>0.001)
                    {
                        HERO.GetComponent<MiniGameHeroAnimation>().Direction = 1 + plusz;
                    }
                    else
                        if (direction.x < -0.001)
                    {
                        HERO.GetComponent<MiniGameHeroAnimation>().Direction = 2 + plusz;
                    }
                    else
                    {
                        HERO.GetComponent<MiniGameHeroAnimation>().Direction = 0;
                    }
                    HERO.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
                }
                else
                {
                    Vector3 direction2 = new Vector3(0, 0, 0);
                    int count = 10;
                    speed = Vector2.Distance(smallFingerMoveCircle.transform.position, BigFingerMoveCircle.transform.position) * 2f;
                    if (MiniGameCameraMove.mapMinX + 0.2f >= HeroMinX)
                    {
                        if (MiniGameCameraMove.mapMinY < HeroMinY && direction.y < 0)
                        {
                            direction2 = new Vector3(0, -count, 0);
                            a = true;
                        }
                        else
                        if (MiniGameCameraMove.mapMaxY > HeroMaxY && direction.y > 0)
                        {
                            direction2 = new Vector3(0, count, 0);
                            a = true;
                        }
                    }
                    if (MiniGameCameraMove.mapMinY + 0.2f >= HeroMinY)
                    {
                        if (MiniGameCameraMove.mapMinX < HeroMinX && direction.x < 0)
                        {
                            direction2 = new Vector3(-count, 0, 0);
                            a = true;
                        }
                        else
                        if (MiniGameCameraMove.mapMaxX > HeroMaxX && direction.x > 0)
                        {
                            direction2 = new Vector3(count, 0, 0);
                            a = true;
                        }
                    }
                    if (MiniGameCameraMove.mapMaxX - 0.2f <= HeroMaxX)
                    {
                        if (MiniGameCameraMove.mapMinY < HeroMinY && direction.y < 0)
                        {
                            direction2 = new Vector3(0, -count, 0);
                            a = true;
                        }
                        else
                        if (MiniGameCameraMove.mapMaxY > HeroMaxY && direction.y > 0)
                        {
                            direction2 = new Vector3(0, count, 0);
                            a = true;
                        }
                    }
                    if (MiniGameCameraMove.mapMaxY - 0.2f <= HeroMaxY)
                    {
                        if (MiniGameCameraMove.mapMinX < HeroMinX && direction.x < 0)
                        {
                            direction2 = new Vector3(-count, 0, 0);
                            a = true;
                        }
                        else
                        if (MiniGameCameraMove.mapMaxX > HeroMaxX && direction.x > 0)
                        {
                            direction2 = new Vector3(count, 0, 0);
                            a = true;
                        }
                    }
                    if (a)
                    {
                        if (direction2.x > 0)
                        {
                            HERO.GetComponent<MiniGameHeroAnimation>().Direction = 1 + plusz;
                        }
                        if (direction2.x < 0)
                        {
                            HERO.GetComponent<MiniGameHeroAnimation>().Direction = 2 + plusz;
                        }
                        else
                        {
                            HERO.GetComponent<MiniGameHeroAnimation>().Direction = 0;
                        }
                        HERO.transform.Translate(direction2.normalized * speed * Time.deltaTime, Space.World);
                    }

                }
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
                    if (LANg.TextCount[i].Text[j].GetComponent<Text>().text != null)
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
    IEnumerator spawner(float a,int i)
    {
        yield return new WaitForSeconds(a);
        GameObject skeleton = Instantiate(Skeleton, Spawners[i].position, gameObject.transform.rotation);
        skeleton.GetComponent<MiniSkeletonMoverAndAttackGAme>().Checkpoint = Spawners[i];
    }
    void Start()
    {
        MiniPousIMageGAme.Bool = false;
        MiniMapOnMosueClickGame.Target = new Vector3(-0.000000000000051515f, 0.254511f, 0);
        MiniGameAllScript.AttackfromHavenTimer = 0;
        MiniGameAllScript.AllEnemys.Clear();
        LOadingSceneGameobject = LOadingSceneGameobject2;
        MiniGame = IMage;
        MiniGame2 = gameObject;
        winner = 0;
        LoadingCount = 0;
        plusz = 0;
        Jozstic = Jozstic2;
        WinnerCheckpoint2 = WinnerCheckpoint;
        Joystick2 =Joystick;
        LOck = 0;
        PrincesCheckpoint2 = PrincesCheckpoint;
        LanguagesChange(database.LNG, LANG);
        for (int i=0;i< Spawnerek.transform.childCount;i++)
        {
            Spawners.Add(Spawnerek.transform.GetChild(i));
        }
        HERO = Instantiate(MENUGamobjects.MiniGameHero, HeroSPawn.transform.position, gameObject.transform.rotation);
        GameOverPanel = GameOverPanel2;
        HealtiBarCanvas = HealtiBarCanvas2;
        HealthBarGamobject = HealthBarGamobject2;
        PresentLoadingSkeletonTime = LoadingSkeletonTime;
        HeroMAxHP = HeroMAxHP2;
        PauseButtonImageLocation = PauseButtonImageLocation2;
        ArrowsDOwnParticleEffect = ArrowsDOwnParticleEffect2;
        PauseMenuPanel = PauseMenuPanel2;
        HealthBarGamobject3 = HealthBarGamobject32;
        attackfromheavenButton = attackfromheavenButton1;
        attackfromheavenButton2 = attackfromheavenButton22;
        ShadowArrow = ShadowArrow2;
        BPositionAttack = BPositionAttack2 ;
        APositionAttack = APositionAttack2;
    attackfromheavenArrows= attackfromheavenArrows2;
    MainCamera= MainCamera2;
        floatMaxHP = HeroMAxHP2;
    }
    public static void Demage(float a)
    {
        HeroMAxHP -= a;
        if(HeroMAxHP<0)
        {
            HeroMAxHP = 0;
        }
        HealthBarGamobject.GetComponent<Transform>().localScale = new Vector3(HeroMAxHP/floatMaxHP, 1,1);
        if(HeroMAxHP<=0)
        {
            Destroy(HERO);
            LOse();
        }
    }
    public static void LOse()
    {
        HealtiBarCanvas.SetActive(false);
        //HealthBarGamobject.SetActive(false);
        //PauseButtonImageLocation.SetActive(false);
        attackfromheavenButton.SetActive(false);
        GameOverPanel.SetActive(true);
        MiniPousIMageGAme.Bool = true;
    }



    public void Winner()
    {
        winner = 1;
        if (LoadAnotherScene.map != "")
        {
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene(LoadAnotherScene.map, LOadingSceneGameobject));
            //SceneManager.LoadScene(LoadAnotherScene.map);
        }
        else
        {
            database.Q = 1;
            FajlDatabase.WriteIntoTxtFile();
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene(NextScene, LOadingSceneGameobject));
            //SceneManager.LoadScene(NextScene);
        }
    }



    public void DestroyAudio2(float timer, AudioSource Sound,GameObject Targy)
    {
        StartCoroutine(DestroyAudio(timer, Sound, Targy));
    }
    public IEnumerator DestroyAudio(float timer, AudioSource Sound, GameObject Targy)
    {
        float PresentTime = 0;
        while (PresentTime < timer)
        {
            if (MiniPousIMageGAme.Bool)
                break;
            yield return PresentTime += Time.deltaTime;
        }
        Component[] Sounds = Targy.GetComponents<AudioSource>();
        for (int i = 0; i < Sounds.Length; i++)
        {
            if (Sounds[i].GetComponent<AudioSource>() == Sound)
            {
                Sounds[i].GetComponent<AudioSource>().mute = true;
                Destroy(Sounds[i].GetComponent<AudioSource>());
            }
        }
        yield return null;

    }
}
