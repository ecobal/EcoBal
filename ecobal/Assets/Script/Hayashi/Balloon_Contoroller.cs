using UnityEngine;
using System.Collections;

public class Balloon_Contoroller : MonoBehaviour {

    public GameObject deathEffect;
    public GameObject deathEffectExposion;

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
}
