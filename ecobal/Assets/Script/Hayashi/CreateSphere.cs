using UnityEngine;
using System.Collections;

public class CreateSphere : MonoBehaviour {

    MeshFilter mesh;
    Vector3[] pos = new Vector3[0];
    public GameObject sphere;

	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshFilter>();
        pos = mesh.mesh.vertices;
        foreach(Vector3 v in pos)
        {
            GameObject obj = Instantiate(sphere, v, Quaternion.Euler(0, 0, 0)) as GameObject;
            obj.transform.parent = transform;

        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
