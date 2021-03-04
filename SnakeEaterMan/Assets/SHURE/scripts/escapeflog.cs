using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class escapeflog : MonoBehaviour
{
    [SerializeField]
    public Transform target;//目標
    public NavMeshAgent agent;//動くために必要な物

    public float distance;//距離

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //二者間の距離を計算してfloat 一定値に行かなければ追跡する
        distance = Vector3.Distance(transform.position,
            target.transform.position);//距離を計算
        //Debug.Log(distance);
        if(distance < 5)
        {
            //5より近い場合追尾
            //ここのagent.destination -= target.transform.positionを
            //　-=　にしていることで、近くに来たら逃げるを実装
            //細かいのはまだ
            agent.destination -= target.transform.position;
        }
        //距離が１以上の時、プレイヤーの近くで停止する
        if(distance <1)
        {
            agent.destination = target.transform.position;
        }
        //  agent.SetDestination(target.position);
    }

}
