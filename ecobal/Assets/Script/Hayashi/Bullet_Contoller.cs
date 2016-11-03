using UnityEngine;
using System.Collections;

public class Bullet_Contoller : MonoBehaviour {

    GameObject player;
    float limitrange;
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
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

        if (col.collider.tag == "Enemy")
        {
            col.gameObject.GetComponent<AudioSource>().PlayOneShot(col.gameObject.GetComponent<AudioSource>().clip);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<AudioSource>().PlayOneShot(col.gameObject.GetComponent<AudioSource>().clip);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        else Destroy(gameObject);

    }


}
