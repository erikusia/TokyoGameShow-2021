using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemState : MonoBehaviour
{
    public enum ItemStatus
    {
        DashItem,       //1+ダッシュ
        Paralysis,      //麻痺
        MiniMap,        //ミニマップ表示
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
    // Start is called before the first frame update
    void Start()
    {
        itemState = ItemStatus.None;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Item")
        {
            itemState = col.gameObject.GetComponent<ItemFruits>().GetStatus;
            //食べるSEを鳴らす
            GetComponent<PlayerSE>().PlayerSoundState = PlayerSE.PlaySoundFlag.Eat;
        }
    }
}
