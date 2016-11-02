using UnityEngine;
using System.Collections;

public class BossMotion : MonoBehaviour
{
    public float floatRange;
    public float sideRange;

    private GameObject player;
    private Quaternion forRotation;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Rotation();
    }

    void Rotation()
    {
        forRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, forRotation, 1 * Time.deltaTime);
    }
}
