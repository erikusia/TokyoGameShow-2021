using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    //public enum ItemStatus
    //{
    //    DashItem,       //1+ダッシュ
    //    Paralysis,      //麻痺
    //    //MiniMap,      //ミニマップ表示
    //    Thunder,        //カミナリ
    //    Debuff,         //デバフ
    //    ColorShuffle,   //カラーシャッフル

    //    None
    //}
    private string itemState;
    private string item = "None";
    public string GetStatus
    {
        get { return itemState; }
        set { itemState = value; }
    }
    public string GetItem
    {
        get { return item; }
        set { item = value; }
    }
    [Header("ItemUIの中のItemImageを入れて"),SerializeField]
    private GameObject itemUI;
    private int playerNumber;
    private string controllerName;

    private float paralysisCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        itemState = "None";
        playerNumber = gameObject.transform.root.GetComponent<PlayerMove>().playerNumber;
        controllerName = "L1_" + playerNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Lボタンを押したら
        if (Input.GetButtonDown(controllerName))
        {
            //Debug.Log(itemState.ToString() + " : Itemを使った");

            //Sound
            GetComponent<PlayerSE>().PlayerSoundName = itemState;

            item = itemState;

            if(itemState == "DashItem")
                GetComponent<PlayerStatus>().PlayerState = itemState;

            if (itemState == "Paralysis")
                item = itemState;

            itemState = "None";
        }
        //麻痺攻撃
        AttackParalysis(3.0f);

        //ItemUI表示
        itemUI.GetComponent<ItemUI>().itemImageName = itemState;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Item")
        {
            itemState = col.gameObject.GetComponent<ItemFruits>().GetStatus;
            //食べるSEを鳴らす
            GetComponent<PlayerSE>().PlayerSoundName = "GetItem";
            //アイテム食べたら遅くなる
            //GetComponent<PlayerHead>().hit = true;
        }

        if (col.gameObject.tag == "tail" && item == "Paralysis")
        {
            var g = col.gameObject.transform.root.gameObject;
            g.transform.Find("group1").GetComponentInChildren<PlayerStatus>().PlayerState = "Paralysis";
        }
    }
    /// <summary>
    /// 麻痺の攻撃
    /// </summary>
    /// <param name="count">なん秒判定を出すか</param>
    private void AttackParalysis(float count)
    {
        if (paralysisCount < count && item == "Paralysis")
        {
            itemState = "Paralysis";
        }
        else if (paralysisCount > count)
        {
            itemState = item = "None";
        }
        if (item == "Paralysis")
        {
            paralysisCount = paralysisCount + Time.deltaTime;
        }
    }
}
