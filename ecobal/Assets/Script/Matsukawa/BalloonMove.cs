using UnityEngine;
using System.Collections;

public class BalloonMove : MonoBehaviour
{
    public float floatRange;

    private float rnd;
    private Vector3 moveVector;

    public bool chase;
    private bool chaseMode;

    Rigidbody rigidbody;
    private GameObject player;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rnd = Random.Range(0, 359);
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update()
    {
        // 浮遊
        moveVector.y = floatRange * Mathf.Sin(rnd + Time.realtimeSinceStartup);
        // 追跡
        if (chase && chaseMode) transform.position = Vector2.Lerp(transform.position, player.transform.position, 1 * Time.deltaTime);
        // 移動
        rigidbody.velocity = transform.TransformVector(moveVector);
    }

    #region Player発見
    void DetectPlayer()
    {
        chaseMode = true;
    }
    #endregion
}
