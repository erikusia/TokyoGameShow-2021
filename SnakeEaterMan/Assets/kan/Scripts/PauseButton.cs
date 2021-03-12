﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private Button returnButton;
    [SerializeField]
    private Button titleButton;
    [SerializeField]
    private Button gameEndButton;

    private float inputTime;

    private int buttonCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        inputTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //ボタン選択
        ButtonInput();
        //
        OnButton(buttonCount);
    }

    void ButtonInput()
    {
        float y = Input.GetAxis("Vertical1");
        if(Time.frameCount % 13 == 0)
        {
            if (y > 0)
                buttonCount--;
            if (y < 0)
                buttonCount++;
        }

        if (buttonCount < 0)
            buttonCount = 0;
        else if (buttonCount > 2)
            buttonCount = 2;
    }

    void OnButton(int count)
    {
        switch (count)
        {
            //タイトルボタンを表示
            case 0:
                returnButton.interactable = true;
                gameEndButton.interactable = titleButton.interactable = false;
                //Bボタン押したら
                if (Input.GetKey("joystick button 3"))
                {
                    Time.timeScale = 1;
                    Destroy(gameObject);
                }
                break;
            //タイトルボタンを表示
            case 1:
                titleButton.interactable = true;
                gameEndButton.interactable = returnButton.interactable = false;
                //Bボタン押したら
                if (Input.GetKey("joystick button 3"))
                {
                    Time.timeScale = 1;
                    titleButton.GetComponent<TitleButton>().OnClick();
                }
                break;
            //エンディングボタンを表示
            case 2:
                titleButton.interactable = returnButton.interactable = false;
                gameEndButton.interactable = true;
                //Bボタン押したら
                if (Input.GetKey("joystick button 3"))
                {
                    Time.timeScale = 1;
                    gameEndButton.GetComponent<GameEndButton>().OnClick();
                }
                break;
        }
    }
}
