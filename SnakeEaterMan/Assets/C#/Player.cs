using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        GetComponent<Rigidbody>().velocity.x = x * speed;
        GetComponent<Rigidbody>().velocity.z = y * speed;

        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("button3");
        }
    }
}
