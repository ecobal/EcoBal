using UnityEngine;
using System.Collections;

public class BossAction : MonoBehaviour
{
    private GameObject breathObject;
    private GameObject summonObject;
    private GameObject assaultObject;

    void Start()
    {
        breathObject = transform.FindChild("BreathInjection").gameObject;
        summonObject = transform.FindChild("SummonArea").gameObject;
        assaultObject = transform.FindChild("dragon").gameObject;
    }

    void Breath()
    {
        breathObject.SendMessage("OnBreathMode");
    }

    void Summon()
    {
        summonObject.SendMessage("OnSummonMode");
    }

    void Assault()
    {
        assaultObject.SendMessage("OnAssaultMode");
    }
}
