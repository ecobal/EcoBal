using UnityEngine;
using System.Collections;

public class Time2Death : MonoBehaviour {

    public float deathtime;
    float time;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time >= deathtime) Destroy(gameObject);
	
	}
}
