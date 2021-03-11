using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private Button titleButton;
    [SerializeField]
    private Button gameEndButton;

    int buttonCount = 0;
    // Start is called before the first frame update
    void Start()
    {

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
        if (y > 0)
            buttonCount = 0;
        if (y < 0)
            buttonCount = 1;
    }

    void OnButton(int count)
    {
        switch (count)
        {
            //タイトルボタンを表示
            case 0:
                titleButton.interactable = true;
                gameEndButton.interactable = false;
                //Bボタン押したら
                if (Input.GetKey("joystick button 1"))
                {
                    Time.timeScale = 1;
                    titleButton.GetComponent<TitleButton>().OnClick();
                }
                break;
            //エンディングボタンを表示
            case 1:
                titleButton.interactable = false;
                gameEndButton.interactable = true;
                //Bボタン押したら
                if (Input.GetKey("joystick button 1"))
                {
                    Time.timeScale = 1;
                    gameEndButton.GetComponent<GameEndButton>().OnClick();
                }
                break;
        }
    }
}
