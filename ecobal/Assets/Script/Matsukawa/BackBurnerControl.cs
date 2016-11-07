using UnityEngine;
using System.Collections;

public class BackBurnerControl : MonoBehaviour
{
    private GameObject rightBurner;
    private GameObject leftBurner;

    private ParticleSystem rightParticle;
    private ParticleSystem leftParticle;

    public float normalStartSize;
    public float moveStartSize;

    public float normalStartSpeed;
    public float moveStartSpeed;

    void Start()
    {
        rightBurner = transform.FindChild("RightBurner").gameObject;
        leftBurner = transform.FindChild("LeftBurner").gameObject;

        rightParticle = rightBurner.GetComponent<ParticleSystem>();
        leftParticle = leftBurner.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") >= 0.2f)
        {
            LeftBurnerGrowing();
            RightBurnerNormal();
        }
        else if (Input.GetAxis("Horizontal") <= -0.2f)
        {
            RightBurnerGrowing();
            LeftBurnerNormal();
        }
        else if (Input.GetAxis("Horizontal") > -0.2f && Input.GetAxis("Horizontal") < 0.2f)
        {
            RightBurnerNormal();
            LeftBurnerNormal();
        }
    }

    void RightBurnerGrowing()
    {
        rightParticle.startSize = moveStartSize;
        rightParticle.startSpeed = moveStartSpeed;
    }

    void LeftBurnerGrowing()
    {
        leftParticle.startSize = moveStartSize;
        leftParticle.startSpeed = moveStartSpeed;
    }

    void RightBurnerNormal()
    {
        rightParticle.startSize = normalStartSize;
        rightParticle.startSpeed = normalStartSpeed;
    }

    void LeftBurnerNormal()
    {
        leftParticle.startSize = normalStartSize;
        leftParticle.startSpeed = normalStartSpeed;
    }
}
