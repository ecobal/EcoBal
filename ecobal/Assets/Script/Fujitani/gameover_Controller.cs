using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameover_Controller : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    
}
