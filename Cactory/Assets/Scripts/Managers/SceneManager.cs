using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tilePrefab;
    public GameObject cactusTilePrefab;
    public GameObject ironTilePrefab;
    void Start()
    {
        for(int col = 0; col < 18; col++) {
            for(int row = 0; row < 11; row++) {
                GameObject tile;
                if(Random.Range(0, 5) == 1) {
                    if(Random.Range(0, 8) == 1) {
                        tile = Instantiate(ironTilePrefab, new Vector3(col - 8, row - 5, 0), Quaternion.identity);    
                    } else {
                        tile = Instantiate(cactusTilePrefab, new Vector3(col - 8, row - 5, 0), Quaternion.identity);
                    }
                } else {
                    tile = Instantiate(tilePrefab, new Vector3(col - 8, row - 5, 0), Quaternion.identity);
                }
            }
        }
    }
}