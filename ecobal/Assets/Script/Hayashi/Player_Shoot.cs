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
    Transform muzzle;
    public float LimitSpecialTime;
    public float SpecialTime;

    public enum ShootBullet
    {
        Normal,
        Penatrte,
        ShellShot

    }

    public ShootBullet shootbullet;
    public int DefaultBulletID;

    bool isSpecial = false;



	// Use this for initialization
	void Start () {
        muzzle = transform.FindChild("Muzzle");
        SpecialTime = LimitSpecialTime;
        shootbullet = (ShootBullet)DefaultBulletID;
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1")) Shoot();
        if (isSpecial) SpecialBulletTime();
        else if (!isSpecial) SpecialTime = LimitSpecialTime;

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
        Bullet = Instantiate(bulletprefab, muzzle.position, muzzle.rotation) as GameObject;
        Bullet.GetComponent<Rigidbody>().AddForce(muzzle.forward * BulletSpeed);

    }

    void SpecialBulletTime()
    {
        SpecialTime -= Time.deltaTime;
        if (SpecialTime <= 0)
        {
            shootbullet = (ShootBullet)DefaultBulletID;
            isSpecial = false;
        }
    }

    public void SetSpecialBullet(int number)
    {
        shootbullet = (ShootBullet)number;
        SpecialTime = LimitSpecialTime;
        isSpecial = true;
    }

    public int GetSpecialBullet()
    {
        return (int)shootbullet;
    }

    public float SpecialBulletProportion()
    {
        return SpecialTime / LimitSpecialTime;
    }
}
