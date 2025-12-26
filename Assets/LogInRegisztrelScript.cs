using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using MimeKit;
using System.Net;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit;
using System.IO;



/*using Google.Play.AppUpdate;
using Google.Play.Common;*/
//using System;

public class LogInRegisztrelScript : MonoBehaviour
{
    //public string presentVersion;
    public GameObject LogInCanvas;
    public GameObject RegisterCanvas;
    public GameObject LogINUsernameText;
    public GameObject LogInPasswordText;
    public GameObject RegisterEmailText;
    public GameObject RegisterPasswordText;
    public GameObject RegisterUsernameText;
    public GameObject WrongTextLogin;
    public GameObject WrongTextRegister;
    public static bool reserve = true;
    public static string username, pasword,email="";
    public GameObject EmailPAsswordCanvas;
    public GameObject EmailPAsswordText;
    public GameObject WrongEmailPAsswordText;
    public GameObject EmailText;
    public GameObject NowfiPanel;
    private int r,r2,location=1;
    public GameObject ForgottePasswordCanvas;
    //public GameObject ForgotteUserName;
    public GameObject ForgotteEmail;
    public GameObject ForgotteMist;
    public GameObject ForgotteWrongText;
    public GameObject ChangePasswordText;
    public GameObject SecuendSide;
    public GameObject FirstSide;
    public GameObject EmailSend;
    public float AlapX2;
    public float AlapY2;
    public static float AlapX;
    public static float AlapY;
    public static float CameraPersentAge = 1;
    private float camMaxX = 0, camMinX = 0;
    public GameObject LOadingSceneGameobject;
    public GameObject WifiJelzo;
    bool WifiBool=true;
    private float WifiCheckTime = 1, Timer = 2;
    private string usernamee;
    public GameObject UpdatePanel;
    private bool nez = true;
    public GameObject LoadSceneSecond;
    public GameObject updateText;
    public GameObject WifiBlock;

    private void Update()
    {
        if (Timer > WifiCheckTime)
        {
            Timer = 0;
            StartCoroutine(database.CheckInternetConnection1(isConnected =>
            {
                WifiBool = isConnected;
                if (nez)
                {
                    nez = false;
                    if (WifiBool)
                    {
                        if (AutomatikUpdateScript.presentVersion == Application.version)
                        {
                            try
                            {
                                if (File.Exists(FajlDatabase.FilePath.ToString()))
                                {
                                    LoadSceneSecond.SetActive(true);
                                }
                            }
                            catch
                            {
                                if (File.Exists(FajlDatabase.FilePath.ToString()))
                                {
                                    LoadSceneSecond.SetActive(true);
                                }
                            }
                            egybolbejelentkezes();
                        }
                        else
                        {
                            //LOadingSceneGameobject.SetActive(false);
                            updateText.GetComponent<Text>().text = AutomatikUpdateScript.Newupdate;
                            UpdatePanel.SetActive(true);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (File.Exists(FajlDatabase.FilePath.ToString()))
                            {
                                LoadSceneSecond.SetActive(true);
                            }
                        }
                        catch
                        {
                            if (File.Exists(FajlDatabase.FilePath.ToString()))
                            {
                                LoadSceneSecond.SetActive(true);
                            }
                        }
                        egybolbejelentkezes();
                    }
                }
            }, Random.Range(0, database.PingTarget.Count)));
            WifiJelzo.SetActive(!WifiBool);
            
        }
        Timer += Time.deltaTime;
        /*if (database.IsConnectedToInternet())
          {
              //database.FillUpConnectionString();
              NowfiPanel.SetActive(false);
              if(location==1)
              {
                  LogInCanvas.SetActive(true);
              }
              else
                  if (location == 2)
              {
                  RegisterCanvas.SetActive(true);
              }
              else
                  if (location == 3)
              {
                  EmailPAsswordCanvas.SetActive(true);
              }
              else
                  if(location==4)
              {
                  ForgottePasswordCanvas.SetActive(true);
              }

          }
          else
          {
              LogInCanvas.SetActive(false);
              RegisterCanvas.SetActive(false);
              EmailPAsswordCanvas.SetActive(false);
              NowfiPanel.SetActive(true);
          }*/

    }
    // Use this for initialization

