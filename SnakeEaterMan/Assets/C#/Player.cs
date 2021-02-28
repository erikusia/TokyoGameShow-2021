using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_speed = 5;
    Vector3 local_angle;
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
            var velocity = new Vector3(x, 0, z) / m_speed;
            transform.localPosition += velocity;

            var direction = new Vector3(x, 0, z);
            transform.localRotation = Quaternion.LookRotation(direction);
        }
    }
}
