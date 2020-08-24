using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public GameObject particle;

    private Vector3 mousePosition;
    
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = new Vector3(mousePosition.x, mousePosition.y, this.transform.position.z);
    }

    public void createParticle() {
        GameObject particleObj = Instantiate(particle, this.transform.position, Quaternion.identity);
        Destroy(particleObj, 0.8f);
    }
}
