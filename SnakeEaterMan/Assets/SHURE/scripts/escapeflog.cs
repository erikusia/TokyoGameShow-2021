using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class escapeflog : MonoBehaviour
{
    [SerializeField]
    private Transform target;//目標(プレイヤー
    private NavMeshAgent agent;//動くために必要な物
    [SerializeField]
    private Transform runpoint;//目標（帰宅するポイント

    public float distance;//距離
    //GameObject movepos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //    runpoint = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //二者間の距離を計算してfloat 一定値に行かなければ追跡する
        distance = Vector3.Distance(transform.position,
            target.transform.position);//距離を計算

        if (distance < 10)
        {
            //5より近い場合追尾
            //ここのagent.destination -= target.transform.positionを
            //　-=　にしていることで、近くに来たら逃げるを実装

            
            agent.destination = agent.destination - (target.transform.position - agent.destination);
            //Debug.Log(target.transform.position);
            //Debug.Log(distance);
        }
        else
        {
            agent.destination = runpoint.transform.position;
        }
        //距離が１以上の時、プレイヤーの近くで停止する
        if (distance < 1)
        {
            agent.destination = target.transform.position;
        }
        //  agent.SetDestination(target.position);
    }

}
