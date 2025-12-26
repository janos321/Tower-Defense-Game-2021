using UnityEngine;
using MySql.Data.MySqlClient;
using System;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Globalization;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Win32;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using UnityEngine.Networking;
using System.Collections;
//using System.Data.SqlClient;

public class database : MonoBehaviour
{

    public List<string> PingTargets = new List<string>();
    public static List<string> PingTarget = new List<string>();
    public static string url = "https://towerdefense.rs/";
    public static string gamedata = ""; //string amiben a jatekos adatai lesznek, kiveve jelszo email nev, azok kulon



    public static int HS, LIGUPG,LIGB,LIGA, QUIUPG,QUIB,QUIA, EGYUPG,EGYB,EGYA, BQSUPG,BQSB,BQSA, GDC, STC, Q, ILO, AUD;
    public static int[] ALN = new int[9];
    public static int[] MAP = new int[10];
    public static List<int> DEC = new List<int>();
    public static string LNG;
    public static DateTime FVT;
    private void Start()
    {
        for(int i=0;i<PingTargets.Count;i++)
        {
            PingTarget.Add(PingTargets[i]);
        }
    }

    public static void ertekado()
    {
        //FillGameDataString();
        HS = int.Parse(gamedata.Substring(gamedata.IndexOf("HS") + 3, 1));
        for (int i = 0; i < 9; i++)
        {
            ALN[i] = int.Parse(gamedata.Substring(gamedata.IndexOf("ALN") + 4 + i, 1));
        }
        for (int i = 0; i < 10; i++)
        {
            MAP[i] = int.Parse(gamedata.Substring(gamedata.IndexOf("MAP") + 4 + i, 1));
        }
        LIGUPG = int.Parse(gamedata.Substring(gamedata.IndexOf("LIGUPG") + 7, 1));
        LIGB = int.Parse(gamedata.Substring(gamedata.IndexOf("LIGB") + 5, 1));
        LIGA = int.Parse(gamedata.Substring(gamedata.IndexOf("LIGA") + 5, 1));
        QUIUPG = int.Parse(gamedata.Substring(gamedata.IndexOf("QUIUPG") + 7, 1));
        QUIB = int.Parse(gamedata.Substring(gamedata.IndexOf("QUIB") + 5, 1));
        QUIA = int.Parse(gamedata.Substring(gamedata.IndexOf("QUIA") + 5, 1));
        EGYUPG = int.Parse(gamedata.Substring(gamedata.IndexOf("EGYUPG") + 7, 1));
        EGYB = int.Parse(gamedata.Substring(gamedata.IndexOf("EGYB") + 5, 1));
        EGYA = int.Parse(gamedata.Substring(gamedata.IndexOf("EGYA") + 5, 1));
        BQSUPG = int.Parse(gamedata.Substring(gamedata.IndexOf("BQSUPG") + 7, 1));
        BQSB = int.Parse(gamedata.Substring(gamedata.IndexOf("BQSB") + 5, 1));
        BQSA = int.Parse(gamedata.Substring(gamedata.IndexOf("BQSA") + 5, 1));
        GDC = 0;
        int j = 0, a;
        while (j >= 0)
        {
            try
            {
                a = int.Parse(gamedata.Substring(gamedata.IndexOf("GDC") + 4 + j, 1));
                GDC = GDC * 10 + a;
                j++;
            }
            catch
            {
                break;
            }
        }
        STC = 0;
        j = 0;
        while (j >= 0)
        {
            try
            {
                a = int.Parse(gamedata.Substring(gamedata.IndexOf("STC") + 4 + j, 1));
                STC = STC * 10 + a;
                j++;
            }
            catch
            {
                break;
            }
        }
        Q = int.Parse(gamedata.Substring(gamedata.IndexOf("Q:") + 2, 1));
        ILO = int.Parse(gamedata.Substring(gamedata.IndexOf("ILO:") + 4, 1));
        AUD = int.Parse(gamedata.Substring(gamedata.IndexOf("AUD:") + 4, 1));
        LNG = gamedata.Substring(gamedata.IndexOf("LNG:") + 4, 2);
        int k = gamedata.IndexOf("DEC:") + 4;
        DEC.Clear();
        while (gamedata[k] != '|')
        {
            if (gamedata[k] == '#')
            {
                DEC.Add(int.Parse(gamedata.Substring(k + 1, 1)) * 10 + int.Parse(gamedata.Substring(k + 2, 1)));
                k += 3;
            }
            else
            {
                DEC.Add(int.Parse(gamedata.Substring(k, 1)));
                k++;
            }
        }
        //gamedata += "FVT:2004. 9. 4. 13:01:27|";
        int hosz = 0, indexx = gamedata.IndexOf("FVT:") + 4;
        while (gamedata[indexx] !='|')
        {
            hosz++;
            indexx++;
        }
        FVT = DateTime.Parse(gamedata.Substring(gamedata.IndexOf("FVT:") + 4, hosz));
        k = gamedata.IndexOf("TIMER:") + 6;
        List<int> szamjegyek = new List<int>();
        while (gamedata[k] != '|')
        {
            szamjegyek.Add(int.Parse(gamedata.Substring(k, 1)));
                k++;
        }
        for(int i=szamjegyek.Count-1,nez=1;i>=0;i--,nez*=10)
        {
            MENUGamobjects.Timer += szamjegyek[i] * nez;
        }
    }
    public static void FillGameDataString()
    {
        string heroshopnumber = "HS:4|";

        string kilencelemutomb = "ALN:111101111|";

        string lightning = "LIGUPG:1|LIGB:0|LIGA:0|";

        string quicksand = "QUIUPG:1|QUIB:0|QUIA:0|";

        string egyptiangod = "EGYUPG:1|EGYB:0|EGYA:0|";

        string bigquicksand = "BQSUPG:1|BQSB:0|BQSA:0|";

        string greendiamondcounter = "GDC:100|";

        string starcounter = "STC:0|";

        string queen = "Q:1|";

        string maps = "MAP:0000000000|";

        string tobbi = "ILO:0|LNG:EN|AUD:0|";

        string Deck = "DEC:0000000|";
        DateTime mai = DateTime.Now;
        mai = mai.AddDays(-1);
        string FreeVideoTime = "FVT:"+ mai.ToString()+"|";

        string timer = "TIMER:0|";

        gamedata = heroshopnumber + kilencelemutomb + lightning + quicksand
            + egyptiangod + bigquicksand + greendiamondcounter + starcounter + queen + maps + tobbi+ Deck+ FreeVideoTime+timer;


        ertekado();

    }

