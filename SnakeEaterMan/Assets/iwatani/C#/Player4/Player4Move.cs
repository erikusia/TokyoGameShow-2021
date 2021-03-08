using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player4Move : MonoBehaviour
{
    //移動用キャラクターコントローラー
    CharacterController m_controller;
    //ダッシュ用スライダー
    GameObject SliderObject;
    Slider DashSlider;
    //移動用の変数たち
    public float m_walk = 10;
    public float m_dash = 7;
    public float m_rotato = 2;
    public float m_dashTimePlus = 0.1f;
    private float m_speed;
    Vector3 local_angle;
    bool dash = false;
    public float dashTime = 1;
    float waitTime = 0;


    // Start is called before the first frame update
    void Start()
    {
        //キャラクターコントローラーの取得
        m_controller = GetComponent<CharacterController>();
        //スライダーオブジェクトの取得
        SliderObject = GameObject.FindWithTag("DashP4");
        DashSlider = SliderObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal4");
        float z = Input.GetAxis("Vertical4");
        //トランスフォーム取得
        Transform myTransform = this.transform;

        DashSlider.value = dashTime;

        if (x != 0 || z != 0)
        {
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

        if (Input.GetKey("joystick button 3"))
        {
            waitTime = 0;
            dash = true;
        }
        else dash = false;

        if (dash == true && dashTime > 0)
        {
            m_speed = m_dash;
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
                    }
                }
            }
            m_speed = m_walk;
        }
    }
}
