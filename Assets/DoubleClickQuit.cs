using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleClickQuit : MonoBehaviour
{
    private bool isPaused=true;

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                { // if game is not yet paused, ESC will pause it
                    isPaused = false;
                    StartCoroutine(varakoztatas(1.5f));
                }
                else
                { // if game is paused and ESC is pressed, it's the second press. QUIT
                    Application.Quit();
                }
            }
            else
               if (Input.GetKeyDown(KeyCode.Home))
            {
                if (isPaused)
                { // if game is not yet paused, ESC will pause it
                    isPaused = false;
                    StartCoroutine(varakoztatas(1.5f));
                }
                else
                { // if game is paused and ESC is pressed, it's the second press. QUIT
                    Application.Quit();
                }
            }
            else
               if (Input.GetKeyDown(KeyCode.Menu))
            {
                if (isPaused)
                { // if game is not yet paused, ESC will pause it
                    isPaused = false;
                    StartCoroutine(varakoztatas(1.5f));
                }
                else
                { // if game is paused and ESC is pressed, it's the second press. QUIT
                    Application.Quit();
                }
            }
        }
    }
    IEnumerator varakoztatas(float Timee)
    {
        float Timer = 0;
        while(Timer<Timee)
        {
            yield return Timer += Time.deltaTime;
        }
        isPaused = true;
    }
}
