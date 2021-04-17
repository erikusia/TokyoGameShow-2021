using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class escapeflog : MonoBehaviour
{
    //色変更用
    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private GameObject[] FlogObj;

    [SerializeField]
    private Transform target;//目標(プレイヤー
    public Transform t2;
    public Transform t3;
    public Transform t4;
    private NavMeshAgent agent;//動くために必要な物
    [SerializeField]
    private Transform runpoint;//目標（帰宅するポイント
    [SerializeField]
    private GameObject flog;

    public float distance;//距離
    public float distance2;
    public float distance3;
    public float distance4;
    //リスポーン
    float deathCout = 0;
    private bool deathflag = false;
    private GameObject flogpos;
    //GameObject movepos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        flogpos = transform.root.gameObject;
    }

    void Update()
    {
        //二者間の距離を計算してfloat 一定値に行かなければ追跡する
        distance = Vector3.Distance(transform.position,
            target.transform.position);//距離を計算
        distance2 = Vector3.Distance(transform.position,
      t2.transform.position);//距離を計算
        distance3 = Vector3.Distance(transform.position,
    t3.transform.position);//距離を計算
        distance4 = Vector3.Distance(transform.position,
    t4.transform.position);//距離を計算
        if (distance < 10)
        {
            agent.destination = agent.destination - (target.transform.position - agent.destination);
        }
        else
        { agent.destination = runpoint.transform.position; }
        if (distance2 <10)//|| distance3 > 20 || distance4 > 20)
        {
            agent.destination = agent.destination - (t2.transform.position - agent.destination);
        }
        if (distance3 < 10)//|| distance2 > 20 || distance4 > 20)
        {
            agent.destination = agent.destination - (t3.transform.position - agent.destination);
        }
        if (distance4 < 10)//|| distance2 > 20 || distance3 > 20)
        {
            agent.destination = agent.destination - (t4.transform.position - agent.destination);
        }


        if (deathflag == true)
        {
          //  flog.GetComponent<Renderer>().material = materials[1];
            //Debug.Log("死んだよ");
            deathCout += Time.deltaTime;
            for (int i = 0; i < FlogObj.Length; i++)
            {
                FlogObj[i].GetComponent<SkinnedMeshRenderer>().
                    material = materials[4];
            }
            flogpos.transform.localPosition =
                runpoint.transform.localPosition;
        }
        if (deathCout > 6)
        {
            Debug.Log("復活");
            for (int i = 0; i < FlogObj.Length; i++)
            {
                //Debug.Log("色");
                FlogObj[i].GetComponent<SkinnedMeshRenderer>().material = materials[i];
            }
            //flog.GetComponent<Renderer>().material = materials[0];
            flog.GetComponent<Collider>().enabled = true;
            deathCout = 0;
            deathflag = false;
            //flog.GetComponent<Renderer>().material =
            ////materials[Random.Range(0, 1)];
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "head1" || col.gameObject.tag == "head2" ||
            col.gameObject.tag == "head3" || col.gameObject.tag == "head4")
        {
            flog.GetComponent<Collider>().enabled = false;
            deathflag = true;

            //プレイヤーように追加
            if (col.gameObject.tag == "head1")
                GameResult.flogEatCount++;
        }
    }
}
