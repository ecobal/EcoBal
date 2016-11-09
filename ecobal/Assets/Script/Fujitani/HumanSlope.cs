using UnityEngine;
using System.Collections;

public class HumanSlope : MonoBehaviour
{
    private GameObject player;

    private float lerpTimer = 0.5f;
    [SerializeField]
    private float lerpSpeed = 1f;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (lerpTimer > 1)
        {
            lerpTimer = 1;
        }
        if (lerpTimer < 0)
        {
            lerpTimer = 0;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        // if(Input.GetAxis("Horizontal") > 0)
        {
            lerpTimer += Time.deltaTime * lerpSpeed;
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        // else if(Input.GetAxis("Horizontal") < 0)
        {
            lerpTimer -= Time.deltaTime * lerpSpeed;
        }
        else
        {
            // 徐々に0.5に近づける
            if (lerpTimer > 0.5f)
            {
                lerpTimer -= Time.deltaTime * lerpSpeed;
            }
            if (lerpTimer < 0.5f)
            {
                lerpTimer += Time.deltaTime * lerpSpeed;
            }
        }

        // 自分のX軸、Y軸は自分から取得し、Z軸だけは-30～30の間で回転
        this.gameObject.transform.rotation = Quaternion.Euler(
            this.gameObject.transform.rotation.eulerAngles.x,
            this.gameObject.transform.rotation.eulerAngles.y,
            Mathf.Lerp(30f, -30f, lerpTimer));



        //if (Input.GetAxis("Horizontal") > 0)
        //{
        //    transform.rotation = Quaternion.Slerp(
        //       player.transform.rotation,
        //        Quaternion.Euler(player.transform.forward * -30.0f),
        //        Input.GetAxis("Horizontal"));
        //}
        //else if (Input.GetAxis("Horizontal") < 0)
        //{
        //    transform.rotation = Quaternion.Slerp(
        //        player.transform.rotation,
        //       Quaternion.Euler(player.transform.forward * 30.0f),
        //        -Input.GetAxis("Horizontal"));
        //}

    }
}
