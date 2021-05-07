using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public GameObject[] gameObjects = new GameObject[4];
    [SerializeField]
    private Material White;
    [SerializeField]
    private Material Blue;
    [SerializeField]
    private Material Green;
    [SerializeField]
    private Material Red;
    [SerializeField]
    private Material Transparency;
    [SerializeField]
    private Material Yellow;

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
                gameObjects[i].GetComponent<Renderer>().material = White;
            else if (s[i].Contains("Blue"))
            {
                gameObjects[i].GetComponent<Renderer>().material = Blue;
                //Debug.Log(Blue.name);
            }
                
            else if (s[i].Contains("Green"))
            {
                gameObjects[i].GetComponent<Renderer>().material = Green;
                //Debug.Log(Green.name);
            }
            else if (s[i].Contains("Red"))
            {
                gameObjects[i].GetComponent<Renderer>().material = Red;
                //Debug.Log(Red.name);
            }

            else if (s[i].Contains("Transparency"))
                gameObjects[i].GetComponent<Renderer>().material = Transparency;
            else if (s[i].Contains("Yellow"))
            {
                gameObjects[i].GetComponent<Renderer>().material = Yellow;
                //Debug.Log(Yellow.name);
            }
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
