using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddParticle : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        this.transform.position = new Vector3(
            this.transform.position.x, 
            this.transform.position.y + speed * Time.deltaTime, 
            this.transform.position.z
        );
    }
}
