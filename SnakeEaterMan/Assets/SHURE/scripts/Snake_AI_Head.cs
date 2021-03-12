using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake_AI_Head : MonoBehaviour
{
    //食べた時
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject[] gameObjects;
    private Material tailMaterial;
    bool hit = false;
    float hitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects[0].GetComponent<Renderer>().material = materials[3];
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            hitCount += Time.deltaTime;
            //gameObject.transform.root.GetComponent<Player4Move>().m_walk = 20;
            //gameObject.transform.root.GetComponent<Player4Move>().m_dash = 14;
            if (hitCount >= 2)
            {
                //gameObject.transform.root.GetComponent<Player4Move>().m_walk = 10;
                //gameObject.transform.root.GetComponent<Player4Move>().m_dash = 7;
                hit = false;
            }
        }
        else hitCount = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        //しっぽにぶつかったら
        if (collision.gameObject.tag == "tail" && hit == false)
        {
            //Debug.Log(collision.gameObject.tag);
            hit = true;
            string tailMatName = collision.gameObject.GetComponent<Renderer>().material.name;
            tailMaterial = collision.gameObject.GetComponent<Renderer>().material;
            //Debug.Log("相手のしっぽ:" + tailMaterial.name);
            for (int i = 0; i < gameObjects.Length; i++)
            {
                //Debug.Log("自分のしっぽ:" + gameObjects[i].GetComponent<Renderer>().material.name);
                string objectName = gameObjects[i].GetComponent<Renderer>().material.name;
                string white = materials[4].name;

                //Debug.Log("自分のしっぽ:" + objectName.Substring(0, 5));
                //Debug.Log("相手のしっぽ:" + tailMaterial);
                //Debug.Log(objectName.Substring(0, 6).Equals(tailMatName.Substring(0, 6)));
                if (objectName.Substring(0, 6).Equals(tailMatName.Substring(0, 6)) && hit)
                {
                    //Debug.Log("持ってる色だよ");
                    //gameObject.transform.root.GetComponent<Player4Move>().dashTime += 1;
                    break;
                }
                else if (white.Equals(objectName.Substring(0, 5), StringComparison.Ordinal) && hit)
                {
                    //  Debug.Log("持ってない色だよ");
                    gameObjects[i].GetComponent<Renderer>().material = tailMaterial;
                    break;
                }
            }
        }

        if (collision.gameObject.tag == "flog" && hit == false)
        {
            hit = true;
            //  gameObject.transform.root.GetComponent<Player4Move>().dashTime += 1;
        }
    }
}
