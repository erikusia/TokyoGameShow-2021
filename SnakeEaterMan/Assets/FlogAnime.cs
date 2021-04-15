using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlogAnime : MonoBehaviour
{
    Animator Jump;
    // Start is called before the first frame update
    void Start()
    {
        Jump = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
