using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Icon_Controller : MonoBehaviour {

    public Sprite[] sprite = new Sprite[2];
    public GameObject player;
    int BulletID;

	// Use this for initialization
	void Start () {
        BulletID = (int)player.GetComponent<Player_Shoot>().shootbullet;
	
	}
	
	// Update is called once per frame
	void Update () {
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
