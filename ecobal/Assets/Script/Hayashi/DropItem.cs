using UnityEngine;
using System.Collections;
public class DropItem : MonoBehaviour {

    public GameObject PenertrateItem;
    public GameObject ShotShellItem;


    void OnDestroy()
    {
        Debug.Log("death");
        int i = Random.Range(0, 2);
        if (!BalloonDestroy.isQUitting)
        {
            if (i == 0) Instantiate(PenertrateItem, transform.position, transform.rotation);
            else Instantiate(ShotShellItem, transform.position, transform.rotation);
        }
    }

}
