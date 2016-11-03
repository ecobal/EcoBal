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

    private bool justBeforeGameover;
    // Use this for initialization
    void Start()
    {
        justBeforeGameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            sendChangeScene();
        }

        if (hp <= 0.21)
        {
            justBeforeGameover = true;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Enemy")
        {
            hp -= downHp;

            if (justBeforeGameover) hp = 0;
            Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            hp -= downHp;

            if (justBeforeGameover) hp = 0;
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
