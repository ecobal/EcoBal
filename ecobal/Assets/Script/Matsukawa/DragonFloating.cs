using UnityEngine;
using System.Collections;

public class DragonFloating : MonoBehaviour
{
    public float floatRange;

    void Start()
    {

    }

    void Update()
    {
        if (!GetComponent<BossAssault>().preliminalyAction)
        {
            transform.position = transform.parent.position + new Vector3(0, floatRange * Mathf.Sin(Time.realtimeSinceStartup), 0);
        }
    }
}
