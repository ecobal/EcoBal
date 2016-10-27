using UnityEngine;
using System.Collections;

public class BossBattleCamera : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;

    public float cameraSpeed;
    public float playerDistance;
    public float rotationSpeed;

    private Quaternion forRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + player.transform.TransformVector(0, 0, -playerDistance), cameraSpeed * Time.deltaTime);
        forRotation = Quaternion.LookRotation(boss.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, forRotation, rotationSpeed * Time.deltaTime);
    }
}
