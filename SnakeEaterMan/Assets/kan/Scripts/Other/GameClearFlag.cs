using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearFlag : MonoBehaviour
{
    //シーン持越し用静的変数
    public static string winner = "none";
    //検索用リスト
    private List<GameObject> matName = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤー分の名前をリストに入れる
        matName.Insert(0, GameObject.FindWithTag("Player1"));
        matName.Insert(1, GameObject.FindWithTag("Player2"));
        matName.Insert(2, GameObject.FindWithTag("Player3"));
        matName.Insert(3, GameObject.FindWithTag("Player4"));
    }
    //GameObject.FindWithTag("Player2").transform.Find("body1").GetComponent<MeshRenderer>().material
    // Update is called once per frame
    void Update()
    {

        //プレイヤー分のマテリアルが白か透明ではなかった場合誰かがクリアしている.
        foreach(var mat in matName)
        {
            //if (mat.transform.Find("body1").GetComponent<MeshRenderer>().material.name.Replace(instanceName,"") != "White "&&
            //    mat.transform.Find("body1").GetComponent<MeshRenderer>().material.name.Replace(instanceName,"") != "Transparency ")
            if (!mat.transform.Find("body1").GetComponent<MeshRenderer>().material.name.Contains("White")&&
                !mat.transform.Find("body1").GetComponent<MeshRenderer>().material.name.Contains("Transparency"))
            {
                //シーン遷移
                //Debug.Log("GameClear " + mat.name + " が勝ち");
                winner = mat.name;
                SceneManager.LoadScene("End");
            }
        }
    }
}
