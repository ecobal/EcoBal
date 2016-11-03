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
        if (hp <= 0)
        {
            sendChangeScene();
        }
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


    public void sendChangeScene()
    {
        Camera.main.gameObject.GetComponent<FadeEffect>().ChangeState();
        StartCoroutine("SceneLoder");
    }

    IEnumerator SceneLoder()
    {
        yield return new WaitForSeconds(0.8f);
        BalloonDestroy.isQUitting = true;
        SceneManager.LoadScene(sceneName);
    }
}
