using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Snake_Ai : MonoBehaviour
{
    private GameObject hebiai;
    //private int nextIndex = 0;
    void Start()
    {
        hebiai = gameObject.transform.root.gameObject;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("tail"))
        { 
            //Debug.Log("コリジョン");
            hebiai.GetComponent<hebi_ai>().nextIndex=Random.Range(0,3);
        }
    }

}