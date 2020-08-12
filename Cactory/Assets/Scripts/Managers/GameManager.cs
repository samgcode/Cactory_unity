using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool inventoryOpen;

    public GameObject inventory;
    public PlayerManager player;

    void Start()
    {
        inventoryOpen = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            inventoryOpen = !inventoryOpen;
        }
        if(inventoryOpen) {
            inventory.SetActive(true);
        } else {
            inventory.SetActive(false);
        }
        detectHover();
    }

    Ray ray;
    RaycastHit2D hit;
    Hoverable prevEntity;
    void detectHover() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        onHover(ray, hit); 
    } 

    void onHover(Ray ray, RaycastHit2D hit) {
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if(hit.collider != null) {
            if(hit.collider.tag == "hoverable") {
                Hoverable entity = hit.collider.GetComponent<Hoverable>();
                entity.hovering = true;
                if(prevEntity && entity.id != prevEntity.id) {
                    prevEntity.hovering = false;
                }
                if(Input.GetMouseButtonDown(0)) {
                    if(!inventoryOpen) {
                        if(entity.GetComponent<Tile>()) {
                            Tile tile = entity.GetComponent<Tile>();
                            if(tile.hasCactus) {
                                Debug.Log("cactus");
                            }
                            if(tile.hasIron) {
                                Debug.Log("iron");
                            }
                        }
                    } else {
                        if(entity.GetComponent<Slot>()) {
                            Slot slot = entity.GetComponent<Slot>();
                            player.selectedItem = slot.item;
                        }
                    }
                }
                prevEntity = entity;
            }
        }
    }
}
