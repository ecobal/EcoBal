using UnityEngine;
using System.Collections;

public class BossBattlePlayerMove : MonoBehaviour
{
    private GameObject boss;
    private Quaternion forRotation;

    private float angleValue;
    public float rotationSpeed;
    public float radius;
    private float floatingValue;
    public float floating;

    public float YRange;

    private Vector3 after;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    void Update()
    {
        Rotation();
        if (Input.GetAxisRaw("Horizontal") > 0.2f) angleValue += rotationSpeed * Time.deltaTime;
        else if (Input.GetAxisRaw("Horizontal") < -0.2f) angleValue -= rotationSpeed * Time.deltaTime;

        if (Input.GetAxisRaw("Vertical") > 0.2f && transform.position.y < YRange) floatingValue += floating * Time.deltaTime;
        else if (Input.GetAxisRaw("Vertical") < -0.2f && transform.position.y > -YRange) floatingValue -= floating * Time.deltaTime;
        
        Move();
    }

    void Rotation()
    {
        forRotation = Quaternion.LookRotation(boss.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, forRotation, 1);
    }

    void Move()
    {
        transform.position = new Vector3(radius * Mathf.Cos(angleValue), floatingValue, radius * Mathf.Sin(angleValue));
    }
}
