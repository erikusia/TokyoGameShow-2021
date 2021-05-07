using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HowToPlayer : MonoBehaviour
{
    private int playerNum;
    private bool[] isPlayer = new bool[4];
    private GameObject[] gameObjects = new GameObject[4];

    private Text p1text;
    private Text p2text;
    private Text p3text;
    private Text p4text;

    public GUIStyleState styleState;
    private GUIStyle style;
    private bool isGUI;

    public bool b = false;
    private void Awake()
    {
        Time.timeScale = 0;
        playerNum = 1;
        AllFalse();
        style = new GUIStyle();
        styleState.textColor = new Color(0, 0, 0, 1);
        isGUI = false;

        gameObjects[0] = GameObject.Find("Player1");
        gameObjects[1] = GameObject.Find("Player2");
        gameObjects[2] = GameObject.Find("Player3");
        gameObjects[3] = GameObject.Find("Player4");

        p1text = transform.GetChild(1).GetComponentInChildren<Text>();
        p2text = transform.GetChild(2).GetComponentInChildren<Text>();
        p3text = transform.GetChild(3).GetComponentInChildren<Text>();
        p4text = transform.GetChild(4).GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < isPlayer.Length; i++)
        {
            if (isPlayer[i])
            {
                int n = i + 1;

                if (Input.GetButtonDown("A" + n.ToString()) && !b)
                {
                    Time.timeScale = 1;
                    //Aiを使う
                    OnAI();
                    isPlayer[i] = false;
                    isGUI = true;
                    b = true;
                    Destroy(gameObject);
                }
            }
        }

        if (isGUI)
            return;

        if (Input.GetButtonDown("A1")&& !isPlayer[0])
        {
            isPlayer[0] = true;
            playerNum++;
        }
        if (Input.GetButtonDown("A2") && !isPlayer[1])
        {
            isPlayer[1] = true;
            playerNum++;
        }
        if (Input.GetButtonDown("A3")&& !isPlayer[2])
        {
            isPlayer[2] = true;
            playerNum++;
        }
        if (Input.GetButtonDown("A4")&& !isPlayer[3])
        {
            isPlayer[3] = true;
            playerNum++;
        }
    }

    private void AllFalse()
    {
        for (int i = 0; i < isPlayer.Length; i++)
        {
            isPlayer[i] = false;
        }
    }

    private void OnGUI()
    {
        for (int i = 0; i < isPlayer.Length; i++)
        {
            if (isPlayer[i])
            {
                if(!b)
                {
                    style.normal = styleState;
                   // GUI.Label(new Rect(100 * i, 20, 100, 50), (i + 1).ToString() + "Player準備完了、Aボタンでスタート", style);

                    if (i == 0)
                        p1text.text = "[1P]準備完了 : Aボタンでスタート";
                    if (i == 1)
                        p2text.text = "[2P]準備完了 : Aボタンでスタート";
                    if (i == 2)
                        p3text.text = "[3P]準備完了 : Aボタンでスタート";
                    if (i == 3)
                        p4text.text = "[4P]準備完了 : Aボタンでスタート";
                }

            }
        }
    }

    private void OnAI()
    {
        for (int j = 0; j < isPlayer.Length; j++)
        {
            if (!isPlayer[j])
            {
                gameObjects[j].GetComponent<PlayerMove>().playerNumber = 0;
            }
            else
            {
                gameObjects[j].GetComponent<hebi_ai>().enabled = false;
                gameObjects[j].GetComponent<NavMeshAgent>().enabled = false;
                gameObjects[j].transform.Find("group1").GetComponentInChildren<Snake_Ai>().enabled = false;
            }
        }
    }
}
