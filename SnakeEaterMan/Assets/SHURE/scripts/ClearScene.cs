using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClearScene : MonoBehaviour
{
    //シーン持越し用静的変数
    public static string winner = "none";
    //検索用リスト
    private List<GameObject> matName = new List<GameObject>();
    [Header("Scene.mp3"), SerializeField]
    private AudioClip clips;

    //sounds
    private AudioSource audioSource;
    private Camera[] cameras = new Camera[4];//勝利時のカメラ

    //カメラ格納場所
    private GameObject[] game_camera = new GameObject[4];
    float peke = 0.0f;//サイズ拡大用
    float size_check;//サイズ調整用

    //文字表示
    [SerializeField]
    private GameObject clear_text;
    [SerializeField]
    private GameObject conte;
    [SerializeField]
    private GameObject exi;

    //マップ消す
    [SerializeField]
    private GameObject maap;

    //ボタン入れる
    [SerializeField]
    private GameObject buttonA;
    [SerializeField]
    private GameObject buttonB;
    [SerializeField]
    private Button Retrybutton;
    [SerializeField]
    private Button exitbutton;
    [SerializeField]
    private GameObject finish;
    //終了時に出すフラグ
    bool fin_flag = false;
    //タイマー
    private float fin_time = 0.0f;

    private int button_ct = 0;
    private int before_ct = 0;
    void Start()
    {
        //ここでオブジェクトににプレイヤーカメラを入れている。
        game_camera[0] = GameObject.Find("Player1Camera");
        game_camera[1] = GameObject.Find("Player2Camera");
        game_camera[2] = GameObject.Find("Player3Camera");
        game_camera[3] = GameObject.Find("Player4Camera");
        //
        cameras[0] = game_camera[0].GetComponent<Camera>();
        cameras[1] = game_camera[1].GetComponent<Camera>();
        cameras[2] = game_camera[2].GetComponent<Camera>();
        cameras[3] = game_camera[3].GetComponent<Camera>();
        //初期座標
        cameras[0].rect = new Rect(0.0f, 0.5f, 0.5f, 0.5f);
        cameras[1].rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
        cameras[2].rect = new Rect(0.0f, 0.0f, 0.5f, 0.5f);
        cameras[3].rect = new Rect(0.5f, 0.0f, 0.5f, 0.5f);
        buttonA.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        buttonB.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        //終了時に出すフィニッシュその後ワイド
        finish.GetComponent<Text>().color = new Color(1, 0, 0, 0);

        Application.targetFrameRate = 60;
        //プレイヤー分の名前をリストに入れる
        for (int i = 1; i < 5; i++)
        {
            string pName = "Player" + i.ToString();
            matName.Insert(i - 1, GameObject.Find(pName));
        }
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Debug.Log(fin_flag);
        Debug.Log(fin_time);
        ////デバッグ用
        if (Input.GetKey(KeyCode.A))
        {
            fin_flag = true;
        }
        if (fin_flag == true)
        {
            Time.timeScale = 0;
            fin_time += 0.01f;
        }
        if (fin_time > 0.1f)
        {
            //テキスト
            finish.GetComponent<Text>().color = new Color(1, 0, 0, 1);
            Text fin = finish.GetComponent<Text>();
            fin.text = ("Finish");
        }
        if (fin_time > 0.8f)
        {
            winner = "Player1";
            maap.SetActive(false);
            buttonA.GetComponent<Image>().color = new Color(0, 1, 0, 1);
            buttonB.GetComponent<Image>().color = new Color(1, 0, 0, 1);
            finish.GetComponent<Text>().color = new Color(1, 0, 0, 1);
            //ボタン選択
            ButtonInput();
            OnButton(button_ct);
            Time.timeScale = 0;
            before_ct = button_ct;
            // winner = null;
            if (fin_time > 1.2f)
            {
                fin_flag = false;
            }
        }
        foreach (var mat in matName)
        {
            if (!mat.transform.Find("group1").Find("Body1").GetComponent<SkinnedMeshRenderer>().material.name.Contains("White") &&
             !mat.transform.Find("group1").Find("Body1").GetComponent<SkinnedMeshRenderer>().material.name.Contains("Transparency"))
            {
                maap.SetActive(false);
                winner = mat.name;

                //ボタン選択
                ButtonInput();
                Debug.Log(button_ct);
                OnButton(button_ct);
                Time.timeScale = 0;

                buttonA.GetComponent<Image>().color = new Color(0, 1, 0, 1);
                buttonB.GetComponent<Image>().color = new Color(1, 0, 0, 1);
                //  Debug.Log("GameClear " + mat.name + " が勝ち");
                winner = null;
                audioSource.PlayOneShot(clips);
            }
        }
        if (winner == "Player1")
        {
            size_check += 0.005f;//ｘ、ｙ
            peke += 0.006f;//ｗ、ｈ
             //画面配置場所：左上
            cameras[0].rect = new Rect(0.0f, 0.5f - size_check, 0.5f + peke, 0.5f + peke);
            if (cameras[0].rect.y < 0)
            {
                cameras[0].rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            }
            //深度設定（画面優先順位変更　前面　１　～　ー１　背面
            cameras[0].depth = 1.0f;
            cameras[1].depth = -1.0f;
            cameras[2].depth = -1.0f;
            cameras[3].depth = -1.0f;
            Text clear = clear_text.GetComponent<Text>();
            clear.text = ("Winner" + " " + winner);
            Text re = conte.GetComponent<Text>();
            re.text = ("Retry_X");
            Text ex = exi.GetComponent<Text>();
            ex.text = ("Exit_Y");
            //ボタン選択
            //ButtonInput();
            //OnButton(button_ct = 0);
        }
        if (winner == "Player2")
        {
            //画面配置場所：右上
            size_check += 0.005f;//ｘ、ｙ
            peke += 0.006f;//ｗ、ｈ
            cameras[1].rect = new Rect(0.5f - size_check,
                0.5f - size_check, 0.5f + peke, 0.5f + peke);
            if (cameras[1].rect.x < 0)
            {
                cameras[1].rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);
            }
            cameras[0].depth = -1.0f;
            cameras[1].depth = 1.0f;
            cameras[2].depth = -1.0f;
            cameras[3].depth = -1.0f;
            Text clear = clear_text.GetComponent<Text>();
            clear.text = ("Winner" + " " + winner);

            Text re = conte.GetComponent<Text>();
            re.text = ("Retry_X");
            Text ex = conte.GetComponent<Text>();
            ex.text = ("Exit_Y");
            // Debug.Log("2の勝利");
        }
        if (winner == "Player3")
        {
            size_check -= 0.001f;//ｘ、ｙ
            peke += 0.006f;//ｗ、ｈ
                           //画面配置場所：左下
            cameras[2].rect = new Rect(0.0f, 0.0f,
                0.5f + peke, 0.5f + peke);

            cameras[0].depth = -1.0f;
            cameras[1].depth = -1.0f;
            cameras[2].depth = 1.0f;
            cameras[3].depth = -1.0f;
            //Debug.Log("3の勝利");
            Text clear = clear_text.GetComponent<Text>();
            clear.text = ("Winner" + " " + winner);

            Text re = conte.GetComponent<Text>();
            re.text = ("Retry_X");
            Text ex = conte.GetComponent<Text>();
            ex.text = ("Exit_Y");
        }
        if (winner == "Player4")
        {
            size_check -= 0.001f;//ｘ、ｙ
            peke += 0.006f;//ｗ、ｈ
                           //画面配置場所：右下
            cameras[3].rect = new Rect(0.0f, 0.0f,
                0.5f + peke, 0.5f + peke);

            cameras[0].depth = -1.0f;
            cameras[1].depth = -1.0f;
            cameras[2].depth = -1.0f;
            cameras[3].depth = 1.0f;
            Text clear = clear_text.GetComponent<Text>();
            clear.text = ("Winner" + " " + winner);
            Text re = conte.GetComponent<Text>();
            re.text = ("Retry_X");
            Text ex = conte.GetComponent<Text>();
            ex.text = ("Exit_Y");
            //Debug.Log("4の勝利");
        }
        if (peke > 1.0f)
        {
            peke = 1.0f;
        }
        if (size_check < 0)
        {
            size_check = 0;
        }
    }
    void ButtonInput()
    {
        float y = Input.GetAxis("Vertical1");//受け取れない？
                                             // Debug.Log(y);
        if (y < 0)
        {
            button_ct = 1;
        }
        if (y > 0)
        {
            button_ct = 0;
        }
        before_ct = button_ct;
    }
    void OnButton(int Ct)
    {
        //Debug.Log(Ct);
        switch (Ct)
        {
            case 0:
                Retrybutton.interactable = true;
                exitbutton.interactable = false;
                //Bを押したら
                if (Input.GetButtonDown("B_ALL"))
                {
                    Retrybutton.GetComponent<retrybutton>().OnClick();
                }
                break;

            case 1:
                Retrybutton.interactable = false;
                exitbutton.interactable = true;
                if (Input.GetButtonDown("B_ALL"))
                {
                    exitbutton.GetComponent<exit>().OnClick();
                }
                break;
        }
    }
}
