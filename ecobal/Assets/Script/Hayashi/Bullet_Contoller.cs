using UnityEngine;
using System.Collections;

public class Bullet_Contoller : MonoBehaviour {

    GameObject player;
    float limitrange;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        limitrange = player.GetComponent<Player_Shoot>().LimitRange;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= limitrange) Destroy(gameObject);

    }

    void OnCollisionEnter(Collision col)
    {
        /*
        if (col.collider.tag == "Enemy") col.gameObject.SendMessage("DestroyObject");
        else Destroy(gameObject);
        */
        if (col.collider.tag == "Enemy") Destroy(col.gameObject);
        else Destroy(gameObject);
    }

}
