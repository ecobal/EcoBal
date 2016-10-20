using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicateReticle : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite aimSprite;
    private Sprite indicateSprite;

    private Image reticleImage;

    void Start()
    {
        reticleImage = GetComponent<Image>();
        indicateSprite = normalSprite;
        reticleImage.sprite = indicateSprite;
    }

    void IndicateNormal()
    {
        reticleImage.sprite = normalSprite;
    }

    void IndicateAim()
    {
        reticleImage.sprite = aimSprite;
    }
}
