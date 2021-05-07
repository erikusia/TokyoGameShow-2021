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
    int[] number;

    int maxRank = 1;

    // Start is called before the first frame update
    void Start()
    {
        list.Add(player1);
        list.Add(player2);
        list.Add(player3);
        list.Add(player4);
    }

    // Update is called once per frame       Debug.Log("");
    void Update()
    {
        number = new int[4];
        //ランキング
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (list[i].GetComponent<PlayerColor>().materialsName[j] != "White" &&
                    list[i].GetComponent<PlayerColor>().materialsName[j] != "Transparency")
                {
                    number[i]++;
                }
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
        for(int i = 0;i < number.Length;i++)
        {
            if (number[i] == maxRank && i != num)
            {
                list[i].transform.Find("group1").GetComponentInChildren<PlayerStatus>().PlayerState = "Debuff";
            }
        }
    }
    /// <summary>
    /// カラーシャッフル
    /// </summary>
    private void ColorShuffle(int num)
    {
        List<GameObject> l = new List<GameObject>();
        if (player1.GetComponent<PlayerColor>().materialsName[0] != "Transparency")
            l.Add(player1);
        if (player2.GetComponent<PlayerColor>().materialsName[0] != "Transparency")
            l.Add(player2);
        if (player3.GetComponent<PlayerColor>().materialsName[0] != "Transparency")
            l.Add(player3);
        if (player4.GetComponent<PlayerColor>().materialsName[0] != "Transparency")
            l.Add(player4);

        int r = 0;
        int lmax = l.Count;
        for (int i = 0; i < lmax;i++)
        {
            r = Random.Range(0, l.Count);
            list[i].GetComponent<PlayerColor>().ChangeColor(l[r].GetComponent<PlayerColor>().materialsName);
            l.RemoveAt(r);
        }
        //Debug.Log(c);
    }
}
