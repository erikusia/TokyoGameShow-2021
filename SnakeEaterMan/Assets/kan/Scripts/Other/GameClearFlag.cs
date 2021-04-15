﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearFlag : MonoBehaviour
{
    //シーン持越し用静的変数
    public static string winner = "none";
    //検索用リスト
    private List<GameObject> matName = new List<GameObject>();

    [Header("Scene.mp3"),SerializeField]
    private AudioClip clips;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤー分の名前をリストに入れる
        matName.Insert(0, GameObject.FindWithTag("Player1"));
        //matName.Insert(1, GameObject.FindWithTag("Player2"));
        //matName.Insert(2, GameObject.FindWithTag("Player3"));
        //matName.Insert(3, GameObject.FindWithTag("Player4"));
		audioSource = GetComponent<AudioSource>();
    }
    //GameObject.FindWithTag("Player2").transform.Find("body1").GetComponent<MeshRenderer>().material
    // Update is called once per frame
    void Update()
    {

        //プレイヤー分のマテリアルが白か透明ではなかった場合誰かがクリアしている.
        foreach(var mat in matName)
        {

            //mat.transform.Find("group1").Find("Body1").GetComponent<SkinnedMeshRenderer>().material.name.Contains("White");
            if (!mat.transform.Find("group1").Find("Body1").GetComponent<SkinnedMeshRenderer>().material.name.Contains("White") &&
                !mat.transform.Find("group1").Find("Body1").GetComponent<SkinnedMeshRenderer>().material.name.Contains("Transparency") )
            {
                //シーン遷移
                //Debug.Log("GameClear " + mat.name + " が勝ち");
                winner = mat.name;
                audioSource.PlayOneShot(clips);
                SceneManager.LoadScene("End");
            }
        }
    }
}
