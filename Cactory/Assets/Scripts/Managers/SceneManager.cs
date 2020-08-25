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
        Vector3 position = this.transform.position;
        for(int col = (int)position.x; col < position.x + 18; col++) {
            for(int row = (int)position.y; row < position.y + 18; row++) {
                GameObject tile;
                if(Random.Range(0, 5) == 1) {
                    if(Random.Range(0, 8) == 1) {
                        tile = Instantiate(ironTilePrefab, new Vector3(col - 8, row - 8, 0), Quaternion.identity);    
                    } else {
                        tile = Instantiate(cactusTilePrefab, new Vector3(col - 8, row - 8, 0), Quaternion.identity);
                    }
                } else {
                    tile = Instantiate(tilePrefab, new Vector3(col - 8, row - 8, 0), Quaternion.identity);
                }
            }
        }
    }
}