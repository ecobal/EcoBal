using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateSphere : MonoBehaviour {

    MeshFilter mesh;
    public GameObject sphere;
    [SerializeField,Range(0.01f,1)]
    public float Amplitude;
	// Use this for initialization
	void Awake () {
        mesh = GetComponent<MeshFilter>();
        List<Vector3> pos = RemoveSamePos(mesh.mesh.vertices);
        Debug.Log(pos.Count);
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
        for (int j = 0; j<PosList.Count-1;j++)
        {
            for (int i = 0; i < PosList.Count-1; i++)
            {
                if (i == j) continue;
                else
                {
                    if (Mathf.Abs( Vector3.Distance(PosList[j], PosList[i])) <= Amplitude) PosList.RemoveAt(j);
                }
            }
        }
        return PosList;

    }
}
