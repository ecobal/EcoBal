using UnityEngine;
using System.Collections;

public class BalloonAppearance : MonoBehaviour
{
    public GameObject[] balloon;
    private int randValue;
    private float appearPoint;
    private Vector3 objectPosition;

    private bool appear;
    public float appearTime;
    private float interval;

    void Start()
    {
        interval = 0;
        objectPosition = transform.position;
        AppearBalloon();
    }

    void Update()
    {
        if (appear) AppearBalloon();
        else if (!appear) AppearInterval();
    }

    void AppearBalloon()
    {
        randValue = Random.Range(0, 100) % balloon.Length;
        appearPoint = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        Instantiate(balloon[randValue], objectPosition + new Vector3(appearPoint, 0, 0), transform.rotation);
        appear = false;
        interval = 0;
    }

    void AppearInterval()
    {
        interval += 1 * Time.deltaTime;
        if (interval >= appearTime) appear = true;
    }
}
