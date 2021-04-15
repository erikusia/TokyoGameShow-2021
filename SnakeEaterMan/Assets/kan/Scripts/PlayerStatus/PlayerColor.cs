using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public GameObject[] gameObjects = new GameObject[4];
    [SerializeField]
    private Material[] materials = new Material[6];
    public string[] materialsName;

    // Start is called before the first frame update
    void Start()
    {
        var g = gameObject.transform.Find("group1").gameObject;
        gameObjects[0] = g.transform.Find("Tail").gameObject;
        gameObjects[1] = g.transform.Find("Body3").gameObject;
        gameObjects[2] = g.transform.Find("Body2").gameObject;
        gameObjects[3] = g.transform.Find("Body1").gameObject;
        materialsName = new string[4];
        for (int i = 0; i < materialsName.Length; i++)
        {
            materialsName[i] = "White";
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            ColorListCount(gameObjects[i].GetComponent<Renderer>().material.name, i);
        }
    }

    public void ChangeColor(string[] s)
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (s[i].Contains("White"))
                gameObjects[i].GetComponent<Renderer>().material = materials[0];
            else if (s[i].Contains("Blue"))
                gameObjects[i].GetComponent<Renderer>().material = materials[1];
            else if (s[i].Contains("Green"))
                gameObjects[i].GetComponent<Renderer>().material = materials[2];
            else if (s[i].Contains("Red"))
                gameObjects[i].GetComponent<Renderer>().material = materials[3];
            else if (s[i].Contains("Transparency"))
                gameObjects[i].GetComponent<Renderer>().material = materials[4];
            else if (s[i].Contains("Yellow"))
                gameObjects[i].GetComponent<Renderer>().material = materials[5];
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

        //foreach (var i in materialsName)
        //{
        //    Debug.Log(i);
        //}
    }
}
