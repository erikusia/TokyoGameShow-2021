using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInGlas : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    [SerializeField]
    private GameObject posObject;

    Vector3 pos;
    bool hit=false;
    // Start is called before the first frame update
    void Start()
    {
        pos = posObject.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player"&&!hit)
        {
            GameObject obj= Instantiate(particle, new Vector3(0,2,0), Quaternion.identity);
            obj.transform.parent = posObject.transform;
            hit = true;
            Debug.Log(pos);
        }
    }
}