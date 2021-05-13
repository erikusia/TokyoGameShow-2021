using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dtc_flog : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private GameObject[] FlogObj;

    private NavMeshAgent agent;//動くために必要な物4
    public Transform runpoint;//リスポーン

    [SerializeField]//目的地
    private Transform[] ROOT;
    private int nextIndex = 0;

    [SerializeField]
    private Transform target;//目標(プレイヤー
    [SerializeField]
    private Transform t2;
    [SerializeField]
    private Transform t3;
    [SerializeField]
    private Transform t4;

    //リスポーン    
    [SerializeField]
    private GameObject spawnpoint;
    //private float flogx;
    //private float flogy;
    //private float flogz;
    public float deathCout = 0;
    private bool deathflag = false;
    private GameObject flogpos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        flogpos = transform.root.gameObject;//カエルの座標
        agent.autoBraking = false;
        agent.destination = ROOT[nextIndex].transform.position;//向かう座標
    }
    //移動するときに別のルートを取るため、
    //ｒAに当たったらlengthから-1して+して次に向かう
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rA")
        {
            if (nextIndex < ROOT.Length - 1)
            {
                nextIndex++;
            }
            else
            {
                nextIndex = 0;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "head1" || col.gameObject.tag == "head2" ||
            col.gameObject.tag == "head3" || col.gameObject.tag == "head4")
        {
            flogpos.GetComponent<Collider>().enabled = false;
            deathflag = true;

            //プレイヤーように追加
            if (col.gameObject.tag == "head1")
                GameResult.flogEatCount++;
        }
    }
    void Update()
    {
        // float a = 0.25f;
        Vector3 pos = transform.position;
        pos.y = 0.25f;
        transform.position = pos;
        //インデックスに応じた目的地に設定する
        agent.destination = ROOT[nextIndex].transform.position;
        //死亡フラグがtrueなら
        if (deathflag == true)
        {
            deathCout += Time.deltaTime;
            for (int i = 0; i < FlogObj.Length; i++)
            {
                FlogObj[i].GetComponent<SkinnedMeshRenderer>().material = materials[4];
            }
            flogpos.transform.localPosition = spawnpoint.transform.localPosition;//リスポーン地点
        }
        //死亡カウントが６より大きいなら
        if (deathCout > 6)
        {
            //Debug.Log("復活");
            for (int i = 0; i < FlogObj.Length; i++)
            {
                //Debug.Log("色");
                FlogObj[i].GetComponent<SkinnedMeshRenderer>().material = materials[i];
            }
            flogpos.GetComponent<Collider>().enabled = true;
            deathCout = 0;

            deathflag = false;
        }
        //flogpos.transform.localPosition = spawnpoint.transform.localPosition;
        // flogpos.GetComponent<Renderer>().material = materials[0];
        //Debug.Log(agent.velocity.magnitude);//移動量
    }
}
