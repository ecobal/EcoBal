using UnityEngine;
using System.Collections;

public class DropItemMotion : MonoBehaviour
{
    public float rangeValue;
    private float objectiveRange;

    private GameObject playerObject;
    private Vector3 objectivePoint;

    void Start()
    {
        ObjectivePointDecide();
    }

    void Update()
    {
        ItemMotion();
    }

    void ItemMotion()
    {
        transform.position = Vector3.Lerp(transform.position, objectivePoint, 1 * Time.deltaTime);
    }

    void ObjectivePointDecide()
    {
        objectiveRange = Random.Range(0, rangeValue);
        playerObject = GameObject.FindGameObjectWithTag("Player");
        objectivePoint = playerObject.transform.position + playerObject.transform.TransformVector(objectiveRange, objectiveRange, 0) + playerObject.transform.forward * -1;
    }
}
