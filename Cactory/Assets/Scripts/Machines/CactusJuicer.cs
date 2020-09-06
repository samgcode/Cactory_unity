using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusJuicer : MonoBehaviour
{
    public Transform juiceSpawnpoint;
    public GameObject juicePrefab;
    public PlayerService playerService;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnJuice", 1f, 3f);
        
    }
    void spawnJuice() {
        Instantiate(juicePrefab, juiceSpawnpoint);
    }
}