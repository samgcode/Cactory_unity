using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{

    public GameObject tilePrefab;
    public GameObject cactusTilePrefab;
    public GameObject ironTilePrefab;
    public GameObject crystalTilePrefab;
    
    public GameObject water;
    public GameObject north;
    public GameObject east;
    public GameObject south;
    public GameObject west;

    public GameObject northEast;
    public GameObject southEast;
    public GameObject northWest;
    public GameObject southWest;
    
    public int worldSize = 50;
    public int bufferSize = 40;

    int crystals = 0;
    public void generateWorld(int size)
    {
        worldSize = size;
        Vector3 position = this.transform.position;
        int bottomSize = (int)0 - worldSize/2 - bufferSize;
        int topSize = 0 + worldSize/2 + bufferSize;

        for(int col = bottomSize; col < topSize; col++) {
            for(int row = bottomSize; row < topSize; row++) {
                GameObject tile;
                if( 
                    col < bottomSize + bufferSize || col > topSize - bufferSize ||
                    row < bottomSize + bufferSize || row > topSize - bufferSize
                ) {
                    int x = col;
                    int y = row; 
                    if( 
                        x < topSize - bufferSize + 2 && x > bottomSize + bufferSize - 2 &&
                        y < topSize - bufferSize + 2 && y > bottomSize + bufferSize - 2
                    ) {
                        if(
                            x < topSize - bufferSize + 1 && 
                            x > bottomSize + bufferSize - 1 &&
                            y == topSize - bufferSize + 1
                        ) {
                            tile = Instantiate(north, new Vector3(col, row, 0), Quaternion.identity);
                        }
                        if(
                            x < topSize - bufferSize + 1 && 
                            x > bottomSize + bufferSize - 1 &&
                            y == bottomSize + bufferSize - 1
                        ) {
                            tile = Instantiate(south, new Vector3(col, row, 0), Quaternion.identity);
                        }
                        if(
                            y < topSize - bufferSize + 1 &&
                            y > bottomSize + bufferSize - 1 &&
                            x == topSize - bufferSize + 1
                        ) {
                            tile = Instantiate(east, new Vector3(col, row, 0), Quaternion.identity);
                        }
                        if(
                            y < topSize - bufferSize + 1 &&
                            y > bottomSize + bufferSize - 1 &&
                            x  == bottomSize + bufferSize - 1
                        ) {
                            tile = Instantiate(west, new Vector3(col, row, 0), Quaternion.identity);
                        }

                        if(x == topSize - bufferSize + 1 && y == topSize - bufferSize + 1) {
                            tile = Instantiate(northEast, new Vector3(col, row, 0), Quaternion.identity);
                        }
                        if(x == topSize - bufferSize + 1 &&  y == bottomSize + bufferSize - 1) {
                            tile = Instantiate(southEast, new Vector3(col, row, 0), Quaternion.identity);
                        }
                        if(x == bottomSize + bufferSize - 1 &&  y == bottomSize + bufferSize - 1) {
                            tile = Instantiate(southWest, new Vector3(col, row, 0), Quaternion.identity);
                        }
                        if(x == bottomSize + bufferSize - 1 &&  y == topSize - bufferSize + 1) {
                            tile = Instantiate(northWest, new Vector3(col, row, 0), Quaternion.identity);
                        }
                    } else {
                        tile = Instantiate(water, new Vector3(col, row, 0), Quaternion.identity);
                    }
                } else {
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