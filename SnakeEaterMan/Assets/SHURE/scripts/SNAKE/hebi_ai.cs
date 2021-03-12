using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class hebi_ai : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemys;
    public int nextIndex;
    private NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextIndex = Random.Range(0, 2);
    }
    void Update()
    {
        agent.destination = enemys[nextIndex].transform.position;
    }
}
