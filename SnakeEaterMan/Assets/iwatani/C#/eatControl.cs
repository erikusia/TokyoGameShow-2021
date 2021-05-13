using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator eat;
    void Start()
    {
        eat = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("当たりました");
        if(other.gameObject.tag=="tail")
        {
            Debug.Log("しっぽに当たりました");
            eat.SetTrigger("eatTrigger");
        }
    }
}
