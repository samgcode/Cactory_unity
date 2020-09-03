using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool hasCactus = false;
    public bool hasIron = false;
    public bool hasCrystal = false;
    public bool hasMachine = false;

    public Settings settings;
    int worldSize = 0;
    public GameManager manager;
    
    void Start() {
        settings = FindObjectOfType<Settings>();
        worldSize = settings.worldSize;

        manager = FindObjectOfType<GameManager>();
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);
        manager.tiles[x + worldSize/2, y + worldSize/2] = this;
    }
}
