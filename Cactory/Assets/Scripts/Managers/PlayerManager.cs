using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public string selectedItem = "empty";

    public InventoryService inventoryService;

    public FollowMouse mouseParticleSystem;

    public TextMeshPro itemCountText;

    public SpriteRenderer selectedItemRenderer;
    public Sprite[] sprites;

    public GameObject[] machinePrefabs;

    public GameManager manager;
    public Tile hoveringTile;

    int rotation = 0;

    void Start() {
        selectedItemRenderer.transform.Rotate (Vector3.forward * 90);    
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            setSelectedItem("empty");
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
            itemCountText.text = inventoryService.getItemCount(selectedItem).ToString();
        }
        if(selectedItem == "generator") {
            showAreaOfEffect(hoveringTile, 1);
        } else if(selectedItem == "power pole") {
            showAreaOfEffect(hoveringTile, 2);
        }
    }

    public void placeItem(Tile tile) {
        if(selectedItem != "empty") {
            if(canPlace(tile)) {
                if(selectedItem == "miner" && tile.hasCactus) {
                    selectedItem = "cactus miner";
                }
                if(inventoryService.getItemType(selectedItem) == "machine") {
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
                    inventoryService.removeItem(selectedItem, 1);
                    tile.transform.eulerAngles = new Vector3(tile.transform.eulerAngles.x, tile.transform.eulerAngles.y, rotation);
                    if(tile.GetComponentInChildren<ConveyorWalls>()) {
                        ConveyorWalls conveyorWalls = tile.GetComponentInChildren<ConveyorWalls>();
                        conveyorWalls.transform.eulerAngles = new Vector3(conveyorWalls.transform.eulerAngles.x, conveyorWalls.transform.eulerAngles.y, 0);
                    }
                    tile.hasMachine = true;
                }
            } else if(inventoryService.getItemType(selectedItem) == "juice") {
                if(canUseItem(tile)) {
                    inventoryService.removeItem(selectedItem, 1);
                    Generator generator = tile.GetComponentInChildren<Generator>();
                    generator.Generate();
                }
            }
        }  
    }

    public void setSelectedItem(string item) {
        selectedItem = item;
        for(int x = 0; x < manager.worldSize * 2 - 1; x++) {
           for(int y = 0; y < manager.worldSize * 2 - 1; y++) {
                AoeHoverable aoeTile;
                if(manager.tiles[x, y] != null) {
                    aoeTile = manager.tiles[x, y].GetComponentInChildren<AoeHoverable>();
                    aoeTile.hovering = false;
                }
            }
        }
    }

    public bool canPlace(Tile tile) {
        if(!tile.hasMachine) {
            if(inventoryService.getItemType(selectedItem) == "machine") {
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
        } else {
            return false;
        }
        return inventoryService.checkItem(selectedItem, 1);
    }
    public bool canUseItem(Tile tile) {
        if(!tile.GetComponentInChildren<Generator>()) {
            return false;
        }
        return inventoryService.checkItem(selectedItem, 1);
    }

    public void mineTile(Tile tile) {
        if(!tile.hasMachine) {
            if(tile.hasCactus) {
                inventoryService.addItem("cactus", 1);
                mouseParticleSystem.createParticle();
            }
            if(tile.hasIron) {
                inventoryService.addItem("iron", 1);
                mouseParticleSystem.createParticle();
            }
            if(tile.hasCrystal) {
                inventoryService.addItem("crystal", 1);
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
                    inventoryService.addItem(name, 1);
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
            if(tile.GetComponentInChildren<ConveyorWalls>()) {
                ConveyorWalls conveyorWalls = tile.GetComponentInChildren<ConveyorWalls>();
                conveyorWalls.transform.Rotate (Vector3.forward * 90);
            }
        }
        rotation -= 90;
        if(rotation <= 0) {
            rotation = 360;
        }
        selectedItemRenderer.transform.Rotate (Vector3.forward * -90);
    }

    public void showAreaOfEffect(Tile tile, int size) {
        int tileX = Mathf.RoundToInt(tile.transform.position.x) + manager.worldSize/2;
        int tileY = Mathf.RoundToInt(tile.transform.position.y) + manager.worldSize/2;
        for(int x = 0; x < manager.worldSize * 2 - 1; x++) {
           for(int y = 0; y < manager.worldSize * 2 - 1; y++) {
                AoeHoverable aoeTile;
                if(manager.tiles[x, y] != null) {
                    if(
                        x >= tileX - size && x <= tileX + size &&
                        y >= tileY - size && y <= tileY + size
                    ) {
                        aoeTile = manager.tiles[x, y].GetComponentInChildren<AoeHoverable>();
                        aoeTile.hovering = true;
                    } else {
                        aoeTile = manager.tiles[x, y].GetComponentInChildren<AoeHoverable>();
                        aoeTile.hovering = false;
                    }
                }
            }
        }
    }
}
