using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AoeHoverable : MonoBehaviour
{
    public SpriteRenderer renderer;
    public bool hovering = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hovering) {
            renderer.enabled = true;
        } else {
            renderer.enabled = false;
        }
    }
}
