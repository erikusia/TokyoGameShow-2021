using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TITLE_SNAKE : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform SNAKEA;
    private float Scene_Time;
    bool flag = false;
    //public  float speed = 0.0001f;

    void Start()
    {
        SNAKEA = GetComponent<Transform>();
        Scene_Time = 0.0f;
        //speed = 0.1f;
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
            Debug.Log(SNAKEA.transform.localPosition);
            if (Scene_Time > 0.5f)
            {
                //Debug.Log("koko");
                SNAKEA.transform.localPosition -= new Vector3(0.02f, 0.0f, 0.55f);
            }
            if (Scene_Time > 3.5f)
            {
                SNAKEA.transform.localPosition = new Vector3(0.0f, -3.0f, 117.0f);
                flag = false;
            }
        }
        if (flag == false)
        {
            Scene_Time = 0.0f;
        }
    }
}
