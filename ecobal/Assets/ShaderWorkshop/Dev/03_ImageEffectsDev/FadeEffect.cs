using UnityEngine;

[ExecuteInEditMode]
#if UNITY_5_4_OR_NEWER
[ImageEffectAllowedInSceneView]
#endif
public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    Shader m_shader;

    Material m_material;
    public Material material
    {
        get
        {
            // 遅延初期化
            if (m_material == null)
            {
                m_material = new Material(m_shader);                // ShaderからMaterialを作成
                m_material.hideFlags = HideFlags.HideAndDontSave;   // シーンに保存されないように指定
            }
            return m_material;
        }
    }

    public enum FadeState
    {
        Idle,
        FadeIn,
        FadeOut
    }

    public FadeState fadestate;

    public Color color;

    private float Alpha;
    public float alpha {
        set
        {
            if (value < 0) Alpha = 0;
            else if (value > 1) Alpha = 1;
            else Alpha = value;
        }

        get
        {
            return Alpha;
        }

    }

    void Start()
    {
        alpha = 1;
        fadestate = FadeState.FadeIn;
    }

    void Update()
    {
        material.SetColor("_Color", color);
        switch (fadestate) {
            case FadeState.Idle:
                alpha = 0;
                break;
            case FadeState.FadeIn:
                alpha -= 0.05f;
                break;
            case FadeState.FadeOut:
                alpha += 0.05f;
                break;
        }
        if (alpha >= 1 && fadestate == FadeState.FadeOut) fadestate = FadeState.FadeIn;
        else if (alpha <= 0 && fadestate == FadeState.FadeIn) fadestate = FadeState.Idle;
        
        material.SetFloat("_Alpha", alpha);
    }

    public void ChangeState()
    {
        fadestate = FadeState.FadeOut;

    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // materialを用いて画面を描画
        // source(RenderTexture)が_MainTex(Shader側)にセットされる
        // 描画先はdestination(RenderTexture)
        Graphics.Blit(source, destination, material);
    }

    void OnDisable()
    {
        if (m_material != null) DestroyImmediate(m_material);       // スクリプト無効時にMaterialを削除
    }
}
