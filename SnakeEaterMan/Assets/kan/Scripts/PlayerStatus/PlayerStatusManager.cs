using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    [Header("Player1を入れる"), SerializeField]
    private GameObject player1;
    [Header("Player2を入れる"), SerializeField]
    private GameObject player2;
    [Header("Player3を入れる"), SerializeField]
    private GameObject player3;
    [Header("Player4を入れる"), SerializeField]
    private GameObject player4;

    private List<GameObject> list = new List<GameObject>();
    int[] number = new int[4];

    int maxRank = 0;

    // Start is called before the first frame update
    void Start()
    {
        list.Add(player1);
        list.Add(player2);
        list.Add(player3);
        list.Add(player4);
    }

    // Update is called once per frame
    void Update()
    {
        //ランキング
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (list[i].GetComponent<PlayerColor>().materialsName[j] != "White")
                    number[i]++;
            }
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (number[i] > maxRank)
                maxRank = number[i];
        }

        for (int i = 0; i < list.Count; i++)
        {
            switch (list[i].transform.Find("group1").GetComponentInChildren<ItemState>().GetItem)
            {
                case "Thunder":
                    Thunder(i);
                    list[i].transform.Find("group1").GetComponentInChildren<ItemState>().GetItem = "None";
                    break;
                case "Debuff":
                    Debuff(i);
                    list[i].transform.Find("group1").GetComponentInChildren<ItemState>().GetItem = "None";
                    break;
                case "ColorShuffle":
                    ColorShuffle(i);
                    list[i].transform.Find("group1").GetComponentInChildren<ItemState>().GetItem = "None";
                    break;
            }
        }
    }
    /// <summary>
    /// サンダーのステータス付与
    /// </summary>
    private void Thunder(int num)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (i != num)
                list[i].transform.Find("group1").GetComponentInChildren<PlayerStatus>().PlayerState = "Thunder";
        }
    }
    /// <summary>
    /// デバフのステータス付与
    /// </summary>
    private void Debuff(int num)
    {
        if (number[num] == maxRank)
        {
            list[num].transform.Find("group1").GetComponentInChildren<PlayerStatus>().PlayerState = "Debuff";
        }
        Debug.Log(list[num].name);
    }
    /// <summary>
    /// カラーシャッフルのステータス付与
    /// </summary>
    private void ColorShuffle(int num)
    {

    }
}
