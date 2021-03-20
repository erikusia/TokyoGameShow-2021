using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    private Sprite[] images;
    private Dictionary<string, Sprite> itemImageList;

    private string imageName;
    public string itemImageName
    {
        set { imageName = value; }
        get { return imageName; }
    }
    // Start is called before the first frame update
    void Start()
    {
        imageName = "None";
        itemImageList = new Dictionary<string, Sprite>();

        //アイテムが増える度に追加
        for (int i = 0; i < images.Length; ++i)
        {
            if (images[i].name == "ダッシュ+1秒")
                itemImageList.Add("DashItem", images[i]);

            if (images[i].name == "麻痺アイコン")
                itemImageList.Add("Paralysis", images[i]);

            if (images[i].name == "カミナリアイコン")
                itemImageList.Add("Thunder", images[i]);

            if (images[i].name == "一位にデバフ")
                itemImageList.Add("Debuff", images[i]);

            if (images[i].name == "全員の色交換")
                itemImageList.Add("ColorShuffle", images[i]);

            //色なし
            if (images[i].name == "UIMask")
                itemImageList.Add("None", images[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowImage();
    }

    void ShowImage()
    {
        GetComponent<Image>().sprite = itemImageList[itemImageName];
    }
}
