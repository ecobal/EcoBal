using UnityEngine;
using System.Collections;

public class BalloonBreath : MonoBehaviour
{
    public GameObject breathBalloon;
    public int balloonCount;

    private bool breathStart;
    Quaternion forRotation;

    void Start()
    {
        breathStart = false;
    }

    void Update()
    {
        if (breathStart) BalloonInjection();
    }

    void OnBreathMode()
    {
        breathStart = true;
    }

    void BalloonInjection()
    {
        for (int i = 0; i < balloonCount; i++)
        {
            Vector3 formPosition = new Vector3(
                Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2),
                Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2),
                Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2));
            Instantiate(breathBalloon, transform.position + formPosition, transform.rotation);
        }
        breathStart = false;
    }
}
