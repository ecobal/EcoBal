using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class title_Controller : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    Color col;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        col = GetComponent<Image>().color;
        col.a = Mathf.Sin(5*Time.time);
        GetComponent<Image>().color = col;

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
