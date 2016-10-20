using UnityEngine;
using System.Collections;

public class ReticleRay : MonoBehaviour
{
    public float rayRange;
    private RaycastHit hit;
    public LayerMask rayMask;
    private bool enemyHit;

    public Sprite nomalReticle;
    public Sprite hitReticle;

    public bool debugMode;

    void Start()
    {
        enemyHit = false;
    }

    void Update()
    {
        ReticleRaycast();
    }

    #region Raycast
    void ReticleRaycast()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange, rayMask))
        {
            if (hit.collider.tag == "Enemy" && !enemyHit)
            {
                enemyHit = true;
                Debug.Log("hit(≧▽≦)");
            }
        }

        if(hit.collider == null && enemyHit)
        {
            enemyHit = false;
            Debug.Log("out('Д')");
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
