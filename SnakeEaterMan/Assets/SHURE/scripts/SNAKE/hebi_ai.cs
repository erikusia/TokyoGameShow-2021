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
    Animator animator;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextIndex = Random.Range(0, 3);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetFloat("MoveSpeed", 1.0f);
        agent.destination = enemys[nextIndex].transform.position;
    }
}