    public void LogINButton()
    {
        if(LogINUsernameText.GetComponent<InputField>().text == "alap"&& LogInPasswordText.GetComponent<InputField>().text == "alap")
        {
            username = RegisterUsernameText.GetComponent<InputField>().text;
            pasword = RegisterPasswordText.GetComponent<InputField>().text;
            FajlDatabase.username = username;
            FajlDatabase.password = pasword;
            database.FillGameDataString();
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
            return;
        }
        //Bejelntkezés adatok
        if (LogINUsernameText.GetComponent<InputField>().text.Length == 0)
        {
            WrongTextLogin.GetComponent<Text>().text = "No Username";
        }
        else
        if (LogInPasswordText.GetComponent<InputField>().text.Length == 0)
        {
            WrongTextLogin.GetComponent<Text>().text = "No Password";
        }
        else
        { 
            database.ReadFromDatabase(LogINUsernameText.GetComponent<InputField>().text, LogInPasswordText.GetComponent<InputField>().text);
            if (!reserve)
            {
                reserve = true;
                WrongTextLogin.GetComponent<Text>().text = "Wrong password or Name";
            }
            else
            if(database.ILO==1)
            {
                WrongTextLogin.GetComponent<Text>().text = "the account is busy";
            }
            else
            {
                username = LogINUsernameText.GetComponent<InputField>().text;
                pasword = LogInPasswordText.GetComponent<InputField>().text;
                FajlDatabase.username = username;
                FajlDatabase.password = pasword;
                database.ILO = 1;
                database.UpdateDatabase(username, pasword);
                FajlDatabase.WriteIntoTxtFile();
                StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
            }
        }
    }
    public void RegisterButton()
    {
        //Regisztrálási adatok  // gamedata string 170karakter
        if (RegisterUsernameText.GetComponent<InputField>().text.Length > 35)
        {
            WrongTextRegister.GetComponent<Text>().text = "Long Username";
        }
        else
        if (RegisterEmailText.GetComponent<InputField>().text.Length > 100)
        {
            WrongTextRegister.GetComponent<Text>().text = "Long Email";
        }
        else
        if (RegisterPasswordText.GetComponent<InputField>().text.Length > 35)
        {
            WrongTextRegister.GetComponent<Text>().text = "Long Password";
        }
        else
                if (RegisterUsernameText.GetComponent<InputField>().text.Length == 0)
        {
            WrongTextRegister.GetComponent<Text>().text = "No Username";
        }
        else
        if (RegisterEmailText.GetComponent<InputField>().text.Length == 0)
        {
            WrongTextRegister.GetComponent<Text>().text = "No Email";
        }
        else
        if (RegisterPasswordText.GetComponent<InputField>().text.Length == 0)
        {
            WrongTextRegister.GetComponent<Text>().text = "No Password";
        }
        else
        if(RegisterPasswordText.GetComponent<InputField>().text.Length <7)
        {
            WrongTextRegister.GetComponent<Text>().text = "Weak Password";
        }
        else
        {
            // Helyes karakterek-e vannak a kodban
                    for(int i=0;i< RegisterPasswordText.GetComponent<InputField>().text.Length;i++)
            {
                if(!((RegisterPasswordText.GetComponent<InputField>().text[i]>=48&& RegisterPasswordText.GetComponent<InputField>().text[i] <= 57)|| (RegisterPasswordText.GetComponent<InputField>().text[i] >= 65 && RegisterPasswordText.GetComponent<InputField>().text[i] <= 90) || (RegisterPasswordText.GetComponent<InputField>().text[i] >= 97 && RegisterPasswordText.GetComponent<InputField>().text[i] <= 122) || RegisterPasswordText.GetComponent<InputField>().text[i]== '#' || RegisterPasswordText.GetComponent<InputField>().text[i] == '_' || RegisterPasswordText.GetComponent<InputField>().text[i] == '-' || RegisterPasswordText.GetComponent<InputField>().text[i] == '$'))
                {
                    WrongTextRegister.GetComponent<Text>().text = "Invalid character: "+ RegisterPasswordText.GetComponent<InputField>().text[i];
                    return;
                }
            }



            int f = database.CheckIfThisExists(RegisterUsernameText.GetComponent<InputField>().text, RegisterEmailText.GetComponent<InputField>().text);
            if (f == 2) { 
                WrongTextRegister.GetComponent<Text>().text = "this Email is taken";
            }
            else
            if (f == 1)
            {
                WrongTextRegister.GetComponent<Text>().text = "this username is taken";
            }
            else
            if(f==3)
            {

                WrongTextRegister.GetComponent<Text>().text = "";
                r = Random.Range(1000, 9999);
                try
                {
                    MimeMessage message = new MimeMessage();
                    //sender
                    message.From.Add(new MailboxAddress("TowerDefenseEgypt", "TowerDefenseEgypt@gmail.com")); //sender name and email address
                                                                                     //receiver
                    message.To.Add(MailboxAddress.Parse(RegisterEmailText.GetComponent<InputField>().text)); //receiver email address
                              //subject
                    message.Subject = "Account registration";

                    //body
                    message.Body = new TextPart("plain")
                    {
                        Text = @"Hello, this is your verification code: " + r
                    };

                    string emailAddress = "TowerDefenseEgypt@gmail.com"; //sender address
                    string emailPassword = "afunphhqicvrtkxw"; //sender password
                    MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();

                    try
                    {
                        client.Connect("smtp.gmail.com", 465, true);

                        client.Authenticate(emailAddress, emailPassword);//
                        client.Send(message);//vvvv

                        //Console.WriteLine("Email sent!");

                    }
                    catch
                    {
                        //Console.WriteLine(err1.Message);
                        WrongTextRegister.GetComponent<Text>().text = "Wrong Email";
                        return;
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }


                }
                catch
                {
                    //Console.WriteLine(ex.Message);
                }
                    EmailText.GetComponent<Text>().text = RegisterEmailText.GetComponent<InputField>().text;
                location = 3;
                EmailPAsswordCanvas.SetActive(true);
                    RegisterCanvas.SetActive(false);
            }
        }
    }

