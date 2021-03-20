using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    public enum ItemStatus
    {
        DashItem,       //1+ダッシュ
        Paralysis,      //麻痺
        //MiniMap,        //ミニマップ表示
        Thunder,        //カミナリ
        Debuff,         //デバフ
        ColorShuffle,   //カラーシャッフル

        None
    }
    private ItemStatus itemState;
    public ItemStatus GetStatus
    {
        get { return itemState; }
    }
    [Header("ItemUIの中のItemImageを入れて"),SerializeField]
    private GameObject itemUI;
    // Start is called before the first frame update
    void Start()
    {
        itemState = ItemStatus.None;
    }

    // Update is called once per frame
    void Update()
    {
        //アイテムを持っていなければ早期Return
        if (!ItemCheck(itemState))
            return;

        //Lボタンを押したら
        if (Input.GetKey("joystick button 4"))
        {
            //Debug.Log(itemState.ToString() + " : Itemを使った");

            //Sound
            GetComponent<PlayerSE>().PlayerSoundName = itemState.ToString();

            itemState = ItemStatus.None;
        }

        //ItemUI表示
        itemUI.GetComponent<ItemUI>().itemImageName = itemState.ToString();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Item")
        {
            itemState = col.gameObject.GetComponent<ItemFruits>().GetStatus;
            //食べるSEを鳴らす
            GetComponent<PlayerSE>().PlayerSoundName = "GetItem";

            GetComponent<Player1Head>().hit = true;
        }
    }
    /// <summary>
    /// アイテムを持っているかどうか
    /// </summary>
    /// <param name="status"></param>
    private bool ItemCheck(ItemStatus status)
    {
        if(status != ItemStatus.None)
        {
            return true;
        }
        return false;
    }
}
