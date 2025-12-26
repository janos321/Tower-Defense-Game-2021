using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameOrVideoSurFaceScript : MonoBehaviour
{
    private GameObject LOadingSceneGameobject;


    private void Start()
    {
        if (AllGameObject.LOadingSceneGameobject!=null)
        {
            LOadingSceneGameobject = AllGameObject.LOadingSceneGameobject;
        }
        else
                    if (LoadAnotherScene.LOadingSceneGameobject2 != null)
        {
            LOadingSceneGameobject = LoadAnotherScene.LOadingSceneGameobject2;
        }
        else
                    if (MiniGameAllScript.LOadingSceneGameobject != null)
        {
            LOadingSceneGameobject = MiniGameAllScript.LOadingSceneGameobject;
        }
    }
    public void Close()
    {
        if (LoadAnotherScene.map == "")
        {
            LoadAnotherScene.footloose = 0;
        }
        gameObject.SetActive(false);
    }
    public void MiniGame()
    {
        //PauseButtonImagePause.Bool = false;
        //AllGameObject.PauseButtonImageLocation.GetComponent<PauseButtonImagePause>().XekNullazo();
        LoadAnotherScene.footloose = 0;
        StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MiniGame", LOadingSceneGameobject));
        //SceneManager.LoadScene("MiniGame");
        //Itt van hogy mit csináljin a miniGameGomb
    }
    public void Video()
    {
        if (!MENUGamobjects.WifiBool)
        {
            Instantiate(MENUGamobjects.WifiBlock);
            return;
        }
        // Itt az kell majd hogy elintitson egy videot





        LoadAnotherScene.footloose = 0;
        database.Q = 1;
        AllGameObject.PauseButtonImageLocation.GetComponent<PauseButtonImagePause>().Retry();
        gameObject.SetActive(false);

    }
    public void MENUMiniGame()
    {
        LoadAnotherScene.footloose = 0;
        StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MiniGame",LOadingSceneGameobject));
        //SceneManager.LoadScene("MiniGame");
        /*if (LoadAnotherScene.map != "")
        {
            SceneManager.LoadScene(LoadAnotherScene.map);
        }
        else
        {
            LoadAnotherScene.PrincessEnemy = true;
        }
        gameObject.SetActive(false);*/
        //Itt van hogy mit csináljin a miniGameGomb
    }
    private void Update()
    {
        if (gameObject.active)
        {
            if (MENUGamobjects.WifiEllenorzesido >= 3)
            {
                MENUGamobjects.WifiEllenorzesido = 0;
                int r = Random.Range(0, database.PingTarget.Count);
                StartCoroutine(database.CheckInternetConnection1(isConnected =>
                {
                    MENUGamobjects.WifiBool = isConnected;
                }, r));
            }
            else
            {
                MENUGamobjects.WifiEllenorzesido += Time.deltaTime;
            }
        }
    }
    public void MENUVideo()
    {
        /*if (!MENUGamobjects.WifiBool)
        {
            Instantiate(MENUGamobjects.WifiBlock);
            return;
        }*/

        // Itt az kell majd hogy elintitson egy videot




        LoadAnotherScene.footloose = 0;
        if (LoadAnotherScene.map != "")
        {
            //SceneManager.LoadScene(LoadAnotherScene.map);
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene(LoadAnotherScene.map, LOadingSceneGameobject));
        }
        else
        {
            LoadAnotherScene.KleoptarasThrone2.SetActive(true);
            LoadAnotherScene.ClassicThrone2.SetActive(false);
            //LoadAnotherScene.KleopatraButton2.transform.GetComponent<Image>().sprite = LoadAnotherScene.KleoptarasThrone2;
            database.Q = 1;
            gameObject.SetActive(false);
        }

    }



}
