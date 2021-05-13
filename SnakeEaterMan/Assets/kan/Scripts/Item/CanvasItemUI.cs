using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasItemUI : MonoBehaviour
{
    private RectTransform pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = pos.rotation;
        Debug.Log(GetComponent<RectTransform>().position);
    }
}
