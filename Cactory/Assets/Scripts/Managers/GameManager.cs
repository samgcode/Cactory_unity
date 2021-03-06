﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public bool inventoryOpen;

    public GameObject inventory;
    public GenerateMap mapGenerator;
    public PlayerManager player;
    public InventoryService inventoryService;
    public Crafting crafting;
    public Settings settings;

    public Tile[,] tiles;

    public int worldSize;

    void Start()
    {
        settings = FindObjectOfType<Settings>();
        worldSize = settings.worldSize;
        tiles = new Tile[worldSize * 2, worldSize * 2];
        mapGenerator.generateWorld(worldSize);

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
            if(hit.collider.GetComponent<Hoverable>()) {
                Hoverable entity = hit.collider.GetComponent<Hoverable>();
                entity.hovering = true;
                if(prevEntity && entity.id != prevEntity.id) {
                    prevEntity.hovering = false;
                }
                if(entity.GetComponent<Tile>()) {
                    Tile tile = entity.GetComponent<Tile>();
                    player.hoveringTile = tile;
                    if(Input.GetMouseButtonDown(0)) {    
                        if(!inventoryOpen) {
                            if(player.selectedItem == "empty") {
                                player.mineTile(tile);
                            } else {
                                player.placeItem(tile);
                            }
                        }
                    } else if(Input.GetMouseButtonDown(1)) {
                        player.breakMachine(tile);
                    } else if(Input.GetKeyDown(KeyCode.R)) {
                        player.rotateTile(tile);
                    }  
                } else {
                    if(Input.GetMouseButtonDown(0)) {
                        if(entity.GetComponent<Slot>()) {
                            Slot slot = entity.GetComponent<Slot>();
                            player.setSelectedItem(slot.item);
                        }
                    }
                }

                if(entity.GetComponent<Recipe>()) { 
                    Recipe recipe = entity.GetComponent<Recipe>();
                    crafting.updateText(recipe);
                    if(prevEntity && entity.id != prevEntity.id) {
                        crafting.updateColors(recipe);
                    }
                    if(Input.GetMouseButtonDown(0)) {
                        crafting.craft(recipe);
                    }
                } else {
                    crafting.resetText();
                }

                if(entity.GetComponent<GroundItem>()) {
                    if(Input.GetMouseButtonDown(0)) {
                        SpriteRenderer renderer = entity.GetComponent<SpriteRenderer>();
                        inventoryService.addItem(renderer.sprite.name, 1);
                        Destroy(entity.gameObject);
                    }
                }
                prevEntity = entity;
            }
        }
    }
}
