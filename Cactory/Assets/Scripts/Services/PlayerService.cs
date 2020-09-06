using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    public PlayerManager player;
    GameManager manager;

    void Awake() {
        manager = FindObjectOfType<GameManager>();
    }

    public Tile[] getAoeTiles(Tile tile, int range) {
        int tileX = Mathf.RoundToInt(tile.transform.position.x) + manager.worldSize/2;
        int tileY = Mathf.RoundToInt(tile.transform.position.y) + manager.worldSize/2;

        Tile[] tiles = new Tile[(range + 2) * (range + 2)];
        int id = 0;
        for(int x = 0; x < manager.worldSize * 2 - 1; x++) {
           for(int y = 0; y < manager.worldSize * 2 - 1; y++) {
                if(manager.tiles[x, y] != null) {
                    if(
                        x >= tileX - range && x <= tileX + range &&
                        y >= tileY - range && y <= tileY + range
                    ) {
                        tiles[id] = (manager.tiles[x, y]);
                        id++;
                    }
                }
            }
        }
        return tiles;
    }

    public PowerNode getNodeInRange(Tile tile) {
        PowerNode[] powerNodes = FindObjectsOfType<PowerNode>();
        foreach(PowerNode node in powerNodes) {
            GameObject nodeParent = node.transform.parent.gameObject;
            Tile[] tiles = getAoeTiles(nodeParent.GetComponent<Tile>(), node.range);
            foreach(Tile t in tiles) {
                if(t == tile) {
                   return node; 
                }
            }
        }
        return null;
    }
}
