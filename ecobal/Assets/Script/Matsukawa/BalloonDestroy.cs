using UnityEngine;
using System.Collections;

public class BalloonDestroy : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject deathEffectExplosion;
    public static bool isQUitting = false;

    public bool explosion;

    void Start()
    {
        isQUitting = false;

    }



    void OnApplicationQuit()
    {
        isQUitting = true;
    }


    void OnDestroy()
    {
        if (!isQUitting)
        {

            if (explosion) Instantiate(deathEffectExplosion, transform.position, transform.rotation);
            else if (!explosion) Instantiate(deathEffect, transform.position, transform.rotation);
        }
    }
}
