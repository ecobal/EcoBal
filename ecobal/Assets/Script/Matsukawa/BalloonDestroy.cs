using UnityEngine;
using System.Collections;

public class BalloonDestroy : MonoBehaviour
{
    public GameObject deathEffect;
    public GameObject deathEffectExplosion;

    public bool explosion;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player") Destroy(gameObject);
    }

    void OnDestroy()
    {
        if (explosion) Instantiate(deathEffectExplosion, transform.position, transform.rotation);
        else if (!explosion) Instantiate(deathEffect, transform.position, transform.rotation);
    }
}
