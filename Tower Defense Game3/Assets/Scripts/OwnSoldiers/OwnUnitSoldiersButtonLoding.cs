using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OwnUnitSoldiersButtonLoding : MonoBehaviour
{

    public GameObject SecoundButton = null;
    public float LoadTime;
    //public float RADIO;
   // public Color color1;
    //public Color color2;
    private bool a = true;
    private void Start()
    {
        MapOnMouseClick.voltmarOwnSoldiers = true;
    }
    private void OnMouseDown()
    {
        if (CameraMOverClick.mozoge || !Spawner.elindulte)
            return;
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 12)
        {
            return;
        }
        else
                if (MENUGamobjects.TutorialMap != 0)
        {
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        AllGameObject.SetactiveFalse(5);
        if (a)
        {
            AllGameObject.OwnUNitSoldiersClickBool = !AllGameObject.OwnUNitSoldiersClickBool;
            if (AllGameObject.OwnUNitSoldiersClickBool)
            {
                gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            }
        }
    }
    //private float PresentTime = -5f;

    [System.Obsolete]
    private void Update()
    {
        if (PauseButtonImagePause.Bool || !MapOnMouseClick.voltmarOwnSoldiers)
            return;
        if (!SecoundButton.active)
            SecoundButton.SetActive(true);
        if (AllGameObject.OwnSOlderTimer <= 0&& AllGameObject.OwnSOlderTimer != -5f)
        {
            MapOnMouseClick.voltmarOwnSoldiers = false;
            SecoundButton.SetActive(false);
            AllGameObject.OwnSOlderTimer = -5f;
            a = true;
            return;
        }
        if (AllGameObject.OwnSOlderTimer == -5f)
        {
            a = false;
            AllGameObject.OwnSOlderTimer = LoadTime;
           // SecoundButton.GetComponent<Transform>().localScale = new Vector3(RADIO, RADIO, 0);
            SecoundButton.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            SecoundButton.GetComponent<Image>().fillAmount = 1;
        }
        AllGameObject.OwnSOlderTimer -= Time.deltaTime;
        SecoundButton.GetComponent<Image>().fillAmount = AllGameObject.OwnSOlderTimer / LoadTime;
        // float radio = (RADIO * AllGameObject.OwnSOlderTimer / LoadTime);

        // SecoundButton.GetComponent<Transform>().localScale = new Vector3(radio, radio, 0);


    }

}


