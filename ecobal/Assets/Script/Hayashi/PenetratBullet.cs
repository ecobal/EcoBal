using UnityEngine;
using System.Collections;

public class PenetratBullet : MonoBehaviour {

    GameObject player;
    float limitrange;

    // Use this for initialization
    void Start () {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);

        player = GameObject.FindGameObjectWithTag("Player");
        limitrange = player.GetComponent<Player_Shoot>().LimitRange * 2;


    }

    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(transform.position, player.transform.position) >= limitrange) Destroy(gameObject);


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy") Destroy(col.gameObject);
        else Destroy(gameObject);

    }

}
