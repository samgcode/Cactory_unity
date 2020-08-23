using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public Transform ironSpawnpoint;
    public GameObject ironPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnIron", 1f, 3f);
    }
    void spawnIron() {
        Instantiate(ironPrefab, ironSpawnpoint);
    }
}
