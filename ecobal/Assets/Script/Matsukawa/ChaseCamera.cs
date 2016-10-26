using UnityEngine;
using System.Collections;

public class ChaseCamera : MonoBehaviour
{
    private GameObject player;
    public float playerDistance;
    public float cameraSpeed;
    public float rotationSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(0, 0, -playerDistance), cameraSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, rotationSpeed * Time.deltaTime);
    }
}
