using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Head : MonoBehaviour
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
        gameObjects[0].GetComponent<Renderer>().material = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            hitCount += Time.deltaTime;
            gameObject.transform.root.GetComponent<Player1Move>().m_walk /= 2;
            gameObject.transform.root.GetComponent<Player1Move>().m_dash /= 2;
            if (hitCount >= 2)
            {
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
            
            tailMaterial = collision.gameObject.GetComponent<Renderer>().material;
            string tailMatName= tailMaterial.name;

            
            for (int i = 0; i < gameObjects.Length; i++)
            {
                hit = true;
                string objectName = gameObjects[i].GetComponent<Renderer>().material.name;
                string white = materials[4].name;

                Debug.Log("自分のしっぽ:" + objectName);
                Debug.Log("相手のしっぽ:" + tailMaterial);
                Debug.Log(objectName.Substring(0, 6).Equals(tailMatName.Substring(0, 6)));
                if (objectName.Substring(0,6).Equals(tailMatName.Substring(0, 6), StringComparison.Ordinal) && hit)
                {
                    Debug.Log("持ってる色だよ");
                    gameObject.transform.root.GetComponent<Player1Move>().dashTime += 1;
                    break;
                }           
                else if (white.Equals(objectName.Substring(0,5), StringComparison.Ordinal) && hit)
                {
                    Debug.Log("持ってない色だよ");
                    gameObjects[i].GetComponent<Renderer>().material = tailMaterial;
                    break;
                }
            }
        }

        if(collision.gameObject.tag=="flog"&&hit==false)
        {
            hit = true;
            gameObject.transform.root.GetComponent<Player1Move>().dashTime += 1;
        }
    }
}