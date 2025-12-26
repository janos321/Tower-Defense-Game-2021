using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

public class FajlDatabase : MonoBehaviour
{
    //ide megy a txt file helye
    // File.WriteAllText(fileName, "input content");
    //public static string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "temp.txt");
    public static FileInfo FilePath ;

    public static int Key = 1;
    public static bool changedfirst = false;
    public static bool changedsecond = false;
    public static bool changedthird = false;

    public static string username = "";
    public static string password = "";


    private void Start()
    {
        start();
    }
    public static void start()
    {
        FilePath = new FileInfo(Application.persistentDataPath + @"/" + "temp.txt");
    }

    public static void DeleteFile()
    {
        if (File.Exists(FilePath.ToString()))
        {
            File.Delete(FilePath.ToString());

        }
    }

    public static void EncryptFile()
    {
        if (File.Exists(FilePath.ToString()))
        {
            string[] lines = null;
            lines = File.ReadAllLines(FilePath.ToString());
            Key = Convert.ToInt32(lines[0]);

            string first = lines[1];
            string second = lines[2];
            string third = lines[3];

            string new1 = "", new2 = "", new3 = "";

            byte[] firstAscii = Encoding.ASCII.GetBytes(first);
            byte[] secondAScii = Encoding.ASCII.GetBytes(second);
            byte[] thirdAscii = Encoding.ASCII.GetBytes(third);
            foreach (int item in firstAscii)
            {
                int newcode = item + Key;
                if (newcode == 10)
                {
                    newcode += 1;
                    changedfirst = true;
                }

                char character = (char)newcode;
                string text = character.ToString();


                char character2, character3, character4, character5;
                if (newcode - 1 == 10)
                {
                    character2 = (char)(newcode);
                    character3 = (char)(newcode + 1);
                    character4 = (char)(newcode);
                    character5 = (char)(newcode + 1);
                }
                else
                {

                    character2 = (char)(newcode + 1);
                    character3 = (char)(newcode - 1);
                    character4 = (char)(newcode + 1);
                    character5 = (char)(newcode - 1);
                }

                string text2 = character2.ToString();

                string text3 = character3.ToString();

                string text4 = character4.ToString();

                string text5 = character5.ToString();

                string toadd = text + text2 + text3 + text4 + text5;

                new1 += toadd;

            }

            foreach (int item in secondAScii)
            {
                int newcode = item + Key;
                if (newcode == 10)
                {
                    newcode += 1;
                    changedsecond = true;
                }

                char character = (char)newcode;
                string text = character.ToString();


                char character2, character3, character4, character5;
                if (newcode - 1 == 10)
                {
                    character2 = (char)(newcode);
                    character3 = (char)(newcode + 1);
                    character4 = (char)(newcode);
                    character5 = (char)(newcode + 1);
                }
                else
                {

                    character2 = (char)(newcode + 1);
                    character3 = (char)(newcode - 1);
                    character4 = (char)(newcode + 1);
                    character5 = (char)(newcode - 1);
                }

                string text2 = character2.ToString();

                string text3 = character3.ToString();

                string text4 = character4.ToString();

                string text5 = character5.ToString();

                string toadd = text + text2 + text3 + text4 + text5;

                new2 += toadd;

            }
            foreach (int item in thirdAscii)
            {
                int newcode = item + Key;
                if (newcode == 10)
                {
                    newcode += 1;
                    changedthird = true;
                }

                char character = (char)newcode;
                string text = character.ToString();


                char character2, character3, character4, character5;
                if (newcode - 1 == 10)
                {
                    character2 = (char)(newcode);
                    character3 = (char)(newcode + 1);
                    character4 = (char)(newcode);
                    character5 = (char)(newcode + 1);
                }
                else
                {

                    character2 = (char)(newcode + 1);
                    character3 = (char)(newcode - 1);
                    character4 = (char)(newcode + 1);
                    character5 = (char)(newcode - 1);
                }

                string text2 = character2.ToString();

                string text3 = character3.ToString();

                string text4 = character4.ToString();

                string text5 = character5.ToString();

                string toadd = text + text2 + text3 + text4 + text5;

                new3 += toadd;

            }


            username = new2;
            password = new3;

            DeleteFile();
            WriteIntoTxtFileAfterEnc(new1);

        }
    }
    public static void DecryptFile()
    {
        if (File.Exists(FilePath.ToString()))
        {
            string[] lines = null;
            lines = File.ReadAllLines(FilePath.ToString());



            Key = Convert.ToInt32(lines[0]);

            string first = lines[1];
            string second = lines[2];
            string third = lines[3];

            string bools = lines[4];
            if (Convert.ToInt32(bools[0]) == 1)
            {
                changedfirst = true;
            }
            if (Convert.ToInt32(bools[1]) == 1)
            {
                changedsecond = true;
            }
            if (Convert.ToInt32(bools[2]) == 1)
            {
                changedthird = true;
            }


            string new1 = "", new2 = "", new3 = "";

            byte[] firstAscii = Encoding.ASCII.GetBytes(first);
            byte[] secondAscii = Encoding.ASCII.GetBytes(second);
            byte[] thirdAscii = Encoding.ASCII.GetBytes(third);


            for (int i = 0; i < firstAscii.Length; i += 5)
            {
                int encryptedcode = firstAscii[i];

                int original = encryptedcode - Key;
                if (changedfirst)
                {
                    original -= 1;
                }

                char character5 = (char)(original);
                string text = character5.ToString();

                new1 += text;

            }

            for (int i = 0; i < secondAscii.Length; i += 5)
            {
                int encryptedcode = secondAscii[i];

                int original = encryptedcode - Key;
                if (changedsecond)
                {
                    original -= 1;
                }

                char character5 = (char)(original);
                string text = character5.ToString();

                new2 += text;

            }

            for (int i = 0; i < thirdAscii.Length; i += 5)
            {
                int encryptedcode = thirdAscii[i];

                int original = encryptedcode - Key;
                if (changedthird)
                {
                    original -= 1;
                }

                char character5 = (char)(original);
                string text = character5.ToString();

                new3 += text;

            }

            username = new2;
            password = new3;

            DeleteFile();
            WriteIntoTxtFileAfterDec(new1);

        }
    }

