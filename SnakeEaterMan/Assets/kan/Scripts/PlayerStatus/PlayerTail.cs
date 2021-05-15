using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTail : MonoBehaviour
{
    //色変更用
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject[] gameObjects;

    //リスポーン用
    public bool deathFlag = false;
    float respawnCount = 0;
    float dashTime;
    [SerializeField]
    private GameObject spawnPoint;
    private GameObject PlayerPos;
    bool hit;
    public bool dash=false;

    private GameObject parent;
    private Quaternion pt;
    [SerializeField]
    private GameObject itemUi;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = transform.root.gameObject;

        parent = gameObject.transform.root.gameObject;
        pt = parent.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(dash)
        {
            dashTime += Time.deltaTime;
        }
        if (deathFlag == true)
        {
            //Debug.Log("Player1Dead");
            //リスポーンするまでの時間計測
            respawnCount += Time.deltaTime;
            //リスポーンする場所に移動
            //PlayerPos.transform.localPosition = spawnPoint.transform.localPosition;
            PlayerPos.GetComponent<PlayerMove>().enabled = false;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                //gameObjects[i].GetComponent<Renderer>().material = materials[5];
                gameObjects[i].GetComponent<Collider>().enabled = false;
            }
            if (respawnCount > 3)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    //ここが白にしているところ
                    if(gameObjects[i].name != "Head1")
                    {
                        gameObjects[i].GetComponent<Renderer>().material = materials[4];
                        gameObjects[i].GetComponent<Collider>().enabled = true;
                    }
                    else
                    {
                        gameObjects[i].GetComponent<Renderer>().material = materials[6];
                        gameObjects[i].GetComponent<Collider>().enabled = true;
                    }
                }
                gameObjects[0].GetComponent<Renderer>().material = materials[Random.Range(0, 4)];
                deathFlag = false;
                PlayerPos.GetComponent<PlayerMove>().enabled = true;
                itemUi.SetActive(true);
                if (parent.GetComponent<PlayerMove>().playerNumber == 0)
                {
                    parent.GetComponent<NavMeshAgent>().speed = 3.5f;
                }
            }

            //死んだ時の演出
            if(respawnCount < 3)
            {
                itemUi.SetActive(false);

                if (parent.GetComponent<PlayerMove>().playerNumber == 0)
                {
                    parent.GetComponent<NavMeshAgent>().speed = 0;
                }
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Renderer>().material = materials[4];
                }
                if (respawnCount < 1)//1.0f - 1.0f / 60.0f * respawnCount
                {
                    parent.transform.Rotate(new Vector3(0, 0, 2.0f));
                }
                if (respawnCount >= 1 && respawnCount < 2)
                {
                    var s = parent.transform.localScale;
                    s -= new Vector3(0.018f, 0.018f, 0.018f);
                    if (s.x > 0)
                        parent.transform.localScale = s;
                    if (s.x <= 0)
                        parent.transform.localScale = new Vector3(0, 0, 0);
                }                  
                if (respawnCount >= 2)
                {
                    var s = parent.transform.localScale += new Vector3(0.018f, 0.018f, 0.018f);
                    if (s.x < 0.53f)
                        parent.transform.localScale = s;
                    if (s.x >= 0.53f)
                        parent.transform.localScale = new Vector3(0.53f, 0.5f, 0.5f);

                    parent.transform.rotation = pt;
                    PlayerPos.transform.localPosition = spawnPoint.transform.localPosition;
                }             
            }
        }
        else
        {
            deathFlag = false;
            respawnCount = 0;
        }

        if(hit)
        {
            hit = false;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.transform.root.name +"の"+ collision.gameObject.tag+ "に当たった");
        Debug.Log("hitのステータス:"+hit);
        //頭がぶつかったら
        if (collision.gameObject.tag == "head1"&&!hit)
        {
            hit = true;
            
            //Debug.Log(collision.gameObject.transform.root.name+"当たった");
            for (int i = 0; i < gameObjects.Length - 2; i++)
            {
                gameObjects[i].GetComponent<Renderer>().material = gameObjects[i + 1].GetComponent<Renderer>().material;
            }
            gameObjects[3].GetComponent<Renderer>().material = materials[4];

            string tailMatName = gameObjects[0].GetComponent<Renderer>().material.name;
            string white = "White";
            if (white.Equals(tailMatName.Substring(0, 5)))
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Renderer>().material = materials[5];
                    deathFlag = true;
                }
            }
            if (!deathFlag)
            {
                this.dash = true;
            }
            //Debug.Log(dash);
        }

        //else if(dashTime>=2.5f)
        //{
        //    this.dash = false;
        //}


    }
}
