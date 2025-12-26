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
//using System;

public class LogInRegisztrelScript : MonoBehaviour
{
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
    public static string username, pasword;
    public GameObject EmailPAsswordCanvas;
    public GameObject EmailPAsswordText;
    public GameObject WrongEmailPAsswordText;
    public GameObject EmailText;
    public GameObject NowfiPanel;
    private int r,r2,location=1;
    public GameObject ForgottePasswordCanvas;
    public GameObject ForgotteUserName;
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
    private void Update()
    {
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
    private void Start()
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
                FajlDatabase.username = username;
                FajlDatabase.password = pasword;
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
                FajlDatabase.username = username;
                FajlDatabase.password = pasword;
                database.ertekado();
                SceneManager.LoadSceneAsync("MENU");
                //StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
                return;
            }
        }
         /*if(database.IsConnectedToInternet())
         database.FillUpConnectionString();*/
    }
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
                FajlDatabase.WriteIntoTxtFile();
                StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));
            }
        }
    }
    public void RegisterButton()
    {
        //Regisztrálási adatok  // gamedata string 170karakter
        if (RegisterUsernameText.GetComponent<InputField>().text.Length > 20)
        {
            WrongTextRegister.GetComponent<Text>().text = "Long Username";
        }
        else
        if (RegisterEmailText.GetComponent<InputField>().text.Length > 30)
        {
            WrongTextRegister.GetComponent<Text>().text = "Long Email";
        }
        else
        if (RegisterPasswordText.GetComponent<InputField>().text.Length > 30)
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
            WrongTextRegister.GetComponent<Text>().text = "Short Password";
        }
        else
        {
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
            ForgotteUserName.GetComponent<InputField>().text = "";
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
        if (ForgotteUserName.GetComponent<InputField>().text.Length > 20)
        {
            ForgotteWrongText.GetComponent<Text>().text = "Long Username";
        }
        else
        if (ForgotteEmail.GetComponent<InputField>().text.Length > 30)
        {
            ForgotteWrongText.GetComponent<Text>().text = "Long Email";
        }
        else
                if (ForgotteUserName.GetComponent<InputField>().text.Length == 0)
        {
            ForgotteWrongText.GetComponent<Text>().text = "No Username";
        }
        else
        if (ForgotteEmail.GetComponent<InputField>().text.Length == 0)
        {
            ForgotteWrongText.GetComponent<Text>().text = "No Email";
        }
        else
        {

            if(database.CheckIfThisUserExists(ForgotteUserName.GetComponent<InputField>().text, ForgotteEmail.GetComponent<InputField>().text))
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
                        Text = @"Hello, this is your verification code: " + r2
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
                EmailSend.GetComponent<Text>().text = "Code was sent to this email:" + ForgotteEmail.GetComponent<InputField>().text;


            }
            else
            {
                ForgotteWrongText.GetComponent<Text>().text = "Wrong Email or Username";
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
            database.UpdateUserPassword(ForgotteUserName.GetComponent<InputField>().text, ForgotteEmail.GetComponent<InputField>().text, ChangePasswordText.GetComponent<InputField>().text);
            database.ReadFromDatabase(ForgotteUserName.GetComponent<InputField>().text, ChangePasswordText.GetComponent<InputField>().text);

                username = ForgotteUserName.GetComponent<InputField>().text;
                pasword = ChangePasswordText.GetComponent<InputField>().text;
                FajlDatabase.username = username;
                FajlDatabase.password = pasword;
                database.ILO = 1;
                FajlDatabase.WriteIntoTxtFile();
            StartCoroutine(MENUGamobjects.LoadYourAsyncScene("MENU", LOadingSceneGameobject));

        }
    }

}
