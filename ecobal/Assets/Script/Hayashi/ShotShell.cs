using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShotShell : MonoBehaviour {

    public GameObject ShellBullet;
    public int ShellCount;
    GameObject[] Shell = new GameObject[10];
    float ShellSpeed;
    public float SpledRange;

    GameObject player;

   


	// Use this for initialization
	void Start () {
        Shell = new GameObject[ShellCount];
        player = GameObject.FindGameObjectWithTag("Player");
        ShellSpeed = player.GetComponent<Player_Shoot>().BulletSpeed;
        for (int i = 0; i < Shell.Length-1; i++)
        {
            Shell[i] = Instantiate(ShellBullet,transform.position, transform.rotation) as GameObject;
            Shell[i].transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            Shell[i].transform.rotation = Quaternion.Euler(Random.Range(-SpledRange, SpledRange), transform.localEulerAngles.y - Random.Range(-SpledRange, SpledRange), Random.Range(-SpledRange, SpledRange));
            Shell[i].GetComponent<Rigidbody>().AddForce(Shell[i].transform.forward * ShellSpeed);

            Shell[i].transform.parent = transform;
        }

        //InitShell();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
