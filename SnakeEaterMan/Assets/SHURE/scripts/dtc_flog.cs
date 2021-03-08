using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dtc_flog : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;

    private NavMeshAgent agent;//動くために必要な物4

    [SerializeField]
    private Transform[] ROOT;
    private int nextIndex = 0;
    //private Transform rootA;//目標（通るルート
    //public Transform rootB;//目標（通るルート
    //public Transform rootC;//目標（通るルート


    [SerializeField]
    private Transform target;//目標(プレイヤー
    public Transform t2;
    public Transform t3;
    public Transform t4;

    private float distance;//プレイヤー距離
    private float distance2;
    private float distance3;
    private float distance4;

    //public bool rta = false;
    //public bool rtb = false;
    //public bool rtc = false;

    //リスポーン    
    [SerializeField]
    private GameObject spawnpoint;

    float deathCout = 0;
    private bool deathflag = false;
    private GameObject flogpos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        flogpos = transform.root.gameObject;
        //agent.autoBraking = false;
        agent.destination = ROOT[nextIndex].transform.position;
    }


     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="rA")
        {
            if(nextIndex < ROOT.Length -1)
            {
                nextIndex++;
            }
            else
            {
                nextIndex = 0;
            }
        }
        //インデックスに応じた目的地に設定する
        agent.destination = ROOT[nextIndex].transform.position;
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

        //rda = Vector3.Distance(transform.position,
        //    rootdistanceA.transform.position);
        //rdb = Vector3.Distance(transform.position,
        //    rootdistanceB.transform.position);
        //rdc = Vector3.Distance(transform.position,
        //    rootdistanceC.transform.position);

        //if (rta == false)
        //{
        //    agent.isStopped = false;
        //    agent.SetDestination(rootA.transform.position);
        //}
        //if (rtb == true)
        //{
        //    agent.isStopped = false;
        //    agent.SetDestination(rootB.transform.position);

        //}
        //if (rtc == true)
        //{
        //    agent.isStopped = false;
        //    agent.SetDestination(rootC.transform.position);
  
        //}


        //距離が1なら
        if (distance < 1)
        {
            agent.destination = target.transform.position;
            agent.destination = t2.transform.position;
            agent.destination = t3.transform.position;
            agent.destination = t4.transform.position;
            spawnpoint.GetComponent<Collider>().enabled = false;

            if (GameObject.FindWithTag("head1"))
            {
                spawnpoint.GetComponent<Collider>().enabled = false;
                deathflag = true;
            }
            if (GameObject.FindWithTag("head2"))
            {
                spawnpoint.GetComponent<Collider>().enabled = false;
                deathflag = true;
            }
            if (GameObject.FindWithTag("head3"))
            {
                spawnpoint.GetComponent<Collider>().enabled = false;
                deathflag = true;
            }
            if (GameObject.FindWithTag("head4"))
            {
                spawnpoint.GetComponent<Collider>().enabled = false;
                deathflag = true;
            }
        }
        //死亡フラグがtrueなら
        if (deathflag == true)
        {
            spawnpoint.GetComponent<Renderer>().material = materials[1];
            Debug.Log("死んだよ");
            deathCout += Time.deltaTime;

            flogpos.transform.localPosition = spawnpoint.transform.localPosition;

        }
        //死亡カウントが６より大きいなら
        if (deathCout > 6)
        {
            Debug.Log("復活");
            spawnpoint.GetComponent<Renderer>().material = materials[0];
            spawnpoint.GetComponent<Collider>().enabled = true;
            deathCout = 0;
            deathflag = false;
            //flog.GetComponent<Renderer>().material = materials[Random.Range(0, 1)];
        }
        //Debug.Log(agent.velocity.magnitude);//移動量
    }

}
