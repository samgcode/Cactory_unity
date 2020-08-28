using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public Transform itemSpawnpoint;
    public GameObject itemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnItem", 1f, 3f);
    }
    void spawnItem() {
        Instantiate(itemPrefab, itemSpawnpoint.position, Quaternion.identity);
    }
}
