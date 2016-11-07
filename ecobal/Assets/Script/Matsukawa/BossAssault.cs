using UnityEngine;
using System.Collections;

public class BossAssault : MonoBehaviour
{
    private GameObject player;
    private Vector3 assaultPosition;

    public float assaultSpeed;
    private float assaultInterpolation;

    public float preliminalyTime;
    public float preliminalyDistance;
    private float timerPreliminaly;

    [HideInInspector]
    public bool assault;
    [HideInInspector]
    public bool preliminalyAction;

    private Quaternion forRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        assault = false;
        preliminalyAction = false;
    }

    void Update()
    {
        if (assault && preliminalyAction) Assault();
        else if (!assault && preliminalyAction) PreliminalyAction();
    }

    void OnAssaultMode()
    {
        preliminalyAction = true;
    }

    void Assault()
    {
        assaultInterpolation += assaultSpeed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, assaultPosition, assaultInterpolation / 10);
        if (assaultInterpolation >= assaultSpeed)
        {
            assault = false;
            preliminalyAction = false;
            assaultInterpolation = 0;
            transform.parent.SendMessage("IntervalStart");
        }
    }

    void PreliminalyAction()
    {
        timerPreliminaly += 1 * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, transform.position + transform.TransformVector(0, 0, -preliminalyDistance), 1 * Time.deltaTime);
        Rotation();
        if (timerPreliminaly >= preliminalyTime)
        {
            assault = true;
            assaultPosition = player.transform.position + player.transform.TransformVector(0, Random.Range(-6.0f, -2.5f), -2.5f);
            timerPreliminaly = 0;
        }
    }

    void Rotation()
    {
        forRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, forRotation, 1 * Time.deltaTime);
    }
}
