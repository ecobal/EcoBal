using UnityEngine;
using System.Collections;

public class TakeItem : MonoBehaviour {
    public int ItemID;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {

            col.gameObject.SendMessage("SetSpecialBullet", ItemID);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            Destroy(gameObject);
        }
    }

}
