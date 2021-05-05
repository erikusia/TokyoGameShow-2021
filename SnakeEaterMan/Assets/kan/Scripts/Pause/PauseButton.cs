using System.Collections;
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

    [SerializeField]
    private AudioClip clip;
    private AudioSource audioSource;

    private int buttonCount = 0;
    private int beforeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if(Time.frameCount % 15 == 0)
        {
            if (y > 0)
            {
                buttonCount--;

            }
            if (y < 0)
            {
                buttonCount++;
            }
        }

        if (buttonCount < 0)
            buttonCount = 0;
        else if (buttonCount > 2)
            buttonCount = 2;

        if(IsOperation())
            audioSource.PlayOneShot(clip);

        beforeCount = buttonCount;
    }

    bool IsOperation()
    {
        if (beforeCount != buttonCount)
            return true;
        return false;
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
                if (Input.GetButtonDown("B_ALL"))
                {
                    //audioSource.PlayOneShot(clip);
                    if(GameObject.Find("HowToPlayer").GetComponentInChildren<HowToPlayer>().b)
                    {
                        Time.timeScale = 1;
                    }
                    Destroy(gameObject);
                }
                break;
            //タイトルボタンを表示
            case 1:
                titleButton.interactable = true;
                gameEndButton.interactable = returnButton.interactable = false;
                //Bボタン押したら
                if (Input.GetButtonDown("B_ALL"))
                {
                    //audioSource.PlayOneShot(clip);
                    Time.timeScale = 1;
                    titleButton.GetComponent<TitleButton>().OnClick();
                }
                break;
            //エンディングボタンを表示
            case 2:
                titleButton.interactable = returnButton.interactable = false;
                gameEndButton.interactable = true;
                //Bボタン押したら
                if (Input.GetButtonDown("B_ALL"))
                {
                    //audioSource.PlayOneShot(clip);
                    Time.timeScale = 1;
                    gameEndButton.GetComponent<GameEndButton>().OnClick();
                }
                break;
        }
    }
}
