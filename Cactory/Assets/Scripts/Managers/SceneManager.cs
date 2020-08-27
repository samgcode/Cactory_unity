using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tilePrefab;
    public GameObject cactusTilePrefab;
    public GameObject ironTilePrefab;
    public GameObject crystalTilePrefab;

    public int worldSize = 100;
    int crystals = 0;
    void Start()
    {
        Vector3 position = this.transform.position;
        for(int col = (int)0 - worldSize/2; col < 0 + worldSize/2; col++) {
            for(int row = (int)0 - worldSize/2; row < 0 + worldSize/2; row++) {
                GameObject tile;
                if(Random.Range(0, 12) == 1) {
                    if(Random.Range(0, 10) == 1) {
                        if(Random.Range(0, 50) == 1) {
                            tile = Instantiate(crystalTilePrefab, new Vector3(col, row, 0), Quaternion.identity);
                            crystals++;
                        } else {
                            tile = Instantiate(ironTilePrefab, new Vector3(col, row, 0), Quaternion.identity);
                        }    
                    } else {
                        tile = Instantiate(cactusTilePrefab, new Vector3(col, row, 0), Quaternion.identity);
                    }
                } else {
                    tile = Instantiate(tilePrefab, new Vector3(col, row, 0), Quaternion.identity);
                }
            }
        }
        if(crystals == 0) {
            Tile[] tiles = FindObjectsOfType<Tile>();
            int selectedTile = Random.Range(1, tiles.Length - 1);
            int count = 1;
            foreach(Tile tile in tiles) {
                if(count == selectedTile) {
                    Instantiate(crystalTilePrefab, tile.transform.position, Quaternion.identity);
                    Destroy(tile.gameObject);
                    break;
                }
                count++;
            }
        }
    }
}