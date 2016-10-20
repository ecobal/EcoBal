using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class End_Zone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == "Player")
        {
            SceneManager.LoadScene("ProtoTestScene");
        }
    }
}
