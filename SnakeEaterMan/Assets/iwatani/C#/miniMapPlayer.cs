using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMapPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Vector3 oldPos;
    Vector3 newPos;
    void Start()
    {
        oldPos = player.GetComponent<Transform>().position;
        this.gameObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(oldPos.x * 2, oldPos.z * 2, 0);
        //Debug.Log("a:"+player.GetComponent<Transform>().position);
        //Debug.Log("b:"+this.gameObject.GetComponent<RectTransform>().anchoredPosition3D);
    }

    // Update is called once per frame
    void Update()
    {
        newPos = player.GetComponent<Transform>().position;
        Vector3 velocity;
        //Debug.Log("newPos:" + newPos);
        //Debug.Log("oldPos:" + oldPos);
        velocity = new Vector3(newPos.x, newPos.z, 0) - new Vector3(oldPos.x, oldPos.z, 0);
        //Debug.Log(velocity);
        this.gameObject.GetComponent<RectTransform>().anchoredPosition3D += new Vector3(velocity.x*2, velocity.y*2, 0);
        //Debug.Log("今のポジション:"+this.gameObject.GetComponent<Transform>().position);
        oldPos = player.GetComponent<Transform>().position;
    }
}
