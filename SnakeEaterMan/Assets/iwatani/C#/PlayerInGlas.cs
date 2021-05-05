using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInGlas : MonoBehaviour
{
    [SerializeField]
    private GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(particle, this.transform.position, Quaternion.identity);
            Debug.Log("Hit");
        }
    }
}