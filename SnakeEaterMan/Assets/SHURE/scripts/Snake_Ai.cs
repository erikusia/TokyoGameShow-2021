using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Snake_Ai : MonoBehaviour
{
    ////色
    //[SerializeField]
    //private Material[] materials;
    //this
    [SerializeField]
    private GameObject HEBI_AI;
    //目標(プレイヤー
    //[SerializeField]
    //private Transform target;
    //（仮）複数のオブジェクトを追う場合のリスト
    [SerializeField]
    private GameObject[] enemys;
    private int nextIndex = 0;
    //動くために必要な物
    private NavMeshAgent agent;

    public float distance;//距離

    private bool inArea = false;
    ////リスポーン用
    //bool deathFlag = false;
    //float respawnCount = 0;
    //[SerializeField]
    //private GameObject spawnPoint;

    //private GameObject Hebi_AI_Pos;
    // Start is called before the first frame update
    void Start()
    {
        // Hebi_AI_Pos= transform.root.gameObject;
        agent = GetComponent<NavMeshAgent>();
        HEBI_AI = transform.root.gameObject;
        agent.destination = enemys[nextIndex].transform.position;
        nextIndex = Random.Range(0, 14);
    }
    void Update()
    {
            
        distance = Vector3.Distance(transform.position,
    enemys[nextIndex].transform.position);//距f離を計算
        if (distance > 1)
        {
            agent.destination = enemys[nextIndex].transform.position;
        }
        //索敵範囲に敵がいて、かつ敵達もいるなら、agentの方向はその敵の咆哮に向かう
        if (inArea == true && enemys[nextIndex].activeInHierarchy == true)
        {
            agent.destination = enemys[nextIndex].transform.position;
        }
    }
    //void OnCollisionEnter(Collision col)
    //{
  
    //    //if (col.gameObject.name == "flogs")
    //    //{
    //    //}
    //}
}