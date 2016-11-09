using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Boss_HP : MonoBehaviour {

    float DefaultBalloonNumber;
    float CurrentBaloonNumber;

    [SerializeField,TextArea]
    public string Intro = "ボスのＨＰはまとっている風船の割合で決まります(もろもろの関係で少々誤差アリ)";

    [Tooltip("ボスが死ぬ値")]
    public float DeathProportion;
    private GameObject Boss_Body;
    private GameObject Boss_Head;
    private GameObject Boss_Right;
    private GameObject Boss_Left;
    private GameObject Boss_Tail;

    public Color DamageColor;
    public Color defaultColor;
    public Material balloon_Mat;

    public string SceneName;
    public float LoadTime;

    // Use this for initialization
    void Start () {
        Boss_Body = GameObject.FindGameObjectWithTag("Boss_Body");
        Boss_Head = GameObject.FindGameObjectWithTag("Boss_Head");
        Boss_Right = GameObject.FindGameObjectWithTag("Boss_Right");
        Boss_Left = GameObject.FindGameObjectWithTag("Boss_Left");
        Boss_Tail = GameObject.FindGameObjectWithTag("Boss_Tail");

        DefaultBalloonNumber = Boss_Body.transform.childCount
                             + Boss_Head.transform.childCount
                             + Boss_Right.transform.childCount
                             + Boss_Left.transform.childCount
                             + Boss_Tail.transform.childCount;

        //Debug.Log(DefaultBalloonNumber);
        DeathProportion /= 100;
        balloon_Mat.color = defaultColor;

    }

    // Update is called once per frame
    void Update () {
        SumBalloon();
        balloon_Mat.color = ColorLerp(DamageColor, defaultColor, CalcProportion());

        if (CalcProportion() <= DeathProportion)
        {
            if (CalcProportion() >= 0)
            {
                balloon_Mat.color = defaultColor;
                BossDeath();
                StartCoroutine(LoadScene());
            }
        }
        Debug.Log(balloon_Mat.color);
	
	}

    public float CalcProportion()
    {
        return CurrentBaloonNumber / DefaultBalloonNumber;
    }

    void SumBalloon()
    {
        CurrentBaloonNumber = Boss_Body.transform.childCount
                     + Boss_Head.transform.childCount
                     + Boss_Right.transform.childCount
                     + Boss_Left.transform.childCount
                     + Boss_Tail.transform.childCount;

    }


    Color ColorLerp(Color a, Color b, float t)
    {
        Color outColor;
        outColor.r = Mathf.Lerp(a.r, b.r, t);
        outColor.b = Mathf.Lerp(a.b, b.b, t);
        outColor.g = Mathf.Lerp(a.g, b.g, t);
        outColor.a = Mathf.Lerp(a.a, b.a, t);

        return outColor;
    }

    void BossDeath()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (var i in obj) Destroy(i);
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(LoadTime);
        BalloonDestroy.isQUitting = true;
        SceneManager.LoadScene(SceneName);
    }

}
