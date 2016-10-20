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
            Shell[i].transform.rotation = Quaternion.Euler(Random.Range(-SpledRange, SpledRange), Random.Range(-SpledRange, SpledRange), Random.Range(-SpledRange, SpledRange));
            Shell[i].GetComponent<Rigidbody>().AddForce(Shell[i].transform.forward * ShellSpeed);
            //Shell[i].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * ShellSpeed);

            Shell[i].transform.parent = transform;
        }

        //InitShell();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void InitShell()
    {
        foreach(var l in Shell)
        {
            l.transform.position = transform.position;
            l.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            l.transform.rotation = Quaternion.Euler(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
            l.AddComponent<Rigidbody>();
            l.GetComponent<Rigidbody>().AddForce(Vector3.forward * ShellSpeed);
            l.AddComponent<Bullet_Contoller>();



        }
    }
}
