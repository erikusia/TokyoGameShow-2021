using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_camera : MonoBehaviour
{
    //草のカメラ
    public Camera cam;
    bool in_cam = true;
    //
    void Start()
    {
    }
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject)
        {   Debug.Log(tag);
            if (GameObject.FindWithTag("ksua"))
            {
                Debug.Log("これは草");
                in_cam = true;
                if (in_cam == true)
                {
                    //xレイヤーを除く
                    cam.cullingMask &= ~(1 << 8);

                }
            }
        }
    }

    void OnTriggerExit(Collider ot)
    {
        in_cam = false;
        if (in_cam == false)
        {
            //全てのレイヤーを有効にする
            cam.cullingMask = -1;
        }
    }
}
