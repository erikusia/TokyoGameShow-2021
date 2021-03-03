using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class escapeflog : MonoBehaviour
{
    [SerializeField]
    Transform target;
    NavMeshAgent agent;

    //プレイヤーと逆の方向に向く
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
