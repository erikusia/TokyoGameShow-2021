using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_walk = 10;
    public float m_dash = 7;
    public float m_rotato = 2;
    public float m_dashTimePlus = 0.1f;
    private float m_speed;
    Vector3 local_angle;
    bool dash=false;
    float dashTime = 1;
    float waitTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //トランスフォーム取得
        Transform myTransform = this.transform;

        if(x!=0||z!=0)
        {
            // 矢印キーが押されている方向にプレイヤーを移動する
            transform.localPosition += transform.forward / m_speed;

            //回転
            var direction = new Vector3(x, 0, z);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.localRotation = Quaternion.Slerp(myTransform.localRotation,targetRotation,Time.deltaTime* m_rotato);
        }

        if (Input.GetKey("joystick button 3"))
        {
            waitTime = 0;
            dash = true;
        }
        else dash = false;

        if (dash == true && dashTime > 0.1)
        {
            m_speed = m_dash;
            dashTime -= Time.deltaTime;
            Debug.Log("ダッシュ");
        }
        else
        {
            
            if (dashTime < 1) 
            {
                waitTime+= Time.deltaTime;

                if(waitTime > 1)
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
        Debug.Log(dashTime);
    }
}
