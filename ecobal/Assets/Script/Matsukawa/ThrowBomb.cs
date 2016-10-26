using UnityEngine;
using System.Collections;

public class ThrowBomb : MonoBehaviour
{
    public GameObject bombObject;
    public float throwInterval;
    private float intervalTime;
    private bool throwMode;
    private bool throwStart;

    void Start()
    {
        throwStart = false;
    }

    void Update()
    {
        if (throwMode && throwStart) BombThrow();
        else if (throwMode && !throwStart) ThrowInterval();
    }

    void BombThrow()
    {
        Instantiate(bombObject, transform.forward, transform.rotation);
        throwStart = false;
    }

    void ThrowInterval()
    {
        intervalTime += 1 * Time.deltaTime;
        if(intervalTime >= throwInterval)
        {
            throwStart = true;
            intervalTime = 0;
        }
    }

    #region 爆弾投擲操作
    void OnThrowMode()
    {
        throwMode = true;
        throwStart = true;
    }

    void OffThrowMode()
    {
        throwMode = false;
        throwStart = false;
    }
    #endregion
}
