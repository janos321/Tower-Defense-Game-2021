using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCactusChooseCube : MonoBehaviour
{
    private int random = 0;
    public GameObject Cube;
    public List<Sprite> CubeSide = new List<Sprite>();
    private int Choose1 = -1;
    public Color ChooseButtonColor;
    public List<GameObject> buttons = new List<GameObject>();
    void Start()
    {
        random = Random.Range(0, 6);
    }

    public void Choose(int Choose)
    {
        buttons[Choose].GetComponent<SpriteRenderer>().color = ChooseButtonColor;
        if (Choose1 == -1)
        {
            Choose1 = Choose;
            return;
        }
        LuckyCactus.forog = false;
        Cube.transform.eulerAngles = new Vector3(0, 0, 0);
        Cube.transform.GetComponent<SpriteRenderer>().sprite = CubeSide[random];
        StartCoroutine(Varas(1.5f, Choose1, Choose));
    }

    public IEnumerator Varas(float a, int Choose1, int Choose2)
    {
        float Timerr = 0;
        while (Timerr < a)
        {
            yield return Timerr += Time.deltaTime;
        }
        if (Choose1 == random|| Choose2 == random)
        {
            //winner
            MiniGameAllScript.MinigameAllScriptGameobject.GetComponent<MiniGameAllScript>().Winner();
        }
        else
        {
            //Continue
            MiniGameAllScript.PauseButtonImageLocation.SetActive(true);
            MiniGameAllScript.PauseButtonImageLocation.GetComponent<MiniPousIMageGAme>().OnMouseDown();
            MiniGameAllScript.LuckyPanel2.SetActive(false);
        }
    }
}
