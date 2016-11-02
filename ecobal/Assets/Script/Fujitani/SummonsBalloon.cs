using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SummonsBalloon : MonoBehaviour
{
    [SerializeField]
    private GameObject balloon;

    [SerializeField]
    private int balloonCount;
    [SerializeField]
    private float rangeMin;
    [SerializeField]
    private float rangeMax;

    private bool summonsStart;

    private List<GameObject> balloonList;

    // Use this for initialization
    void Start()
    {
        balloonList = new List<GameObject>();
        summonsStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (summonsStart) SummonsBalloonUpdate();
    }

    void SummonsBalloonUpdate()
    {
        // 生成
        for (int i = 0; i < balloonCount; ++i)
        {
            GameObject obj = Instantiate(balloon, transform.position, transform.rotation) as GameObject;
            // リストに追加
            balloonList.Add(obj);
            // 親子関係
            obj.gameObject.transform.parent = this.gameObject.transform;
        }

        // ランダムで角度を指定
        for (int i = 0; i < balloonList.Count; ++i)
        {
            balloonList[i].gameObject.transform.eulerAngles =
                new Vector3(
                    Random.Range(0.0f, 360.0f),
                    Random.Range(0.0f, 360.0f),
                    Random.Range(0.0f, 360.0f));
        }

        // 向いている方向に移動
        for (int i = 0; i < balloonList.Count; ++i)
        {
            balloonList[i].transform.position += balloonList[i].transform.forward * Random.Range(rangeMin, rangeMax);
        }
        summonsStart = false;

    }

    public void OnSummonsMode()
    {
        summonsStart = true;
    }

    public void OffSummonsMode()
    {
        summonsStart = false;
    }
}
