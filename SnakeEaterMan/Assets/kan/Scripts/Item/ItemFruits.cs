using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFruits : MonoBehaviour
{
    // Start is called before the first frame update
    private ItemState.ItemStatus status;
    private bool isDead;
    public ItemState.ItemStatus GetStatus
    {
        get { return status; }
    }
    public bool GetIsDead
    {
        get { return isDead; }
    }
    void Start()
    {
        isDead = false;

        //確率
        int probability = Random.Range(1, 101);
        status = ItemState.ItemStatus.None;

        //60%
        if (probability <= 60)
        {
            status = (ItemState.ItemStatus)Random.Range(0, 3);
        }
        //30%
        else if(probability > 60 && probability <= 90)
        {//カミナリ
            status = (ItemState.ItemStatus)3;
        }
        //10%
        else
        {//鈍足・カラーシャッフル         
            status = (ItemState.ItemStatus)Random.Range(4, 6);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "head1")
        {
            isDead = true;
            //Destroy(gameObject);
        }
    }
}
