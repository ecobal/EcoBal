using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {


    [SerializeField, Tooltip("弾速")]
    public float BulletSpeed;

    [SerializeField, Tooltip("射程")]
    public float LimitRange;

    [SerializeField, Tooltip("弾のプレハブ")]
    public GameObject BulletPrefab;
    GameObject Bullet;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) Shoot();
	
	}

    void Shoot()
    {
        Bullet = Instantiate(BulletPrefab, transform.position+transform.forward*0.5f, transform.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * BulletSpeed);

    }
}
