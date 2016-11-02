using UnityEngine;
using System.Collections;

public class TitleBalloonMotion : MonoBehaviour
{
    private float sinRadius;
    private float cosRadius;
    private Vector3 moveVector;

    public float floatRange = 1.75f;
    public float sideRange = 0.01f;
    public float sideValue = 2.0f;
    
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        sinRadius = Random.Range(0, 359);
        cosRadius = Random.Range(0, 359);
    }

    void Update()
    {
        moveVector.y = floatRange * Mathf.Sin(sinRadius + Time.realtimeSinceStartup);
        moveVector.x = sideRange + Mathf.Cos(cosRadius + (Time.realtimeSinceStartup / sideValue));
        if (Mathf.Sin(sinRadius + Time.realtimeSinceStartup) >= 0) moveVector.y = moveVector.y * 1.2f;
        rigidbody.velocity = transform.TransformVector(moveVector);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Respawn") Destroy(gameObject);
    }
}
