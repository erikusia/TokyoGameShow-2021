using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private int maxCount;
    [Header("PrefabのAngleFruitsを入れろ"),SerializeField]
    private GameObject itemObj;
    private GameObject[] items;
    private Vector3[] positions;
    private float[] spawnTimes;
    // Start is called before the first frame update
    void Start()
    {
        maxCount = transform.childCount;
        items = new GameObject[maxCount];
        positions = new Vector3[maxCount];
        spawnTimes = new float[maxCount];

        for (int i = 0; maxCount > i; i++)
        {
            items[i] = transform.GetChild(i).gameObject;
            positions[i] = transform.GetChild(i).gameObject.transform.position;
            spawnTimes[i] = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; maxCount > i; i++)
        {
            if(items[i] == null)
            {
                spawnTimes[i] += Time.deltaTime;

                if (spawnTimes[i] > 1.0f)
                {
                    items[i] = Instantiate(itemObj,positions[i],Quaternion.identity);
                    spawnTimes[i] = 0.0f;
                }
                continue;
            }

            bool flag = false;
            flag = items[i].GetComponent<ItemFruits>().GetIsDead;
            if(flag)
            {
                Destroy(items[i]);
                items[i] = null;
            }
        }
    }
}
