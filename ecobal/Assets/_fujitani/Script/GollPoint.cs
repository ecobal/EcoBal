using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GollPoint : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }

}
