using UnityEngine;
using System.Collections;

public class Camera_Chase : MonoBehaviour {

    public float Player2Range;
    private GameObject player;
    Vector3 DefaultPos;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        DefaultPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 target = player.transform.position;
        target.z -= Player2Range;
        Vector3 campos = new Vector3(DefaultPos.x, DefaultPos.y, target.z);
        transform.position = Vector3.Lerp(campos, target, 0.9f);
//        transform.position = new Vector3(DefaultPos.x, DefaultPos.y, player.transform.position.z);
        transform.LookAt(player.transform);

	
	}
}
