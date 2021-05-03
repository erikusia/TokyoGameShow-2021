using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GAME_FADE : MonoBehaviour
{
    public float fade_speed = 0.01f;
    private float alpha = 1;
    private float R, G, B;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        R = GetComponent<Image>().color.r;
        G = GetComponent<Image>().color.g;
        B = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        flag = true;
        Debug.Log(alpha);
        if (flag == true)
        {
            alpha -= fade_speed;
            GetComponent<Image>().color = new Color(R, G, B, alpha);
        }
        if (alpha < 0)
        {
            alpha = 0;

        }

    }
}
