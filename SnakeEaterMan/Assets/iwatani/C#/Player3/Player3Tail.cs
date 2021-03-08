using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Tail : MonoBehaviour
{
    //色変更用
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject[] gameObjects;

    //リスポーン用
    bool deathFlag = false;
    float respawnCount = 0;
    [SerializeField]
    private GameObject spawnPoint;
    private GameObject PlayerPos;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPos = transform.root.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (deathFlag == true)
        {
            Debug.Log("Player1Dead");
            //リスポーンするまでの時間計測
            respawnCount += Time.deltaTime;
            //リスポーンする場所に移動
            PlayerPos.transform.localPosition = spawnPoint.transform.localPosition;
            PlayerPos.GetComponent<Player3Move>().enabled = false;
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].GetComponent<Renderer>().material = materials[5];
                gameObjects[i].GetComponent<Collider>().enabled = false;
            }
            if (respawnCount > 3)
            {
                for (int i = 0; i < gameObjects.Length; i++)
                {
                    gameObjects[i].GetComponent<Renderer>().material = materials[4];
                    gameObjects[i].GetComponent<Collider>().enabled = true;
                }
                gameObjects[0].GetComponent<Renderer>().material = materials[Random.Range(0, 4)];
                deathFlag = false;
                PlayerPos.GetComponent<Player3Move>().enabled = true;
            }
        }
        else
        {
            deathFlag = false;
            respawnCount = 0;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //頭がぶつかったら
        if (collision.gameObject.tag == "head1" || collision.gameObject.tag == "head2" ||
            collision.gameObject.tag == "head4" && deathFlag == false)
        {
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
        }
    }
}