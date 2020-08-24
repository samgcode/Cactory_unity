using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hoverable : MonoBehaviour
{
    public int id = 0;
    public bool hovering = false;
    public SpriteRenderer hoveringRenderer;
    
    private void Awake() {
        Hoverable[] entities = FindObjectsOfType<Hoverable>();
        id = entities.Length;
    }

    private void Update() {
        if(hovering) {
            hoveringRenderer.enabled = true;
        } else {
            hoveringRenderer.enabled = false;
        }    
    }
}
