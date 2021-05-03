using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GAMEPLAY_FADE : MonoBehaviour
{
    public float speed = 0.01f;
    private float alfa = 1;
    private float R, G, B;
    private bool flag2 = true;
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
        if (flag2 == true)
        {
            alfa -= speed;
            GetComponent<Image>().color = new Color(R, G, B, alfa);
            if (alfa < 0)
            {
                flag2 = false;
            }
        }

        if (flag2 == false)
        {
            alfa = 0;
        }
    }
}
