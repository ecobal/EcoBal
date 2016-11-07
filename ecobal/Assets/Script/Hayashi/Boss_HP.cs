using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Boss_HP : MonoBehaviour {

    float DefaultBalloonNumber;
    float CurrentBaloonNumber;

    [SerializeField,TextArea]
    public string Intro = "ボスのＨＰはまとっている風船の割合で決まります";

    [Tooltip("ボスが死ぬ値")]
    public float DeathProportion;

    public string SceneName;

    public Color DamageColor;
    public Material balloon_Mat;
    Color defaultColor;
	// Use this for initialization
	void Start () {
        DefaultBalloonNumber = transform.childCount;
        //Debug.Log(DefaultBalloonNumber);
        DeathProportion /= 100;
        defaultColor = balloon_Mat.color;
	
	}
	
	// Update is called once per frame
	void Update () {
        CurrentBaloonNumber = transform.childCount;
        balloon_Mat.color = ColorLerp(DamageColor, defaultColor, CalcProportion());
        if (CalcProportion() <= DeathProportion)
        {
            balloon_Mat.color = defaultColor;
            BalloonDestroy.isQUitting = true;
            SceneManager.LoadScene(SceneName);
        }
        //Debug.Log(Proportion);
	
	}

    public float CalcProportion()
    {
        return CurrentBaloonNumber / DefaultBalloonNumber;
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

}
