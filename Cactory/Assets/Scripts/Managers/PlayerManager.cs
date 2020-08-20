using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public string selectedItem = "empty";

    public Inventory inventory;

    public SpriteRenderer selectedItemRenderer;
    public Sprite[] sprites;

    public GameObject[] machinePrefabs;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            selectedItem = "empty";
        }
        if(selectedItemRenderer.sprite.name != selectedItem) {
            foreach(Sprite sprite in sprites) {
                if(sprite.name == selectedItem) {
                    selectedItemRenderer.sprite = sprite;
                }
            }
        }   
    }

    public void placeItem(Tile tile) {
        if(selectedItem != "empty") {
            if(canPlace(tile) == true) {
                foreach(GameObject prefab in machinePrefabs) {
                    if(prefab.name == selectedItem) {
                        Instantiate(prefab, tile.transform);
                    }
                }
                if(selectedItem == "conveyor") {
                    Conveyor[] conveyors = FindObjectsOfType<Conveyor>();
                    foreach(Conveyor conveyor in conveyors) {
                        Animator conveyorObj = conveyor.GetComponent<Animator>();
                        
                    }
                }
                tile.hasMachine = true;
            }
        }  
    }

    public bool canPlace(Tile tile) {
        if(!tile.hasMachine) {
            if(selectedItem == "cactus juicer") {
                if(!tile.hasCactus) {
                    return false;
                }
            }
        } else {
            return false;
        }
        switch(selectedItem) {
            case "cactus juicer":
                if(inventory.cactusJuicers >= 1) {
                    inventory.cactusJuicers--;
                } else {
                    return false;
                }
            break;
            case "conveyor":
                if(inventory.conveyors >= 1) {
                    inventory.conveyors--;
                } else {
                    return false;
                }
            break;
        }

        return true;
    }

    public void mineTile(Tile tile) {
        if(tile.hasCactus) {
            inventory.cactus++;
        }
    }

    public void rotateTile(Tile tile) {
        if(tile.hasMachine) {
            Transform tileTransform = tile.GetComponent<Transform>();
            tileTransform.Rotate (Vector3.forward * -90);
        }
    }
}
