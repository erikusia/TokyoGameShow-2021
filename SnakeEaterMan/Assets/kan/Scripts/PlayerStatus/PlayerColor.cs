using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public GameObject[] gameObjects;

    public string[] materialsName;

    // Start is called before the first frame update
    void Start()
    {

        materialsName = new string[4];
        for (int i = 0; i < materialsName.Length; i++)
        {
            materialsName[i] = "White";
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < gameObjects.Length;i++)
        {
            ColorListCount(gameObjects[i].GetComponent<Renderer>().material.name, i);
        }
    }


    void ColorListCount(string name, int num)
    {
        if (name.Contains("White"))
            materialsName[num] = "White";
        else if (name.Contains("Blue"))
            materialsName[num] = "Blue";
        else if (name.Contains("Green"))
            materialsName[num] = "Green";
        else if (name.Contains("Red"))
            materialsName[num] = "Red";
        else if (name.Contains("Transparency"))
            materialsName[num] = "Transparency";
        else if (name.Contains("Yellow"))
            materialsName[num] = "Yellow";

        //foreach(var i in materialsName)
        //{
        //    Debug.Log(i);
        //}
    }
}
