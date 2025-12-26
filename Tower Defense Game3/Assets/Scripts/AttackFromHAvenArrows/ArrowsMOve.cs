using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsMOve : MonoBehaviour
{
    private float present = 0;
    void Start()
    {
        StartCoroutine(ArrowsDown(1f));


    }

    IEnumerator ArrowsDown(float time)
    {
        while (present <= time)
        {
            present += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(AllGameObject.APositionAttack.position, AllGameObject.BPositionAttack.position, (present) / time );//AllGameObject.Arrowsoblique.Evaluate(present / time));
            yield return null;
        }
        Destroy(gameObject);

    }
}