    public static void InsertPlayTime(string username, float playtime)
    {
        try
        {
            String username1 = HttpUtility.UrlEncode(username);
            String playtime1 = HttpUtility.UrlEncode(playtime.ToString());


            string response = SendPost(url + "InsertPlayTime.php", String.Format("username={0}&playtime={1}", username1, playtime1));

            Console.WriteLine(response);
        }
        catch (Exception error1)
        {
            //hiba dobas
            Console.WriteLine(error1.Message);
        }
    }
    public static void transforms()
    {
        string heroshopnumber = "HS:" + HS.ToString() + "|"; //HS = 4;

        string kilencelemutomb = "ALN:" + ALN[0].ToString() + ALN[1].ToString() + ALN[2].ToString() + ALN[3].ToString() + ALN[4].ToString() + ALN[5].ToString() + ALN[6].ToString() + ALN[7].ToString() + ALN[8].ToString() + "|";//ALN[0] = 1; ALN[1] = 1; ALN[2] = 1; ALN[3] = 0; ALN[4] = 1; ALN[5] = 1; ALN[6] = 1; ALN[7] = 1; ALN[8] = 1;

        string lightning = "LIGUPG:" + LIGUPG.ToString() + "|LIGB:" + LIGB.ToString() + "|LIGA:" + LIGA.ToString() + "|"; //LIGUPG = 1; LIGB = 0; LIGA = 0;

        string quicksand = "QUIUPG:" + QUIUPG.ToString() + "|QUIB:" + QUIB.ToString() + "|QUIA:" + QUIA.ToString() + "|"; //QUIUPG = 1; QUIB = 0; QUIA = 0;

        string egyptiangod = "EGYUPG:" + EGYUPG.ToString() + "|EGYB:" + EGYB.ToString() + "|EGYA:" + EGYA.ToString() + "|"; //EGYUPG = 1; EGYB = 0; EGYA = 0;

        string bigquicksand = "BQSUPG:" + BQSUPG.ToString() + "|BQSB:" + BQSB.ToString() + "|BQSA:" + BQSA.ToString() + "|"; //BQSUPG = 1; BQSB= 0; BQSA = 0;

        string greendiamondcounter = "GDC:" + GDC.ToString() + "|"; //GDC = 100;

        string starcounter = "STC:" + STC.ToString() + "|"; //STC = 0;

        string queen = "Q:" + Q.ToString() + "|";//Q = 1;

        string maps = "MAP:" + MAP[0].ToString() + MAP[1].ToString() + MAP[2].ToString() + MAP[3].ToString() + MAP[4].ToString() + MAP[5].ToString() + MAP[6].ToString() + MAP[7].ToString() + MAP[8].ToString() + MAP[9].ToString() + "|";//MAP[0] = 0; MAP[1] = 0; MAP[2] = 0; MAP[3] = 0; MAP[4] = 0; MAP[5] = 0; MAP[6] = 0; MAP[7] = 0; MAP[8] = 0; MAP[9] = 0;

        string tobbi = "ILO:"+ILO+"|LNG:"+LNG+"|AUD:"+AUD+"|";//Q = 1;

        string Deck = "DEC:";

        for (int i=0;i<DEC.Count;i++)
        {
            if (DEC[i]<10)
            {
                Deck += DEC[i];
            }
            else
            {
                Deck += "#";
                Deck += (int)(DEC[i] / 10);
                Deck += DEC[i] % 10;
            }
        }
        Deck += "|";


        string FreeVideoTime = "FVT:"+ FVT.ToString() +"|";

        string timer = "TIMER:" + Mathf.Ceil( MENUGamobjects.Timer).ToString() + "|";

        gamedata = heroshopnumber + kilencelemutomb + lightning + quicksand
        + egyptiangod + bigquicksand + greendiamondcounter + starcounter + queen + maps + tobbi + Deck + FreeVideoTime+timer;
;
    }
    //MOVED TO PHP !!!!
    public static void UpdateDatabase(string nickname, string password) //itt updatelunk mikor mar regisztralt az ember
    {
        transforms();
        String username1 = HttpUtility.UrlEncode(nickname);
        String password1 = HttpUtility.UrlEncode(password);
        String gamedata1 = HttpUtility.UrlEncode(gamedata);

        string response = SendPost(url + "UpdateUserGameData.php", String.Format("username={0}&password_={1}&gamedata={2}", username1, password1, gamedata1));

    }


