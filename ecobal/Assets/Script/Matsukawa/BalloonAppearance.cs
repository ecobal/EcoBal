using UnityEngine;
using System.Collections;

public class BalloonAppearance : MonoBehaviour
{
    public GameObject[] appearBalloon;
    private int randValue;
    private float appearPointX;
    private float appearPointZ;
    private Vector3 objectPosition;

    private bool appear;
    public float appearTime;
    private float interval;

    public int totalBalloon;
    [HideInInspector]
    public int id;
    public GameObject[] balloon;
    bool forceDelete;

    void Start()
    {
        id = 0;
        interval = 0;
        objectPosition = transform.position;
        forceDelete = false;
        AppearBalloon();
    }

    void Update()
    {
        if (appear) AppearBalloon();
        else if (!appear) AppearInterval();
    }

    void AppearBalloon()
    {
        IDCheck();
        randValue = Random.Range(0, 100) % appearBalloon.Length;
        appearPointX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
        appearPointZ = Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2);
        Instantiate(appearBalloon[randValue], objectPosition + new Vector3(appearPointX, 0, appearPointZ), transform.rotation);
        appear = false;
        interval = 0;
    }

    void AppearInterval()
    {
        interval += 1 * Time.deltaTime;
        if (interval >= appearTime) appear = true;
    }

    void SendesseageBalloon()
    {
        balloon = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < balloon.Length; i++)
        {
            balloon[i].SendMessage("SameID");
        }
    }

    void IDCheck()
    {
        id++;
        if(id > totalBalloon)
        {
            forceDelete = true;
            id = 0;
        }

        if (forceDelete) SendesseageBalloon();
    }
}
