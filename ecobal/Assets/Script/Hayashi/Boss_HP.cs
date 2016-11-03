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
	// Use this for initialization
	void Start () {
        DefaultBalloonNumber = transform.childCount;
        //Debug.Log(DefaultBalloonNumber);
        DeathProportion /= 100;
        
	
	}
	
	// Update is called once per frame
	void Update () {
        CurrentBaloonNumber = transform.childCount;
        float Proportion = CurrentBaloonNumber / DefaultBalloonNumber;
        if (Proportion <= DeathProportion)
        {
            BalloonDestroy.isQUitting = true;
            SceneManager.LoadScene(SceneName);
        }
        //Debug.Log(Proportion);
	
	}
}
