using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kusamura : MonoBehaviour
{
     public MeshRenderer mr;
    void Start()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
    }

    //void Update()
    //{

    //}
    //void OnCollisionEnter(Collision col)
    //{
    //    Debug.Log(col.gameObject.name);
    //}
     void OnTriggerEnter(Collider other)
    {
        if (GameObject.FindWithTag("head"))
        {
            mr.material.color = new Color(0, 0.5f, 0, 0.3f);
        }
        
        //Debug.Log(other.gameObject.tag);
    }
    private void OnTriggerExit(Collider ot)
    {
        mr.material.color = new Color(0, 0.5f, 0, 1.0f);
    }
}
