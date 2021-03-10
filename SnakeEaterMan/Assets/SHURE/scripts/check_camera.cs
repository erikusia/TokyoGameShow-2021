using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_camera : MonoBehaviour
{
    //草のカメラ
    public Camera cam;
    bool in_cam = true;


    void Start()
    {
    }
    void Update()
    {
    
    }
    void OnTriggerEnter(Collider other)
    {
        //    if (GameObject.FindWithTag("Player1") || GameObject.FindWithTag("Player2") ||
        //GameObject.FindWithTag("Player3") || GameObject.FindWithTag("Player4"))
        //    {

        //    }

        if (GameObject.Find("KUSAS"))
        {
            Debug.Log("これは草");
            Debug.Log(tag);
            in_cam = true;
            if (in_cam == true)
            {
                //xレイヤーを除く
                cam.cullingMask &= ~(1 << 8);
            }

        }
        //if (GameObject.Find("root_ALL"))
        //{
        //    Debug.Log("これは箱");
        //}
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
