using UnityEngine;
using System.Collections;

public class Reticle_Move : MonoBehaviour {

    Ray ray;
    RaycastHit hit;
    public LayerMask IgnoreLayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray , out hit ,10,~IgnoreLayer))
        {
            transform.position = hit.point;
        }else
        {
            transform.position = ray.GetPoint(10);
        }

	
	}
}
