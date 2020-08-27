using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public string selectedItem = "empty";

    public Inventory inventory;

    public FollowMouse mouseParticleSystem;

    public TextMeshPro itemCountText;

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
        if(selectedItem == "empty") {
            itemCountText.text = "";
        } else {
            itemCountText.text = getItemCount(selectedItem).ToString();
        }
    }

    public void placeItem(Tile tile) {
        if(selectedItem != "empty") {
            if(canPlace(tile)) {
                if(selectedItem == "miner" && tile.hasCactus) {
                    selectedItem = "cactus miner";
                }
                if(getItemType(selectedItem) == "machine") {
                    foreach(GameObject prefab in machinePrefabs) {
                        if(prefab.name == selectedItem) {
                            Instantiate(prefab, tile.transform);
                        }
                    }
                    if(selectedItem == "conveyor") {
                        Conveyor[] conveyors = FindObjectsOfType<Conveyor>();
                        foreach(Conveyor conveyor in conveyors) {
                            Animator conveyorAnim = conveyor.GetComponent<Animator>();
                            conveyorAnim.Play("conveyor belt", 0, 0.0f);
                        }
                    }
                    if(selectedItem == "cactus miner") {
                        selectedItem = "miner";
                    }
                    removeItem(selectedItem, 1);
                    tile.hasMachine = true;
                }
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
            if(selectedItem == "miner") {
                if(!tile.hasIron && !tile.hasCactus) {
                    return false;
                }
            }
            if(selectedItem == "laser drill") {
                if(!tile.hasCrystal) {
                    return false;
                }
            }
        } else {
            return false;
        }
        return checkItem(selectedItem, 1);
    }

    public void mineTile(Tile tile) {
        if(!tile.hasMachine) {
            if(tile.hasCactus) {
                inventory.cactus++;
                mouseParticleSystem.createParticle();
            }
            if(tile.hasIron) {
                inventory.iron++;
                mouseParticleSystem.createParticle();
            }
            if(tile.hasCrystal) {
                inventory.crystals++;
                mouseParticleSystem.createParticle();
            }
        }
    }

    public void breakMachine(Tile tile) {
        if(tile.hasMachine) {
            foreach(Transform child in tile.transform) {
                if(child.gameObject.tag == "machine") {
                    GameObject machine = child.gameObject;
                    string name = machine.name.Substring(0, machine.name.LastIndexOf("(Clone)"));
                    addItem(name, 1);
                    tile.hasMachine = false;
                    Destroy(machine);
                }
            }
        }
    }

    public void rotateTile(Tile tile) {
        if(tile.hasMachine) {
            Transform tileTransform = tile.GetComponent<Transform>();
            tileTransform.Rotate (Vector3.forward * -90);
        }
    }


    public void addItem(string item, int amount) {
        switch(item) {
            case "cactus":
                inventory.cactus += amount;
            break;
            case "iron":
                inventory.iron += amount;
            break;
            case "cactus juice":
                inventory.juice += amount;
            break;
            case "crystal":
                inventory.crystals += amount;
            break;
            case "beacon":
                inventory.beacons += amount;
            break;
            case "cactus juicer":
                inventory.cactusJuicers += amount;
            break;
            case "conveyor":
                inventory.conveyors += amount;
            break;
            case "miner":
                inventory.miners += amount;
            break;
            case "cactus miner":
                inventory.miners += amount;
            break;
            case "collector":
                inventory.collectors += amount;
            break;
            case "laser drill":
                inventory.drills += amount;
            break;
        }
    }

    public bool checkItem(string item, int amount) {
        int inventoryAmount = getItemCount(item);

        if(inventoryAmount < amount) {
            return false;
        } else {
            return true;
        }
    }

    public int getItemCount(string item) {
        int inventoryAmount = 0;
        switch(item) {
            case "cactus":
                inventoryAmount = inventory.cactus;
            break;
            case "iron":
                inventoryAmount = inventory.iron;
            break;
            case "cactus juice":
                inventoryAmount = inventory.juice;
            break;
            case "crystal":
                inventoryAmount = inventory.crystals;
            break;
            case "beacon":
                inventoryAmount = inventory.beacons;
            break;
            case "cactus juicer":
                inventoryAmount = inventory.cactusJuicers;
            break;
            case "conveyor":
                inventoryAmount = inventory.conveyors;
            break;
            case "miner":
                inventoryAmount = inventory.miners;
            break;
            case "collector":
                inventoryAmount = inventory.collectors;
            break;
            case "laser drill":
                inventoryAmount = inventory.drills;
            break;
        }

        return inventoryAmount;
    }

    public void removeItem(string item, int amount) {
        switch(item) {
            case "cactus":
                inventory.cactus -= amount;
            break;
            case "iron":
                inventory.iron -= amount;
            break;
            case "cactus juice":
                inventory.juice -= amount;
            break;
            case "crystal":
                inventory.crystals -= amount;
            break;
            case "beacon":
                inventory.beacons -= amount;
            break;
            case "cactus juicer":
                inventory.cactusJuicers -= amount;
            break;
            case "conveyor":
                inventory.conveyors -= amount;
            break;
            case "miner":
                inventory.miners -= amount;
            break;
            case "cactus miner":
                inventory.miners -= amount;
            break;
            case "collector":
                inventory.collectors -= amount;
            break;
            case "laser drill":
                inventory.drills -= amount;
            break;
        }
    }

    public string getItemType(string item) {
        switch(item) {
            case "cactus juice":
                return "usable item";
            case "beacon":
                return "machine";
            case "cactus juicer":
                return "machine";
            case "conveyor":
                return "machine";
            case "miner":
                return "machine";
            case "cactus miner":
                return "machine";
            case "collector":
                return "machine";
            case "laser drill":
                return "machine";
        }
        return "item";
    }
}
