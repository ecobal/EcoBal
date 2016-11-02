using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BalloonBless : MonoBehaviour
{

    [SerializeField]
    private GameObject balloon;

    [SerializeField]
    private int balloonCount;
    [SerializeField]
    private int blessCount;
    [SerializeField]
    private float range;
    [SerializeField]
    private float blessSpeed;
    [SerializeField]
    private int blessFrequency;
    [SerializeField]
    private int blessStartPositionZ;

    private List<GameObject> bomBalloonList;

    private int count;
    private int rigitCount;

    private bool blessStart;

    // Use this for initialization
    void Start()
    {
        count = 0;
        bomBalloonList = new List<GameObject>();
        blessStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        count++;

        if (count > blessCount)
        {
            blessStart = false;
        }
        if (blessStart && count % blessFrequency == 0)
        {
            rigitCount++;
            BalloonBlessUpdate();
        }

        for (int i = 0; i < balloonCount * rigitCount; i++)
        {
            bomBalloonList[i].transform.rotation = Quaternion.Euler(
                Random.Range(-range, range),
                Random.Range(-range, range),
                 Random.Range(-range, range)
                 );

            bomBalloonList[i].GetComponent<Rigidbody>().AddForce(
                bomBalloonList[i].transform.forward * blessSpeed
               );
        }
    }


    void BalloonBlessUpdate()
    {
        for (int i = 0; i < balloonCount; i++)
        {
            GameObject obj = Instantiate(balloon, transform.position + transform.forward * blessStartPositionZ, transform.rotation) as GameObject;
            bomBalloonList.Add(obj);
            obj.gameObject.transform.parent = this.gameObject.transform;

        }

    }

    public void OnBlessMode()
    {
        blessStart = true;
    }

    public void OffBressMode()
    {
        blessStart = false;
    }
}
