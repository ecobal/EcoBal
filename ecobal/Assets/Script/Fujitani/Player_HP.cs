using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player_HP : MonoBehaviour
{
    private GameObject imaje;

    [SerializeField]
    private float hp;

    [SerializeField]
    private float downHp;

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
            
            hp -= downHp;
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            hp -= downHp;
            Destroy(col.gameObject);
        }
    }

    public float GetHP()
    {
        return hp;
    }

    void SceneLoder()
    {
        BalloonDestroy.isQUitting = true;
        SceneManager.LoadScene(sceneName);
    }
}
