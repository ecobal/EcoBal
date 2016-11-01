using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Icon_Controller : MonoBehaviour {

    public Sprite[] sprite = new Sprite[2];
    public GameObject player;
    Player_Shoot Bullet;
    bool isFront;
    int BulletID;
	// Use this for initialization
	void Start () {
        if (this.name == "Icon_Front") isFront = true;
        Bullet = player.GetComponent<Player_Shoot>();
        BulletID = Bullet.GetSpecialBullet();
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Image>().fillAmount = Bullet.SpecialBulletProportion();


        BulletID = (int)player.GetComponent<Player_Shoot>().shootbullet;
        switch (BulletID)
        {
            case 0:
                GetComponent<Image>().enabled = false;
                break;
            case 1:
                GetComponent<Image>().enabled = true;
                GetComponent<Image>().sprite = sprite[0];
                break;
            case 2:
                GetComponent<Image>().enabled = true;
                GetComponent<Image>().sprite = sprite[1];
                break;

        }

    }
}
