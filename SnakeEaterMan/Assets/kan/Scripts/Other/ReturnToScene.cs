using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReturnToScene : MonoBehaviour
{
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
        if (y > 0)
            buttonCount = 0;
        if (y < 0)
            buttonCount = 1;

        if (IsOperation())
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
                titleButton.interactable = true;
                gameEndButton.interactable = false;
                //Bボタン押したら
                if (Input.GetButtonDown("B_ALL"))
                {
                    audioSource.PlayOneShot(clip);
                    titleButton.GetComponent<TitleButton>().OnClick();
                }
                break;
            //エンディングボタンを表示
            case 1:
                titleButton.interactable = false;
                gameEndButton.interactable = true;
                //Bボタン押したら
                if (Input.GetButtonDown("B_ALL"))
                {
                    audioSource.PlayOneShot(clip);
                    gameEndButton.GetComponent<GameEndButton>().OnClick();
                }
                break;
        }
    }
}
