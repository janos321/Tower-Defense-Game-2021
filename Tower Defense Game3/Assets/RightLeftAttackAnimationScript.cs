using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftAttackAnimationScript : MonoBehaviour
{

    public GameObject Right;
    //public GameObject Left;
    //public GameObject DirectionMother;
    public int Direction;
    void Update()
    {
        if (Direction == 0)
        {
            gameObject.GetComponent<Animator>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<Animator>().enabled = true;
            if (Direction == 3)
            {
                Right.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(Right.transform.rotation.x, 180f, 0f));
                gameObject.GetComponent<Animator>().Play("Right");
            }
            else
                if (Direction == 4)
            {
                Right.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(Right.transform.rotation.x, 0f, 0f));
                gameObject.GetComponent<Animator>().Play("Right");
            }
        }
    }
}
