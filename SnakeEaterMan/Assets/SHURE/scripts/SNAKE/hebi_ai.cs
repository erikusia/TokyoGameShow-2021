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
    [SerializeField]
    private Vector3 tailPos=new Vector3();
    private float time;
    private float time2;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextIndex = Random.Range(0, 3);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animator.SetFloat("MoveSpeed", 1.0f);
        time += Time.deltaTime;
        
        if(time<=2)
        {
            time2 = 0;
            agent.destination = enemys[nextIndex].transform.position - tailPos;
            Debug.Log("ちょい↓");
        }
        else if(time>2)
        {
            agent.destination = enemys[nextIndex].transform.position;
            time2 += Time.deltaTime;
            Debug.Log("本体");
            if (time2>=2)
            {
                time = 0;
            }
        }
        
    }
}
