using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_HP : MonoBehaviour
{

    [SerializeField]
    private int hp;

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
        if (col.collider.tag == "Enemy")
        {
            hp--;
            col.gameObject.SendMessage("DestroyObject");
        }
        if (hp > 0) return;
        SceneManager.LoadScene(sceneName);
    }
}
