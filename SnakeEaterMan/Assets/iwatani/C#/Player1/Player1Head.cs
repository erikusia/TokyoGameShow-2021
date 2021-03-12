using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Head : MonoBehaviour
{
    //食べた時
    [SerializeField]
    private Material[] materials;
    [SerializeField]
    private GameObject[] gameObjects;
    private Material tailMaterial;
    bool hit = false;
    bool hitDef=false;
    float hitCount = 0;
    float hitCount2 = 0;
    [SerializeField]
    private Text colorText;
    private string tailMatName;
    // Start is called before the first frame update
    void Start()
    {
        gameObjects[0].GetComponent<Renderer>().material = materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (hitDef == true)
        {
            hitCount2 += Time.deltaTime;
            if (hitCount2 >= 0.5)
            {
                hitDef = false;
            }
        }
        else hitCount2 = 0;
        if (hit == true)
        {
            hitCount += Time.deltaTime;
            gameObject.transform.root.GetComponent<Player1Move>().m_walk = 20;
            gameObject.transform.root.GetComponent<Player1Move>().m_dash = 14;

            if (hitCount >= 2)
            {
                gameObject.transform.root.GetComponent<Player1Move>().m_walk = 10;
                gameObject.transform.root.GetComponent<Player1Move>().m_dash = 5;
                colorText.text = "";
                hit = false;

            }
        }
        else hitCount = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        //しっぽにぶつかったら
        if (collision.gameObject.tag == "tail"&& hitDef==false)
        {
            hitCount = 0;
            hit = true;
            hitDef = true;
            tailMaterial = collision.gameObject.GetComponent<Renderer>().material;
            tailMatName= tailMaterial.name;

            switch (tailMatName.Substring(0, 1))
            {
                case "B":
                    colorText.text = "青色を食べた";
                    colorText.color = new Color(0, 0, 255);
                    break;
                case "G":
                    colorText.text = "緑色を食べた";
                    colorText.color = new Color(0, 255, 0);
                    break;
                case "R":
                    colorText.text = "赤色を食べた";
                    colorText.color = new Color(255, 0, 0);
                    break;
                case "Y":
                    colorText.text = "黄色を食べた";
                    colorText.color = new Color(255, 255, 0);
                    break;
            }

            for (int i = 0; i < gameObjects.Length; i++)
            {
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

        //if (collision.gameObject.tag != "Player1")
        //{
        //    //Debug.Log(collision.gameObject.tag);
        //}

        if (collision.gameObject.tag=="flog"&&hitDef==false)
        {
            hit = true;
            gameObject.transform.root.GetComponent<Player1Move>().dashTime += 1;
        }
    }
}