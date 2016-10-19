using UnityEngine;
using System.Collections;

public class BalloonMove : MonoBehaviour
{
    public float floatMultipule;

    private Vector3 moveVector;

    public bool chase;
    private bool chaseMode;

    Rigidbody rigidbody;
    private GameObject player;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
    }

    void Update()
    {
        // 浮遊
        moveVector.y = floatMultipule * Mathf.Sin(Time.realtimeSinceStartup);
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
