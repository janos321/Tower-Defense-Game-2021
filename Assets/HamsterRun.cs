using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterRun : MonoBehaviour
{
    public GameObject cel;
    public GameObject indulas;
    public List<Sprite> HumsterPics = new List<Sprite>();
    public float RunTime=2;
    private float Timer=0,animationTime=0;
    private int index = 0;
    void Update()
    {
        if(gameObject.active&&cel!=null&&indulas!=null)
        {
            if(animationTime<=0)
            {
                if(index+1== HumsterPics.Count)
                {
                    index = 0;
                }
                else
                { 
                    index++;
                }
                gameObject.GetComponent<SpriteRenderer>().sprite = HumsterPics[index];
                animationTime = 0.1f;
            }
            animationTime -= Time.deltaTime;
            if (Timer> RunTime)
            {
                Destroy(gameObject);
            }
            else
            {
                Timer += Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(indulas.transform.position, cel.transform.position, Timer / RunTime);
            }
        }
    }
}
