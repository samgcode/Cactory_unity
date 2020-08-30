using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltManager : MonoBehaviour
{
    public Settings settings;
    public Conveyor[,] conveyors;
    int worldSize = 0;

    public Sprite[] wallSprites;
    public Sprite[] cornerSprites;
    public Dictionary<string, Sprite> wallSpriteLookup = new Dictionary<string, Sprite>();
    public Dictionary<string, Sprite> cornerSpriteLookup = new Dictionary<string, Sprite>();

    void Start() {
        settings = FindObjectOfType<Settings>();
        worldSize = settings.worldSize;
        conveyors = new Conveyor[worldSize, worldSize];
        
        foreach (Sprite s in wallSprites) {
            wallSpriteLookup.Add(s.name, s);
        }
        foreach (Sprite s in cornerSprites) {
            cornerSpriteLookup.Add(s.name, s);
        }
    }

    void Update() {
       for(int x = 0; x < worldSize; x++) {
           for(int y = 0; y < worldSize; y++) {
               if(conveyors[x, y] != null) {
                    bool north = false;
                    bool south = false;
                    bool east = false;
                    bool west = false;

                    bool northEast = true;
                    bool southEast = true;
                    bool northWest = true;
                    bool southWest = true;

                    if(y+1 < worldSize) {
                        north = (conveyors[x, y+1] != null);
                    }
                    if(y-1 > 0) {
                        south = (conveyors[x, y-1] != null);
                    }
                    if(x+1 < worldSize) {
                        east = (conveyors[x+1, y] != null);
                    }
                    if(x-1 > 0) {
                        west = (conveyors[x-1, y] != null);
                    }

                    if(y+1 < worldSize && x+1 < worldSize) {
                        northEast = (conveyors[x+1, y+1] != null);
                    }
                    if(y-1 > 0 && x+1 < worldSize) {
                        southEast = (conveyors[x+1, y-1] != null);
                    }
                    if(y+1 < worldSize && x-1 > 0) {
                        northWest = (conveyors[x-1, y+1] != null);
                    }
                    if(y-1 > 0 && x-1 > 0) {
                        southWest  = (conveyors[x-1, y-1] != null);
                    }
                    
                    string wallSprite = $"North_{north}_South_{south}_East_{east}_West_{west}";
                    string cornerSprite = $"NE_{northEast}_SE_{southEast}_NW_{northWest}_SW_{southWest}";
                    try {
                        conveyors[x,y].wallRenderer.sprite = wallSpriteLookup[wallSprite];
                        conveyors[x,y].cornerRenderer.sprite = cornerSpriteLookup[cornerSprite];
                    } catch(Exception err) {
                        Debug.LogError(err);
                        Debug.Log(wallSprite);
                        Debug.Log(cornerSprite);
                    }
               }
           }
       } 
    }
}
