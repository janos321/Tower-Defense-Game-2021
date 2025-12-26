using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CameraMove : MonoBehaviour
{
    public float panSpeed = 30f;
    public GameObject map;
    public static float mapMinX, mapMaxX, mapMinY, mapMaxY, camMinX, camMaxX, camMinY, camMaxY;
   // private float  StartcamMinX, StartcamMaxX, StartcamMinY, StartcamMaxY;
    private float stabilizatTime = 0.5f;
    public float ScalaPersentage = 1;
    //public List<GameObject> ChangeScaleObject = new List<GameObject>();
    public List<GameObject> Panels = new List<GameObject>();
    //private float ScaleAtlagPersentage=1;
    //private float ScalaCameraMove=1;

    private void Awake()
    {
        Start();
    }

    public void Start()
    {

        mapMaxX = map.GetComponent<BoxCollider2D>().bounds.center.x + map.GetComponent<BoxCollider2D>().bounds.extents.x;
        mapMinX = map.GetComponent<BoxCollider2D>().bounds.center.x - map.GetComponent<BoxCollider2D>().bounds.extents.x;
        mapMaxY = map.GetComponent<BoxCollider2D>().bounds.center.y + map.GetComponent<BoxCollider2D>().bounds.extents.y;
        mapMinY = map.GetComponent<BoxCollider2D>().bounds.center.y - map.GetComponent<BoxCollider2D>().bounds.extents.y;
        CoordChange();

        if (LogInRegisztrelScript.AlapX != 0)
        {
            for (int i = 0; i < Panels.Count; i++)
            {
                Panels[i].transform.localScale = new Vector3(Panels[i].transform.localScale.x * LogInRegisztrelScript.CameraPersentAge, Panels[i].transform.localScale.y * LogInRegisztrelScript.CameraPersentAge, Panels[i].transform.localScale.z);
            }
        }
        
        

    }
        void Update()
    {
        if (stabilizatTime > 0)
        {
            stabilizatTime -= Time.deltaTime;
        }
        else
        if(stabilizatTime<0)
        {
            CoordChange();
            stabilizatTime = 0;
        }

        if (MENUGamobjects.kameramozgatas != 0)
            return;
        if (camMaxX != gameObject.transform.position.x + (2f * Camera.main.orthographicSize * Camera.main.aspect) / 2 || camMaxY != gameObject.transform.position.y + (2f * Camera.main.orthographicSize) / 2)
        {
            CoordChange();
        }
        if (Input.GetKey("w") && camMaxY < mapMaxY)
        {
            Vector2 direction = new Vector2(0f, 1f);
            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }
        else
            if (Input.GetKey("d") && camMaxX < mapMaxX)
        {
            Vector2 direction = new Vector2(1f, 0f);         
            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }
        else
        if (Input.GetKey("a") && camMinX > mapMinX)
        {

            Vector2 direction = new Vector2(-1f, 0f);
           
            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }
        else
        if (Input.GetKey("s") && camMinY > mapMinY)
        {
            
            Vector2 direction = new Vector2(0f, -1f);
            

            transform.Translate(direction.normalized * panSpeed * Time.deltaTime, Space.World);
            CoordChange();
        }
       



    }
    public void fixalas()
    {
        if(camMaxX>mapMaxX)
        {
            camMaxX = mapMaxX;
        }
        if (camMinX < mapMinX)
        {
            camMinX = mapMinX;
        }
        if (camMaxY > mapMaxY)
        {
            camMaxY = mapMaxY;
        }
        if (camMinY < mapMinY)
        {
            camMinY = mapMinY;
        }
        gameObject.transform.position=new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, gameObject.transform.position.z);
    }
    public void CoordChange()
        {
            //float camMaxX2 = camMaxX, camMinX2 = camMinX, camMaxY2 = camMaxY, camMinY2 = camMinY;
            camMaxX = gameObject.transform.position.x + (2f*Camera.main.orthographicSize*Camera.main.aspect)/2;
        camMinX = gameObject.transform.position.x - (2f * Camera.main.orthographicSize * Camera.main.aspect) / 2;
        camMaxY = gameObject.transform.position.y + (2f * Camera.main.orthographicSize) / 2;
        camMinY = gameObject.transform.position.y - (2f * Camera.main.orthographicSize) / 2;
        fixalas();
        if (stabilizatTime>0)
        {
            stabilizatTime -= Time.deltaTime;
            return;
        }
        float PersentAgeX = ScalaPersentage * LogInRegisztrelScript.CameraPersentAge;
        float PersentAgeY = ScalaPersentage * LogInRegisztrelScript.CameraPersentAge;
        if (SceneManager.GetActiveScene().name == "MENU")
        {
            MENUGamobjects.YellowDiamondImage.transform.position = new Vector3((camMaxX - 6f* PersentAgeX), camMaxY - 1f * PersentAgeY, 5);
            //MENUGamobjects.SettingsPanel.transform.position = new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);
            MENUGamobjects.SettingsButton.transform.position = new Vector3(camMinX + 2f * PersentAgeX, camMinY + 1.5f * PersentAgeY, 5);
           // MENUGamobjects.YellowDiamondImageShopPanel.transform.position = new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);
           // MENUGamobjects.HeroShop.transform.position = new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);

            //MENUGamobjects.ShopPanel2.transform.position = new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);

        }
        else
        if (SceneManager.GetActiveScene().name == "SinglePlayerMenu")
        {
            LoadAnotherScene.ClassicThrone2.transform.position = new Vector3(camMaxX - 1.75f* PersentAgeX, camMinY + 2f * PersentAgeY, 5);
            LoadAnotherScene.KleoptarasThrone2.transform.position = new Vector3(camMaxX - 1.75f* PersentAgeX, camMinY + 2f * PersentAgeY, 5);
            LoadAnotherScene.RightDownSettings.transform.position = new Vector3(camMinX + 1.5f * PersentAgeX, camMinY + 1f * PersentAgeY, 5);
            LoadAnotherScene.EncikplopediaButton.transform.position = new Vector3(camMinX + 5f * PersentAgeX, camMinY + 1.65f * PersentAgeY, 5);
            LoadAnotherScene.CenterEnciklopedia.transform.position = new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);
            LoadAnotherScene.RightUpDiamondCounterAndStarCounter.transform.position = new Vector3(camMaxX - 5f * PersentAgeX, camMaxY - 1.25f * PersentAgeY, 5);
            LoadAnotherScene.EnciklopediaHelp.transform.position = new Vector3(camMinX + 1.3f * PersentAgeX, camMaxY - 1.3f * PersentAgeY, 5);
            LoadAnotherScene.EnciklopediaHelp3.transform.position = new Vector3(camMinX + 1.3f * PersentAgeX, camMaxY - 1.3f * PersentAgeY, 5);
            for(int i=0;i<LoadAnotherScene.LevelStarPanel.Count;i++)
            {
                LoadAnotherScene.LevelStarPanel[i].transform.position = new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);
            }
            LoadAnotherScene.StartTutorialPanel2.transform.position = new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);
        }
        else
         if (SceneManager.GetActiveScene().name == "MiniGame")
        {
            try
            {
                MiniGameAllScript.attackfromheavenButton.transform.position = new Vector2(camMaxX - 5.5f , camMinY + 1.65f );
                MiniGameAllScript.PauseButtonImageLocation.transform.position = new Vector2(camMinX + 1.5f , camMaxY - 1f);
                MiniGameAllScript.GameOverPanel.transform.position = new Vector2((camMaxX - camMinX) / 2, (camMaxY - camMinY) / 2 + camMinY);
                MiniGameAllScript.HealthBarGamobject3.transform.position = new Vector2((camMaxX - camMinX) / 2 + camMinX, camMaxY - 1f);
            }
            catch
            {

            }
        }
        else
        if(SceneManager.GetActiveScene().name == "MultiPlayerMenu")
        {
            MultiPlayerMenuAllGameobject.DeckButton.transform.position = new Vector3(camMinX + 2.7f * PersentAgeX, camMinY + 0.9f * PersentAgeY, 5);
            MultiPlayerMenuAllGameobject.BackMainMenu2.transform.position = new Vector3(camMinX + 0.8f * PersentAgeX, camMinY + 0.75f * PersentAgeY, 5);
            MultiPlayerMenuAllGameobject.YellowDiamondImage.transform.position = new Vector3(camMaxX - 2.6f * PersentAgeX, camMaxY - 0.5f * PersentAgeY, 5);
            MultiPlayerMenuAllGameobject.HeroBodyImagesBackground.transform.position = new Vector3(camMinX + 1f * PersentAgeX, camMaxY - 1f * PersentAgeY, 5);
            MultiPlayerMenuAllGameobject.PLayButton.transform.position = new Vector3(camMaxX - 1.8f * PersentAgeX, camMinY + 1.1f * PersentAgeY, 5);
        }
        else
            {
            AllGameObject.OwnUnitSoldiersButton1.transform.position= new Vector2(camMaxX - 8.8f * PersentAgeX, camMinY + 1.65f * PersentAgeY);
            AllGameObject.attackfromheavenButton.transform.position = new Vector2(camMaxX -5.5f * PersentAgeX, camMinY+1.65f * PersentAgeY);
            AllGameObject.attackfromheavenButton2.transform.position = new Vector2(camMaxX - 5.5f * PersentAgeX, camMinY +1.65f * PersentAgeY);
            AllGameObject.WinnerCanvas.transform.position = new Vector2((camMaxX - camMinX) / 2 + camMinX+2f * PersentAgeX, (camMaxY - camMinY) / 2 + camMinY);
            AllGameObject.MoneyLocation.transform.position = new Vector2(camMaxX - 4f * PersentAgeX, camMaxY - 1.5f * PersentAgeY);
            AllGameObject.PauseButtonImageLocation.transform.position = new Vector2(camMinX + 2f * PersentAgeX, camMaxY - 1.5f * PersentAgeY);
            // AllGameObject.GameOverCanvas.transform.position = new Vector2(camMinX-1f * ScalaPersentage, camMaxY-2f * ScalaPersentage);
            AllGameObject.ShopArrowButton.transform.position = new Vector2(camMinX + 2f * PersentAgeX, camMinY + 1f * PersentAgeY);
            AllGameObject.BubbleAllSkillObjects.transform.position = new Vector2(camMaxX - 2f * PersentAgeX, camMinY + 2f * PersentAgeY);
            AllGameObject.PauseMenuPanel.transform.position = new Vector2((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY);
        }


    }
    public static IEnumerator SkillShopBe(float Maxtime,GameObject Targy,int merre,Vector3 indulas)
    {
            MENUGamobjects.ShopPanelMozoge = true;
        
        float PresentTime=0;
        if (merre == 0)
        {
            Targy.transform.position = new Vector3(camMinX, camMinY,5);
            Vector3 target= new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5);
            Vector3 vege = Targy.transform.localScale;
            Targy.transform.localScale = new Vector3(0, 0, 0);
            Targy.SetActive(true);
            while (PresentTime<Maxtime)
            {
                Targy.transform.position = Vector3.Lerp(indulas, target, PresentTime / Maxtime);
                Targy.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), vege, PresentTime / Maxtime);
                yield return PresentTime += Time.deltaTime;
            }
            Targy.transform.position = target;
            Targy.transform.localScale = vege;
        }
        else
        {
            Vector3 SceleEredeti = Targy.transform.localScale;
            while (PresentTime < Maxtime)
            { 
                Targy.transform.position = Vector3.Lerp(new Vector3((camMaxX - camMinX) / 2 + camMinX, (camMaxY - camMinY) / 2 + camMinY, 5), indulas, PresentTime / Maxtime);
                Targy.transform.localScale = Vector3.Lerp(SceleEredeti, new Vector3(0, 0, 0), PresentTime / Maxtime);
                yield return PresentTime += Time.deltaTime;
            }
            Targy.transform.localScale = SceleEredeti;
            Targy.SetActive(false);
            if(!MENUGamobjects.ShopPanel2.active&&!MENUGamobjects.SettingsPanel.active)
            {
                MENUGamobjects.footloose = 0;
                MENUGamobjects.kameramozgatas = 0;
            }
        }
            MENUGamobjects.ShopPanelMozoge = false;
        yield return null;
    }
}
