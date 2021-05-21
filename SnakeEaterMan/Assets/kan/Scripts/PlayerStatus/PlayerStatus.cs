using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //public enum Status
    //{
    //    DashItem,
    //    Paralysis,
    //    Thunder,
    //    Debuff,
    //}

    private string status;

    [Header("ダッシュパーティクル"), SerializeField]
    private GameObject dashParticle;

    [Header("カミナリパーティクル"),SerializeField]
    private GameObject thunderParticle;

    [Header("デバフパーティクル"), SerializeField]
    private GameObject debuffParticle;

    [Header("麻痺パーティクル"), SerializeField]
    private GameObject paralysisParticle;

    [SerializeField]
    private Material[] m;

    public string PlayerState
    {
        get { return status; }
        set { status = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        thunderParticle.GetComponent<ParticleSystem>().Stop();
        debuffParticle.GetComponent<ParticleSystem>().Stop();
        paralysisParticle.GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.root.Find("group1").GetComponentInChildren<PlayerTail>().deathFlag)
        {
            thunderParticle.GetComponent<ParticleSystem>().Stop();
            debuffParticle.GetComponent<ParticleSystem>().Stop();
            paralysisParticle.GetComponent<ParticleSystem>().Stop();
            dashParticle.GetComponent<TrailRenderer>().material = m[0];
        }
        else
        {
            dashParticle.GetComponent<TrailRenderer>().material = m[1];
        }

        if (status == "Thunder")
        {
            thunderParticle.GetComponent<ParticleSystem>().Play();
            debuffParticle.GetComponent<ParticleSystem>().Play();
        }

        if(status == "Debuff")
        {
            debuffParticle.GetComponent<ParticleSystem>().Play();
        }

        if(status == "Paralysis")
        {
            paralysisParticle.GetComponent<ParticleSystem>().Play();
        }

        if (status == "Paralysis" || status == "Thunder" || status == "Debuff")
        {
            //あしおそ
            GetComponent<PlayerHead>().hit = true;
            //Debug.Log(gameObject.transform.root.gameObject.name + status);
            if(transform.root.GetComponent<PlayerMove>().playerNumber != 0)
                status = "None";
        }    
    }
}
