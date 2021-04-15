using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayer : MonoBehaviour
{
    private int playerNum;
    private bool[] isPlayer = new bool[4];

    public GUIStyleState styleState;
    private GUIStyle style;
    private bool isGUI;
    private void Awake()
    {
        Time.timeScale = 0;
        playerNum = 1;
        AllFalse();
        style = new GUIStyle();
        styleState.textColor = new Color(0, 0, 0, 1);
        isGUI = false;
    }

    // Update is called once per frame
    void Update()
    {


        for (int i = 0; i < isPlayer.Length; i++)
        {
            if (isPlayer[i])
            {
                int n = i + 1;

                if (Input.GetButtonDown("A" + n.ToString()))
                {
                    Time.timeScale = 1;
                    isPlayer[i] = false;
                    isGUI = true;
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
                style.normal = styleState;
                GUI.Label(new Rect(100 * i, 20, 100, 50), (i + 1).ToString() + "Player準備完了、Aボタンでスタート", style);
            }
        }
    }
}
