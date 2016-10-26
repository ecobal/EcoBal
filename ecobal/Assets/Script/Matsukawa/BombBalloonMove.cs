using UnityEngine;
using System.Collections;

public class BombBalloonMove : MonoBehaviour
{
    public GameObject explosionObject;
    private GameObject player;
    private Vector3 playerPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPosition = player.transform.position;
    }

    void Update()
    {
        BalloonMove();
    }

    void BalloonMove()
    {
        transform.position = Vector3.Lerp(transform.position, playerPosition, 1 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Balloon")
        {
            Instantiate(explosionObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
