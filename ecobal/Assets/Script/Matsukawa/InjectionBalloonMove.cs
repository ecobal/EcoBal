using UnityEngine;
using System.Collections;

public class InjectionBalloonMove : MonoBehaviour
{
    public float range;
    public float breathSpeed;

    Rigidbody rigidbody;
    Quaternion forRotation;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        forRotation = Quaternion.LookRotation(GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, forRotation, 1);
    }

    void Update()
    {
        rigidbody.AddForce((transform.forward + new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range))) * breathSpeed);
    }
}