    public void ChangeBackgraunddd()
    {
        if (LogInCanvas.active)
        {
            location = 2;
            LogInCanvas.SetActive(false);
            RegisterCanvas.SetActive(true);
            WrongTextLogin.GetComponent<Text>().text = "";
        }
        else
        {
            location = 1;
            LogInCanvas.SetActive(true);
            RegisterCanvas.SetActive(false);
            WrongTextRegister.GetComponent<Text>().text = "";
        }
    }
    public void EmailPassword()
    {
        if (EmailPAsswordText.GetComponent<InputField>().text.Length <4 )
        {
            WrongEmailPAsswordText.GetComponent<Text>().text = "short Password";
        }
        else
        if(r.ToString()!= EmailPAsswordText.GetComponent<InputField>().text)
        {
            WrongEmailPAsswordText.GetComponent<Text>().text = "Wrong Password";
        }
        else
        {
                        username = RegisterUsernameText.GetComponent<InputField>().text;
            pasword = RegisterPasswordText.GetComponent<InputField>().text;
            FajlDatabase.username = username;
            FajlDatabase.password = pasword;
            database.FillGameDataString();
            database.WriteIntoDatabase(RegisterUsernameText.GetComponent<InputField>().text, RegisterEmailText.GetComponent<InputField>().text, RegisterPasswordText.GetComponent<InputField>().text);
            database.ILO = 1;
            database.UpdateDatabase(username, pasword);
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
        }
    }
    public void backbutton()
    {
        location = 2;
        WrongEmailPAsswordText.GetComponent<Text>().text = "";
        EmailPAsswordText.GetComponent<InputField>().text="";
        EmailPAsswordCanvas.SetActive(false);
        RegisterCanvas.SetActive(true);
    }

    public void ForgottePasswordSetActive()//
    {
        if (ForgottePasswordCanvas.active)
        {
            location = 1;
            SecuendSide.SetActive(false);
            FirstSide.SetActive(true);
            ForgottePasswordCanvas.SetActive(false);
            LogInCanvas.SetActive(true);
            //ForgotteUserName.GetComponent<InputField>().text = "";
            ForgotteEmail.GetComponent<InputField>().text = "";
            ForgotteWrongText.GetComponent<Text>().text = "";
            ForgotteMist.GetComponent<InputField>().text = "";
            ChangePasswordText.GetComponent<InputField>().text = "";
        }
        else
        {
            location = 4;
            ForgottePasswordCanvas.SetActive(true);
            LogInCanvas.SetActive(false);
        }
    }

