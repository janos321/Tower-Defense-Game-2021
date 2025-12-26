using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PasswordSee : MonoBehaviour
{
    public GameObject PasswordText;
    public GameObject x;
    public bool nez=false;


    public void click()
    {
        if(nez)
        {
            string textt = PasswordText.GetComponent<InputField>().text;
            PasswordText.GetComponent<InputField>().text = "";
            PasswordText.GetComponent<InputField>().contentType = InputField.ContentType.Password;
            x.SetActive(false);
            PasswordText.GetComponent<InputField>().text=textt;
        }
        else
        {
            string textt = PasswordText.GetComponent<InputField>().text;
            PasswordText.GetComponent<InputField>().text = "";
            PasswordText.GetComponent<InputField>().contentType = InputField.ContentType.Standard;
            x.SetActive(true);
            PasswordText.GetComponent<InputField>().text = textt;
        }
        nez = !nez;
    }
}
