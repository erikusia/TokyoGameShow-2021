using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnime : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animator.SetFloat("MoveSpeed", 1.0f);
        }
    }
}
