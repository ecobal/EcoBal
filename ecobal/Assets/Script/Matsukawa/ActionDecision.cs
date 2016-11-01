using UnityEngine;
using System.Collections;

public class ActionDecision : MonoBehaviour
{
    #region Interval
    public float maxActionInterval;
    public float minActionInterval;
    private float actionInterval;
    private float intervalTime;
    private bool isInterval;
    #endregion

    public string[] actionName;
    private int actionNumber;

    void Start()
    {
        isInterval = true;
        actionInterval = maxActionInterval / 2;
    }

    void Update()
    {
        if (!isInterval) ActDecision();

        actionNumber = Random.Range(0, 5);
        IntervalProcessing();
    }

    void DecisionInterval()
    {
        actionInterval = Random.Range(minActionInterval, maxActionInterval);
        isInterval = true;
        // IntervalTime Debug
        //Debug.Log(actionInterval);
    }

    void IntervalProcessing()
    {
        if (isInterval) intervalTime += 1 * Time.deltaTime;

        if (intervalTime >= actionInterval)
        {
            isInterval = false;
            intervalTime = 0;
        }
    }

    void ActDecision()
    {
        actionNumber = Random.Range(0, actionName.Length) % actionName.Length;
        // ActionNumber Debug
        //Debug.Log(actionNumber);
        
        SendMessage(actionName[actionNumber]);
        DecisionInterval();
    }
}
