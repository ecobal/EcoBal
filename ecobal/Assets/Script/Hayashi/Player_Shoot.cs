using UnityEngine;
using System.Collections;

public class Player_Shoot : MonoBehaviour {


    [SerializeField, Tooltip("弾速")]
    public float BulletSpeed;

    [SerializeField, Tooltip("射程")]
    public float LimitRange;

    [SerializeField, Tooltip("弾のプレハブ")]
    public GameObject normalBullet;
    public GameObject PenertrateBullet;
    public GameObject ShotShell;
    GameObject Bullet;

    public enum ShootBullet
    {
        Normal,
        Penatrte,
        ShellShot

    }

    public ShootBullet shootbullet;
    public int DefaultBulletID;
	// Use this for initialization
	void Start () {
        shootbullet = (ShootBullet)DefaultBulletID;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) Shoot();
	
	}

    void Shoot()
    {
        GameObject bulletprefab =null;
        switch (shootbullet)
        {
            case ShootBullet.Normal:
                bulletprefab = normalBullet;
                break;
            case ShootBullet.Penatrte:
                bulletprefab = PenertrateBullet;
                break;
            case ShootBullet.ShellShot:
                bulletprefab = ShotShell;
                break;
        }
        Bullet = Instantiate(bulletprefab, transform.position+transform.forward*0.5f, transform.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * BulletSpeed);
        if (shootbullet != 0) shootbullet = (ShootBullet)DefaultBulletID;

    }

    public void GetSpecialBullet(int number)
    {
        shootbullet = (ShootBullet)number;
    }
}
