using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFruits : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private string status = "None";
    private bool isDead;
    public string GetStatus
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
        
        if(status != "None")
        { return; }

        //60%
        if (probability <= 60)
        {
            int r = Random.Range(0, 2);
            if (r == 0)
                status = "DashItem";
            else
                status = "Paralysis";
        }
        //30%
        else if(probability > 60 && probability <= 85)
        {//カミナリ
            status = "Thunder";
        }
        //10%
        else
        {//鈍足・カラーシャッフル         
            int r = Random.Range(0, 2);
            if (r == 0)
                status = "Debuff";
            else
                status = "ColorShuffle";
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
