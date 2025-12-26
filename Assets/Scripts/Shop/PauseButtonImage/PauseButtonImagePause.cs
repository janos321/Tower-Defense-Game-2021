using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtonImagePause : MonoBehaviour
{
    public static bool Bool = false;
    public void OnMouseDown()
    {

        if (CameraMOverClick.mozoge || !AllGameObject.SettingsButton)
            return;
        if(MENUGamobjects.TutorialMap!=0)
        {
            if(MENUGamobjects.TutorialMap== 20&&Bool)
            {
                return;
            }
            Bool = !Bool;
            AllGameObject.PauseMenuPanel.SetActive(Bool);
            AllGameObject.Kulsok.SetActive(!Bool);
            AllGameObject.attackfromheavenButton.SetActive(!Bool);
            AllGameObject.OwnUnitSoldiersButton1.SetActive(!Bool);
            AllGameObject.BubbleAllSkillObjects.SetActive(!Bool);
            AllGameObject.HeroButton.SetActive(!Bool);
            return;
        }
        AllGameObject.SetactiveFalse(-1);
        Bool = !Bool;
        AllGameObject.PauseMenuPanel.SetActive(Bool);
        AllGameObject.Kulsok.SetActive(!Bool);
        AllGameObject.attackfromheavenButton.SetActive(!Bool);
        AllGameObject.attackfromheavenButton2.SetActive(false);
        AllGameObject.OwnUnitSoldiersButton1.SetActive(!Bool);
        AllGameObject.OwnUnitSoldiersButton2.SetActive(false);
        AllGameObject.OwnUNitSoldiersClickBool = false;
        AllGameObject.BubbleAllSkillObjects.SetActive(!Bool);
        AllGameObject.HeroButton.SetActive(!Bool);
        if(Bool)
        {
            MENUGamobjects.kameramozgatas = 1;
        }
        else
        {
            MENUGamobjects.kameramozgatas = 0;
        }
    }
    public void Retry()
    {
        if(MENUGamobjects.TutorialMap!=0)
        {
            return;
        }
        if (database.Q == 1)
        {
            //XekNullazo();
            database.Q = 0 ;
            //Bool = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            AllGameObject.MiniGamesOrVideoSurface.SetActive(true);
        }
    }
    public void Menu()
    {
        if (MENUGamobjects.TutorialMap != 0)
        {
            //XekNullazo();
            MENUGamobjects.TutorialMap = 0;
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene(AllGameObject.NextScene,AllGameObject.LOadingSceneGameobject));
            //SceneManager.LoadScene(AllGameObject.NextScene);
        }
        //XekNullazo();
        //Bool = false;
        StartCoroutine(MENU());
        //SceneManager.LoadScene(AllGameObject.NextScene);
    }
    IEnumerator MENU()
    {
        AllGameObject.LOadingSceneGameobject.GetComponent<Animator>().Play("LOadingLostScene");
        float presentTimer = 0;
        while (presentTimer < 1.5f)
        {
            yield return presentTimer += Time.deltaTime;

        }
        SceneManager.LoadSceneAsync(AllGameObject.NextScene);
    }
   /*public void XekNullazo()
    {
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
        for (int i=0;i<AllGameObject.SpacesTransform.Length;i++)
        {
            AllGameObject.SpacesTransform[i] = null;
        }
    }*/
}