    public void ForgotteSendButton()
    {
        if (ForgotteEmail.GetComponent<InputField>().text.Length > 100)
        {
            ForgotteWrongText.GetComponent<Text>().text = "Long Email";
        }
        else
        if (ForgotteEmail.GetComponent<InputField>().text.Length == 0)
        {
            ForgotteWrongText.GetComponent<Text>().text = "No Email";
        }
        else
        {
            usernamee = database.FetchUsernameThroughEmail(ForgotteEmail.GetComponent<InputField>().text);
            if(usernamee=="")
            {
                ForgotteWrongText.GetComponent<Text>().text = "Wrong Email";
            }
            else
            if (database.CheckIfThisUserExists(usernamee, ForgotteEmail.GetComponent<InputField>().text))
            {
                ForgotteWrongText.GetComponent<Text>().text = "";
                r2 = Random.Range(1000, 9999);
                try
                {
                    MimeMessage message = new MimeMessage();
                    //sender
                    message.From.Add(new MailboxAddress("TowerDefenseEgypt", "TowerDefenseEgypt@gmail.com")); //sender name and email address
                                                                                                              //receiver
                    message.To.Add(MailboxAddress.Parse(ForgotteEmail.GetComponent<InputField>().text)); //receiver email address
                                                                                                             //subject
                    message.Subject = "Account registration";

                    //body
                    message.Body = new TextPart("plain")
                    {
                        Text = @"Hello "+ usernamee + ", this is your verification code: " + r2
                    };

                    string emailAddress = "TowerDefenseEgypt@gmail.com"; //sender address
                    string emailPassword = "afunphhqicvrtkxw"; //sender password
                    MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();

                    try
                    {
                        client.Connect("smtp.gmail.com", 465, true);

                        client.Authenticate(emailAddress, emailPassword);//
                        client.Send(message);//vvvv

                        //Console.WriteLine("Email sent!");

                    }
                    catch
                    {

                        //Console.WriteLine(err1.Message);
                        ForgotteWrongText.GetComponent<Text>().text = "Wrong Email";
                        return;
                    }
                    finally
                    {
                        client.Disconnect(true);
                        client.Dispose();
                    }


                }
                catch
                {
                    //Console.WriteLine(ex.Message);
                }
                SecuendSide.SetActive(true);
                FirstSide.SetActive(false);
                EmailSend.GetComponent<Text>().text = ForgotteEmail.GetComponent<InputField>().text;


            }
            else
            {
                ForgotteWrongText.GetComponent<Text>().text = "Wrong Email";
            }
        }
    }

    public void ChangePassword()
    {

        if(r2.ToString()!=ForgotteMist.GetComponent<InputField>().text)
        {
            ForgotteWrongText.GetComponent<Text>().text = "Wrong Mist";
        }
        else
        if(ChangePasswordText.GetComponent<InputField>().text.Length<7)
        {
            ForgotteWrongText.GetComponent<Text>().text = "Short Password";
        }
        else
        {

            //Bele irni az adatbázisba a megfelelö passwordot
            database.UpdateUserPassword(usernamee, ForgotteEmail.GetComponent<InputField>().text, ChangePasswordText.GetComponent<InputField>().text);
            database.ReadFromDatabase(usernamee, ChangePasswordText.GetComponent<InputField>().text);

                username = usernamee;
                pasword = ChangePasswordText.GetComponent<InputField>().text;
                FajlDatabase.username = username;
                FajlDatabase.password = pasword;
                database.ILO = 1;
            database.UpdateDatabase(username, pasword);
            FajlDatabase.WriteIntoTxtFile();
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));

        }
    }

   public void egybolbejelentkezes()
    {
        AlapX = AlapX2;
        AlapY = AlapY2;
        camMaxX = gameObject.transform.position.x + (2f * Camera.main.orthographicSize * Camera.main.aspect) / 2;
        camMinX = gameObject.transform.position.x - (2f * Camera.main.orthographicSize * Camera.main.aspect) / 2;
        float presentalapX = camMaxX - camMinX;
        float PercentAgeX = presentalapX * 100 / AlapX;
        PercentAgeX = PercentAgeX / 100;
        CameraPersentAge = PercentAgeX;
        try
        {
            if (File.Exists(FajlDatabase.FilePath.ToString()))
            {
                string[] lines = FajlDatabase.ReadDataFromFile();
                database.gamedata = lines[1];
                username = lines[2];
                pasword = lines[3];
                //email = lines[4];
                FajlDatabase.username = username;
                FajlDatabase.password = pasword;
                //FajlDatabase.email = email;
                database.ertekado();
                SceneManager.LoadSceneAsync("MENU");
                //StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
                return;
            }
        }
        catch
        {
            FajlDatabase.start();
            if (File.Exists(FajlDatabase.FilePath.ToString()))
            {
                string[] lines = FajlDatabase.ReadDataFromFile();
                database.gamedata = lines[1];
                username = lines[2];
                pasword = lines[3];
                //email = lines[4];
                FajlDatabase.username = username;
                FajlDatabase.password = pasword;
                //FajlDatabase.email = email;
                database.ertekado();
                SceneManager.LoadSceneAsync("MENU");
                //StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
                return;
            }
        }
    }

    public void ClosePopUp(GameObject obj)
    {
        /*firstLoadingscene.SetActive(false);
        SecondLoadingScene.SetActive(true);*/
        try
        {
            if (File.Exists(FajlDatabase.FilePath.ToString()))
            {
                LoadSceneSecond.SetActive(true);
            }
        }
        catch
        {
            if (File.Exists(FajlDatabase.FilePath.ToString()))
            {
                LoadSceneSecond.SetActive(true);
            }
        }
        obj.SetActive(false);
        egybolbejelentkezes();
    }
    public void OpenUrl(string url)
    {
        if (!WifiBool)
        {
            Instantiate(WifiBlock);
            return;
        }
        Application.OpenURL(url);
    }

}
