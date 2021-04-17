﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dtc_flog : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;

    [SerializeField]
    private GameObject[] FlogObj;

    private NavMeshAgent agent;//動くために必要な物4
    public Transform runpoint;//リスポーン

    [SerializeField]
    private Transform[] ROOT;
    private int nextIndex = 0;
    //private Transform rootA;//目標（通るルート
    //public Transform rootB;//目標（通るルート
    //public Transform rootC;//目標（通るルート


    [SerializeField]
    private Transform target;//目標(プレイヤー
    [SerializeField]
    private Transform t2;
    [SerializeField]
    private Transform t3;
    [SerializeField]
    private Transform t4;

    private float distance;//プレイヤー距離
    private float distance2;
    private float distance3;
    private float distance4;
    //リスポーン    
    [SerializeField]
    private GameObject spawnpoint;

    //private float flogx;
    //private float flogy;
    //private float flogz;


    public float deathCout = 0;
    private bool deathflag = false;
    private GameObject flogpos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        flogpos = transform.root.gameObject;
        //agent.autoBraking = false;
        agent.destination = ROOT[nextIndex].transform.position;
    }
    //移動するときに別のルートを取るため、
    //ｒAに当たったらlengthから-1して+して次に向かう
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "rA")
        {
            if (nextIndex < ROOT.Length - 1)
            {
                nextIndex++;
            }
            else
            {
                nextIndex = 0;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "head1" || col.gameObject.tag == "head2" ||
            col.gameObject.tag == "head3" || col.gameObject.tag == "head4")
        {
            flogpos.GetComponent<Collider>().enabled = false;
            deathflag = true;

            //プレイヤーように追加
            if (col.gameObject.tag == "head1")
                GameResult.flogEatCount++;
        }
    }
    void Update()
    {
        float a = 0.25f;
        Vector3 pos = transform.position;
        pos.y = 0.25f;
        transform.position = pos;
        //インデックスに応じた目的地に設定する
        agent.destination = ROOT[nextIndex].transform.position;
        //二者間の距離を計算してfloat 一定値に行かなければ追跡する
        distance = Vector3.Distance(transform.position,
            target.transform.position);//距離を計算
        distance2 = Vector3.Distance(transform.position,
      t2.transform.position);//距離を計算
        distance3 = Vector3.Distance(transform.position,
    t3.transform.position);//距離を計算
        distance4 = Vector3.Distance(transform.position,
    t4.transform.position);//距離を計算
        //死亡フラグがtrueなら
        if (deathflag == true)
        {
            //ランダムスポーン場所
            //flogx = Random.Range(-30.0f, 30.0f);
            //flogy = Random.Range(0.0f, 0.0f);
            //flogz = Random.Range(-30.0f, 30.0f);
            //   Debug.Log("死んだよ");
            deathCout += Time.deltaTime;
            //flogpos.transform.localPosition = //runpoint.transform.localPosition;
               // new Vector3(flogx, flogy, flogz);//Quaternion.identity);

            for (int i = 0; i < FlogObj.Length; i++)
            {
                FlogObj[i].GetComponent<SkinnedMeshRenderer>().material = materials[4];
            }


            flogpos.transform.localPosition = spawnpoint.transform.localPosition;
        }
        //死亡カウントが６より大きいなら
        if (deathCout> 6)
        {
            Debug.Log("復活");
            flogpos.GetComponent<Renderer>().material = materials[0];
            flogpos.GetComponent<Collider>().enabled = true;
            //flogpos.transform.localPosition = spawnpoint.transform.localPosition;

            for (int i = 0; i < FlogObj.Length; i++)
            {
                Debug.Log("色");
                FlogObj[i].GetComponent<SkinnedMeshRenderer>().material = materials[i];
            }
            deathCout = 0;
            deathflag = false;
        }
        //Debug.Log(agent.velocity.magnitude);//移動量
    }

}
