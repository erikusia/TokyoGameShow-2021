using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //移動用キャラクターコントローラー
    CharacterController m_controller;
    //ダッシュ用スライダー
    [SerializeField]
    private GameObject SliderObject;
    Slider DashSlider;
    //移動用の変数たち
    public float m_walk = 10;
    public float m_dash = 7;
    public float m_rotato = 2;
    public float m_dashTimePlus = 0.1f;
    private float m_speed;
    Vector3 local_angle;
    public bool dash = false;
    public float dashTime = 1;
    float waitTime = 0;

    [Header("自分のプレイヤーの番号"),SerializeField]
    public int playerNumber = 1;

    private string inputHorizontal = "Horizontal";
    private string inputVertical = "Vertical";

    private bool dashSound = false;

    //移動アニメーション用アニメーター
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //キャラクターコントローラーの取得
        m_controller = GetComponent<CharacterController>();
        //スライダーオブジェクトの取得
        DashSlider = SliderObject.GetComponent<Slider>();

        //Inputで使う物を指定  Horizontal + 1
        inputHorizontal += playerNumber.ToString();
        inputVertical += playerNumber.ToString();

        //アニメーターの取得
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 0)
            return;

        float x = Input.GetAxis(inputHorizontal);
        float z = Input.GetAxis(inputVertical);
        //トランスフォーム取得
        Transform myTransform = this.transform;

        DashSlider.value = dashTime;

        if (x != 0 || z != 0)
        {
            animator.SetFloat("MoveSpeed", 1.0f);
            if (Time.timeScale == 0)
                return;
            // 矢印キーが押されている方向にプレイヤーを移動する
            m_controller.Move(transform.forward / m_speed);
            Vector3 pos = myTransform.position;
            pos.y = 0.3f;
            myTransform.position = pos;

            //回転
            var direction = new Vector3(x, 0, z);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.localRotation = Quaternion.Slerp(myTransform.localRotation, targetRotation, Time.deltaTime * m_rotato);
        }
        else animator.SetFloat("MoveSpeed", 0.0f);


        string s = "A" + playerNumber.ToString();

        if (Input.GetButton(s))
        {
            waitTime = 0;
            m_speed = m_dash;
            dash = true;
        }
        else dash = false;

        //ダッシュしたら音を鳴らす
        PlayDashSound();

        if (dash == true && dashTime > 0)
        {
            
            dashTime -= Time.deltaTime;
            //Debug.Log("ダッシュ");
        }
        else
        {
            if (dashTime < 1)
            {
                if (dashTime <= 0)
                {
                    dashTime = 0;
                }
                waitTime += Time.deltaTime;

                if (waitTime > 1)
                {
                    dashTime += m_dashTimePlus;
                    if (dashTime > 1)
                    {
                        dashTime = 1;
                        waitTime = 0;

                        //スタミナ回復SE
                        //GetComponentInChildren<PlayerSE>().PlayerSoundName = "Stamina";
                    }
                }
            }
            m_speed = m_walk;
        }
    }

    void PlayDashSound()
    {
        if (dash && !dashSound)
        {
            //いったん消しとく
            //GetComponentInChildren<PlayerSE>().PlayerSoundName = "Dash";
        }

        if (dash)
            dashSound = true;
        else
            dashSound = false;

    }

}
