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

    public int id;
    GameObject appearanceZone;
    GameObject childBalloon;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        childBalloon = transform.FindChild("Balloon").gameObject;
        childBalloon.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.Range(0, 0.3f), 1.0f);
        appearanceZone = GameObject.FindGameObjectWithTag("Respawn");
        id = appearanceZone.GetComponent<BalloonAppearance>().id;
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

    void SameID()
    {
        if (id == appearanceZone.GetComponent<BalloonAppearance>().id) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Respawn") ;
        else if (other.tag == "Enemy") ;
        else Destroy(gameObject);
    }
}
