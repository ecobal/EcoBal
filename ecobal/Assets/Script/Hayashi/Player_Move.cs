using UnityEngine;
using System.Collections;

public class Player_Move : MonoBehaviour {

    [SerializeField,Tooltip("前進のスピード")]
    public float speed;
    [SerializeField,Tooltip("横移動のスピード")]
    public float turnSpeed;

    [SerializeField, Tooltip("スタート位置")]
    public GameObject SpwanPoint;

    FadeEffect fade;

    private Rigidbody rig;


    // Use this for initialization
    void Start () {
        fade = Camera.main.GetComponent<FadeEffect>();
        Init();
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
        rig.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * turnSpeed, Input.GetAxisRaw("Vertical"), speed);

	
	}

    public void Init()
    {
        transform.position = SpwanPoint.transform.position;
        transform.rotation = SpwanPoint.transform.rotation;
        fade.ChangeState();

    }


}
