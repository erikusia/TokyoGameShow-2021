using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TITLE_fade : MonoBehaviour
{
    public float speed = 0.01f;
    float alfa;
    float R, G, B;
    private float time;
    bool flag2 = false;
    // Start is called before the first frame update
    void Start()
    {
        R = GetComponent<Image>().color.r;
        G = GetComponent<Image>().color.g;
        B = GetComponent<Image>().color.b;
        //time = Time.deltaTime;
        time = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            flag2 = true;
        }
        if (flag2 == true)
        {
            time += Time.deltaTime;

            if (time > 3.3f)
            {
                alfa += speed;
                GetComponent<Image>().color = new Color(R, G, B, alfa);
            }
            if (time > 7)
            {
                flag2 = false;
            }
        }
        if (flag2 == false)
        {
            time = 0.0f;
            alfa = 0.0f;
        }
    }
}
