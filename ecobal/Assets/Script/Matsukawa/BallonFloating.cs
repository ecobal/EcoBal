using UnityEngine;
using System.Collections;

public class BallonFloating : MonoBehaviour
{

    public float floatSpeed;
    public float moveSpeed;
    public float maxFloatSpeed;

    public Vector3 move;
    private bool floatup;
    public bool chase;
    private bool chaseMode;
    public bool explosion;
    [Tooltip("eキー:爆発,oキー:ただ消えるだけ")]
    public bool debugcode;

    Rigidbody rigidbody;
    private GameObject player;
    private GameObject ballonObject;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        ballonObject = gameObject.transform.FindChild("Balloon").gameObject;
        floatup = true;
    }

    void Update()
    {
        Floating();
        if (chaseMode && chase) Chase();
        Move();

        #region Debug_Destroy
        if (debugcode)
        {
            DebugCode();
        }
        #endregion
    }

    #region 浮遊
    void Floating()
    {
        if (move.y >= maxFloatSpeed)
        {
            floatup = false;
        }
        else if (move.y <= -maxFloatSpeed)
        {
            floatup = true;
        }

        if (floatup)
        {
            move.y += floatSpeed * Time.deltaTime;
        }
        else if (!floatup)
        {
            move.y -= floatSpeed * Time.deltaTime;
        }
    }
    #endregion

    #region 移動
    void Move()
    {
        rigidbody.velocity = transform.TransformVector(move) * Time.deltaTime;
    }
    #endregion

    #region 追跡
    void Chase()
    {
        if(transform.position.x >= player.transform.position.x)
        {
            move.x -= moveSpeed * Time.deltaTime; 
        }
        else
        {
            move.x += moveSpeed * Time.deltaTime;
        }

        if(transform.position.y >= player.transform.position.y)
        {
            move.y -= moveSpeed * Time.deltaTime;
        }
        else
        {
            move.y += moveSpeed * Time.deltaTime;
        }
    }
    #endregion

    #region Player発見
    void DetectPlayer()
    {
        chaseMode = true;
        floatSpeed = 0;
    }
    #endregion

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            ballonObject.SendMessage("ExplosionObject");
        }
        else if (other.collider.tag == "Player")
        {
            ballonObject.SendMessage("DestroyObject");
        }
    }

    #region DebugCode
    void DebugCode()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ballonObject.SendMessage("DestroyObject");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            ballonObject.SendMessage("ExplosionObject");
        }
    }
    #endregion
}
