using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TITLE_SNAKE : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform SNAKEA;
    private float Scene_Time;
    private bool flag = false;
    void Start()
    {
        SNAKEA = GetComponent<Transform>();
        Scene_Time = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            flag = true;
        }
        if (flag == true)
        {

            Scene_Time += Time.deltaTime;
            if (Scene_Time > 0.5f)
            {
                //Debug.Log("koko");

                SNAKEA.transform.localPosition -= new Vector3(0.01f, 0.0f, 0.5f);
            }
            if (Scene_Time > 3.3f)
            {
                SNAKEA.transform.localPosition = new Vector3(0, -3, 117);
                flag = false;
            }

        }
        if (flag == false)
        {
            Scene_Time = 0.0f;
        }
    }
}
