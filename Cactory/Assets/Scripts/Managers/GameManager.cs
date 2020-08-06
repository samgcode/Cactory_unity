using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
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
                prevEntity = entity;
            }
        }
    }
}
