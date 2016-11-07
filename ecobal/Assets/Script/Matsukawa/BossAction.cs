using UnityEngine;
using System.Collections;

public class BossAction : MonoBehaviour
{
    private GameObject breathObject;
    private GameObject summonObject;
    private GameObject assaultObject;

    public Animator anim;


    void Start()
    {
        anim = transform.FindChild("dragon").GetComponent<Animator>();
        breathObject = transform.FindChild("BreathInjection").gameObject;
        summonObject = transform.FindChild("SummonArea").gameObject;
        assaultObject = transform.FindChild("dragon").gameObject;
    }

    void Breath()
    {
        anim.Play("Bless");
        breathObject.SendMessage("OnBreathMode");
    }

    void Summon()
    {
        anim.Play("Summon");
        summonObject.SendMessage("OnSummonMode");
    }

    void Assault()
    {
        assaultObject.SendMessage("OnAssaultMode");
    }
}
