using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;

    private ItemState.ItemStatus status;
    // Start is called before the first frame update
    void Start()
    {
        status = obj.GetComponent<ItemState>().GetStatus;
    }

    // Update is called once per frame
    void Update()
    {
        status = obj.GetComponent<ItemState>().GetStatus;
        gameObject.GetComponent<Text>().text = "Item : " + status.ToString();
    }
}
