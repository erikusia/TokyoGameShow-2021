using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TITLE_SNAKE : MonoBehaviour
{
    private Transform SNAKEA;
    private float Scene_Time;//time 
    bool flag = false;
    private float speed=200.0f;

    Animator anim;//アニメーション管理

    void Start()
    {
        SNAKEA = GetComponent<Transform>();
        Scene_Time = 0.0f;
        anim = this.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {
            flag = true;
        }
        if (flag == true)
        {
            Scene_Time += Time.deltaTime;
            
            Debug.Log(SNAKEA.transform.localPosition);
            if (Scene_Time > 0.5f)
            {

                SNAKEA.transform.localPosition -= new Vector3(0.04f, 0.0f, 0.66f)*speed*Time.deltaTime;
            }
            if (Scene_Time > 3.5f)
            {
                SNAKEA.transform.localPosition = new Vector3(-1.0f, -37.0f, 160.0f);

                flag = false;
            }
        }
        if (flag == false)
        {

            Scene_Time = 0.0f;
        }
    }
}
