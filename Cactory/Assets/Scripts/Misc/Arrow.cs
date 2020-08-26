using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject goTarget;

    public SpriteRenderer renderer;
 
     void Update () {
         if(FindObjectOfType<Beacon>()) {
            goTarget = FindObjectOfType<Beacon>().gameObject;
         }
         PositionArrow();        
     }
     
     void PositionArrow()
     {
        if(goTarget) {
            renderer.enabled = false;
         
            Vector3 v3Pos = Camera.main.WorldToViewportPoint(goTarget.transform.position);
            
            if (v3Pos.x >= 0.0f && v3Pos.x <= 1.0f && v3Pos.y >= 0.0f && v3Pos.y <= 1.0f)
                return; // Object center is visible
                    
            renderer.enabled = true;
            v3Pos.x -= 0.5f;  // Translate to use center of viewport
            v3Pos.y -= 0.5f; 
            v3Pos.z = 0;      // I think I can do this rather than do a 
                            //   a full projection onto the plane
            
            float fAngle = Mathf.Atan2 (v3Pos.x, v3Pos.y);
            transform.localEulerAngles = new Vector3(0.0f, 0.0f, -fAngle * Mathf.Rad2Deg + 90);
            
            v3Pos.x = 0.5f * Mathf.Sin (fAngle) + 0.5f;  // Place on ellipse touching 
            v3Pos.y = 0.5f * Mathf.Cos (fAngle) + 0.5f;  //   side of viewport
            v3Pos.z = 6;
            transform.position = Camera.main.ViewportToWorldPoint(v3Pos);
            // transform.position -= transform.forward * 10;
        } else {
            renderer.enabled = false;
        }
     }
}
