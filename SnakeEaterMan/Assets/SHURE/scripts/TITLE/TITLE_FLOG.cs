using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TITLE_FLOG : MonoBehaviour
{
    private Transform flog;
    public Transform returnpos;
    float movetime = 0.0f;
    //bool flogflag = false;
    // Start is called before the first frame update
    void Start()
    {
        flog = GetComponent<Transform>();
        returnpos = GetComponent<Transform>();
        movetime = 0;
      //  flog.transform.localPosition = returnpos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movetime += 0.01f;
        //Debug.Log(movetime);
        if (movetime > 3.0f)
        {
            flog.transform.localPosition += new Vector3(0.2f, 0.0f, 0.0f);

        }
        if (movetime > 13.0f)
        {
            flog.transform.localPosition =  new Vector3(-97.6f,-19.6f,62.1f);
            movetime = 0;

        }
    }
}
