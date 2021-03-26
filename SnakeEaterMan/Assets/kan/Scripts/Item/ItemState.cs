using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    //public enum ItemStatus
    //{
    //    DashItem,       //1+ダッシュ
    //    Paralysis,      //麻痺
    //    //MiniMap,        //ミニマップ表示
    //    Thunder,        //カミナリ
    //    Debuff,         //デバフ
    //    ColorShuffle,   //カラーシャッフル

    //    None
    //}
    private string itemState;
    public string GetStatus
    {
        get { return itemState; }
        set { itemState = value; }
    }
    [Header("ItemUIの中のItemImageを入れて"),SerializeField]
    private GameObject itemUI;
    // Start is called before the first frame update
    void Start()
    {
        itemState = "None";
    }

    // Update is called once per frame
    void Update()
    {
        //Lボタンを押したら
        if (Input.GetKey("joystick button 4"))
        {
            //Debug.Log(itemState.ToString() + " : Itemを使った");

            //Sound
            GetComponent<PlayerSE>().PlayerSoundName = itemState;

            GetComponent<PlayerStatus>().PlayerState = itemState;

            itemState = "None";
        }

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
            //GetComponent<Player1Head>().hit = true;
        }
    }
}
