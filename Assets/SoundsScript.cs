using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Scripting;

public class SoundsScript : MonoBehaviour
{
    public List<soundsList> SoundsList2 = new List<soundsList>();
    public static List<soundsList> SoundsList = new List<soundsList>();
    public static GameObject Menugameobject = null;

    [System.Serializable]
    public class soundsList
    {
        public string ListName;
        public List<AudioClip> SoundsLists = new List<AudioClip>();
        public float volume = 0.5f;
        public float Pitch = 1;
    }
    public List<sounds> Sounds2 = new List<sounds>();
    public static List<sounds> Sounds = new List<sounds>();

    [System.Serializable]
    public class sounds
    {
        public AudioClip Sound;
        public float volume = 0.5f;
        public float Pitch = 1;

    }



    private void Start()
    {
        Menugameobject = gameObject;
        SoundsList = SoundsList2;
        Sounds = Sounds2;
    }
    public static void MusicStart(GameObject Targy, string nev)
    {

        AudioClip music = null;
        float volume = 0.5f, Pitch = 1;
        if (database.AUD == 1)
            return;
        for (int i = 0; i < SoundsList.Count; i++)
        {
            if (SoundsList[i].ListName == nev)
            {
                int r = Random.Range(0, SoundsList[i].SoundsLists.Count);
                music = SoundsList[i].SoundsLists[r];
                volume = SoundsList[i].volume;
                Pitch = SoundsList[i].Pitch;
                break;
            }
        }
        if (music == null)
        {
            for (int i = 0; i < Sounds.Count; i++)
            {
                if (Sounds[i].Sound.name == nev)
                {
                    music = Sounds[i].Sound;
                    volume = Sounds[i].volume;
                    Pitch = Sounds[i].Pitch;
                    break;
                }
            }

        }
        AudioSource Audio = Targy.AddComponent<AudioSource>();
        Audio.clip = music;
        Audio.volume = volume;
        Audio.pitch = Pitch;
        Audio.Play();
        if (Menugameobject != null)
        {
            Menugameobject.GetComponent<SoundsScript>().DestroyAudio2(Audio.clip.length, Audio, Targy);
        }
        else
           if (LoadAnotherScene.SinglePlayerMenu != null)
        {
            LoadAnotherScene.SinglePlayerMenu.GetComponent<LoadAnotherScene>().DestroyAudio2(Audio.clip.length, Audio, Targy);
        }
        else
                    if (AllGameObject.SinglePlayerMApsAndTutorial != null)
        {
            AllGameObject.SinglePlayerMApsAndTutorial.GetComponent<AllGameObject>().DestroyAudio2(Audio.clip.length, Audio, Targy);
        }
        else
                    if (MiniGameAllScript.MiniGame2 != null)
        {
            MiniGameAllScript.MiniGame2.GetComponent<MiniGameAllScript>().DestroyAudio2(Audio.clip.length, Audio,Targy);
        }
        else
                    if (MultiPlayerMenuAllGameobject.MultiPlayerMenu != null)
        {
            MultiPlayerMenuAllGameobject.MultiPlayerMenu.GetComponent<MultiPlayerMenuAllGameobject>().DestroyAudio2(Audio.clip.length, Audio, Targy);
        }
    }
    public void DestroyAudio2(float timer, AudioSource Sound, GameObject Targy)
    {
        StartCoroutine(DestroyAudio(timer, Sound, Targy));
    }
    public IEnumerator DestroyAudio(float timer, AudioSource Sound, GameObject Targy)
    {
        yield return new WaitForSeconds(timer);
        Component[] Sounds = Targy.GetComponents<AudioSource>();
        for (int i = 0; i < Sounds.Length; i++)
        {
            if (Sounds[i].GetComponent<AudioSource>() == Sound)
            {
                Sounds[i].GetComponent<AudioSource>().mute = true;
                Destroy(Sounds[i].GetComponent<AudioSource>());
            }
        }

    }
}
