using UnityEngine;
using System.Collections;

public class RayJudge : MonoBehaviour
{
    public float rayRange;
    private RaycastHit hit;
    public LayerMask balloonLayer;
    private bool balloonHit;

    [Header("Rayの長さ確認用")]
    public bool debugMode;

    private GameObject reticleImage;

    void Start()
    {
        balloonHit = false;
        reticleImage = GameObject.Find("Reticle");
    }

    void Update()
    {
        BalloonHitJudge();
    }

    #region RaycastとReticle変更指示
    void BalloonHitJudge()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit, rayRange, balloonLayer))
        {
            if(hit.collider.tag == "Enemy" && !balloonHit)
            {
                balloonHit = true;
                reticleImage.SendMessage("IndicateAim");
            }
        }

        if(hit.collider == null && balloonHit)
        {
            balloonHit = false;
            reticleImage.SendMessage("IndicateNormal");
        }

        #region DebugMode
        if (debugMode)
        {
            Debug.DrawRay(transform.position, transform.forward * rayRange, Color.red);
        }
        #endregion
    }
    #endregion
}
