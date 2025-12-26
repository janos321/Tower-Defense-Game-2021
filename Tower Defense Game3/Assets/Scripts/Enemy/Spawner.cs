
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public GameObject NextWaveCanvas = null;
    public GameObject LoadingNextWaveCircle = null;
    public GameObject LoadingNextWaveButton = null;
    public List<GameObject> WayPoints = new List<GameObject>();
    public List<WaveList> WavesDifficulti = new List<WaveList>();
    public static bool elindulte = false;
    [System.Serializable]
    public class Enemy
    {
        public string WaveKezdetetolido2 = "Az enemyk indulasa a wave-tol kezdve szamitott idokjlklélm,";//
        public float WaveKezdetetolido = 0;
        public string Ellenseg2 = "Ellenseg GameObject";
        public GameObject Ellenseg = null;
        public string Ellensegszama2 = "Ellensegszama";
        public int Ellensegszama = 0;
        public string KetEllensegkozottiIdostring = "KetEllensegkozottiIdo";
        public float KetEllensegkozottiIdo = 0;

    }
    [System.Serializable]
    public class Wave
    {
        public float KetWaveKozottiIdo = 0;
        public List<Enemy> Enemys = new List<Enemy>();
    }
    [System.Serializable]
    public class WaveList
    {
        public List<Wave> WavesCount = new List<Wave>();
    }
    private float Presenttime = 0;
    private int PresentWaveIndex = 0;
    public float KetWaveKozottiIdo;
    private int szabalyozo = 0;
    private float legnagyobbIdo = 0;
    private void Start()
    {
        elindulte = false;
        if (WavesDifficulti[LoadAnotherScene.ForceSojdan-1].WavesCount[0].KetWaveKozottiIdo==-1)
        {
            NextWaveCanvas.SetActive(true);

            KetWaveKozottiIdo = -1;
        }
        else
        KetWaveKozottiIdo = WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[0].KetWaveKozottiIdo;
    }
    void Update()
    {
        if (PauseButtonImagePause.Bool || WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount.Count <= PresentWaveIndex || szabalyozo != 0||KetWaveKozottiIdo==-1)
            return;
        if (KetWaveKozottiIdo <= 0)
        {
            LoadingNextWaveCircle.GetComponent<Transform>().localScale = new Vector3(0.1f, 0.1f, 0);
            if(NextWaveCanvas.active)
            {
            NextWaveCanvas.SetActive(false);
                SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial,"trombita #1");
            }

            Presenttime = 0;
            szabalyozo = 1;
            StartCoroutine(WaveComing());
        }
        else
        {           
            NextWaveCanvas.SetActive(true);
                    float radio = (AllGameObject.radioNextWaveCircle* Presenttime  / WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].KetWaveKozottiIdo);
                    LoadingNextWaveCircle.GetComponent<Transform>().localScale = new Vector3(radio, radio, 0);
            KetWaveKozottiIdo -= Time.deltaTime;
            Presenttime += Time.deltaTime;
        }

    }

    [System.Obsolete]
    IEnumerator WaveComing()
    {
        if (PauseButtonImagePause.Bool) { yield return null; }
        legnagyobb();
        Vector2 k = gameObject.transform.position;
        while (legnagyobbIdo >= Presenttime)
        {
            for (int i = 0; i < WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys.Count; i++)
            {
                while (PauseButtonImagePause.Bool) { yield return null; }
                if (Presenttime % WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].KetEllensegkozottiIdo < 0.1f && WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].WaveKezdetetolido <= Presenttime && WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].Ellensegszama > 0)
                {
                    WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].Ellensegszama--;
                    Transform Enemy2 = Instantiate(WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].Ellenseg.transform, k, gameObject.transform.rotation);
                    AllGameObject.AllEnemys.Add(Enemy2);
                    Enemy2.GetComponent<EnemyMove>().segedStart = gameObject;
                    Enemy2.SetParent(GameObject.Find("Enemys").transform);
                }
            }
            Presenttime += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        PresentWaveIndex++;
        if (WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount.Count > PresentWaveIndex)
        {
            KetWaveKozottiIdo = WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].KetWaveKozottiIdo;
        }
        else
        {
            for(int i=0;i<AllGameObject.Starts.Count;i++)
            {
                if(AllGameObject.Starts[i].active&&AllGameObject.Starts[i]!=gameObject)
                {
                    gameObject.SetActive(false);
                }
            }
            NextWaveCanvas.SetActive(false);
            while (AllGameObject.AllEnemys.Count!=0) { yield return null; }
            if (HeartCounter.BeginnerHeart != 0&&!AllGameObject.GameOverCanvas.active)
            {
                MENUGamobjects.kameramozgatas = 1;
                AllGameObject.WinnerCanvas.SetActive(true);
                //AllGameObject.PauseButtonImageLocation.SetActive(false);
                AllGameObject.SettingsButton = false;
                AllGameObject.ShopArrowButton.SetActive(false);
                AllGameObject.KarakterSkillGameObject.SetActive(false);
                AllGameObject.Star1.sprite = AllGameObject.StarImage;
                int a = 1, yellowDiamond = 5;
                if (100 * HeartCounter.BeginnerHeart / HeartCounter.MaxBeginnerHeart >= 60)
                {
                    AllGameObject.Star2.sprite = AllGameObject.StarImage;
                    a++;
                }
                else
                {
                    AllGameObject.Star2.sprite = AllGameObject.EmptyStarImage;
                }
                if (100 * HeartCounter.BeginnerHeart / HeartCounter.MaxBeginnerHeart >= 80)
                {
                    AllGameObject.Star3.sprite = AllGameObject.StarImage;
                    a++;
                }
                else
                {
                    AllGameObject.Star3.sprite = AllGameObject.EmptyStarImage;
                }

                if (database.MAP[AllGameObject.LevelCount - 1] - (LoadAnotherScene.ForceSojdan - 1) * 3==0)
                {
                    yellowDiamond += (a) * 30;
                    database.STC += a;
                    database.MAP[AllGameObject.LevelCount - 1] = (LoadAnotherScene.ForceSojdan-1) * 3+a;
                }
                else
                if (database.MAP[AllGameObject.LevelCount - 1] - (LoadAnotherScene.ForceSojdan - 1) *3  < a)
                {
                    yellowDiamond += (a - (database.MAP[AllGameObject.LevelCount - 1] - (LoadAnotherScene.ForceSojdan - 1) * 3)) * 30;
                    database.STC += a - (database.MAP[AllGameObject.LevelCount - 1] - (LoadAnotherScene.ForceSojdan - 1) * 3);
                    database.MAP[AllGameObject.LevelCount - 1] = a+(LoadAnotherScene.ForceSojdan - 1) * 3;
                }

                /*if (database.MAP[AllGameObject.LevelCount-1]==0 )
                {
                    yellowDiamond += (a) * 30;
                    database.STC += a;
                    database.MAP[AllGameObject.LevelCount-1] = a;
                }
                else
                if (database.MAP[AllGameObject.LevelCount - 1] < a)
                {
                    yellowDiamond += (a - database.MAP[AllGameObject.LevelCount - 1]) * 30;
                    database.STC += a - database.MAP[AllGameObject.LevelCount - 1];
                    database.MAP[AllGameObject.LevelCount - 1] = a;
                }*/
                yellowDiamond += BeginnerMoney.Beginnermoney / 10;
                AllGameObject.YellowDiamondText.GetComponent<Text>().text = "+" + yellowDiamond.ToString();
                database.GDC += yellowDiamond;
                database.Q = 1;
            }
            FajlDatabase.WriteIntoTxtFile();
            gameObject.SetActive(false);

        }
        Presenttime = 0;
        szabalyozo = 0;
    }

    void legnagyobb()
    {
        legnagyobbIdo = 0;
        for (int i = 0; i < WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys.Count; i++)
        {
            if (WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].Ellensegszama * WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].KetEllensegkozottiIdo + WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].WaveKezdetetolido > legnagyobbIdo)
            {
                legnagyobbIdo = WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].Ellensegszama * WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].KetEllensegkozottiIdo + WavesDifficulti[LoadAnotherScene.ForceSojdan - 1].WavesCount[PresentWaveIndex].Enemys[i].WaveKezdetetolido;
            }
        }
    }

    public void LoadingNextWaveButtonDepression()
    {
        if (CameraMOverClick.mozoge)
            return;
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 9)
        {
            return;
        }
        else
                if (MENUGamobjects.TutorialMap != 0)
        {
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        elindulte = true;
        MapOnMouseClick.masrakatintottam = 1;
        AllGameObject.SetactiveFalse(-1);
        if (KetWaveKozottiIdo != -1)
        {
            AllGameObject.MoneyText.GetComponent<Text>().text = (BeginnerMoney.Beginnermoney + ((int)KetWaveKozottiIdo)).ToString();
            BeginnerMoney.Beginnermoney += ((int)KetWaveKozottiIdo);
        }
        SoundsScript.MusicStart(AllGameObject.SinglePlayerMApsAndTutorial,"trombita #1");
        if(KetWaveKozottiIdo==-1)
        {
            for(int i=0;i<AllGameObject.Starts.Count;i++)
            {
                AllGameObject.Starts[i].GetComponent<Spawner>().KetWaveKozottiIdo = 0;
            }
        }
        else
        KetWaveKozottiIdo = 0;
    }
}
