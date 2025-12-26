using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackFromHavenButtonClik : MonoBehaviour
{
    public GameObject SecoundButton = null;
    public float LoadTime;
    //public float RADIO;
    private bool a=true;
    private void Start()
    {
        MapOnMouseClick.voltmar = true;
    }
    private void OnMouseDown()
    {
        if (CameraMOverClick.mozoge)
            return;
        if (MENUGamobjects.TutorialMap != 0 && MENUGamobjects.TutorialMap != 10)
        {
            return;
        }
        else
                if (MENUGamobjects.TutorialMap != 0)
        {
            MENUGamobjects.TutorialMap++;
            TutorialScript.ChangePages();
        }
        AllGameObject.SetactiveFalse(2);
        if (a)
        {
            AllGameObject.attackfromheavenClickBool = !AllGameObject.attackfromheavenClickBool;
            if (AllGameObject.attackfromheavenClickBool)
            {
                gameObject.GetComponent<Image>().color  = new Color(0.5f, 0.5f, 0.5f);
            }
            else
            {
                gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            }
        }
    }
    [System.Obsolete]
    
    private void Update()
    {
            if (PauseButtonImagePause.Bool|| !MapOnMouseClick.voltmar)
                return;
    if(!SecoundButton.active)
            SecoundButton.SetActive(true);
        if(AllGameObject.AttackfromHavenTimer <= 0)
            {
                MapOnMouseClick.voltmar = false;
            SecoundButton.SetActive(false);
            AllGameObject.AttackfromHavenTimer = 0.1f;
            a = true;
                return;
            }
    if(AllGameObject.AttackfromHavenTimer == 0.1f)
        {
            a = false;
            AllGameObject.AttackfromHavenTimer = LoadTime;
            //SecoundButton.GetComponent<Transform>().localScale = new Vector3(RADIO, RADIO, 0);
            SecoundButton.SetActive(true);
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
            SecoundButton.GetComponent<Image>().fillAmount = 1;
        }
        AllGameObject.AttackfromHavenTimer -= Time.deltaTime;
        SecoundButton.GetComponent<Image>().fillAmount =AllGameObject.AttackfromHavenTimer / LoadTime;
       /* Sprite Next=MENUGamobjects.LoadingCirceSprite(LoadTime, AllGameObject.AttackfromHavenTimer);
        if (Next != SecoundButton.GetComponent<Image>().sprite) {
            SecoundButton.GetComponent<Image>().sprite = Next;
                }*/
        // float radio = (RADIO * AllGameObject.AttackfromHavenTimer / LoadTime);

        //SecoundButton.GetComponent<Transform>().localScale = new Vector3(radio, radio, 0);


    }
}
