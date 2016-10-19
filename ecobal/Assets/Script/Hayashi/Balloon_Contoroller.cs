using UnityEngine;
using System.Collections;

public class Balloon_Contoroller : MonoBehaviour {

    public GameObject deathEffect;
    public GameObject deathEffectExplosion;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DestroyObject()
    {
        Destroy(transform.parent.gameObject);
        Instantiate(deathEffect, transform.position, transform.rotation);
    }

    void ExplosionObject()
    {
        Destroy(transform.parent.gameObject);
        Instantiate(deathEffectExplosion, transform.position, transform.rotation);
    }
}
