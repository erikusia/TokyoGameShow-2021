using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TITLE_FADE : MonoBehaviour
{
    public  float speed = 0.01f;

    float alfa;
    float R, G, B;
    float time;
    private bool flag = false;

    void Start()
    {
        R = GetComponent<Image>().color.r;
        G = GetComponent<Image>().color.g;
        B = GetComponent<Image>().color.b;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            flag = true;
        }
        if (flag == true)
        {
            time += Time.deltaTime;
            Debug.Log(time);
            if (time > 3.3)
            {
                GetComponent<Image>().color = new Color(R, G, B, alfa);
                alfa += speed;
            }
        }
        if (flag == false)
        {
            alfa = 0.0f;
            time = 0.0f;
        }
    }
}