    public static string[] ReadDataFromFile()
    {
        string[] lines = null;
        try
        {

            if (File.Exists(FilePath.ToString()))
            {
                DecryptFile();

                lines = File.ReadAllLines(FilePath.ToString());

                EncryptFile();
            }

        }
        catch (Exception Ex)
        {
            Debug.Log(Ex);
        }
        return lines;
    }

    public static void WriteIntoTxtFile(/*string username, string password_*/)
    {
        database.transforms();
        try
        {

            if (File.Exists(FilePath.ToString()))
            {
                DeleteFile();
            }
            // DecryptFile();
            using (FileStream fs = File.Create(FilePath.ToString()))
            {
                // Add some text to file    
                Byte[] key = new UTF8Encoding(true).GetBytes($"{Key}\n");
                fs.Write(key, 0, key.Length);

                Byte[] gamedata1 = new UTF8Encoding(true).GetBytes($"{database.gamedata}\n"); //database.gamedata
                fs.Write(gamedata1, 0, gamedata1.Length);

                Byte[] usern = new UTF8Encoding(true).GetBytes($"{LogInRegisztrelScript.username}\n");
                fs.Write(usern, 0, usern.Length);

                Byte[] pass = new UTF8Encoding(true).GetBytes($"{LogInRegisztrelScript.pasword}\n");
                fs.Write(pass, 0, pass.Length);



            }
            EncryptFile();




        }
        catch (Exception Ex)
        {
            Debug.Log(Ex);
        }
    }

    public static void WriteIntoTxtFileAfterDec(string gamedata)
    {
        try
        {

            if (File.Exists(FilePath.ToString()))
            {
                DeleteFile();
            }


            // DecryptFile();
            using (FileStream fs = File.Create(FilePath.ToString()))
            {
                // Add some text to file    
                Byte[] key = new UTF8Encoding(true).GetBytes($"{Key}\n");
                fs.Write(key, 0, key.Length);


                Byte[] gamedata1 = new UTF8Encoding(true).GetBytes($"{gamedata}\n");
                fs.Write(gamedata1, 0, gamedata1.Length);

                Byte[] usern = new UTF8Encoding(true).GetBytes($"{username}\n");
                fs.Write(usern, 0, usern.Length);

                Byte[] pass = new UTF8Encoding(true).GetBytes($"{password}\n");
                fs.Write(pass, 0, pass.Length);



            }

        }
        catch (Exception Ex)
        {
            //Console.WriteLine(Ex.ToString());
        }
    }

    public static void WriteIntoTxtFileAfterEnc(string gamedata)
    {
        try
        {

            if (File.Exists(FilePath.ToString()))
            {
                DeleteFile();
            }


            // DecryptFile();
            using (FileStream fs = File.Create(FilePath.ToString()))
            {



                // Add some text to file    
                Byte[] key = new UTF8Encoding(true).GetBytes($"{Key}\n");
                fs.Write(key, 0, key.Length);


                Byte[] gamedata1 = new UTF8Encoding(true).GetBytes($"{gamedata}\n");
                fs.Write(gamedata1, 0, gamedata1.Length);

                Byte[] usern = new UTF8Encoding(true).GetBytes($"{username}\n");
                fs.Write(usern, 0, usern.Length);

                Byte[] pass = new UTF8Encoding(true).GetBytes($"{password}\n");
                fs.Write(pass, 0, pass.Length);
                int first = 0, second = 0, third = 0;
                if (changedfirst)
                {
                    first = 1;
                }
                if (changedsecond)
                {
                    second = 1;

                }
                if (changedthird)
                {
                    third = 1;

                }


                Byte[] boolinfo = new UTF8Encoding(true).GetBytes($"{first}{second}{third}\n");
                fs.Write(boolinfo, 0, boolinfo.Length);


            }




        }
        catch (System.Exception Ex)
        {
            Debug.Log(Ex.ToString());
        }
    }


}
