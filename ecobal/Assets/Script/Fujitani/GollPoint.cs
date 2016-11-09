using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GollPoint : MonoBehaviour
{
    [SerializeField]
    private string sceneName;

    public GameObject BossCanvas;

    // Use this for initialization
    void Start()
    {
        BossCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            BossCanvas.SetActive(true);
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(1);
        Camera.main.GetComponent<FadeEffect>().ChangeState();
        StartCoroutine(ChangeScene());

    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.8f);
        BalloonDestroy.isQUitting = true;
        SceneManager.LoadScene(sceneName);

    }


}