    //**MOVED TO PHP !!!!
    public static void WriteIntoDatabase(string nickname, string email, string password) //adatbazisba iras
    {
        FajlDatabase.WriteIntoTxtFile();
        WebClient client = new WebClient();
        NameValueCollection UserInfo = new NameValueCollection();
        UserInfo.Add("username", nickname);
        UserInfo.Add("email", email);
        UserInfo.Add("password_", password);
        UserInfo.Add("gamedata", gamedata);

        byte[] InsertUser = client.UploadValues(url + "InsertUser.php", "POST", UserInfo);

        client.Headers.Add("Content-Type", "binary/octet-stream");

    }





    //olvasas az adatbazisbol

    /*MOVED TO PHP !!!!*/
    public static void ReadFromDatabase(string nickname, string password)
    {
        // WebClient client = new WebClient();

        String username = HttpUtility.UrlEncode(nickname);
        String password_ = HttpUtility.UrlEncode(password);


        gamedata = SendPost(url +"SelectGameData.php", String.Format("username={0}&password_={1}", username, password_));

        LogInRegisztrelScript.reserve = false;
        if (gamedata.Length >5)
        {
            LogInRegisztrelScript.reserve = true;
            ertekado();
        }



    }



    //torles az adatbazisbol

    /*MOVED TO PHP !!!!*/
    public static void DeleteUserFromDB(string nickname, string password)
    {
        try
        {
            String username = HttpUtility.UrlEncode(nickname);
            String password_ = HttpUtility.UrlEncode(password);


            string response = SendPost(url + "DeleteUser.php", String.Format("username={0}&password_={1}", username, password_));

            Console.WriteLine(response);
        }
        catch (Exception error1)
        {
            //hiba dobas
            Console.WriteLine(error1.Message);
        }


    }

    // MOVED TO PHP !!!!
    public static int CheckIfThisExists(string username, string email)
    {
        String username1 = HttpUtility.UrlEncode(username);
        String email1 = HttpUtility.UrlEncode(email);

        string response = SendPost(url + "CheckIfThisExists.php", String.Format("username={0}&email={1}", username1, email1));

        return Convert.ToInt32(response);
    }

