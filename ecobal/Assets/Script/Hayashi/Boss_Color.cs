using UnityEngine;
using System.Collections;

public class Boss_Color : MonoBehaviour {

    public Color DamageColor;

    Color DefaultColor;

    Material mat;

    Boss_HP boss;
	// Use this for initialization
	void Start () {

        mat = GetComponent<Material>();
        DefaultColor = mat.color;
        boss = GameObject.Find("polySurface1").GetComponent<Boss_HP>();


    }
	
	// Update is called once per frame
	void Update () {
        mat.SetColor("_Color", ColorLerp(DamageColor, DefaultColor, boss.CalcProportion()));
	
	}

    Color ColorLerp(Color a,Color b,float t)
    {
        Color outColor;
        outColor.r = Mathf.Lerp(a.r, b.r, t);
        outColor.b = Mathf.Lerp(a.b, b.b, t);
        outColor.g = Mathf.Lerp(a.g, b.g, t);
        outColor.a = Mathf.Lerp(a.a, b.a, t);

        return outColor;
    }
}
