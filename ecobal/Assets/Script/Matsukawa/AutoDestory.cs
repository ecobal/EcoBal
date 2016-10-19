using UnityEngine;
using System.Collections;

public class AutoDestory : MonoBehaviour
{

    public float destroyTime;
    private float elapsedTime;

    void Start()
    {
        elapsedTime = 0;
    }

    void Update()
    {
        if(elapsedTime >= destroyTime)
        {
            Destroy(gameObject);
        }

        elapsedTime += 1 * Time.deltaTime;
    }
}
