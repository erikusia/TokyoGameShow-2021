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
    { }
    void Update()
    { }
    void OnTriggerEnter(Collider other)
    {
        //草の個体ごとにレイヤー分け（いくつか同じのを使っている
        if (other.CompareTag("ksua"))
        {
            //Debug.Log(tag);
            in_cam = true;
            if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 11);
            }
        }
        if (other.CompareTag("kusa2"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 13);
            }
        }
        if (other.CompareTag("kusa3"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 14);
            }
        }
        if (other.CompareTag("kusa4"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 14);
            }
        }
        if (other.CompareTag("kusa5"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 12);
            }
        }
        if (other.CompareTag("kusa6"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 17);
            }
        }
        if (other.CompareTag("kusa7"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 16);
            }
        }
        if (other.CompareTag("kusa8"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 16);
            }
        }
        if (other.CompareTag("kusa9"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 15);
            }
        }
        if (other.CompareTag("kusa10"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 17);
            }
        }
        if (other.CompareTag("kusa11"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 18);
            }
        }
        if (other.CompareTag("kusa12"))
        {
            in_cam = true; if (in_cam == true)
            {//xレイヤーを除く
                cam.cullingMask &= ~(1 << 19);
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
