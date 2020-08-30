using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public int speed = 1;

    public ConveyorBeltManager conveyorBeltManager;
    public SpriteRenderer wallRenderer;
    public SpriteRenderer cornerRenderer;

    public Settings settings;
    int worldSize = 0;
    
    void Awake() {
        settings = FindObjectOfType<Settings>();
        worldSize = settings.worldSize;

        conveyorBeltManager = FindObjectOfType<ConveyorBeltManager>();
        int x = Mathf.RoundToInt(transform.position.x);
        int y = Mathf.RoundToInt(transform.position.y);
        conveyorBeltManager.conveyors[x + worldSize/2, y + worldSize/2] = this;
    }
}
