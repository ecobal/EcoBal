using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateSphere : MonoBehaviour {

    MeshFilter mesh;
    public GameObject sphere;

	// Use this for initialization
	void Start () {
        mesh = GetComponent<MeshFilter>();
        List<Vector3> pos = RemoveSamePos(mesh.mesh.vertices);
        foreach (Vector3 v in pos)
        {
            GameObject obj = Instantiate(sphere, v, Quaternion.Euler(0, 0, 0)) as GameObject;
            obj.transform.parent = transform;

        }



    }

    // Update is called once per frame
    void Update () {
	
	}

    List<Vector3> RemoveSamePos(Vector3[] PosArray)
    {
        int count = 0;
        List<Vector3> PosList = new List<Vector3>(PosArray);
        for (int j = 0; j<PosList.Count;j++)
        {
            for (int i = 0; i < PosList.Count; i++)
            {
                if (i == j) continue;
                else
                {
                    if (Vector3.Distance(PosList[j], PosList[i]) <= 0.0001f) PosList.RemoveAt(i);
                }
            }
        }
        return PosList;

    }
}
