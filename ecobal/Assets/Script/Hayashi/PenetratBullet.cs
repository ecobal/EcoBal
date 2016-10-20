using UnityEngine;
using System.Collections;

public class PenetratBullet : MonoBehaviour {

    float PenetratSpeed = 0;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        PenetratSpeed = player.GetComponent<Player_Shoot>().BulletSpeed * 2;

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy") Destroy(col.gameObject);

    }

}
