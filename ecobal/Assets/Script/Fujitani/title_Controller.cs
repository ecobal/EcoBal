using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class title_Controller : MonoBehaviour
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

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
