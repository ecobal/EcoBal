using UnityEngine;
using System.Collections;

public class BalloonSummon : MonoBehaviour
{
    public GameObject summonBalloon;
    public int balloonCount;

    private bool summonStart;

    void Start()
    {
        summonStart = false;
    }

    void Update()
    {
        if (summonStart) SummonPosition();
    }

    void OnSummonMode()
    {
        summonStart = true;
    }

    void SummonPosition()
    {
        for(int i = 0; i < balloonCount; i++)
        {
            Vector3 formPosition = new Vector3(
                Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2),
                Random.Range(-transform.localScale.y / 2, transform.localScale.y / 2),
                Random.Range(-transform.localScale.z / 2, transform.localScale.z / 2));
            Instantiate(summonBalloon, transform.position + formPosition, transform.rotation);
        }
        summonStart = false;
        transform.parent.SendMessage("IntervalStart");
    }
}
