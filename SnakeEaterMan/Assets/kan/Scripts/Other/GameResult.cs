using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    public static int snakeEatCount = 0;
    public static int flogEatCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "食べたカエルの数 : " + flogEatCount.ToString() + "\n" + "食べたヘビの数 : " + snakeEatCount.ToString();
        snakeEatCount = 0;
        flogEatCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(snakeEatCount);
        //Debug.Log(flogEatCount);
    }
}
