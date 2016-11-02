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
    public int[] actionProbability;
    private int actionNumber = 0;
    public int actTotalNum;
    private int rnd;

    void OnValidate()
    {
        System.Array.Resize(ref actionProbability, actionName.Length);
        actTotalNum = 0;
        for (int i = 0; i < actionProbability.Length; i++) actTotalNum += actionProbability[i];
    }

    void Start()
    {
        isInterval = true;
        actionInterval = maxActionInterval / 2;
        actionNumber = 0;
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
        actionNumber = 0;
        rnd = Random.Range(0, actTotalNum) % actTotalNum;

        if (rnd > actionProbability[0])
        {
            for (int i = 1; i < actionProbability.Length; i++)
            {
                ActNumDecision(i);
            }
        }

        SendMessage(actionName[actionNumber]);
        DecisionInterval();
    }

    void ActNumDecision(int i)
    {
        if (actionNumber == 0)
        {
            int min = 0;
            for (int j = i - 1; j >= 0; j--) min += actionProbability[j];
            int max = min + actionProbability[i];

            if (rnd > min && rnd <= max) actionNumber = i;
        }
    }
}