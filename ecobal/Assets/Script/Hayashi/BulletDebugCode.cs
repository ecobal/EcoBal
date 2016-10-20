using UnityEngine;
using System.Collections;

public class BulletDebugCode : MonoBehaviour {

    Player_Shoot shot;

	// Use this for initialization
	void Start () {
        shot = GetComponent<Player_Shoot>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha0)) shot.DefaultBulletID = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha1)) shot.DefaultBulletID = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) shot.DefaultBulletID = 2;

	
	}
}
