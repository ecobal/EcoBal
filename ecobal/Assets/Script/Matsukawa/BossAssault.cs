using UnityEngine;
using System.Collections;

public class BossAssault : MonoBehaviour
{
    private GameObject player;
    private Vector3 assaultPosition;
    private float assaultTime;

    [HideInInspector]
    public bool assault;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        assault = false;
    }

    void Update()
    {
        if (assault) Assault();
    }

    void OnAssaultMode()
    {
        assault = true;
        assaultPosition = player.transform.position + player.transform.TransformVector(0, -2.5f, -2.5f);
    }

    void Assault()
    {
        assaultTime += 1 * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, assaultPosition, 2 * Time.deltaTime);
        if (assaultTime >= 1.5f)
        {
            assault = false;
            assaultTime = 0;
        }
    }
}
