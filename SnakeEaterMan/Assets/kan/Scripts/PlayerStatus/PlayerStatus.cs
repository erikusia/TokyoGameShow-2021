using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    //public enum Status
    //{
    //    DashItem,
    //    Paralysis,
    //    Thunder,
    //    Debuff,
    //}

    private string status;

    public string PlayerState
    {
        get { return status; }
        set { status = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(status == "Paralysis" || status == "Thunder" || status == "Debuff")
        {
            //あしおそ
            GetComponent<PlayerHead>().hit = true;
            //Debug.Log(gameObject.transform.root.gameObject.name + status);
            status = "None";
        }        
    }
}