    public static void SendComplaint(string content)
    {
        try
        {
            String content1 = HttpUtility.UrlEncode(content);
            String currentime = HttpUtility.UrlEncode(DateTime.UtcNow.ToString());


            string response = SendPost(url + "SendComplaint.php", String.Format("content={0}&timedata={1}", content1, currentime));

        }
        catch (Exception error1)
        {
            //hiba dobas
        }


    }

    // MOVED TO PHP !!!!
    public static void UpdateUserPassword(string nickname, string email, string newpassword)
    {

        String username = HttpUtility.UrlEncode(nickname);
        String newpassword1 = HttpUtility.UrlEncode(newpassword);
        String email1 = HttpUtility.UrlEncode(email);

        string response = SendPost(url + "UpdateUserPassword.php", String.Format("username={0}&newpassword={1}&email={2}", username, newpassword1, email1));

        Console.WriteLine(response);

    }


    //MOVED TO PHP !!!!
    public static bool CheckIfThisUserExists(string username, string email)
    {
        String username1 = HttpUtility.UrlEncode(username);
        String email1 = HttpUtility.UrlEncode(email);

        string response = SendPost(url+"CheckIfUserExists.php", String.Format("username={0}&email={1}", username1, email1));
        // Console.WriteLine(response);
        if (response == "1")
        {
            return true;
        }
        else
        {
            return false;
        }




    }

    /*public static bool IsConnectedToInternet()
    {
        try
        {

            string culture = CultureInfo.CurrentCulture.EnglishName;
            string country = System.Globalization.RegionInfo.CurrentRegion.EnglishName;


            System.Net.NetworkInformation.Ping myPing = new System.Net.NetworkInformation.Ping();
            String host = "";
            if (country == "China")
            {
                host = "baidu.com";
            }
            if (country == "Iran")
            {
                host = "aparat.com";
            }
            else
            {
                host = "google.com";
            }

            byte[] buffer = new byte[32];
            int timeout = 2000;
            PingOptions pingOptions = new PingOptions();
            PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
            return (reply.Status == IPStatus.Success);
        }
        catch (Exception)
        {
            return false;
        }
    }*/

    public static IEnumerator CheckInternetConnection1(Action<bool> action,int randomNumber)
    {
       // Debug.Log(PingTarget[randomNumber]);
        UnityWebRequest request = new UnityWebRequest(PingTarget[randomNumber]);
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            Debug.Log(PingTarget[randomNumber]);
            action(false);
        }
        else
        {
            action(true);
        }
    }
    

    /*public static IEnumerator CheckInternetConnection2(Action<bool> syncResult)
    {
        const string echoServer = "http://google.com";

        bool result;
        using (var request = UnityWebRequest.Head(echoServer))
        {
            request.timeout = 5;
            yield return request.SendWebRequest();
            result = !request.isNetworkError && !request.isHttpError && request.responseCode == 200;
        }
        syncResult(result);
    }
    */
    public static string SendPost(string url, string postData)
    {
        string webpageContent = string.Empty;

        try
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;

            using (Stream webpageStream = webRequest.GetRequestStream())
            {
                webpageStream.Write(byteArray, 0, byteArray.Length);
            }

            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                {
                    webpageContent = reader.ReadToEnd();
                }
            }
        }
        catch (Exception ex)
        {
            //throw or return an appropriate response/exception
        }

        return webpageContent;
    }

    public static string FetchUsernameThroughEmail(string email)
    {
        String email1 = HttpUtility.UrlEncode(email);


        //The username is stored in this string - ebben a stringben lesz a username
        string username = SendPost(url + "FetchUsernameThroughEmail.php", String.Format("email={0}", email1));

        return username;

    }

    public static string ChangeUsernameThroughOldUsernameAndPassword(string oldname, string password, string newname)
    {
        String oldname1 = HttpUtility.UrlEncode(oldname);
        String newn1 = HttpUtility.UrlEncode(newname);
        String pass1 = HttpUtility.UrlEncode(password);

        //The response is stored in this string - ebben a stringben lesz a valasz
        string username = SendPost(url + "ChangeUsernameThroughOldUsernameAndPassword.php", String.Format("oldname={0}&newname={1}&password={2}", oldname1, newn1, pass1));

        return username;

    }

}
