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
    private Vector3[] originPos;
    [SerializeField]
    private float spawnCount = 1.0f;

    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        maxCount = transform.childCount;
        items = new GameObject[maxCount];
        positions = new Vector3[maxCount];
        spawnTimes = new float[maxCount];
        originPos = new Vector3[maxCount];

        for (int i = 0; maxCount > i; i++)
        {
            items[i] = transform.GetChild(i).gameObject;
            positions[i] = transform.GetChild(i).gameObject.transform.position;
            spawnTimes[i] = 0.0f;
            var p = transform.GetChild(i).gameObject.transform.position;
            originPos[i] = p;
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

                if (spawnTimes[i] > spawnCount)
                {
                    items[i] = Instantiate(itemObj, positions[i], Quaternion.identity);
                    items[i].GetComponent<ItemFruits>().spawn = true;
                    items[i].GetComponent<Transform>().position = new Vector3(originPos[i].x, originPos[i].y + 10.0f, originPos[i].z);
                }
                continue;
            }

            if(items[i].GetComponent<ItemFruits>().spawn)
            {
                var p = items[i].GetComponent<Transform>().position;
                items[i].GetComponent<Transform>().position = new Vector3(p.x, p.y - speed * Time.deltaTime, p.z);

                if (p.y < originPos[i].y)
                {
                    items[i].GetComponent<Transform>().position = originPos[i];
                    items[i].GetComponent<ItemFruits>().spawn = false;
                }
                    
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
