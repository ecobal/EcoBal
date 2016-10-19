using UnityEngine;
using System.Collections;

public class PlayerSearch : MonoBehaviour
{
    GameObject parentObject;

    void Start()
    {
        parentObject = transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            parentObject.SendMessage("DetectPlayer");
        }
    }
}
