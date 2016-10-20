using UnityEngine;
using System.Collections;

public class TakeItem : MonoBehaviour {
    public int ItemID;

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {

            col.gameObject.SendMessage("GetSpecialBullet", ItemID);
            Destroy(gameObject);
        }
    }

}
