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

    private float defSpeed;
    private float debuffTime;
    private bool debuff;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        nextIndex = Random.Range(0, 3);
        animator = GetComponent<Animator>();
        defSpeed = agent.speed;
        debuffTime = 0.0f;
        debuff = false;
    }
    void Update()
    {
        animator.SetFloat("MoveSpeed", 1.0f);
        time += Time.deltaTime;
        
        if(time<=2)
        {
            time2 = 0;
            agent.destination = enemys[nextIndex].transform.position - tailPos;
           // Debug.Log("ちょい↓");
        }
        else if(time>2)
        {
            agent.destination = enemys[nextIndex].transform.position;
            time2 += Time.deltaTime;
           // Debug.Log("本体");
            if (time2>=2)
            {
                time = 0;
            }
        }

        if(debuff)
        {
            debuffTime += Time.deltaTime;
            agent.speed = 1.0f;
            GetComponentInChildren<PlayerStatus>().PlayerState = "None";
            if (debuffTime > 3.0f)
            {
                debuff = false;
                debuffTime = 0;
                agent.speed = defSpeed;
            }
        }

        if(GetComponentInChildren<PlayerStatus>().PlayerState == "Paralysis")
        {
            debuff = true;
        }
        else if(GetComponentInChildren<PlayerStatus>().PlayerState == "Thunder")
        {
            debuff = true;
        }
        else if(GetComponentInChildren<PlayerStatus>().PlayerState == "Debuff")
        {
            debuff = true;
        }
    }
}
