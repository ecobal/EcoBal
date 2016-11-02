using UnityEngine;
using System.Collections;

public class BossAssault : MonoBehaviour
{


    private bool assault;

    void Start()
    {
        assault = false;
    }

    void Update()
    {
        if (assault) Assault();
    }

    void OnAssaultMode()
    {
        assault = true;
    }

    void Assault()
    {
        Debug.Log("a");
    }
}
