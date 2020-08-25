using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tilePrefab;
    public GameObject cactusTilePrefab;
    public GameObject ironTilePrefab;

    public int worldSize = 100;
    void Start()
    {
        Vector3 position = this.transform.position;
        for(int col = (int)0 - worldSize/2; col < 0 + worldSize/2; col++) {
            for(int row = (int)0 - worldSize/2; row < 0 + worldSize/2; row++) {
                GameObject tile;
                if(Random.Range(0, 12) == 1) {
                    if(Random.Range(0, 10) == 1) {
                        tile = Instantiate(ironTilePrefab, new Vector3(col, row, 0), Quaternion.identity);    
                    } else {
                        tile = Instantiate(cactusTilePrefab, new Vector3(col, row, 0), Quaternion.identity);
                    }
                } else {
                    tile = Instantiate(tilePrefab, new Vector3(col, row, 0), Quaternion.identity);
                }
            }
        }
    }
}