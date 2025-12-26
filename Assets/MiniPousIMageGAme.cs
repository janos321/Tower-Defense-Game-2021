using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MiniPousIMageGAme : MonoBehaviour
{
    public static bool Bool = false;
    public void OnMouseDown()
    {
        if(MiniGameAllScript.Losee)
        {
            return;
        }
        MiniGameAllScript.MinigameAllScriptGameobject.GetComponent<MiniGameAllScript>().HelpedAll();
        MiniGameAllScript.SetactiveFalse(0);
        Bool = !Bool;
        MiniGameAllScript.PauseMenuPanel.SetActive(Bool);
        MiniGameAllScript.attackfromheavenButton.SetActive(!Bool);
        MiniGameAllScript.attackfromheavenButton2.SetActive(false);
    }
    public void Retry()
    {
            //XekNullazo();
            //Bool = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        //XekNullazo();
        //Bool = false;
        //StartCoroutine(MENUGamobjects.LoadYourAsyncScene(MiniGameAllScript.NextScene));
        StartCoroutine(MENU());
       /*MiniGameAllScript.LOadingSceneGameobject.GetComponent<Animator>().Play("LOadingLostScene");
        float presentTimer = 0;
        while (presentTimer < 1.5f)
        {
            yield return presentTimer += Time.deltaTime;

        }
        SceneManager.LoadSceneAsync(MiniGameAllScript.NextScene);
        //SceneManager.LoadScene(MiniGameAllScript.NextScene);*/
    }

    public IEnumerator MENU()
    {
        MiniGameAllScript.LOadingSceneGameobject.GetComponent<Animator>().Play("LOadingLostScene");
        float presentTimer = 0;
        while (presentTimer < 1.5f)
        {
            yield return presentTimer += Time.deltaTime;

        }
        SceneManager.LoadSceneAsync(MiniGameAllScript.NextScene);
    }
   /* void XekNullazo()
    {
        MiniMapOnMosueClickGame.Target = new Vector3(-0.000000000000051515f, 0.254511f, 0);
        MiniGameAllScript.AttackfromHavenTimer = 0;
        MiniGameAllScript.AllEnemys.Clear();
    }*/
}
